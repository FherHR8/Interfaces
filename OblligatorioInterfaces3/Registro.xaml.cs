using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
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
using MySql.Data.MySqlClient;

namespace OblligatorioInterfaces3
{
    /// <summary>
    /// Lógica de interacción para Registro.xaml
    /// </summary>
    public partial class Registro : Window
    {
        private string usuario;
        private string contrasena;
        private string email;
        private string repetir;
        private int puntos;
        private string tipo;

        public int Puntos { get => puntos; set => puntos = value; }
        public string Tipo { get => tipo; set => tipo = value; }
        public Registro()
        {
            InitializeComponent();
            usuario = Nombre.Text;
            contrasena = Contrasena.Text;
            email = Email.Text;
            repetir = Repetir.Text;
            puntos = 1;
            tipo = "usuario";
        }
        private void entrar(object sender, RoutedEventArgs e)
        {
            if (validarUsuario())
            {
                MessageBox.Show("Adentro");
                BaseDatos b = new BaseDatos();
                int nuevoId = b.ObtenerId();
                users u = new users (nuevoId, usuario, contrasena, email, puntos, false);
                

                b.Insertar(u);
            }
        }
        public bool validarUsuario()
        {
            usuario = Nombre.Text;
            contrasena = Contrasena.Text;
            email = Email.Text;
            repetir = Repetir.Text;
            bool ok = true;
            if (string.IsNullOrWhiteSpace(usuario))
            {
                MessageBox.Show("El nombre de usuario no puede estar vacío");
                return false;
            }
            else if(string.IsNullOrWhiteSpace(email) || email.Length <4) {
                MessageBox.Show("El email no es válido");
                return false;
            }
            else if(string.IsNullOrWhiteSpace(contrasena) || (!contrasena.Equals(repetir))){
                MessageBox.Show("La contraseña no coincide con la repetición o está vacía");
                return false;
            }
            return ok;
        }
    }
}
