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
    public partial class FormInicio3 : Form
    {
        public FormInicio3()
        {
            InitializeComponent();
        }

        private void lblCartelera_Load(object sender, EventArgs e)
        {
            // Cargamos la fecha actual en la esquina superior derecha de forma dinámica
            LFecha.Text = DateTime.Now.ToString("dddd, dd 'de' MMMM 'de' yyyy");

            // Llamamos a los métodos al iniciar la pantalla
            ClassEstilosHelper.AplicarEstiloTabla(dgvFunciones);
            CargarDatosPrueba();
        }

        private void CargarDatosPrueba()
        {
            // Si ya agregaste las columnas desde el diseñador, sólo carga las filas:
            dgvFunciones.Rows.Clear();
            dgvFunciones.Rows.Add("Intensamente 2", "Sala 2", "18:30 hs", "12 butacas libres");
            dgvFunciones.Rows.Add("Avengers", "Sala 1", "19:00 hs", "5 butacas libres");
            dgvFunciones.Rows.Add("Dune: Parte Dos", "Sala 3", "20:15 hs", "34 butacas libres");
        }
    }
}

