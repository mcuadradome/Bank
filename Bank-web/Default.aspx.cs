using Bank_web.Models;
using Bank_web.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Bank_web
{
    public partial class _Default : Page
    {
        Model model;

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Login(object sender, EventArgs e)
        {
            model = new Model();

            try
            {
                string user = "";
                string endpoint = "http://localhost/api/user/"+ user;

                User use = model.GetUser(endpoint);

            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}