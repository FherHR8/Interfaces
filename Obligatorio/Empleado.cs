using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Obligatorio2
{
    class Empleado
    {
        private int codigo;
        private String nombre="";
        private DateTime fecha = new DateTime();
        private int antigüedad;
        private String especialidad="";
        private String titulacion = "";
        private String premios = "";
        private String comentarios = "";
        private int categoria;
        private String completo = "";
        private double salario;
        private int irpf;
        private String departamento = "";
        private String grado = "";

        public Empleado(int codigo, String nombre, DateTime fecha, int antigüedad, String especialidad, String titulacion, String premios, String comentarios
            , int categoria, String completo, double salario, int irpf, String departamento, String grado)
        {
            this.codigo = codigo;
            this.nombre = nombre;
            this.fecha = fecha;
            this.antigüedad = antigüedad;
            this.especialidad = especialidad;
            this.titulacion=titulacion;
            this.premios = premios;
            this.comentarios = comentarios;
            this.categoria=categoria;
            this.completo= completo;
            this.salario=salario;  
            this.irpf=irpf;
            this.departamento=departamento;
            this.grado=grado;
        }
        public int Codigo { get => codigo; set => codigo = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public DateTime Fecha { get => fecha; set => fecha = value; }
        public int Antigüedad { get => antigüedad; set => antigüedad = value; }
        public string Especialidad { get => especialidad; set => especialidad = value; }
        public string Titulacion { get => titulacion; set => titulacion = value; }
        public string Premios { get => premios; set => premios = value; }
        public string Comentarios { get => comentarios; set => comentarios = value; }
        public int Categoria { get => categoria; set => categoria = value; }
        public string Completo { get => completo; set => completo = value; }
        public double Salario { get => salario; set => salario = value; }
        public int Irpf { get => irpf; set => irpf = value; }
        public string Departamento { get => departamento; set => departamento = value; }
        public string Grado { get => grado; set => grado = value; }
    }
}
