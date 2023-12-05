using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OblligatorioInterfaces3
{
    public class users
    {
        public int id;
        public string username;
        public string password;
        public string email;
        public int puntos;
        public string rol;
       
        public users() { }
        public users(int id, string username, string password, string email)
        {
            this.Id = id;
            this.Username = username;
            this.Password = password;
            this.Email = email;
            this.Puntos = 0;
            this.Rol = "usuario";
        }

        public int Id { get => id; set => id = value; }
        public string Username { get => username; set => username = value; }
        public string Password { get => password; set => password = value; }
        public string Email { get => email; set => email = value; }
        public int Puntos { get => puntos; set => puntos = value; }
        public string Rol { get => rol; set => rol = value; }
    }
}
