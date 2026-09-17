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
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void BIngresar_Click(object sender, EventArgs e)
        {
            // Validar campos vacíos
            if (string.IsNullOrWhiteSpace(TCorreo.Text) || string.IsNullOrWhiteSpace(TContraseña.Text))
            {
                MessageBox.Show(
                    "Debe ingresar el correo y la contraseña.",
                    "Atención",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return;
            }

            // Validar credenciales (Usuario y Contraseña)
            if (TCorreo.Text == "admin" && TContraseña.Text == "1234")
            {
                MessageBox.Show(
                    "¡Bienvenido al Sistema de Gestión de Cine!",
                    "Acceso Correcto",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );

                // Instanciar y mostrar el formulario principal de clientes/boletería
                Form1 formPrincipal = new Form1();
                formPrincipal.Show();

                // Ocultar el formulario de Login
                this.Hide();
            }
            else
            {
                MessageBox.Show(
                    "Usuario o contraseña incorrectos.",
                    "Error de Autenticación",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );

                TContraseña.Clear();
                TContraseña.Focus();
            }
        }

        private void BSalir_Click(object sender, EventArgs e)
        {
            // Confirmación antes de salir
            DialogResult ask = MessageBox.Show(
                "¿Está seguro que desea salir del sistema?",
                "Confirmar Salida",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question,
                MessageBoxDefaultButton.Button2
            );

            if (ask == DialogResult.Yes)
            {
                Application.Exit();
            }
        }  
    }
}
