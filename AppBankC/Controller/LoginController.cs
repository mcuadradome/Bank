using AppBankC.Model;
using AppBankC.WSBank;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppBankC.Controller
{
    
    class LoginController
    {
        LoginModel model;

        public LoginController()
        {
            model = new LoginModel();
        }

        public USUARIO[] GetUserLogin(string user, string password)
        {
            try
            {
               var userRes = model.GetUsuario(user, password);

                if (userRes.Length > 0)
                {
                    return userRes;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public USUARIOS[] GetUserLoginById(int id)
        {
            try
            {
                var userRes = model.GetRolByIdUser(id);

                if (userRes.Length > 0)
                {
                    return userRes;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

    }
}
