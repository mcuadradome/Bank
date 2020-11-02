using AppBankC.Commons;
using AppBankC.Controller;
using AppBankC.View;
using AppBankC.WSBank;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace AppBankC
{
   
    public partial class MainWindow : Window
    {
        LoginController controller;
        public static USER userResponse;
        public MainWindow()
        {
            InitializeComponent();
            controller = new LoginController();
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            string user = Common.Encrypt(txtBoxUser.Text).ToLower().Trim();
            string pass = Common.Encrypt(passwordBox.Password).ToLower().Trim();

            var res = controller.GetUserLogin(user, pass);

            if (res != null)
            {
                string passDes = Common.DesEncrypt(res.FirstOrDefault().password);
                string userDes = Common.DesEncrypt(res.FirstOrDefault().user_name);

                userResponse = res.FirstOrDefault();

                userResponse.user_name = userDes;
                userResponse.password = passDes;

                var newForm = new Home(); //create your new form.
                newForm.Show(); //show the new form.
                this.Close(); //only if you want to close the current form.
            }
            else
            {
                MessageBox.Show("Usuario o contraseña invalido");
            }

        }
    }
}
