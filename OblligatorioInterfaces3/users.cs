using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OblligatorioInterfaces3
{
    internal class users
    {
        private int id;
        private string username;
        private string password;
        private string email;
        private int puntos;
        private bool rol;
        public users(int id, string username, string password, string email, int puntos, bool rol)
        {
            this.Id = id;
            this.Username = username;
            this.Password = password;
            this.Email = email;
            this.Puntos = obtenerPuntos();
            this.Rol = false;
        }
        private int obtenerPuntos()
        {
            Random aleatorio=new Random();
            int puntos=aleatorio.Next(1,11);
            return puntos;
        }

        public int Id { get => id; set => id = value; }
        public string Username { get => username; set => username = value; }
        public string Password { get => password; set => password = value; }
        public string Email { get => email; set => email = value; }
        public int Puntos { get => puntos; set => puntos = value; }
        public bool Rol { get => rol; set => rol = value; }
    }
}
