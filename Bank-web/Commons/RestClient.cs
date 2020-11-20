using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;

namespace Bank_web.Commons
{

    public enum httpVerb
    {
        GET,
        POST,
        PUT,
        DELETE
    }
    public class RestClient
    {

        public string EndPoint { get; set; }
        public httpVerb HttpMethod { get; set; }

        public RestClient()
        {
            EndPoint = "";
            HttpMethod = httpVerb.GET;
        }

        public string MakeRequest()
        {
            string strResponseValue = string.Empty;

            var request = (HttpWebRequest)WebRequest.Create(EndPoint);

            request.Method = HttpMethod.ToString();

            HttpWebResponse response = null;

            try
            {
                response = (HttpWebResponse)request.GetResponse();


                //Proecess the resppnse stream... (could be JSON, XML or HTML etc..._

                using (Stream responseStream = response.GetResponseStream())
                {
                    if (responseStream != null)
                    {
                        using (StreamReader reader = new StreamReader(responseStream))
                        {
                            strResponseValue = reader.ReadToEnd();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                //We catch non Http 200 responses here.
                strResponseValue = "{\"errorMessages\":[\"" + ex.Message.ToString() + "\"],\"errors\":{}}";
            }
            finally
            {
                if (response != null)
                {
                    ((IDisposable)response).Dispose();
                }
            }

            return strResponseValue;

        }
    }
}