using AppBankC.WSBank;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppBankC.Model
{
    class HomeModel
    {

        Service1Client client;

        public HomeModel()
        {
            client = new Service1Client();
        }

        public int Insertusuario(USUARIOS usu)
        {
            try
            {
                return client.SetUsuario(usu);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public int InsertCuenta(CUENTAS cuenta) 
        { 
            try
            {
                return client.SetAccount(cuenta);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool DelAccount(string idCuenta)
        {
            try
            {
                var res = client.DelAccount(idCuenta);

                if (res.codigo != 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool ModAccount(string idCuenta, string numCuenta)
        {
            try
            {
                var res = client.UptAccount(idCuenta, numCuenta);

                if (res.codigo != 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool AddAmount(string idCuenta, double numCuenta)
        {
            try
            {
                var res = client.AddAmount(idCuenta, numCuenta);

                if (res.codigo != 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
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
                var res = client.RemoveAmount(idCuenta, numCuenta);

                if (res.codigo != 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
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
                var res = client.GetBalance(idCuenta);

                if (res.Length > 0)
                {
                    return res;
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
