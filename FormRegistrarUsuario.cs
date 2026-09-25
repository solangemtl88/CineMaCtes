using CinemaCtes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CinemaCtes
{
    public partial class FormRegistrarUsuario : Form
    {
        // Propiedades públicas para exponer los datos del usuario al formulario principal
        public string Nombre => TNombre.Text.Trim();
        public string Apellido => TApellido.Text.Trim();
        public string Dni => TDni.Text.Trim();
        public string Correo => TCorreo.Text.Trim();
        public string Contrasena => TContraseña.Text;
        public string TipoUsuario => CBTipo.SelectedItem?.ToString() ?? "";

        public FormRegistrarUsuario()
        {
            InitializeComponent();

            CargarTiposUsuario();
        }

        private void FormRegistrarUsuario_Load(object sender, EventArgs e)
        {
        }

        // Método para cargar los tipos de usuario desde la base de datos y llenar el ComboBox
        private void CargarTiposUsuario()
        {
            ConexionBD conexionBD = new ConexionBD();
            try
            {
                using (SqlConnection conexion = conexionBD.ObtenerConexión())
                {
                    string query = "SELECT id_tipo_usuario, descripcion FROM tipo_usuario";
                    using (SqlCommand comando = new SqlCommand(query, conexion))
                    {
                        using (SqlDataReader lector = comando.ExecuteReader())
                        {
                            DataTable dt = new DataTable();
                            dt.Load(lector);

                            // Vinculamos el ComboBox a la tabla obtenida
                            CBTipo.DataSource = dt;
                            CBTipo.DisplayMember = "descripcion"; // Lo que ve el usuario
                            CBTipo.ValueMember = "id_tipo_usuario";     // El ID real que guardaremos en la BD
                            CBTipo.SelectedIndex = -1; // Para que comience sin selección obligatoria
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los tipos de usuario: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Propiedad pública que devuelve el ID del tipo de usuario seleccionado
        public int IdTipoUsuario
        {
            get
            {
                if (CBTipo.SelectedValue != null && int.TryParse(CBTipo.SelectedValue.ToString(), out int id))
                {
                    return id;
                }
                return 0;
            }
        }

        // Evento para formatear el nombre y apellido al perder el foco, convirtiendo la primera letra de cada palabra en mayúscula
        private void FormatearNombreApellido_Leave(object sender, EventArgs e)
        {
            if (sender is TextBox txtBox && !string.IsNullOrWhiteSpace(txtBox.Text))
            {
                // Convierte la primera letra de cada palabra en mayúscula
                TextInfo textInfo = Thread.CurrentThread.CurrentCulture.TextInfo;
                txtBox.Text = textInfo.ToTitleCase(txtBox.Text.ToLower().Trim());
            }
        }

        // Evento para permitir solo dígitos numéricos mientras se escribe
        private void TDni_TextChanged(object sender, EventArgs e)
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

        // Evento para permitir solo letras y espacios mientras se escribe
        private void TTextoSoloLetras_TextChanged(object sender, EventArgs e)
        {
            if (sender is TextBox txtBox)
            {
                int cursorPos = txtBox.SelectionStart;
                string soloLetras = new string(txtBox.Text.Where(c => char.IsLetter(c) || char.IsWhiteSpace(c)).ToArray());

                if (txtBox.Text != soloLetras)
                {
                    txtBox.Text = soloLetras;
                    txtBox.SelectionStart = Math.Min(cursorPos, txtBox.Text.Length);
                }
            }
        }

        // Evento para eliminar espacios en blanco mientras se escribe
        private void LimpiarEspacios_TextChanged(object sender, EventArgs e)
        {
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

        // Evento para validar y guardar los datos del usuario
        private void BInsertar_Click(object sender, EventArgs e)
        {
            // Validar que ningún campo esté vacío
            if(!ClassValidacionesHelper.ValidarCampoVacio(TNombre, "nombre")) return;
            if(!ClassValidacionesHelper.ValidarCampoVacio(TApellido, "apellido")) return;
            if(!ClassValidacionesHelper.ValidarCampoVacio(TDni, "DNI")) return;
            if(!ClassValidacionesHelper.ValidarCampoVacio(TCorreo, "correo electrónico")) return;
            if(!ClassValidacionesHelper.ValidarCampoVacio(TContraseña, "contraseña")) return;
            if(!ClassValidacionesHelper.ValidarCampoVacio(TConf_contraseña, "confirmación de contraseña")) return;

            // Validar formato básico de correo electrónico
            if (!ClassValidacionesHelper.ValidarEmail(TCorreo)) return;

            // Validar longitud del DNI (permitiendo 7 u 8 dígitos válidos)
            if (TDni.Text.Length < 7 || TDni.Text.Length > 8)
            {
                MessageBox.Show("El DNI ingresado debe tener 7 u 8 dígitos.", "DNI inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                TDni.Focus();
                TDni.SelectAll();
                return;
            }

            if (TContraseña.Text.Length < 6)
            {
                MessageBox.Show("La contraseña debe tener al menos 6 caracteres.", "Contraseña inválida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                TContraseña.Focus();
                TContraseña.SelectAll();
                return;
            }

            // Validar que el primer carácter sea una letra mayúscula
            if (!ClassValidacionesHelper.ValidarPrimerCaracterMayuscula(TContraseña)) return;

            // Validar que contenga al menos un número
            if (!TContraseña.Text.Any(char.IsDigit))
            {
                MessageBox.Show("La contraseña debe contener al menos un número.", "Contraseña inválida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                TContraseña.Focus();
                TContraseña.SelectAll();
                return;
            }

            // Validar que las contraseñas coincidan
            if (TContraseña.Text != TConf_contraseña.Text)
            {
                MessageBox.Show("Las contraseñas no coinciden. Por favor, verifíquelas.", "Error de contraseña", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                TConf_contraseña.Focus();
                TConf_contraseña.SelectAll();
                return;
            }

            // Validar que se haya seleccionado un tipo de usuario
            if (!ClassValidacionesHelper.ValidarComboBox(CBTipo, "un tipo de usuario")) return;

            // Establecemos DialogResult en OK y cerramos
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        // Evento para cerrar el formulario sin guardar cambios
        private void BCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        // Método para cargar datos en los campos del formulario, útil para modificar un usuario existente
        public void CargarDatos(string nombre, string apellido, string dni, string correo, int idTipoUsuario)
        {
            TNombre.Text = nombre;
            TApellido.Text = apellido;
            TDni.Text = dni;
            TCorreo.Text = correo;
            CBTipo.SelectedValue = idTipoUsuario; // Ahora funcionará perfectamente

            this.Text = "Modificar Usuario"; // Cambia el título de la ventana 
        }
    }
}
