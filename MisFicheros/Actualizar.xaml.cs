using System;
using System.Collections.Generic;
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

namespace MisFicheros
{
    /// <summary>
    /// Lógica de interacción para Actualizar.xaml
    /// </summary>
    public partial class Actualizar : Window
    {
        public Actualizar()
        {
            InitializeComponent();
        }

        private void refrescar(object sender, RoutedEventArgs e)
        {
                StreamReader fichero;
                StreamWriter auxiliar;
                string n = nom.Text;
                int c;
                if(int.TryParse(her.Text, out c)) {
                if (File.Exists("alumnos.txt"))
                {
                    using (fichero = File.OpenText("alumnos.txt"))
                    using (auxiliar = File.CreateText("auxiliar.txt"))
                    {
                        string linea=fichero.ReadLine();
                        while (linea != null)
                        {
                            auxiliar.WriteLine(linea);
                            if (linea.Equals("Nombre: " + n)){
                                linea = fichero.ReadLine();
                                auxiliar.WriteLine(linea);
                                linea = fichero.ReadLine();
                                auxiliar.WriteLine("Hermanos: " + c);
                            }
                            linea=fichero.ReadLine();
                        }
                        fichero.Close();
                        auxiliar.Close();
                        File.Delete("alumnos.txt");
                        File.Move("auxiliar.txt", "alumnos.txt");
                        MessageBox.Show("Usuario actualizado");
                    }
                }
                else{
                    MessageBox.Show("El fichero no existe");
                }
                }
            else
            {
                MessageBox.Show("El número de hermanos ha de ser un número entero");
            }
                

        }
        
    }
}
