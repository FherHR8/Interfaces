using MySql.Data.MySqlClient;
using MySqlX.XDevAPI.Relational;
using System;
using System.Collections.Generic;
using System.Data;
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
        users u=new users();
        BaseDatos b=new BaseDatos();
        public MainWindow()
        {
            InitializeComponent();
            
        }

        private void entrar(object sender, RoutedEventArgs e)
        {
            if (b.login(email.Text,contrasena.Text, b, u))
            {
                //aquí no muestro la ventana....si luego sigo haciendo cosas...
                //tendrias que comprobar si es admin antes de mostrar los datos.
                if (u.Rol == "admin")
                {
                    opcionesAdministracion oa = new opcionesAdministracion();
                    oa.Show();
                }
                else
                {
                    BienvenidoUsuario bu = new BienvenidoUsuario(u);
                    bu.Show();
                }
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
