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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MisFicheros
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

        private void abre(object sender, RoutedEventArgs e)
        {
            AbrirDialogo();
        }

        private void guarda(object sender, RoutedEventArgs e)
        {
            GuardarDialogo();
        }

        private void escribe(object sender, RoutedEventArgs e)
        {
            validar();
            escribirFichero(CrearAlumno());
            limpiamos();
        }

        private void actualiza(object sender, RoutedEventArgs e)
        {
            Actualizar x=new Actualizar();
            x.Show();
        }

        private void salir(object sender, RoutedEventArgs e)
        {
            MessageBoxResult respuesta = MessageBox.Show("¿Deseas salir?", "Ventana de salir", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if(respuesta == MessageBoxResult.Yes)
            {
                Environment.Exit(0);
            }
        }

        private void borrado(object sender, RoutedEventArgs e)
        {
            limpiamos();
        }
        private void AbrirDialogo()
        {
            Microsoft.Win32.OpenFileDialog abrir = new Microsoft.Win32.OpenFileDialog();
            abrir.DefaultExt = ".txt";
            abrir.Filter = "Documentos de texto (.txt)|*.txt";
            Nullable<bool> result = abrir.ShowDialog();
            if(result == true)
            {
                string documento = abrir.FileName;
                StreamReader fichero;
                fichero=File.OpenText(documento);
                string contenido = "";
                string linea;
                linea=fichero.ReadLine();
                while (linea != null)
                {
                    contenido += linea + " ";
                    linea = fichero.ReadLine();
                }
                ver.Text = contenido;
                fichero.Close();
            }
        }
        private void GuardarDialogo()
        {
            Microsoft.Win32.SaveFileDialog guardar = new Microsoft.Win32.SaveFileDialog();
            guardar.DefaultExt = ".txt";
            guardar.Filter = "Documentos de texto (.txt)|*.txt";
            Nullable<bool>resultado = guardar.ShowDialog();
            if(resultado == true)
            {
                string documento = guardar.FileName;
                StreamWriter fichero;
                fichero = File.CreateText(documento);
                fichero.WriteLine("Este repaso es definitivo");
                fichero.Write("Vamos a por ");
                fichero.Write("todas");
                fichero.Close() ;
            }
        }
        private void limpiamos()
        {
            nombre.Clear();
            hermanos.Clear();
            fecha.SelectedDate = DateTime.Now;
            hombre.IsChecked = false;
            mujer.IsChecked = false;
            casado.IsChecked = false;
            ciclo.SelectedIndex = -1;
            colegio.SelectedIndex = -1;
            ver.Text = "";
        }
        private bool validarFecha()
        {
            bool correcto = false;
            DateTime f;
            if(DateTime.TryParse(fecha.Text, out f))
            {
                correcto=true;
            }
            else
            {
                MessageBox.Show("El valor de fecha no es correcto");
            }
            return correcto;
        }
        private bool validarHermanos()
        {
            bool correcto = false;
            int h;
            if(int.TryParse(hermanos.Text,out h))
            {
                correcto=true;
            }
            else
            {
                MessageBox.Show("Los hermanos han de ser un número entero");
            }
            return correcto;
        }
        private bool validar()
        {
            bool ok = true;
            if (string.IsNullOrWhiteSpace(nombre.Text))
            {
                ok = false;
                MessageBox.Show("el nombre no puede estar vacio");
            }
            else if((validarHermanos() == false) || (int.Parse(hermanos.Text)<0 || int.Parse(hermanos.Text)> 20))
            {
                ok = false;
                MessageBox.Show("No puedes tener hermanos negativos o tantos");
            }
            else if((validarFecha() || false) && fecha.SelectedDate > DateTime.Now)
            {
                ok = false;
                MessageBox.Show("No puedes estar matriculado a futuro");
            }
            else if(hombre.IsChecked==false && mujer.IsChecked==false)
            {
                ok = false;
                MessageBox.Show("Debes marcar un sexo");
            }
            else if(ciclo.SelectedIndex==-1)
            {
                ok = false;
                MessageBox.Show("Debes marcar un ciclo");
            }
            else if (colegio.SelectedIndex == -1)
            {
                ok = false;
                MessageBox.Show("Debes marcar al menos un colegio");
            }
            return ok;
        }
        private Alumno CrearAlumno()
        {
            Alumno a;
            string no = nombre.Text;
            DateTime fe = fecha.SelectedDate ?? DateTime.Now;
            int he = int.Parse(hermanos.Text);
            bool se = false;
            if (hombre.IsChecked==true)
            {
                se= true;
            }
            bool ca = false;
            if (casado.IsChecked == true)
            {
                ca = true;
            }
            String ci = ciclo.Text;
            List<string> co = new List<string>();
            for (int i = 0; i < colegio.Items.Count; i++)
            {
                ListBoxItem? l = colegio.Items[i] as ListBoxItem;
                if (l.IsSelected)
                {
                    co.Add(l.ToString());
                }
            }
            a = new Alumno(no, fe, he, se, ca, ci, co);
            return a;
        }
        private void escribirFichero(Alumno a)
        {
            using(StreamWriter fichero = File.AppendText("alumnos.txt"))
            {
                fichero.WriteLine("Nombre: " + a.Nombre);
                fichero.WriteLine("Fecha: " + a.Fecha);
                fichero.WriteLine("Hermanos: " + a.Hermanos);
                fichero.Write("Sexo: ");
                    if (a.Sexo)
                    {
                        fichero.WriteLine("Hombre");
                    }
                    else
                    {
                        fichero.WriteLine("Mujer");
                    }
                fichero.WriteLine("¿Casado?: " + a.Casado);
                fichero.WriteLine("Ciclo: " + a.Ciclo);
                fichero.Write("Colegio: ");
                for(int i = 0; i < a.Colegios.Count;i++)
                {
                    fichero.Write(a.Colegios[i] +" ");
                }
                fichero.WriteLine("");
                fichero.Close();
            }
        }
    }
}
