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
            EstilizarTablaFunciones();
            CargarDatosPrueba();
        }
        private void EstilizarTablaFunciones()
        {
            // Opciones de comportamiento
            dgvFunciones.AllowUserToAddRows = false;
            dgvFunciones.AllowUserToDeleteRows = false;
            dgvFunciones.ReadOnly = true;
            dgvFunciones.RowHeadersVisible = false;
            dgvFunciones.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvFunciones.MultiSelect = false;
            dgvFunciones.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvFunciones.BorderStyle = BorderStyle.None;
            dgvFunciones.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvFunciones.GridColor = Color.FromArgb(38, 42, 60);

            // Estilo de encabezados
            dgvFunciones.EnableHeadersVisualStyles = false;
            dgvFunciones.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dgvFunciones.ColumnHeadersHeight = 38;
            dgvFunciones.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(20, 24, 40);
            dgvFunciones.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvFunciones.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10.5F, FontStyle.Bold);
            dgvFunciones.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

            // Estilo de las filas
            dgvFunciones.BackgroundColor = Color.FromArgb(18, 20, 32);
            dgvFunciones.DefaultCellStyle.BackColor = Color.FromArgb(18, 20, 32);
            dgvFunciones.DefaultCellStyle.ForeColor = Color.FromArgb(210, 215, 230);
            dgvFunciones.DefaultCellStyle.Font = new Font("Segoe UI", 10F, FontStyle.Regular);
            dgvFunciones.DefaultCellStyle.SelectionBackColor = Color.FromArgb(48, 38, 75);
            dgvFunciones.DefaultCellStyle.SelectionForeColor = Color.White;
            dgvFunciones.RowTemplate.Height = 36;
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

