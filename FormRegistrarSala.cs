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
    public partial class FormRegistrarSala : Form
    {
        // Propiedades públicas para exponer los datos
        public int NroSala => int.TryParse(TNroSala.Text.Trim(), out int nro) ? nro : 0;
        public int Capacidad => int.TryParse(TCapacidad.Text.Trim(), out int cap) ? cap : 0;

        public FormRegistrarSala()
        {
            InitializeComponent();
        }

        // Permitir solo números en el número de sala
        private void TNroSala_TextChanged(object sender, EventArgs e)
        {
            ValidarSoloNumeros(sender);
        }

        // Permitir solo números en la capacidad
        private void TCapacidad_TextChanged(object sender, EventArgs e)
        {
            ValidarSoloNumeros(sender);
        }

        private void ValidarSoloNumeros(object sender)
        {
            if (sender is TextBox txtBox)
            {
                int cursorPos = txtBox.SelectionStart; 
                string soloNumeros = new string(txtBox.Text.Where(char.IsDigit).ToArray());
                
                if (txtBox.Text != soloNumeros)
                { 
                    txtBox.Text = soloNumeros;
                    txtBox.SelectionStart = Math.Min(cursorPos, txtBox.Text.Length);
                }
            }
        }

        private void BInsertar_Click(object sender, EventArgs e)
        {

            // Validaciones de campos vacíos
            if (!ClassValidacionesHelper.ValidarCampoVacio(TNroSala, "Número de sala")) return;
            if (!ClassValidacionesHelper.ValidarCampoVacio(TCapacidad, "Capacidad")) return;

            // Validación de número de sala positivo
            if (NroSala <= 0)
            {
                MessageBox.Show("El número de sala debe ser mayor a 0.", "Valor inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                TNroSala.Focus();
                TNroSala.SelectAll();
                return;
            }

            // Validación de capacidad entre 100 y 200 (mayor a 99 y menor a 201)
            if (Capacidad <= 100 || Capacidad >= 200)
            {
                MessageBox.Show("La capacidad de la sala debe ser mayor a 99 y menor a 201 asientos.", "Capacidad fuera de rango", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                TCapacidad.Focus();
                TCapacidad.SelectAll();
                return;
            }

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void BCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        // Método para cargar datos al modificar una sala existente
        public void CargarDatos(int nroSala, int capacidad)
        {
            TNroSala.Text = nroSala.ToString();
            TNroSala.Enabled = false; // Como es la PK manual, no dejamos modificar el número al editar
            TCapacidad.Text = capacidad.ToString();
            this.Text = "Modificar Sala";
        }

        private void FormRegistrarSala_Load(object sender, EventArgs e)
        {

        }
    }
}
