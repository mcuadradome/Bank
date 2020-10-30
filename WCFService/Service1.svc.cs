using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using WCFService.Model;

namespace WCFService
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "Service1" en el código, en svc y en el archivo de configuración.
    // NOTE: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione Service1.svc o Service1.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class Service1 : IService1
    {
        public int codeResult;

        public Result AddAmount(int idAccount, double valor)
        {
            try
            {
                using (var ctx = new BANKEntities())
                {  
                    codeResult = ctx.Database.ExecuteSqlCommand("UPDATE [SALDO] SET [saldo] = {0} WHERE [id_cuenta] = {1}", valor, idAccount);

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
                    return context.CUENTAS.Where(p => cuenta.Contains(p.cuenta)).Select(p => new CUENTAS() { id = p.id, id_user = p.id_user, cuenta = p.cuenta });

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Result DelAccount(string idAccount)
        {
            using (var ctx = new Model.BANKEntities())
            {
                codeResult = ctx.Database.ExecuteSqlCommand("DELETE FROM [CUENTAS] WHERE [cuenta] = {0} ", idAccount);

                return new Result { codigo = codeResult, Mensaje = "OK" };
            }
        }

        public IEnumerable<SALDO> GetBalance(int idAccount)
        {
            try
            {
                using (var context = new Model.BANKEntities())
                {
                    var account = new int[] { idAccount };
                    return context.SALDO.Where(p => account.Contains(p.id_cuenta)).Select(p => new SALDO() { saldo1 = p.saldo1, nuevo_saldo = p.nuevo_saldo });
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Result RemoveAmount(int idAccount, double valor)
        {
            try
            {
                using (var ctx = new BANKEntities())
                {
                    codeResult = ctx.Database.ExecuteSqlCommand("UPDATE [SALDO] SET [nuevo_saldo] = {0} WHERE [id_cuenta] = {1}", valor, idAccount);

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
    }
}
