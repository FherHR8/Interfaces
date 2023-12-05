using MySql.Data.MySqlClient;
using MySqlX.XDevAPI.Common;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
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
using System.Diagnostics;

namespace OblligatorioInterfaces3
{
    /// <summary>
    /// Lógica de interacción para TemasAdministrar.xaml
    /// </summary>
    public partial class TemasAdministrar : Window
    {
        BaseDatos b = new BaseDatos();
        MySqlDataAdapter adaptador;
        DataTable tabla;
        public TemasAdministrar()
            
        {
            InitializeComponent();
            ver();
        }
        private void ver()
        {
            adaptador = new MySqlDataAdapter("SELECT nombretema,contenido,tiempo FROM tema",b.Conectar);
            tabla = new DataTable();
            adaptador.Fill(tabla);
            dbDataGrid.ItemsSource = tabla.DefaultView;
        }
        public int obtenerIndice()
        {
            int selectedRow = -1;
            {
                if (dbDataGrid.SelectedItem != null)
                {
                    var itemsSource = dbDataGrid.ItemsSource as IList;
                    selectedRow = dbDataGrid.SelectedIndex;
                    MessageBox.Show("" + selectedRow);
                }
            }
            return selectedRow;
        }
        private String obtenerRuta(int indice)
        {
            String ru = "";
            var itemElegido = dbDataGrid.Items[indice];
            var pdf = dbDataGrid.Columns[1].GetCellContent(itemElegido) as TextBlock;
            ru = pdf.Text;
            MessageBox.Show(ru);
            return ru;
        }

        private void agregar(object sender, RoutedEventArgs e)
        {
            AgregarPreguntas ap=new AgregarPreguntas();
            ap.Show();
        }

        private void variar(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("¿Quieres realizar la actualización de esta tupla?", "Confirmación", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                cambios(obtenerIndice(), "tema");
                ver();
            }
            else
            {
                MessageBox.Show("De momento el tema no se actualizará");
            } 
        }
        public void cambios(int indice, String tabla)
        {
            var itemElegido = dbDataGrid.Items[indice];
            var nombreTema = dbDataGrid.Columns[0].GetCellContent(itemElegido) as TextBlock;
            var contenido = dbDataGrid.Columns[1].GetCellContent(itemElegido) as TextBlock;
            var tiempo = dbDataGrid.Columns[2].GetCellContent(itemElegido) as TextBlock;
            String nt = nombreTema.Text;
            String c = contenido.Text;
            int t = int.Parse(tiempo.Text);
            int id = b.elegirId(indice, tabla, b);
            string actualiza = "UPDATE " + tabla + " SET nombretema= '" + nt + "' , contenido = '" + c + "' , tiempo = " + t + " where id= " + id;
            if (b.AbrirConectar())
            {
                MySqlCommand cmd = new MySqlCommand(actualiza, b.Conectar);
                cmd.ExecuteNonQuery();
                b.CerrarConectar();
            }
            MessageBox.Show("Tupla actualizada para el id "+id);
        }
        private void fulminar(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("¿Quieres realizar el borrado de esta tupla?", "Confirmación", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                int ide = b.elegirId(obtenerIndice(), "tema", b);
                //Obtenemos el id, y borramos todas las actividades de ese id
                string eliminar = "DELETE from actividades Where tema = " + ide;
                if (b.AbrirConectar())
                {
                    MySqlCommand cmd = new MySqlCommand(eliminar, b.Conectar);
                    cmd.ExecuteNonQuery();
                    b.CerrarConectar();
                    MessageBox.Show("Eliminadas todas las actividades del tema " + ide);
                }
                MessageBox.Show("Tupla borrada");
                //Después borramos el tema
                b.Borrar(ide, "tema", b);
                ver();
            }
            else
            {
                MessageBox.Show("De momento no se borrará el tema");
            }
        }
    }
}
