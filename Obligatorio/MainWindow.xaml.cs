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

namespace Obligatorio2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            string rutaPDF = "C:\\EXAMENINTERFACES.pdf";
            webBrowser.Source = new Uri(rutaPDF);
        }
        private void Salir(object sender, RoutedEventArgs e)
        {
            MessageBoxResult respuesta=MessageBox.Show("¿Deseas salir de la aplicación?","Confirmacíón",MessageBoxButton.YesNo,MessageBoxImage.Question);

            if(respuesta==MessageBoxResult.Yes)
            {
                Application.Current.Shutdown();
            }
        }
        private void Alta(object sender, RoutedEventArgs e)
        {
            alta ventana = new alta();
            ventana.Show();
        }

        private void Consulta(object sender, RoutedEventArgs e)
        {
            consulta ventana = new consulta();
            ventana.Show();
           
        }

        private void Actualizar(object sender, RoutedEventArgs e)
        {
            actualizar ventana = new actualizar();
            ventana.Show();
        }

        private void Ayuda(object sender, RoutedEventArgs e)
        {
            ayuda ventana = new ayuda();
            ventana.Show();
        }

        private void Acerca(object sender, RoutedEventArgs e)
        {
            acercade ventana = new acercade();
            ventana.Show();
        }
    }
}
