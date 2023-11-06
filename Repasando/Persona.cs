using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repasando
{
    public class Persona
    {
        private string nombre;
        private bool mayor;
        private bool sexo;
        private int edad;
        private string color;
        private List<string> deportes=new List<string>();
        public Persona(string nombre, bool mayor, bool sexo, int edad, string color, List<string>deportes)
        {
            this.Nombre = nombre;
            this.Mayor = mayor;
            this.Sexo = sexo;
            this.Edad = edad;
            this.Color = color;
            this.Deportes = deportes;
        }
        public string Nombre { get => nombre; set => nombre = value; }
        public bool Mayor { get => mayor; set => mayor = value; }
        public bool Sexo { get => sexo; set => sexo = value; }
        public int Edad { get => edad; set => edad = value; }
        public List<string> Deportes { get => deportes; set => deportes = value; }
        public string Color { get => color; set => color = value; }
    }
}
