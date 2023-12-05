using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
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
    /// Lógica de interacción para AgregarPreguntas.xaml
    /// </summary>
    public partial class AgregarPreguntas : Window
    {
        private BaseDatos b;
        tema t;
        Actividad[] actividades; 
        public AgregarPreguntas()
        {
            InitializeComponent();
            b= new BaseDatos();
            t = new tema();
            actividades = new Actividad[5];
        }

        private void otroTema_Click(object sender, RoutedEventArgs e)
        {
            if (validar())
            {
                int id = b.ObtenerId("tema");
                InsertarTema(t,id);
                InsertarPreguntas(actividades,b.ObtenerId("actividades"),id);
            }
        }
        public void InsertarTema(tema t, int iden)
        {
            t.Nombretema = nomTema.Text;
            t.Contenido = nomPDF.Text;
            int time=0;
            if (int.TryParse(tiempo.Text, out time));
            t.Tiempo = time;
            string meter = "INSERT INTO tema VALUES (" + iden + ",'" + t.Nombretema + "','" + t.Contenido + "'," +time+ ")";
            if (b.AbrirConectar())
            {
                MySqlCommand cmd = new MySqlCommand(meter, b.Conectar);

                cmd.ExecuteNonQuery();

                b.CerrarConectar();
            }
        }
        public void InsertarPreguntas(Actividad[] actividades, int iden, int tema)
        {
            actividades[0].Pregunta = pregunta1.Text.ToString;
            actividades[0].Verdadera=verdadera1.Text;
            actividades[0].Respuesta1 = erronea11.Text;
            actividades[0].Respuesta2 = erronea12.Text;
            actividades[0].Puntos = int.Parse(puntos.Text);
            actividades[0].Tipo = tipo.Text;

            actividades[1].Pregunta = pregunta2.Text;
            actividades[1].Verdadera = verdadera2.Text;
            actividades[1].Respuesta1 = erronea21.Text;
            actividades[1].Respuesta2 = erronea22.Text;

            actividades[2].Pregunta = pregunta3.Text;
            actividades[2].Verdadera = verdadera3.Text;
            actividades[2].Respuesta1 = erronea31.Text;
            actividades[2].Respuesta2 = erronea32.Text;

            actividades[3].Pregunta = pregunta4.Text;
            actividades[3].Verdadera = verdadera4.Text;
            actividades[3].Respuesta1 = erronea41.Text;
            actividades[3].Respuesta2 = erronea42.Text;

            actividades[4].Pregunta = pregunta5.Text;
            actividades[4].Verdadera = verdadera5.Text;
            actividades[4].Respuesta1 = erronea51.Text;
            actividades[4].Respuesta2 = erronea52.Text;
            for(int i=0; i < 5; i++)
            {
                string meter = "INSERT INTO actividades VALUES (" + iden + ",'" + actividades[i].Pregunta + "','" + actividades[i].Verdadera + "'," + actividades[i].Respuesta1+  "','" + actividades[i].Respuesta2 + "'," + actividades[0].Puntos + ",'" + actividades[0].Tipo+ "'," + tema+")";
                if (b.AbrirConectar())
                {
                    MySqlCommand cmd = new MySqlCommand(meter, b.Conectar);

                    cmd.ExecuteNonQuery();
                }
                b.CerrarConectar();
            }
        }
        public bool validar()
        {
            bool ok = true;
            if (string.IsNullOrEmpty(nomTema.Text))
            {
                ok= false;
            }
            else if(string.IsNullOrEmpty(nomPDF.Text))
            {
                ok = false;
            }
            else if (string.IsNullOrEmpty(tiempo.Text) || !int.TryParse(tiempo.Text, out int result))
            {
                ok = false;
            }
            else if (string.IsNullOrEmpty(puntos.Text) || !int.TryParse(puntos.Text, out int result2))
            {
                ok = false;
            }
            else if (string.IsNullOrEmpty(pregunta1.Text))
            {
                ok = false;
            }
            else if (string.IsNullOrEmpty(verdadera1.Text))
            {
                ok = false;
            }
            else if (string.IsNullOrEmpty(erronea11.Text))
            {
                ok = false;
            }
            else if (string.IsNullOrEmpty(erronea12.Text))
            {
                    ok = false;
            }
            else if (string.IsNullOrEmpty(pregunta2.Text))
            {
                ok = false;
            }
            else if (string.IsNullOrEmpty(verdadera2.Text))
            {
                ok = false;
            }
            else if (string.IsNullOrEmpty(erronea21.Text))
            {
                ok = false;
            }
            else if (string.IsNullOrEmpty(erronea22.Text))
            {
                ok = false;
            }
            else if (string.IsNullOrEmpty(pregunta3.Text))
            {
                ok = false;
            }
            else if (string.IsNullOrEmpty(verdadera3.Text))
            {
                ok = false;
            }
            else if (string.IsNullOrEmpty(erronea31.Text))
            {
                ok = false;
            }
            else if (string.IsNullOrEmpty(erronea32.Text))
            {
                ok = false;
            }
            else if (string.IsNullOrEmpty(pregunta4.Text))
            {
                ok = false;
            }
            else if (string.IsNullOrEmpty(verdadera4.Text))
            {
                ok = false;
            }
            else if (string.IsNullOrEmpty(erronea41.Text))
            {
                ok = false;
            }
            else if (string.IsNullOrEmpty(erronea42.Text))
            {
                ok = false;
            }
            else if (string.IsNullOrEmpty(pregunta5.Text))
            {
                ok = false;
            }
            else if (string.IsNullOrEmpty(verdadera5.Text))
            {
                ok = false;
            }
            else if (string.IsNullOrEmpty(erronea51.Text))
            {
                ok = false;
            }
            else if (string.IsNullOrEmpty(erronea52.Text))
            {
                ok = false;
            }
            if (ok == false)
            {
                MessageBox.Show("Debes rellenar adecuadamente todos los campos");
            }
            return ok;
        }
        }
    }

