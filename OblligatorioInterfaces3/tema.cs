using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OblligatorioInterfaces3
{
    public class tema
    {
        private int id;
        private string nombretema;
        private string contenido;
        private int tiempo;
   
    public tema(int id, string nombretema, string contenido, int tiempo)
    {
            this.id = id;
            this.nombretema = nombretema;
            this.contenido = contenido;
            this.tiempo = tiempo;
    }
        public tema()
        {
            
        }
        

        public int Id { get => id; set => id = value; }
        public string Nombretema { get => nombretema; set => nombretema = value; }
        public string Contenido { get => contenido; set => contenido = value; }
        public int Tiempo { get => tiempo; set => tiempo = value; }
    }
}
