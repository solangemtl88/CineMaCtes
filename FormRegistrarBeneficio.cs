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
    public partial class FormRegistrarBeneficio : Form
    {

        // Propiedades públicas para exponer los datos ingresados
        public string Descripcion => TDescripcion.Text;
        public string Descuento => TDescuento.Text;
        public string TipoBeneficio => CBTipo.Text;

        public FormRegistrarBeneficio()
        {
            InitializeComponent();
        }

        private void FormRegistrarBeneficio_Load(object sender, EventArgs e)
        {  
        }

        private void BInsertar_Click(object sender, EventArgs e)
        {
            // Validar que la descripción no esté vacía
            if (string.IsNullOrWhiteSpace(TDescripcion.Text))
            {
                MessageBox.Show("Debe ingresar una descripción para el beneficio.", "Campo requerido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                TDescripcion.Focus();
                return;
            }

            // Validar que el descuento tenga contenido (por ejemplo, "10%" o "2x1")
            if (string.IsNullOrWhiteSpace(TDescuento.Text))
            {
                MessageBox.Show("Debe ingresar el valor del descuento o promoción.", "Campo requerido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                TDescuento.Focus();
                return;
            }

            // Validar seleccion para el tipo de descuento
            if (CBTipo.SelectedIndex == -1 || string.IsNullOrWhiteSpace(CBTipo.Text))
            {
                MessageBox.Show("Debe seleccionar un tipo de descuento válido.", "Selección requerida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                CBTipo.Focus();
                return;
            }

            // Validar longitud mínima para la descripción
            if (TDescripcion.Text.Trim().Length < 5)
            {
                MessageBox.Show(
                    "La descripción debe tener al menos 5 caracteres.",
                    "Longitud de descripción inválida",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                TDescripcion.Focus();
                TDescripcion.SelectAll();
                return;
            }

            // asignamos el resultado OK y cerramos.
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        //Metodo para filtrar espacios en los textbox de descuento y descripcion
        private void LimpiarEspacios_TextChanged(object sender, EventArgs e)
        {
            // Convertimos el 'sender' al tipo TextBox para saber cuál control lo llamó
            if (sender is TextBox txtBox)
            {
                int cursorPos = txtBox.SelectionStart;
                string textoSinEspacios = txtBox.Text.Replace(" ", "");

                if (txtBox.Text != textoSinEspacios)
                {
                    txtBox.Text = textoSinEspacios;
                    txtBox.SelectionStart = Math.Max(0, cursorPos - 1);
                }
            }
        }

        private void BCancelar_Click(object sender, EventArgs e)
        {
            // Indicamos que el resultado de la ventana es Cancelar
            this.DialogResult = DialogResult.Cancel;

            // Cerramos el formulario de registro
            this.Close();
        }

        public void CargarDatos(string descripcion, string tipo, string descuento)
        {
            // Asignamos los valores recibidos a los controles de tu formulario de registro
            // (Asegurate de cambiar los nombres si tus TextBox o ComboBox se llaman distinto)
            TDescripcion.Text = descripcion;
            CBTipo.Text = tipo;
            TDescuento.Text = descuento;

            this.Text = "Modificar Beneficio";
        }
    }
}
