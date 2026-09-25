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
    public partial class FormModificarPrecio : Form
    {
        public FormModificarPrecio()
        {
            InitializeComponent();
        }

        private void BConfirmar_Click(object sender, EventArgs e)
        {

            // Validamos que no esté vacío y que sea un número válido
            if (!ClassValidacionesHelper.ValidarCampoVacio(TPrecio, "DNI")) return;

            // Validamos que el precio sea un número decimal válido y mayor a cero
            if (decimal.TryParse(TPrecio.Text.Trim(), out decimal nuevoPrecio))
            {
                if (nuevoPrecio <= 0)
                {
                    MessageBox.Show("El precio debe ser mayor a cero.", "Valor inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Confirmación de la modificación
                DialogResult resultado = MessageBox.Show(
                    $"¿Confirma actualizar el precio del boleto a ${nuevoPrecio}?",
                    "Confirmar Modificación",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (resultado == DialogResult.Yes)
                {
                    // Aquí agregarías la lógica para guardar en la base de datos (ej: UPDATE Tarifas SET Precio = ...)

                    MessageBox.Show("Precio actualizado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Cerramos el formulario devolviendo un resultado OK
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
            else
            {
                MessageBox.Show("Por favor, ingrese un valor numérico válido.", "Error de formato", MessageBoxButtons.OK, MessageBoxIcon.Error);
                TPrecio.Focus();
                TPrecio.SelectAll();
            }
        }

        private void BCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void TPrecio_TextChanged(object sender, EventArgs e)
        {
            // Guardamos la posición actual del cursor para que no salte al final al limpiar
            int seleccionInicio = TPrecio.SelectionStart;

            // Filtramos el texto actual para conservar únicamente los dígitos numéricos
            string textoFiltrado = new string(TPrecio.Text.Where(char.IsDigit).ToArray());

            // Si el texto contenía letras o espacios, actualizamos el TextBox sin ellos
            if (TPrecio.Text != textoFiltrado)
            {
                TPrecio.Text = textoFiltrado;

                // Restauramos la posición del cursor de manera segura
                TPrecio.SelectionStart = Math.Min(seleccionInicio, TPrecio.Text.Length);
            }
        }

        private void FormModificarPrecio_Load(object sender, EventArgs e)
        {

        }
    }
}
