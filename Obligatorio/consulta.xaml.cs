using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
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

namespace Obligatorio2
{
    /// <summary>
    /// Lógica de interacción para consulta.xaml
    /// </summary>
    public partial class consulta : Window
    {
        public consulta()
        {
            InitializeComponent();
        }

        private void consultar(object sender, RoutedEventArgs e)
        {
                StreamReader fichero;
                bool existe = false;
                String nom = nombre.Text;
                if (File.Exists("empleados.txt"))
                {
                    fichero = File.OpenText("empleados.txt");
                    String linea = fichero.ReadLine();
                    while (linea != null && existe==false)
                    {
                        if (linea.Equals("Nombre: "+nom))
                        {
                        linea = fichero.ReadLine();
                        codigo.Text = linea.Substring(8);
                        linea = fichero.ReadLine();
                        alta.Text = linea.Substring(6);
                        linea = fichero.ReadLine();
                        antigüedad.Content = linea.Substring(12);
                        linea = fichero.ReadLine();
                        especialidad.Text = linea.Substring(14);
                        linea = fichero.ReadLine();
                        titulacion.Text = linea.Substring(12);
                        linea = fichero.ReadLine();
                        premios.Text = linea.Substring(9);
                        linea = fichero.ReadLine();
                        comentarios.Text = linea.Substring(13);
                        linea = fichero.ReadLine();
                        categoria.Text = linea.Substring(11);
                        linea = fichero.ReadLine();
                        completo.Text = linea.Substring(18);
                        linea = fichero.ReadLine();
                        salario.Text = linea.Substring(9);
                        linea = fichero.ReadLine();
                        irpfpor.Text = linea.Substring(8);
                        linea = fichero.ReadLine();
                        departamento.Text = linea.Substring(14);
                        linea = fichero.ReadLine();
                        grado.Text = linea.Substring(7);
                        existe = true;
                        }
                        linea = fichero.ReadLine();
                    }
                    fichero.Close();
                    double s;
                    if (double.TryParse(salario.Text, out s));
                    int p;
                    if (int.TryParse(irpfpor.Text, out p));
                    double c;
                    if (double.TryParse(sspor.Text, out c)) ;
                    irpf.Text = (s * p / 100).ToString();
                    ss.Text = (s * c/100).ToString();   
                    neto.Text = (s-(s*p/100)-(s*c/100)).ToString();
                if (existe == false)
                {
                    MessageBox.Show("Lo sentimos, dicho empleado no existe");
                    limpiar();
                }
            }
        }
        private void limpiar()
        {
            nombre.Clear();
            codigo.Clear();
            antigüedad.Content = "";
            especialidad.Clear();
            titulacion.Clear();
            premios.Clear();
            comentarios.Clear();
            categoria.Clear();
            salario.Clear();
            irpf.Clear();
            irpfpor.Clear();
            neto.Clear();
            ss.Clear();        
        }
        private void regreso(object sender, RoutedEventArgs e)
        {
                this.Close();
        }
    }
}
