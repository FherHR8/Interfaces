using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Runtime.Intrinsics.Arm;
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
    /// Lógica de interacción para actualizar.xaml
    /// </summary>
    public partial class actualizar : Window
    {
        public actualizar()
        {
            InitializeComponent();
        }

        private void volver(object sender, RoutedEventArgs e)
        {
            Boolean existe = leer();
            if (existe)
            {
                MessageBox.Show("Estos son los datos actuales del empleado indicado");
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
        private bool validar(Empleado emp)
        {
            DateTime hoy = DateTime.Now;
            bool todo = true;
            if (String.IsNullOrEmpty(emp.Nombre))
            {
                todo = false;
                MessageBox.Show("Por favor, rellene el nombre");
            }
            else if (emp.Fecha > hoy)
            {
                todo = false;
                MessageBox.Show("La fecha no puede ser futura");
            }
            else if (String.IsNullOrEmpty(emp.Especialidad))
            {
                todo = false;
                MessageBox.Show("Por favor, rellene la especialidad");
            }
            else if (String.IsNullOrEmpty(emp.Titulacion))
            {
                todo = false;
                MessageBox.Show("Por favor, rellene la titulación");
            }
            else if ((emp.Categoria) < 1 || (emp.Categoria) > 11)
            {
                todo = false;
                MessageBox.Show("La categoría es un grupo del 1 al 11, por favor, introduzca un número adecuado");
            }
            else if (emp.Salario < 1100 || emp.Irpf > 3000)
            {
                todo = false;
                MessageBox.Show("Esta empresa sólo paga salarios entre 1100 y 3000");
            }
            else if (emp.Irpf < 19 || emp.Irpf > 47)
            {
                todo = false;
                MessageBox.Show("El porcentaje de IRPF está entre el 19 y el 47%, por favor, introduzca un número adecuado");
            }
            return todo;
        }
        private Empleado crearEmpleado()
        {
            int cod;
            if (int.TryParse(codigo.Text, out cod)) ;
            String nom = nombre.Text;
            DateTime fec;
            int anti = 0;
            if (DateTime.TryParse(alta.Text, out fec)) {
                DateTime hoy = DateTime.Now;
                TimeSpan diferencia = hoy - fec;
                anti = (int)(diferencia.Days / 365.25);
            }
            antigüedad.Content = anti.ToString() + " años";
            String esp = especialidad.Text;
            String tit = titulacion.Text;
            String pre = premios.Text;
            String com = comentarios.Text;
            int cat;
            if (int.TryParse(categoria.Text, out cat)) ;
            String compl = completo.Text;
            double sal;
            if (double.TryParse(salario.Text, out sal)) ;
            int irp;
            if (int.TryParse(irpf.Text, out irp)) ;
            String dep = departamento.Text;
            String gra = grado.Text;
            Empleado emp = new Empleado(cod, nom, fec, anti, esp, tit, pre, com, cat, compl, sal, irp, dep, gra);
            return emp;
        }
        private bool leer()
        {
            StreamReader fichero;
            bool existe = false;
            String nom = nombre.Text;
            if (File.Exists("empleados.txt"))
            {
                fichero = File.OpenText("empleados.txt");
                String linea = fichero.ReadLine();
                while (linea != null && existe == false)
                {
                    if (linea.Equals("Nombre: " + nom))
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
                        irpf.Text = linea.Substring(8);
                        linea = fichero.ReadLine();
                        departamento.Text = linea.Substring(14);
                        linea = fichero.ReadLine();
                        grado.Text = linea.Substring(7);
                        existe = true;
                    }
                    linea = fichero.ReadLine();

                }
                fichero.Close();
                if (existe == false)
                {
                    MessageBox.Show("Lo sentimos, dicho empleado no existe");
                }
            }
            return existe;
        }
        private void traspasar(Empleado emp)
        {
            StreamReader fichero;
            StreamWriter auxiliar;
            emp = crearEmpleado();
            String nom = nombre.Text;
            bool existe = false;
            if (File.Exists("empleados.txt"))
            {
                using (fichero = File.OpenText("empleados.txt"))
                using (auxiliar = File.CreateText("auxiliar.txt")) //Fichero sobreescribible
                {
                String linea = fichero.ReadLine();
                while (linea != null)
                {       
                        if (linea.Equals("Nombre: " + nom))
                        {
                            auxiliar.WriteLine("Nombre: " + nombre.Text);
                            linea = fichero.ReadLine();
                            auxiliar.WriteLine("Codigo: " + emp.Codigo);
                            linea = fichero.ReadLine();
                            auxiliar.WriteLine("Alta: " + emp.Fecha);
                            linea = fichero.ReadLine();
                            auxiliar.WriteLine("Antigüedad: " + emp.Antigüedad);
                            linea = fichero.ReadLine();
                            auxiliar.WriteLine("Especialidad: " + especialidad.Text);
                            linea = fichero.ReadLine();
                            auxiliar.WriteLine("Titulación: " + titulacion.Text);
                            linea = fichero.ReadLine();
                            auxiliar.WriteLine("Premios: " + premios.Text);
                            linea = fichero.ReadLine();
                            auxiliar.WriteLine("Comentarios: " + comentarios.Text);
                            linea = fichero.ReadLine();
                            auxiliar.WriteLine("Categoria: " + categoria.Text);
                            linea = fichero.ReadLine();
                            auxiliar.WriteLine("Jornada Completa: " + completo.Text);
                            linea = fichero.ReadLine();
                            auxiliar.WriteLine("Salario: " + salario.Text);
                            linea = fichero.ReadLine();
                            auxiliar.WriteLine("% IRPF: " + irpf.Text);
                            linea = fichero.ReadLine();
                            auxiliar.WriteLine("Departamento: " + departamento.Text);
                            linea = fichero.ReadLine();
                            auxiliar.WriteLine("Grado: " + grado.Text);
                            linea = fichero.ReadLine();
                            auxiliar.WriteLine("");
                            linea = fichero.ReadLine();
                            existe = true;
                        }
                        auxiliar.WriteLine(linea);
                        linea = fichero.ReadLine();
                    }
                }
                fichero.Close();
                auxiliar.Close();
                File.Delete("empleados.txt");
                File.Move("auxiliar.txt", "empleados.txt");
                if (existe == false)
                {
                    MessageBox.Show("Lo siento, el empleado indicado no existe");
                }
            }
        }
        private void renovar(object sender, RoutedEventArgs e)
        {
            bool val;
            {
                MessageBoxResult respuesta = MessageBox.Show("¿Deseas actualizar los datos de este empleado?", "Confirmacíón", MessageBoxButton.YesNo, MessageBoxImage.Question);

                if (respuesta == MessageBoxResult.Yes)
                {
                    Empleado emp = crearEmpleado();
                    val=validar(emp);
                    if(val) {
                        traspasar(emp);
                    }
                    else
                    {
                        MessageBox.Show("cambia los datos para poder actualizar");
                    }
                    
                }
            }
        }
    }
}
