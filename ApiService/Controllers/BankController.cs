using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ApiService.Models;
using ServiceDataAccess;

namespace ApiService.Controllers
{
    [Route("api/[controller]")]
    public class BankController : ApiController
    {
        // GET: api/Bank
        public int codeResult;

        public IEnumerable<SALDO> GetBalance(string idAccount)
        {
            using (var context = new BANKEntities())
            {
                var result = UserController.GetAccountbyId(idAccount);
                int id = result.FirstOrDefault().id;
                return context.SALDO.OrderBy(p => p.id).ToList().Where(p => p.id_cuenta == id).Select(p => new SALDO() { id = p.id, id_cuenta = p.id_cuenta, saldo1 = p.saldo1, nuevo_saldo = p.nuevo_saldo });

            }
        }

        // GET: api/Bank/5      
        public Result Transfer(string idAccount1, string idAccount2, [FromBody]double valor)
        {
            try
            {
                using (var ctx = new BANKEntities())
                {
                    var acount1 = UserController.GetAccountbyId(idAccount1);
                    var acount2 = UserController.GetAccountbyId(idAccount2);

                    int id = acount1.FirstOrDefault().id;
                    int id2 = acount2.FirstOrDefault().id;

                    if (acount1.FirstOrDefault().state_account.Value && acount2.FirstOrDefault().state_account.Value)
                    {
                        var saldo = GetBalance(idAccount1).FirstOrDefault();

                        if (saldo.saldo1 <= valor)
                        {
                            var saldo2 = GetBalance(idAccount2).FirstOrDefault();

                            double newValor = saldo.saldo1.GetValueOrDefault() -  valor;
                            double valorTranfer = saldo2.saldo1.GetValueOrDefault() + valor;

                            codeResult = ctx.Database.ExecuteSqlCommand("UPDATE [SALDO] SET [nuevo_saldo] = {2}, [saldo] = {0} WHERE [id_cuenta] = {1}", newValor, id, valor);
                            codeResult = ctx.Database.ExecuteSqlCommand("UPDATE [SALDO] SET [nuevo_saldo] = {2}, [saldo] = {0} WHERE [id_cuenta] = {1}", valorTranfer, id2, valor);

                            return new Result { Codigo = codeResult, Mensaje = "OK" };
                        }
                        else
                        {
                            return new Result { Codigo = 0, Mensaje = "Error valor a transeferir es mayor al saldo actual." };
                        }

                    }
                    else
                    {
                        return new Result { Codigo = 0, Mensaje = "Error cuenta bloqueada." };
                    }

                }

            }
            catch (Exception ex)
            {
                return new Result { Codigo = 0, Mensaje = ex.Message };
            }
        }


        // PUT: api/Bank/5
        public Result Put(string idAccount, [FromBody]double value)
        {
            using (var ctx = new BANKEntities())
            {
                var result = UserController.GetAccountbyId(idAccount);
                int id = result.FirstOrDefault().id;

                if (result.FirstOrDefault().state_account.Value)
                {
                    var saldo = GetBalance(idAccount).FirstOrDefault();
                    double newValor = saldo.saldo1.GetValueOrDefault() - value;

                    codeResult = ctx.Database.ExecuteSqlCommand("UPDATE [SALDO] SET [nuevo_saldo] = {2}, [saldo] = {0} WHERE [id_cuenta] = {1}", newValor, id, value);
                    return new Result { Codigo = codeResult, Mensaje = "OK" };
                }
                else
                {
                    return new Result { Codigo = 0, Mensaje = "Error cuenta bloqueada." };
                }

            }
        }
    }
}
