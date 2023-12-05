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
using System.Windows.Shapes;

namespace OblligatorioInterfaces3
{
    /// <summary>
    /// Lógica de interacción para Olvidar.xaml
    /// </summary>
    public partial class Olvidar : Window
    {
        public Olvidar()
        {
            InitializeComponent();
        }

        private void obtener(object sender, RoutedEventArgs e)
        {
            if(respuesta.Text.Equals("Blanco") || respuesta.Text.Equals("blanco") || respuesta.Text.Equals("BLANCO"))
            {
                string x = recuperarContra();
              
                    MessageBox.Show("Tu contraseña es:  " + x);
            }
            else
            {
                MessageBox.Show("La respuesta a la pregunta es incorrecta, no podemos darte la contraseña hasta que aciertes");
            }
        }
        private string recuperarContra()
        {
            BaseDatos b = new BaseDatos();
            string contra="";
            string consulta = "SELECT password from users where username like '" + nombre.Text + "'";
            if (b.AbrirConectar())
            {
                MySqlCommand cmd = new MySqlCommand(consulta, b.Conectar);
                Object pass = cmd.ExecuteScalar();
                contra = (string)pass;
            }
            return contra;
        }
    }
}
