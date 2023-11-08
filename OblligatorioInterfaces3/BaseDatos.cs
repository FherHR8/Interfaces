using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using MySql.Data.MySqlClient;
using Org.BouncyCastle.Bcpg;

namespace OblligatorioInterfaces3
{
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
        public void Iniciar()
        {
            Servidor = "localhost";
            BaseD = "interfaces3";
            Nombre = "root";
            Contrasena = "";
            string cadenaConectar = "SERVER=" + Servidor + ";" + "DATABASE=" + BaseD + ";" + "UID=" + Nombre + ";" + "PASSWORD=" + Contrasena + ";";
            Conectar = new MySqlConnection(cadenaConectar);
        }
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
        public void Insertar(users u)
        {
            int id = u.Id;
            string username = u.Username;
            string password = u.Password;
            string email = u.Email;
            int puntos = u.Puntos;
            bool rol = u.Rol;
            string nombrerol="";
            if (rol == false)
            {
                nombrerol = "usuario";
            }
            string meter = "INSERT INTO users (id,username,password,email,puntos,rol) VALUES ("+id+",'"+username+"','"+password+"','"+email+"',"+puntos+",'"+nombrerol+"')";
            if (this.AbrirConectar())
            {
                MySqlCommand cmd = new MySqlCommand(meter, Conectar);

                cmd.ExecuteNonQuery();

                CerrarConectar();
            }
        }
        public int ObtenerId()
        {
            int proximoId = 0;
            string consulta = "SELECT MAX(id) FROM users";
            if (this.AbrirConectar())
            {
                MySqlCommand cmd = new MySqlCommand(consulta, Conectar);
                Object obtener = cmd.ExecuteScalar();
                proximoId = (int)obtener;
                proximoId++;
            } 
            CerrarConectar();
            return proximoId;
        }
    }
}
