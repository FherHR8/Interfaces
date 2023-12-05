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
            MessageBoxResult result = MessageBox.Show("¿Quieres ir a tus temas?", "Confirmación", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                UsuarioTema ut= new UsuarioTema();
                ut.Show();
            }
            else
            {
                MessageBox.Show("No vamos a temas");
            }
        }
        private void pass(object sender, RoutedEventArgs e)
        {
            {
                MessageBoxResult result = MessageBox.Show("¿De verdad quieres recuperar la constraseña?", "Confirmación", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (result == MessageBoxResult.Yes)
                {
                    RecuperarContra rc = new RecuperarContra();
                    rc.Show();
                }
                else
                {
                    MessageBox.Show("No recuperaremos la constraseña");
                }
            }
            
        }
    }
}
