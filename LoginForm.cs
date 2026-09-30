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
            if (!ClassValidacionesHelper.ValidarCampoVacio(TCorreo, "correo")) return;
            if (!ClassValidacionesHelper.ValidarCampoVacio(TContraseña, "contraseña")) return;
            // Validar formato de correo electrónico
            if (!ClassValidacionesHelper.ValidarEmail(TCorreo)) return;

            string nombreUsuario = "";
            string rolUsuario = "";
            bool loginExitoso = false;

            // Instanciamos la clase de conexión con la base de datos
            ConexionBD conexionBD = new ConexionBD();

            try
            {
                using (SqlConnection conexion = conexionBD.ObtenerConexión())
                {
                    // Usamos el procedimiento almacenado que creamos en SQL
                    using (SqlCommand comando = new SqlCommand("SP_LoginUsuario", conexion))
                    {
                        // Indicamos que es un Stored Procedure
                        comando.CommandType = CommandType.StoredProcedure;

                        // Pasamos los parámetros
                        comando.Parameters.AddWithValue("@Correo", TCorreo.Text.Trim());
                        comando.Parameters.AddWithValue("@Contrasena", TContraseña.Text.Trim());

                        using (SqlDataReader lector = comando.ExecuteReader())
                        {
                            if (lector.Read())
                            {
                                // Si encuentra al usuario, extraemos sus datos
                                nombreUsuario = lector["nombre"].ToString();
                                rolUsuario = lector["id_tipo_usuario"].ToString();
                                loginExitoso = true;
                            }
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
            if (loginExitoso)
            {

                // Instanciamos el menú principal pasándole el rol obtenido de la BD
                FormMenuPrincipal formPrincipal = new FormMenuPrincipal(rolUsuario);
                formPrincipal.Show();

                // Ocultar el formulario de Login
                this.Hide();

                MessageBox.Show(
                    $"¡Bienvenido, {nombreUsuario}!",
                    "Acceso Exitoso",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );
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
