using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OblligatorioInterfaces3
{
    public class Actividad
    {
        private int id;
        private string pregunta;
        private string verdadera;
        private string respuesta1;
        private string respuesta2;
        private int puntos;
        private string tipo;
        private int tema;
        Actividad()
        {

        }
        public int Id { get => id; set => id = value; }
        public string Pregunta { get => pregunta; set => pregunta = value; }
        public string Verdadera { get => verdadera; set => verdadera = value; }
        public string Respuesta1 { get => respuesta1; set => respuesta1 = value; }
        public string Respuesta2 { get => respuesta2; set => respuesta2 = value; }
        public int Puntos { get => puntos; set => puntos = value; }
        public string Tipo { get => tipo; set => tipo = value; }
        public int Tema { get => tema; set => tema = value; }
    }
}
