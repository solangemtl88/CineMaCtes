using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CinemaCtes
{
    public partial class FormInicio : Form
    {
        public FormInicio()
        {
            InitializeComponent();
        }

        private void FormInicio_Load(object sender, EventArgs e)
        {
            // Cargamos la fecha actual en la esquina superior derecha de forma dinámica
            LFecha.Text = DateTime.Now.ToString("dddd, dd 'de' MMMM 'de' yyyy");

            // Llamamos a los métodos el estilo y configuracion de la tabla al iniciar la pantalla
            ClassEstilosHelper.AplicarEstiloTabla(DGVProximas);

            // Cargamos registros ficticios de prueba (Modo Maqueta)
            CargarTablaProximasFunciones();
        }

        private void CargarTablaProximasFunciones()
        {
            DGVProximas.Rows.Clear();

            // Asegurate de que tu DataGridView tenga las 4 columnas en este orden: 
            // Hora Inicio, Hora Fin, Película, Sala
            DGVProximas.Rows.Add("16:00", "18:15", "Intensamente 2", "Sala 2");
            DGVProximas.Rows.Add("18:30", "21:15", "Avengers: Endgame", "Sala 1");
            DGVProximas.Rows.Add("21:30", "23:45", "Dune: Parte Dos", "Sala 3");
        }

        // Botón Acceso Rápido: Programar Función
        private void BProgramarFuncion_Click(object sender, EventArgs e)
        {
            using (FormRegistroFuncion formRegistro = new FormRegistroFuncion())
            {
                formRegistro.ShowDialog();
            }
        }

        // Botón Acceso Rápido: Registrar Película
        private void BRegistrarPelicula_Click(object sender, EventArgs e)
        {
            using (FormRegistrarPelicula formPelicula = new FormRegistrarPelicula())
            {
                formPelicula.ShowDialog();
            }
        }

    }
}
