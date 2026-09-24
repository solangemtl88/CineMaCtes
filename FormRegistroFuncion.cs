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
    public partial class FormRegistroFuncion : Form
    {
        // Propiedades públicas para exponer los datos seleccionados al formulario principal
        public string PeliculaSeleccionada => CBPelicula.SelectedItem?.ToString() ?? "";
        public int NroSalaSeleccionada => int.TryParse(CBSala.SelectedItem?.ToString(), out int sala) ? sala : 0;

        // Propiedades de Fecha y Hora combinadas para el tipo DATETIME de la BD
        public DateTime FechaFuncion => DTPFecha.Value.Date;
        public DateTime InicioFuncion => FechaFuncion.Add(DTPInicio.Value.TimeOfDay);

        // Simulamos la duración de la película (en un sistema real se obtiene según la película elegida, ej: 150 minutos)
        public int DuracionPeliculaMinutos = 150;
        public DateTime FinFuncion => InicioFuncion.AddMinutes(DuracionPeliculaMinutos);

        public FormRegistroFuncion()
        {
            InitializeComponent();
            CargarDatosMaqueta();
        }

        // Método para cargar datos de ejemplo en los ComboBoxes (Modo Maqueta)
        private void CargarDatosMaqueta()
        {
            // Cargamos películas de ejemplo (Modo Maqueta)
            CBPelicula.Items.Clear();
            CBPelicula.Items.Add("Avengers: Endgame");
            CBPelicula.Items.Add("Intensamente 2");
            if (CBPelicula.Items.Count > 0) CBPelicula.SelectedIndex = 0;

            // Cargamos salas de ejemplo (Modo Maqueta)
            CBSala.Items.Clear();
            CBSala.Items.Add("1");
            CBSala.Items.Add("2");
            CBSala.Items.Add("3");
            if (CBSala.Items.Count > 0) CBSala.SelectedIndex = 0;
        }

        // Evento del botón "Insertar" para validar y cerrar el formulario con OK
        private void BInsertar_Click(object sender, EventArgs e)
        {
            if (CBPelicula.SelectedItem == null || CBSala.SelectedItem == null)
            {
                MessageBox.Show("Por favor, seleccione una película y una sala.", "Campos incompletos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Validamos que la fecha de la función no sea anterior a hoy
            if (FechaFuncion < DateTime.Now.Date)
            {
                MessageBox.Show("No se pueden programar funciones en fechas pasadas.", "Fecha inválida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            /*
             * =========================================================================
             * LÓGICA DE ALTA MÚLTIPLE POR RANGO (Desde - Hasta de la Película):
             * Cuando conectes a la BD, aquí harás un bucle tomando el 'desde' y 'hasta' 
             * de la película seleccionada:
             * 
             * DateTime fechaIteracion = fechaDesdePelicula;
             * while (fechaIteracion <= fechaHastaPelicula)
             * {
             *     DateTime inicioDia = fechaIteracion.Date.Add(DTPIpicio.Value.TimeOfDay);
             *     DateTime finDia = inicioDia.AddMinutes(DuracionPeliculaMinutos);
             *     
             *     // INSERT INTO funcion (inicio, fin, fecha, estado, id_pelicula, nro_sala) 
             *     // VALUES (inicioDia, finDia, fechaIteracion.Date, 'Activo', idPel, sala)
             *     
             *     fechaIteracion = fechaIteracion.AddDays(1);
             * }
             * =========================================================================
            */

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void BCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        // Método para cargar datos existentes al modificar una función
        public void CargarDatos(string pelicula, int sala, DateTime fecha, DateTime inicio)
        {
            CBPelicula.SelectedItem = pelicula;
            CBSala.SelectedItem = sala.ToString();
            DTPFecha.Value = fecha.Date;
            DTPInicio.Value = fecha.Date.Add(inicio.TimeOfDay);

            this.Text = "Modificar Función";
        }

        private void FormRegistroFuncion_Load(object sender, EventArgs e)
        {

        }
    }
}
