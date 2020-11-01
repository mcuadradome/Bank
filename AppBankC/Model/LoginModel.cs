using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppBankC.WSBank;
namespace AppBankC.Model
{
   
    class LoginModel
    {
        
        Service1Client client;
        public LoginModel()
        {
            client = new Service1Client();              
        }
        
        public USER[] GetUsuario(string user, string pass)
        {
            USER[] usuario;
            try
            {
                usuario = client.GetUserByUserAndPass(user, pass);

            }
            catch (Exception)
            {
                throw;
            }
            return usuario;
        }

        public USUARIOS[] GetRolByIdUser(int idUser)
        {
            USUARIOS[] usuario;
            try
            {
                usuario = client.GetRolByIdUser(idUser);

            }
            catch (Exception)
            {
                throw;
            }
            return usuario;
        }


    }
}
