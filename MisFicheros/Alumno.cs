using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace MisFicheros
{
    public class Alumno
    {
        private string nombre;
        private DateTime fecha;
        private int hermanos;
        private bool sexo;
        private bool casado;
        private string ciclo;
        private List<String> colegios;

        public Alumno(string nombre, DateTime fecha, int hermanos, bool sexo, bool casado, string ciclo, List <string> colegios)
        {
            this.Nombre = nombre;
            this.Fecha = fecha;
            this.Hermanos = hermanos;
            this.Sexo = sexo;
            this.Casado = casado;
            this.Ciclo = ciclo;
            this.Colegios = colegios;
        }

        public string Nombre { get => nombre; set => nombre = value; }
        public DateTime Fecha { get => fecha; set => fecha = value; }
        public int Hermanos { get => hermanos; set => hermanos = value; }
        public bool Sexo { get => sexo; set => sexo = value; }
        public bool Casado { get => casado; set => casado = value; }
        public string Ciclo { get => ciclo; set => ciclo = value; }
        public List<string> Colegios { get => colegios; set => colegios = value; }
    }
}
