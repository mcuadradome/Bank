using AppBankC.Commons;
using AppBankC.Controller;
using AppBankC.Model;
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
using System.Windows.Shapes;

namespace AppBankC.View
{
    /// <summary>
    /// Lógica de interacción para Home.xaml
    /// </summary>
    public partial class Home : Window
    {
        LoginController loginController;
        HomeController homeController;
        public Home()
        {
            InitializeComponent();

            loginController = new LoginController();
            homeController = new HomeController();

            var validateRol = loginController.GetUserLoginById(MainWindow.userResponse.id_user);

            if (validateRol != null)
            {
                ShowHide(validateRol.FirstOrDefault().id_rol);
            }


        }
        #region vizualizacion de items
        private void ShowHide(int id)
        {
            if (id.Equals(1))
            {
                btnRemMount.Visibility = Visibility.Collapsed;
                btnAddMount.Visibility = Visibility.Collapsed;

            }
            else if (id.Equals(2))
            {
                btnBorrarCuenta.Visibility = Visibility.Collapsed;
                btnCrearCuenta.Visibility = Visibility.Collapsed;
                btnModCuenta.Visibility = Visibility.Collapsed;

            }
            else if (id.Equals(3))
            {

            } else if (id.Equals(4))
            {

            }
        }
    
        private void ShowHideCrear()
        {
            txtSaldo.Visibility = Visibility.Collapsed;
            lblSaldo.Visibility = Visibility.Collapsed;

            txtNuevoSaldo.Visibility = Visibility.Collapsed;
            lblNuevoSaldo.Visibility = Visibility.Collapsed;

            dtgCuentas.Visibility = Visibility.Collapsed;

            //txtNombre.Visibility = Visibility.Collapsed;
            //lblNombre.Visibility = Visibility.Collapsed;

            //txtApellido.Visibility = Visibility.Collapsed;
            //lblApellido.Visibility = Visibility.Collapsed;

            //txtEmail.Visibility = Visibility.Collapsed;
            //lblEmail.Visibility = Visibility.Collapsed;

            //txtTel.Visibility = Visibility.Collapsed;
            //lblTel.Visibility = Visibility.Collapsed;
        }

        private void ShowHideBorrar()
        {
            ShowHideCrear();

            txtNombre.Visibility = Visibility.Collapsed;
            lblNombre.Visibility = Visibility.Collapsed;

            txtApellido.Visibility = Visibility.Collapsed;
            lblApellido.Visibility = Visibility.Collapsed;

            txtEmail.Visibility = Visibility.Collapsed;
            lblEmail.Visibility = Visibility.Collapsed;

            txtTel.Visibility = Visibility.Collapsed;
            lblTel.Visibility = Visibility.Collapsed;
        }

        private void ShowHideModificar()
        {
            ShowHideCrear();
            ShowHideBorrar();

            dtgCuentas.Visibility = Visibility.Visible;

        }

        private void ShowHideAdicionar()
        {
            txtNCuenta.Visibility = Visibility.Collapsed;
            lblCuenta.Visibility = Visibility.Collapsed;

            txtSaldo.Visibility = Visibility.Visible;
            lblSaldo.Visibility = Visibility.Visible;

            txtNuevoSaldo.Visibility = Visibility.Visible;
            lblNuevoSaldo.Visibility = Visibility.Visible;

            ShowHideCrear();
            ShowHideBorrar();

            dtgCuentas.Visibility = Visibility.Visible;
        }

        private void ShowHideRetirar()
        {
            ShowHideAdicionar();
        }

        private void ShowHideObtener()
        {
            ShowHideAdicionar();
        }
        #endregion

        private void button6_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnCrearCuenta_Click(object sender, RoutedEventArgs e)
        {
            ShowHideCrear();

            USUARIOS usu = new USUARIOS();

            usu.nombre = Common.Encrypt(txtNombre.Text);
            usu.apellido = Common.Encrypt(txtApellido.Text);
            usu.email = txtEmail.Text.Equals("") ? " " : txtEmail.Text;
            usu.telefono = txtTel.Text;
            usu.id_rol = 4;
            usu.identificacion = txtIdent.Text;

           int res = homeController.Insertuser(usu);
            
            if(res != 0)
            {
                CUENTAS cuenta = new CUENTAS();

                cuenta.id_user = res;
                cuenta.cuenta = txtNCuenta.Text;
                cuenta.state_account = true;

               int result = homeController.InsertAccount(cuenta);
                if(result != 0)
                {
                    MessageBox.Show("Cuenta creada con exito");
                }
                else
                {
                    MessageBox.Show("Error al crear cuenta");
                }

            }
            else
            {
                MessageBox.Show("Error al crear cuenta");
            }
        }

        private void btnBorrarCuenta_Click(object sender, RoutedEventArgs e)
        {
            ShowHideBorrar();
            if (!txtNCuenta.Text.Equals(""))
            {
                var res = homeController.DelAccount(txtNCuenta.Text);

                if (res)
                {
                    MessageBox.Show("Cuenta eliminada");
                }
                else
                {
                    MessageBox.Show("Cuenta no eliminada");
                }
            }
            else
            {
                MessageBox.Show("Cuenta necesaria");
            }
            
        }

        private void btnModCuenta_Click(object sender, RoutedEventArgs e)
        {
            ShowHideModificar();

            if (!txtNCuenta.Text.Equals("") && !txtCCuenta.Text.Equals(""))
            {
                var res = homeController.UpdAccount(txtNCuenta.Text, txtCCuenta.Text);

                if (res)
                {
                    MessageBox.Show("Cuenta Actualizada");
                }
                else
                {
                    MessageBox.Show("Cuenta no Actualizada");
                }
            }
            else
            {
                MessageBox.Show("Cuenta necesaria");
            }
        }

        private void btnAddMount_Click(object sender, RoutedEventArgs e)
        {
            ShowHideAdicionar();

            if (!txtNCuenta.Text.Equals("") && !txtNuevoSaldo.Text.Equals(""))
            {
                double valor = double.Parse(txtNuevoSaldo.Text);
                var res = homeController.AddAmount(txtNCuenta.Text, valor);

                if (res)
                {
                    MessageBox.Show("Valor Actualizada");
                }
                else
                {
                    MessageBox.Show("Valor no Actualizada");
                }
            }
            else
            {
                MessageBox.Show("Cuenta y valor necesaria");
            }
        }

        private void btnRemMount_Click(object sender, RoutedEventArgs e)
        {
            ShowHideRetirar();

            if (!txtNCuenta.Text.Equals("") && !txtNuevoSaldo.Text.Equals(""))
            {
                double valor = double.Parse(txtNuevoSaldo.Text);
                var res = homeController.RemoveAmount(txtNCuenta.Text, valor);

                if (res)
                {
                    MessageBox.Show("Valor Actualizada");
                }
                else
                {
                    MessageBox.Show("Valor no Actualizada");
                }
            }
            else
            {
                MessageBox.Show("Cuenta y valor necesaria");
            }
        }

        private void btnGetSaldo_Click(object sender, RoutedEventArgs e)
        {
            ShowHideObtener();

            if (!txtNCuenta.Text.Equals(""))
            {
               
                var res = homeController.GetBalance(txtNCuenta.Text);

                if (res != null)
                {
                    txtSaldo.Text = res.FirstOrDefault().saldo1.ToString();
                    txtNuevoSaldo.Text = res.FirstOrDefault().nuevo_saldo.ToString();
                   
                }
                else
                {
                    MessageBox.Show("Valor no Consultado");
                }
            }
            else
            {
                MessageBox.Show("Cuenta necesaria");
            }
        }
    }
}
