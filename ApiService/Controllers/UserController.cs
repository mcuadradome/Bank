using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ServiceDataAccess;

namespace ApiService.Controllers
{
    
    public class UserController : ApiController
    {

        public IEnumerable<USER> Get()
        {
            using (BANKEntities entities = new BANKEntities())
            {
                return entities.USER.ToList().Select(p => new USER() { id = p.id, id_user = p.id_user, user_name=p.user_name, password=p.password });
            }
        }
		
		   public IEnumerable<USER> GetbyUser(string user)
        {
            using (BANKEntities entities = new BANKEntities())
            {
                return entities.USER.ToList().Where(p => p.user_name == user).Select(p => new USER() { id = p.id, id_user = p.id_user, user_name=p.user_name, password=p.password });
            }
        }

        public static IEnumerable<CUENTAS> GetAccountbyId(string id)
        {
            try
            {
                using (var context = new BANKEntities())
                {
                    var cuenta = new string[] { id };
                    return context.CUENTAS.OrderBy(p => p.id).ToList().Where(p => p.cuenta == id).Select(p => new CUENTAS() { id = p.id, id_user = p.id_user, cuenta = p.cuenta, state_account = p.state_account });
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public USER GetByID(int id)
        {
            using (BANKEntities entities = new BANKEntities())
            {
                return entities.USER.ToList().Where(e => e.id_user.Equals(id)).Select(p => new USER() { id = p.id, id_user = p.id_user, user_name = p.user_name, password = p.password }).FirstOrDefault();
            }
        }


    }
}
