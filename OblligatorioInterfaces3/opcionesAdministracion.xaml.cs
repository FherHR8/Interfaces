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
    /// Lógica de interacción para opcionesAdministracion.xaml
    /// </summary>
    public partial class opcionesAdministracion : Window
    {
        public opcionesAdministracion()
        {
            InitializeComponent();
        }

        private void alumnos(object sender, RoutedEventArgs e)
        {
            Entrar en = new Entrar();
            en.Show();
        }

        private void temas(object sender, RoutedEventArgs e)
        {
            TemasAdministrar ta = new TemasAdministrar();
            ta.Show();
        }
    }
}
