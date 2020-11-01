using AppBankC.Model;
using AppBankC.WSBank;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppBankC.Controller
{
    
    class HomeController
    {
        HomeModel model;
        public HomeController()
        {
            model = new HomeModel();
        }

        public int Insertuser(USUARIOS user)
        {
            int res;
            try
            {
                 res = model.Insertusuario(user);

            }
            catch (Exception)
            {

                throw;
            }

            return res;
        }

        public int InsertAccount(CUENTAS cuenta)
        {
            int res;
            try
            {
                res = model.InsertCuenta(cuenta);

            }
            catch (Exception)
            {

                throw;
            }

            return res;
        }

        public bool DelAccount(string cuenta)
        {
            bool res;
            try
            {
                res = model.DelAccount(cuenta);

            }
            catch (Exception)
            {

                throw;
            }

            return res;
        }

        public bool UpdAccount(string cuenta, string numCuenta)
        {
            bool res;
            try
            {
                res = model.ModAccount(cuenta, numCuenta);

            }
            catch (Exception)
            {

                throw;
            }

            return res;
        }

        public bool AddAmount(string idCuenta, double numCuenta)
        {
         
            try
            {
               return model.AddAmount(idCuenta, numCuenta);
  
            }
            catch (Exception)
            {
                throw;
            }

        
        }

        public bool RemoveAmount(string idCuenta, double numCuenta)
        {
            try
            {
                return model.RemoveAmount(idCuenta, numCuenta);

            }
            catch (Exception)
            {
                throw;
            }
        }

        public SALDO[] GetBalance(string idCuenta)
        {
            try
            {
                return model.GetBalance(idCuenta);
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}
