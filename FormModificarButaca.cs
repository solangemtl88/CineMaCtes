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
    public partial class FormModificarButaca : Form
    {
        public FormModificarButaca()
        {
            InitializeComponent();
        }

        private void BCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void BConfirmar_Click(object sender, EventArgs e)
        {
            // Validar que se haya seleccionado una  sala en el ComboBox
            if (!ClassValidacionesHelper.ValidarComboBox(CBSala, "una sala")) return;

            // Validar que el TextBox de la butaca no esté vacío
            if (!ClassValidacionesHelper.ValidarCampoVacio(TButaca, "DNI")) return;

            // Capturamos los datos ingresados en el formulario
            string salaSeleccionada = CBSala.SelectedItem.ToString();
            string idButaca = TButaca.Text.Trim().ToUpper(); // Lo pasamos a mayúsculas por prolijidad (ej: a1 -> A1)

            // Simulación de la obtención del estado actual desde la base de datos
            string estadoActualSimulado = "Ocupada"; // Simulamos que actualmente está ocupada o disponible

            // Mostrar el mensaje de confirmación dinámico
            DialogResult confirmacion = MessageBox.Show(
                $"¿Está seguro que desea cambiar el estado de la butaca '{idButaca}' (Sala: {salaSeleccionada})? \nEstado actual detectado: {estadoActualSimulado}.",
                "Confirmar Cambio de Estado",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question,
                MessageBoxDefaultButton.Button2
            );

            // Si el supervisor confirma con "Sí"
            if (confirmacion == DialogResult.Yes)
            {
                // Aquí es donde posteriormente harás el UPDATE en la base de datos:
                // UPDATE butaca SET estado = 'Inactiva' WHERE numero = @idButaca AND id_sala = @sala...

                MessageBox.Show(
                    $"El estado de la butaca '{idButaca}' ha sido modificado exitosamente.",
                    "Operación Exitosa",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );

                // Limpiamos los campos
                TButaca.Clear();
                CBSala.SelectedIndex = -1;
                TButaca.Focus();
            }
        }

        private void FormModificarButaca_Load(object sender, EventArgs e)
        {

        }
    }
}
