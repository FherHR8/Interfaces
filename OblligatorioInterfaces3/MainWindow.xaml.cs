using MySql.Data.MySqlClient;
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

namespace OblligatorioInterfaces3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private bool login ()
        {
            bool login = false;
            BaseDatos b = new BaseDatos();
            string ema = "";
            string con = "";
            string consulta = "SELECT password,email from users where password like '" +contrasena.Text + "' and email like '"+email.Text + "'";
            if (b.AbrirConectar())
            {
                MySqlCommand cmd = new MySqlCommand(consulta, b.Conectar);
                MySqlDataReader lector = cmd.ExecuteReader();
                if(lector.Read())
                {
                    con = lector["password"].ToString();
                    ema = lector["email"].ToString();
                    return true;
                }
                else
                {
                    MessageBox.Show("Correo y contraseña no coinciden");
                }
            }
            return login;
        }

        private void entrar(object sender, RoutedEventArgs e)
        {
            if (login())
            {
                Entrar en = new Entrar();
                en.Show();
            } 
        }
        private void registrarse(object sender, RoutedEventArgs e)
        {
            Registro r = new Registro();
            r.Show();
        }

        private void olvidaContra(object sender, RoutedEventArgs e)
        {
            Olvidar o = new Olvidar();
            o.Show();
        }
    }
}
