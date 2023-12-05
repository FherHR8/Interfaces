using MySql.Data.MySqlClient;
using MySqlX.XDevAPI.Relational;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Diagnostics.Contracts;
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
        BaseDatos dBConnect=new BaseDatos();
        MySqlDataAdapter adaptador;
        DataTable tabla;
        public Entrar()
        {
            InitializeComponent();
            ver(); // si aqui es donde cargo el formulario aqui es donde compruebo y hago todo    
        }
        private void ver()
        {
            adaptador = new MySqlDataAdapter("SELECT username,email,puntos FROM users", dBConnect.Conectar);
            tabla = new DataTable();
            adaptador.Fill(tabla);
            // Enlaza el DataGrid con el DataTable
            dbDataGrid.ItemsSource = tabla.DefaultView;
        }

        private void actualizar_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("¿Quieres realizar la actualización de esta tupla?", "Confirmación", MessageBoxButton.YesNo, MessageBoxImage.Question);
            
            // Verifica la respuesta del usuario
            if (result == MessageBoxResult.Yes)
            {
                int ind = obtenerIndice();
                cambios(ind, "users");
                MessageBox.Show("Usuario actualizado");
                ver();
            }
            else
            {
                MessageBox.Show("De momento el usuario no se actualizará");
            }
        }
        public void cambios(int indice, String tabla)
        {
            var itemElegido = dbDataGrid.Items[indice];
            var usuario = dbDataGrid.Columns[0].GetCellContent(itemElegido) as TextBlock;
            var emilio = dbDataGrid.Columns[1].GetCellContent(itemElegido) as TextBlock;
            var puntos = dbDataGrid.Columns[2].GetCellContent(itemElegido) as TextBlock;
            String u = usuario.Text;
            String e = emilio.Text;
            int p =int.Parse(puntos.Text);
            int id=dBConnect.elegirId(indice, tabla, dBConnect);
            string actualiza = "UPDATE " + tabla + " SET username= '" + u + "' , email = '" + e + "' , puntos = " + p + " where id= " + id;
    if (dBConnect.AbrirConectar())
    {
        MySqlCommand cmd = new MySqlCommand(actualiza, dBConnect.Conectar);
        cmd.ExecuteNonQuery();
        dBConnect.CerrarConectar();
    }
    MessageBox.Show("Tupla actualizada");
}
        private void borrar_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("¿Quieres realizar el borrado de esta tupla?", "Confirmación", MessageBoxButton.YesNo, MessageBoxImage.Question);

            // Verifica la respuesta del usuario
            if (result == MessageBoxResult.Yes)
            {
                int id = dBConnect.elegirId(obtenerIndice(), "users", dBConnect);
                dBConnect.Borrar(id, "users", dBConnect);
                MessageBox.Show("Usuario borrado");
                ver();
                ;
            }
            else
            {
                MessageBox.Show("De momento el usuario no se borrará");
            }
        }
        public int obtenerIndice()
        {
            int selectedRow = -1;
            {
                // Verifica si hay una fila seleccionada
                if (dbDataGrid.SelectedItem != null)
                {
                    // Obtiene la fila seleccionada
                    var itemsSource = dbDataGrid.ItemsSource as IList;

                    selectedRow = dbDataGrid.SelectedIndex;
                    MessageBox.Show("" + selectedRow);

                    //itemsSource.RemoveAt(dbDataGrid.SelectedIndex);
                    // Elimina la fila de la colección de datos asociada al DataGrid
                    // Ajusta según tu tipo de datos y nombre de columna del ID
                }
            }
            return selectedRow;
        }
    }


}