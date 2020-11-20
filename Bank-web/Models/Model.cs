using Bank_web.Commons;
using Bank_web.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft;

namespace Bank_web.Models
{
    public class Model
    {
        readonly RestClient resClient;
        public Model()
        {
            resClient = new RestClient();
        }

        public User GetUser(string endpint)
        {
            User user;

            try
            {
                resClient.EndPoint = endpint;              
                string strJSON = string.Empty;
                strJSON = resClient.MakeRequest();

                user = Newtonsoft.Json.JsonConvert.DeserializeObject<User>(strJSON);
            }
            catch (Exception)
            {

                throw;
            }

            return user;
        }

        public Saldo GetBalance(string endpoint)
        {
            Saldo saldo;

            try
            {
                resClient.EndPoint = endpoint;
                string strJSON = string.Empty;
                strJSON = resClient.MakeRequest();

                saldo = Newtonsoft.Json.JsonConvert.DeserializeObject<Saldo>(strJSON);
            }
            catch (Exception)
            {

                throw;
            }

            return saldo;
        }

        public bool Transfer(string endpoint, string json)
        {
            
            try
            {
                resClient.EndPoint = endpoint;
                string strJSON = string.Empty;
                strJSON = resClient.MakeRequest();

                var res = Newtonsoft.Json.JsonConvert.DeserializeObject<Saldo>(strJSON);

                if (res != null)
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
        public bool Put(string endpoint, string json)
        {
            
            try
            {
                resClient.EndPoint = endpoint;
                string strJSON = string.Empty;
                strJSON = resClient.MakeRequest();

                var res = Newtonsoft.Json.JsonConvert.DeserializeObject<Saldo>(strJSON);
                if (res != null)
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
    }
}