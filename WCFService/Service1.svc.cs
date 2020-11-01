using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using WCFService.Common;
using WCFService.Model;

namespace WCFService
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "Service1" en el código, en svc y en el archivo de configuración.
    // NOTE: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione Service1.svc o Service1.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class Service1 : IService1
    {
        public int codeResult;

        public Result AddAmount(String idAccount, double valor)
        {
            try
            {
                using (var ctx = new BANKEntities())
                {
                    var result = GetAccountbyId(idAccount);
                    int id = result.FirstOrDefault().id;

                    codeResult = ctx.Database.ExecuteSqlCommand("UPDATE [SALDO] SET [saldo] = {0} WHERE [id_cuenta] = {1}", valor, id);

                    return new Result { codigo = codeResult, Mensaje = "OK" };
                }
            }
            catch (Exception ex)
            {
                return new Result { codigo = 0, Mensaje = ex.Message };
            }
        }

        public IEnumerable<CUENTAS> GetAccountbyId(string id)
        {
            try
            {
                using (var context = new Model.BANKEntities())
                {
                    var cuenta = new string[] { id };
                    return context.CUENTAS.OrderBy(p => p.id).ToList().Where(p => p.cuenta == id).Select(p => new CUENTAS() { id = p.id, id_user = p.id_user, cuenta = p.cuenta });
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Result DelAccount(string idAccount)
        {
            try
            {
                using (var ctx = new Model.BANKEntities())
                {
                    codeResult = ctx.Database.ExecuteSqlCommand("UPDATE [CUENTAS] SET [state_account]= 0 WHERE [cuenta] = {0} ", idAccount);

                    return new Result { codigo = codeResult, Mensaje = "OK" };
                }
            }
            catch (Exception ex)
            {
                return new Result { codigo = 0, Mensaje = "Error " + ex.Message };
                throw;
            }
            
        }

        public IEnumerable<SALDO> GetBalance(string idAccount)
        {
            try
            {
                using (var context = new Model.BANKEntities())
                {
                    var result = GetAccountbyId(idAccount);
                    int id= result.FirstOrDefault().id;
                    return context.SALDO.OrderBy(p => p.id).ToList().Where(p => p.id_cuenta == id).Select(p => new SALDO() { id = p.id, id_cuenta=p.id_cuenta, saldo1 = p.saldo1, nuevo_saldo = p.nuevo_saldo });

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Result RemoveAmount(string idAccount, double valor)
        {
            try
            {
                using (var ctx = new BANKEntities())
                {
                    var result = GetAccountbyId(idAccount);
                    int id = result.FirstOrDefault().id;

                    codeResult = ctx.Database.ExecuteSqlCommand("UPDATE [SALDO] SET [nuevo_saldo] = {0} WHERE [id_cuenta] = {1}", valor, id);

                    return new Result { codigo = codeResult, Mensaje = "OK" };
                }
            }
            catch (Exception ex)
            {
                return new Result { codigo = 0, Mensaje = ex.Message };
            }
        }

        public int SetAccount(CUENTAS cuenta)
        {
            try
            {
                using (var context = new Model.BANKEntities())
                {
                    var newControl = new CUENTAS
                    {
                        id_user = cuenta.id_user,
                        cuenta = cuenta.cuenta

                    };

                    context.CUENTAS.Add(newControl);
                    context.SaveChanges();
                    int id = (int)newControl.id;
                    return id;
                }
            }
            catch (Exception)
            {
                return 0;
                throw;
            }
        }

        public int SetUsuario(USUARIOS usuario)
        {
            try
            {
                using (var context = new Model.BANKEntities())
                {
                    var newControl = new USUARIOS
                    {
                        nombre = Common.Common.DesEncrypt(usuario.nombre),
                        apellido = Common.Common.DesEncrypt(usuario.apellido),
                        email = usuario.email,
                        telefono= usuario.telefono,
                        id_rol = usuario.id_rol,
                        identificacion = usuario.identificacion
                       
                    };

                    context.USUARIOS.Add(newControl);
                    context.SaveChanges();
                    int id = (int)newControl.id;
                    return id;
                }
            }
            catch (Exception)
            {
                return 0;
                throw;
            }
        }
  
        public Result UptAccount(string idAccount, string numCuenta)
        {
            try
            {
                using (var ctx = new Model.BANKEntities())
                {
               
                    ctx.CUENTAS.Where(s => s.cuenta == idAccount).ToList().ForEach(s => {
                        s.cuenta = numCuenta;
                    });

                    //4. call SaveChanges
                    codeResult = ctx.SaveChanges();
                    return new Result { codigo = codeResult, Mensaje = "OK" };
                }
            }
            catch (Exception ex)
            {
                return new Result { codigo = 0, Mensaje = ex.Message };
            }
        }

        IEnumerable<ROL> IService1.GetRolbyId(int id)
        {
            try
            {
                using (var context = new Model.BANKEntities())
                {
                    var rol = new int[] { id };
                    return context.ROL.OrderBy(p => p.id).ToList().Where(p => rol.Contains(p.id)).Select(p => new ROL() { id = p.id, rol1 = p.rol1 });
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        IEnumerable<USER> IService1.GetUserByUserAndPass(string user, string pass)
        {
            try
            {
                using (var context = new Model.BANKEntities())
                {
                    string passDes = Common.Common.DesEncrypt(pass);
                    string userDes = Common.Common.DesEncrypt(user);
                    return context.USER.OrderBy(p => p.id).ToList().Where(p => p.user_name.Equals(userDes) && p.password.Equals(passDes)).Select(p => new USER() { id = p.id, id_user = p.id_user, user_name=p.user_name, password=p.password});
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        IEnumerable<USUARIOS> IService1.GetRolByIdUser(int idUser)
        {
            try
            {
                using (var context = new Model.BANKEntities())
                {
                    return context.USUARIOS.OrderBy(p => p.id).ToList().Where(p => p.id.Equals(idUser)).Select(p => new USUARIOS() { id = p.id, nombre=p.nombre, apellido=p.apellido, email=p.email, id_rol=p.id_rol, identificacion=p.identificacion});

                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
