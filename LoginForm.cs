using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace CinemaCtes
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
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

            // Validar formato de correo electrónico
            string patronEmail = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";

            if (!Regex.IsMatch(TCorreo.Text, patronEmail))
            {
                MessageBox.Show("Por favor, ingrese un correo electrónico válido (ejemplo: usuario@dominio.com).", "Formato Inválido", MessageBoxButtons.OK, MessageBoxIcon.Error);
                TCorreo.Focus();
                TCorreo.SelectAll();
                return;
            }

            string rolUsuario = "";

            // Instanciamos la clase de conexión con la base de datos
            ConexionBD conexionBD = new ConexionBD();

            try
            {
                using (SqlConnection conexion = conexionBD.ObtenerConexión())
                {
                    string query = @"SELECT t.id_tipo_usuario 
                                     FROM usuario u 
                                     INNER JOIN tipo_usuario t ON u.id_tipo_usuario = t.id_tipo_usuario 
                                     WHERE u.correo = @Correo AND u.contraseña = @Contrasena";

                    using (SqlCommand comando = new SqlCommand(query, conexion))
                    {
                        comando.Parameters.AddWithValue("@Correo", TCorreo.Text.Trim());
                        comando.Parameters.AddWithValue("@Contrasena", TContraseña.Text.Trim());

                        object resultado = comando.ExecuteScalar();

                        if (resultado != null)
                        {
                            rolUsuario = resultado.ToString(); // Ejemplo: "Supervisor" - "Vendedor" - "Administrador"
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al conectar con la base de datos: " + ex.Message, "Error de Conexión", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Validamos si la autenticación fue exitosa
            if (!string.IsNullOrEmpty(rolUsuario))
            {
                // Instanciamos el menú principal pasándole el rol obtenido de la BD
                FormMenuPrincipal formPrincipal = new FormMenuPrincipal(rolUsuario);
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
