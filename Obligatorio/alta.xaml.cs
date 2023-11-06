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

namespace Obligatorio2
{
    
    public partial class alta : Window
    {
        public alta()
        {
            InitializeComponent();
            
        }
        private void agregarFichero(Empleado emp)
        {
            using (StreamWriter fichero = File.AppendText("empleados.txt")) //Fichero sobreescribible
            {
                bool x = validar(emp);
                if (x)
                {
                    fichero.WriteLine("Nombre: " + emp.Nombre);
                    fichero.WriteLine("Codigo: " + emp.Codigo.ToString());
                    fichero.WriteLine("Alta: " + emp.Fecha.ToString());
                    fichero.WriteLine("Antigüedad: " + emp.Antigüedad.ToString());
                    fichero.WriteLine("Especialidad: " + emp.Especialidad);
                    fichero.WriteLine("Titulación: " + emp.Titulacion);
                    fichero.WriteLine("Premios: " + emp.Premios);
                    fichero.WriteLine("Comentarios: " + emp.Comentarios);
                    fichero.WriteLine("Categoría: " + emp.Categoria);
                    fichero.WriteLine("Jornada Completa: " + emp.Completo);
                    fichero.WriteLine("Salario: " + emp.Salario.ToString());
                    fichero.WriteLine("% IRPF: " + emp.Irpf.ToString());
                    fichero.WriteLine("Departamento: " + emp.Departamento);
                    fichero.WriteLine("Grado: " + emp.Grado);
                    fichero.WriteLine("");
                    fichero.Close();
                    MessageBox.Show("Añadido al fichero un empleado");
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
        }
    private int obtenerCodigo()
        {
            int cod=0;
            StreamReader fichero;
            string linea;
            if (File.Exists("empleados.txt"))
            {
                fichero = File.OpenText("empleados.txt");
                linea = fichero.ReadLine();
                while (linea != null)
                {
                    if (linea.StartsWith("Codigo: "))
                    {
                        cod = int.Parse(linea.Substring(8));
                    }
                    linea = fichero.ReadLine();
                }
                fichero.Close();
            }
            cod++;
            codigo.Text = cod.ToString();
            return cod;

        }
    private bool validar(Empleado emp)
        {
            DateTime hoy = DateTime.Now;
            bool todo = true;
            if (String.IsNullOrEmpty(emp.Nombre)){
                todo= false;
                MessageBox.Show("Por favor, rellene el nombre");
            }
            else if (emp.Fecha > hoy)
            {
                todo=false;
                MessageBox.Show("La fecha no puede ser futura");
            }
            else if (String.IsNullOrEmpty(emp.Especialidad))
            {
                todo= false;
                MessageBox.Show("Por favor, rellene la especialidad");
            }
            else if (String.IsNullOrEmpty(emp.Titulacion))
            {
                todo = false;
                MessageBox.Show("Por favor, rellene la titulación");
            }
            else if((emp.Categoria)<1 || (emp.Categoria) > 11){
                todo = false;
                MessageBox.Show("La categoría es un grupo del 1 al 11, por favor, introduzca un número adecuado");
            }
            else if (emp.Salario < 1100 || emp.Irpf > 3000)
            {
                todo = false;
                MessageBox.Show("Esta empresa sólo paga salarios entre 1100 y 3000");
            }
            else if(emp.Irpf< 19 || emp.Irpf>47)
            {
                todo = false;
                MessageBox.Show("El porcentaje de IRPF está entre el 19 y el 47%, por favor, introduzca un número adecuado");
            }
            return todo;
        }
    private void guardar(object sender, RoutedEventArgs e)
        {       
                int cod = obtenerCodigo();
                String nom = nombre.Text;
                DateTime fec;
                int anti=0;
                if(DateTime.TryParse(fecha.Text, out fec)){
                DateTime hoy = DateTime.Now;
                TimeSpan diferencia=hoy - fec;
                anti = (int)(diferencia.Days /365.25);
            }
                antigüedad.Content = anti.ToString()+" años";
                String esp = especialidad.Text;
                String tit = titulacion.Text;
                String pre = premios.Text;
                String com = comentarios.Text;
                int cat;
                if(int.TryParse(categoria.Text,out cat));
                String compl = completo.Text;
                double sal; 
                if(double.TryParse(salario.Text,out sal));
                int irp; 
                if(int.TryParse(irpf.Text,out irp));
                String dep = departamento.Text;
                String gra = grado.Text;
                Empleado emp = new Empleado(cod, nom, fec, anti, esp, tit, pre, com, cat, compl, sal, irp, dep, gra);
            agregarFichero(emp);
            limpiar();
            }
        }
    }

