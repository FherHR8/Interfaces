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

namespace OblligatorioInterfaces3
{
    /// <summary>
    /// Lógica de interacción para BienvenidoUsuario.xaml
    /// </summary>
    public partial class BienvenidoUsuario : Window
    {
        public BienvenidoUsuario(users u)
        {
            InitializeComponent();
            informacion.Content = u.username + " " + u.puntos + " puntos";
        }

        private void temitas(object sender, RoutedEventArgs e)
        {

        }

        private void pass(object sender, RoutedEventArgs e)
        {

        }
    }
}
