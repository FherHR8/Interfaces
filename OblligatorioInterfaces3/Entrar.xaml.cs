using MySql.Data.MySqlClient;
using MySqlX.XDevAPI.Relational;
using System;
using System.Collections.Generic;
using System.Data;
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
    /// Lógica de interacción para Entrar.xaml
    /// </summary>
    public partial class Entrar : Window
    {
        MySqlDataAdapter adaptador;
        DataTable tabla;
        public Entrar()
        {
            InitializeComponent();
            ver();
            MessageBox.Show("cosa");
        }
        /*private void ver()
        {
            BaseDatos bd = new BaseDatos();
            adaptador = new MySqlDataAdapter("SELECT username,email,puntos from users", bd.Conectar);
            tabla = new DataTable();
            adaptador.Fill(tabla);
            if(tabla.Rows.Count > 0 )
            {
                data.ItemsSource = tabla.DefaultView;
                MessageBox.Show("Hola");
            }
            bd.CerrarConectar();
        }*/
        private void ver()
        {
            BaseDatos bd = new BaseDatos();
            adaptador = new MySqlDataAdapter("SELECT username,email,puntos from users", bd.Conectar);
            tabla = new DataTable();
            adaptador.Fill(tabla);

            // Configurar las columnas del DataGrid
            DataGridTextColumn colUsuario = new DataGridTextColumn();
            colUsuario.Width = 300;
            colUsuario.Header = "Usuario";
            colUsuario.Binding = new Binding("username");
            data.Columns.Add(colUsuario);

            DataGridTextColumn colEmail = new DataGridTextColumn();
            colEmail.Width = 300;
            colEmail.Header = "Email";
            colEmail.Binding = new Binding("email");
            data.Columns.Add(colEmail);

            DataGridTextColumn colPuntuacion = new DataGridTextColumn();
            colPuntuacion.Width = 200;
            colPuntuacion.Header = "Puntuación";
            colPuntuacion.Binding = new Binding("puntos");
            data.Columns.Add(colPuntuacion);

            if (tabla.Rows.Count > 0)
            {
                data.ItemsSource = tabla.DefaultView;
                MessageBox.Show("Hola");
            }
            bd.CerrarConectar();
        }

    }
}
