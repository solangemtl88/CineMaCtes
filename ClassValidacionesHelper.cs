using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace CinemaCtes
{
    public static class ClassValidacionesHelper
    {
        // Valida si un control está vacío armando el mensaje automáticamente
        public static bool ValidarCampoVacio(Control control, string nombreCampo)
        {
            if (string.IsNullOrWhiteSpace(control.Text))
            {
                MessageBox.Show(
                    $"Debe ingresar {nombreCampo}.",
                    "Atención",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                control.Focus();
                return false;
            }
            return true;
        }

        // Valida el formato específico de un correo electrónico
        public static bool ValidarEmail(TextBox txtEmail)
        {
            string patronEmail = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";

            if (!Regex.IsMatch(txtEmail.Text.Trim(), patronEmail))
            {
                MessageBox.Show(
                    "Por favor, ingrese un correo electrónico válido (ejemplo: usuario@dominio.com).",
                    "Formato Inválido",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
                txtEmail.Focus();
                txtEmail.SelectAll();
                return false;
            }
            return true;
        }

        public static bool ValidarPrimerCaracterMayuscula(TextBox txtContraseña)
        {
            if (string.IsNullOrEmpty(txtContraseña.Text)) return false;

            char primerChar = txtContraseña.Text[0];

            // Si es una letra Y NO es mayúscula -> Error. Si es número/símbolo, no entra.
            if (char.IsLetter(primerChar) && !char.IsUpper(primerChar))
            {
                MessageBox.Show(
                    "Si la contraseña comienza con una letra, esta debe estar en mayúscula.",
                    "Contraseña inválida",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                txtContraseña.Focus();
                txtContraseña.SelectAll();
                return false;
            }
            return true;
        }

        // Valida un ComboBox de forma individual con un mensaje específico
        public static bool ValidarComboBox(ComboBox cb, string nombreCampo)
        {
            if (cb.SelectedItem == null)
            {
                MessageBox.Show(
                    $"Debe seleccionar {nombreCampo}.",
                    "Atención",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                cb.Focus();
                return false;
            }
            return true;
        }
    }
}
