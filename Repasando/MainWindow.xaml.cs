using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;

namespace Repasando
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string nom, col;
        int eda;
        bool may, sex;
        List<string> dep;
        public MainWindow()
        {
            InitializeComponent();
            nom = "";
            col = "";
            eda = 0;
            may = false;
            sex = false;
            dep = new List<string>();
        }
        private void actualizar()
        {
            StreamReader fichero;
            StreamWriter auxiliar;
            string n = nomb.Text;
            int c;
            if (int.TryParse(numero.Text, out c))
            {
                if (File.Exists("Personas.txt"))
                {
                    using (fichero = File.OpenText("Personas.txt"))
                    using (auxiliar = File.CreateText("auxiliar.txt"))
                    {
                        string linea = fichero.ReadLine();
                        while (linea != null)
                        {
                            auxiliar.WriteLine(linea);
                            if (linea.Contains("Codigo: " + c))
                            {
                                linea = fichero.ReadLine();
                                auxiliar.WriteLine("Nombre: " + n);
                            }
                            linea = fichero.ReadLine();
                        }
                        fichero.Close();
                        auxiliar.Close();
                        File.Delete("Personas.txt");
                        File.Move("auxiliar.txt", "Personas.txt");
                        MessageBox.Show("Usuario actualizado");
                    }
                }
            }    
        }
        private void visualizar()
        {
            int x;
            if (int.TryParse(resultado.Text, out x));
            StreamReader fichero;
            string linea;
            if (File.Exists("personas.txt"))
            {
                fichero = File.OpenText("personas.txt");
                linea = fichero.ReadLine();
                String esc = "";
                while (linea != null)
                {
                    if(linea.StartsWith("Codigo: " + x))
                    {
                        linea=fichero.ReadLine();
                        while(linea!=null && !linea.StartsWith("Codigo: "))
                        {
                            esc += linea + " ";
                            linea=fichero.ReadLine() ;
                        }    
                    }
                    linea = fichero.ReadLine();
                }
                resultado.Text = esc;
                fichero.Close();
            }
        }
        private int obtenerCodigo()
        {
            int cod = 0;
            StreamReader fichero;
            string linea;
            if (File.Exists("personas.txt"))
            {
                fichero = File.OpenText("personas.txt");
                linea = fichero.ReadLine();
                while(linea != null)
                {
                    if(linea.StartsWith("Codigo: "))
                    {
                        cod=int.Parse(linea.Substring(8));
                        MessageBox.Show(linea.Substring(8));
                    }
                    linea = fichero.ReadLine();
                }
                fichero.Close();
            }
            cod++;
            return cod;
        }
        private void escribirPersona(Persona per)
        {
            int cod = obtenerCodigo();
            using (StreamWriter fichero = File.AppendText("personas.txt"))
            {
                fichero.WriteLine("Codigo: " + cod);
                fichero.WriteLine("Nombre: " + per.Nombre);
                fichero.WriteLine("Edad: " + per.Edad);
                fichero.WriteLine("Color: " + per.Color);
                fichero.Write("Sexo: ");
                if (per.Sexo)
                {
                    fichero.WriteLine("hombre");
                }
                else
                {
                    fichero.WriteLine("mujer");
                }
                fichero.WriteLine("¿Mayor de edad? " + per.Mayor);
                fichero.Write("Deportes: ");
                for (int i = 0; i < per.Deportes.Count; i++)
                {
                    fichero.WriteLine(per.Deportes[i] + " ");
                }
                fichero.WriteLine("");
                fichero.Close();
                MessageBox.Show("Persona añadida");
            }
        }
        private Persona agregarPersona()
        {
            nom = nombre.Text;
            int c = color.SelectedIndex;
            col = color.Text;
            eda = int.Parse(edad.Text);
            may = false;
            if ((bool)mayor.IsChecked)
            {
                may = true;
            }
            sex = false;
            if ((bool)hombre.IsChecked)
            {
                sex = true;
            }
            dep = new List<string>();
            foreach (var item in deportes.SelectedItems)
            {
                string deporte = item.ToString();
                dep.Add(deporte);
                MessageBox.Show(deporte);
            }
            Persona per = new Persona(nom, may, sex, eda, col, dep);
            return per;
        }
        public void limpiar()
        {
            nombre.Clear();
            edad.Clear();
            color.SelectedIndex = -1;
            deportes.SelectedIndex = -1;
            mayor.IsChecked = false;
            hombre.IsChecked = false;
            mujer.IsChecked = false;
        }
        public bool validarEdad()
        {
            bool correcto = false;
            if (int.TryParse(edad.Text, out eda) && (eda > 0 && eda < 120))
            {
                correcto = true;
            }
            return correcto;
        }
        public bool validando()
        {
            bool ok = true;
            if (string.IsNullOrWhiteSpace(nombre.Text))
            {
                ok = false;
                MessageBox.Show("El nombre no puede estar vacío");
            }
            else if (validarEdad() == false)
            {
                ok = false;
                MessageBox.Show("La edad no es un número o no está comprendida entre 0 y 120");
            }

            else if (color.SelectedIndex == -1)
            {
                ok = false;
                MessageBox.Show("Debes elegir uno de los colores");

            }
            else if ((bool)!hombre.IsChecked && (bool)!mujer.IsChecked)
            {
                ok = false;
                MessageBox.Show("Debes seleccionar un sexo");
            }
            else if (deportes.SelectedIndex == -1)
            {
                ok = false;
                MessageBox.Show("Debes seleccionar al menos un deporte");
            }
            return ok;
        }
        private void validar(object sender, RoutedEventArgs e)
        {
            if (validando() == false)
            {
                MessageBox.Show("Validación incorrecta");
            }
            else
            {
                MessageBox.Show("Queda validado y listo para escribir");
            }
        }

        private void abrir(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog abrirtxt = new Microsoft.Win32.OpenFileDialog();
            abrirtxt.DefaultExt = ".txt";
            abrirtxt.Filter = "Documentos de texto (.txt)|*.txt";
            Nullable<bool> result = abrirtxt.ShowDialog();
            if (result == true)
            {
                string documento = abrirtxt.FileName;
                StreamReader fichero;
                fichero = File.OpenText(documento);
                string contenido = "";
                string linea;
                do
                {
                    linea = fichero.ReadLine();
                    if (linea != null)
                    {
                        contenido += " " + linea;
                    }
                } while (linea != null);
                copia.Text = contenido;
                fichero.Close();
            }
        }

        private void guardar(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.SaveFileDialog guardar = new Microsoft.Win32.SaveFileDialog();
            guardar.DefaultExt = ".txt";
            guardar.Filter = "Documentos de texto (.txt)|*.txt";
            Nullable<bool> result = guardar.ShowDialog();
            if (result == true)
            {
                string documento = guardar.FileName;
                StreamWriter fichero;
                fichero = File.CreateText(documento);
                fichero.WriteLine("Soy el mejor");
                fichero.Write("y nadie puede negarlo");
                fichero.Close();
            }
        }
        private void escribir(object sender, RoutedEventArgs e)
        {
            MessageBoxResult respuesta = MessageBox.Show("¿Deseas salir de la aplicación?", "Salir o escribir", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (respuesta == MessageBoxResult.Yes)
            {
                Application.Current.Shutdown();
            }
            else
            {
                if (validando())
                {
                    MessageBox.Show("Procedemos a escribir en un fichero de texto la nueva persona");

                    escribirPersona(agregarPersona());
                    limpiar();
                }
                else
                {
                    MessageBox.Show("No hacemos nada");
                }
            }
        }

        private void consultar(object sender, RoutedEventArgs e)
        {
            visualizar();
        }
        private void mostrar(object sender, RoutedEventArgs e)
        {
            MainWindow otra = new MainWindow();
            otra.Title = "Ventana 2";
            otra.Show();

        }

        private void ayuda(object sender, RoutedEventArgs e)
        {
            actualizar();
            Ayuda help = new Ayuda();
            help.Show();
            
        }
    }
}
