using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using MySql.Data.MySqlClient;
using MySqlX.XDevAPI.Relational;
using Org.BouncyCastle.Bcpg;

namespace OblligatorioInterfaces3
{
    //Clase BaseDatos con sus atributos indispensables MySqlConnection, servidor, base de datos, nombre y contraseña (y sus getter and setter)
    class BaseDatos
    {
        private MySqlConnection conectar;
        private string servidor;
        private string baseD;
        private string nombre;
        private string contrasena;

        public MySqlConnection Conectar { get => conectar; set => conectar = value; }
        public string Servidor { get => servidor; set => servidor = value; }
        public string BaseD { get => baseD; set => baseD = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Contrasena { get => contrasena; set => contrasena = value; }

        public BaseDatos()
        {
            Iniciar();
        }
        /*Para conectar a la base de datos, estos atributos deben coincidir con los de la bbdd con la que se trabaja. Si todo es correcto,
         pasamos todos los datos a una conectionString que será la que conecte meddiante nuestro objeto MySqlConnection*/
        public void Iniciar()
        {
            servidor = "localhost";
            baseD = "proyectointerfaces";
            nombre = "root";
            contrasena = "";
            string connectionString;
            connectionString = "SERVER=" + servidor + " ;" + "DATABASE=" +
            baseD + " ;" + "UID=" + nombre + " ;" + "PASSWORD=" + contrasena + " ;";

            conectar = new MySqlConnection(connectionString);
        }
        //Método para abrir la conexión y enviar mensaje de error en el caso de que por lo que sea, no se pueda conectar.
        public bool AbrirConectar()
        {
            try
            {
                Conectar.Open();
                MessageBox.Show("Conecta");
                return true;
            }catch (MySqlException ex)
            {
                switch (ex.Number)
                {
                    case 0:
                    MessageBox.Show("No se puede conectar con el servidor");
                    break;
                    case 1045:
                        MessageBox.Show("Contraseña o usuario no válidos");
                        break;
                    default:
                        MessageBox.Show("Otro error: " + ex.Message + ex.Number);
                        break;
                }
                return false;
            }
        }
        //Lo mismo que con abrir pero al cerrar
        public bool CerrarConectar()
        {
            try
            {
                Conectar.Close();
                MessageBox.Show("Cerrado con éxito");
                return true;
            }catch (MySqlException ex)
            {
                MessageBox.Show("Error al cerrar");
                return false;
            }
        }
        //Método que nos insertar un nuevo usuario en la bbdd
        public void Insertar(users u)
        {
            int id = u.Id;
            string username = u.Username;
            string password = u.Password;
            string email = u.Email;
            int puntos = u.Puntos;
            string rol = u.Rol;
            string meter = "INSERT INTO users (id,username,password,email,puntos,rol) VALUES ("+id+",'"+username+"','"+password+"','"+email+"',"+puntos+",'"+rol+"')";
            if (this.AbrirConectar())
            {
                MySqlCommand cmd = new MySqlCommand(meter, Conectar);

                cmd.ExecuteNonQuery();

                CerrarConectar();
            }
        }
        public int elegirId(int fila, String tabla, BaseDatos b)
        {
            int idelegido = -1;
            string consulta = "select id from " + tabla + " order by id limit 1 offset " + fila;
            if (this.AbrirConectar())
            {
                MySqlCommand cmd = new MySqlCommand(consulta, Conectar);
                Object obtener = cmd.ExecuteScalar();
                idelegido = (int)obtener;
                cmd.ExecuteNonQuery();
                CerrarConectar();
            }
            return idelegido;
        }
        public void Borrar(int idElegido, String tabla, BaseDatos b)
        {
            string elimina = "DELETE from " + tabla + " Where id = "+ idElegido;
            if (this.AbrirConectar())
            {
                MySqlCommand cmd = new MySqlCommand(elimina, Conectar);
                cmd.ExecuteNonQuery();
                CerrarConectar();
            }
            MessageBox.Show("Tupla borrada");
        }
        //Obtenemos el id de usuario a partir del máximo de la tabla users, le voy a meter un parametro string para que me sirva en temas.
        public int ObtenerId(String tabla)
        {
            int proximoId = 1;
            string consulta = "SELECT MAX(id) FROM "+tabla;
            if (this.AbrirConectar())
            {
                MySqlCommand cmd = new MySqlCommand(consulta, Conectar);
                Object obtener = cmd.ExecuteScalar();
                if (obtener != null && obtener!= DBNull.Value)
                {
                    proximoId = (int)obtener;
                    proximoId++;
                }     
            } 
            CerrarConectar();
            return proximoId;
        }
        public bool login(String emilio, String contra, BaseDatos b, users u)
        {
            bool login = false;
            string consulta = "SELECT * from users where password like '" + contra + "' and email like '" + emilio + "'";
            if (b.AbrirConectar())
            {
                MySqlCommand cmd = new MySqlCommand(consulta, b.Conectar);
                MySqlDataReader lector = cmd.ExecuteReader();
                if (lector.Read())
                {
                    u.id = lector.GetInt32(0);
                    u.Username = lector["username"].ToString();
                    u.Password = lector["password"].ToString();
                    u.Email = lector["email"].ToString();
                    u.Rol =lector["rol"].ToString();
                    u.puntos = lector.GetInt32(4);
                    return true;
                }
                else
                {
                    MessageBox.Show("Correo y contraseña no coinciden");
                }
            }
            b.CerrarConectar();
            return login;
        }
    }
}
