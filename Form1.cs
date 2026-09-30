using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CinemaCtes
{
    public partial class FormMenuPrincipal : Form
    {
        private string rolUsuario; // Variable para almacenar el rol recibido

        private Form formularioActivo = null;

        public FormMenuPrincipal(string rol)
        {
            InitializeComponent();
            rolUsuario = rol;
        }

        private void FormMenuPrincipal_Load(object sender, EventArgs e)
        {
            if (rolUsuario == "1") // Administrador
            {
                AbrirFormularioHijo(new FormInicio());

            } else if (rolUsuario == "2") // Supervisor
            {
                AbrirFormularioHijo(new FormInicio2());

            }
            else // Vendedor
            {
                AbrirFormularioHijo(new FormInicio3());
            }
            ConfigurarPermisosMenu();
        }


            private void ConfigurarPermisosMenu()
        {
            // Por defecto, asumimos que todos los botones están visibles (True) desde el diseñador.
            // Aquí solo declaramos explícitamente qué se OCULTA (False) según el rol que inició sesión.

            if (rolUsuario == "3") // Vendedor (Solo ve 2 botones)
            {
                // Ocultamos todos los botones excepto los que el vendedor debe ver
                BInicio2.Visible = false;
                BClientes.Visible = false;
                BVentas.Visible = false;
                BInicio.Visible = false;
                BUsuarios.Visible = false;
                BFunciones.Visible = false;
                BBeneficios.Visible = false;
                BSala.Visible = false;
                BPeliculas.Visible = false;
            }
            else if (rolUsuario == "2") // Supervisor (Ve 3 botones)
            {
                BInicio.Visible = false;
                BUsuarios.Visible = false;
                BFunciones.Visible = false;
                BBeneficios.Visible = false;
                BSala.Visible = false;
                BPeliculas.Visible = false;
                BInicio3.Visible = false;
                BRegistrarVenta.Visible = false;
            }
            else if (rolUsuario == "1") // Administrador (6 botones)
            {
                BClientes.Visible = false;
                BVentas.Visible = false;
                BInicio2.Visible = false;
                BInicio3.Visible = false;
                BRegistrarVenta.Visible = false;
            }
        }

        private void AbrirFormularioHijo(Form formHijo)
        {
            // Si ya hay un formulario abierto, lo cerramos
            if (formularioActivo != null)
            {
                formularioActivo.Close();
            }

            formularioActivo = formHijo;

            // Configuración para incrustar el Formulario dentro del Panel
            formHijo.TopLevel = false;
            formHijo.FormBorderStyle = FormBorderStyle.None;
            formHijo.Dock = DockStyle.Fill;

            // Agregamos el formulario a la lista de controles del panel y lo mostramos
            PContenido.Controls.Add(formHijo);
            PContenido.Tag = formHijo;
            formHijo.BringToFront();
            formHijo.Show();
        }

        private void FormMenuPrincipal_FormClosed(object sender, FormClosedEventArgs e)
        {
            // Asegura que al cerrar la ventana principal se finalice toda la aplicación
            Application.Exit();
        }


        //Botones del menu lateral para el administrador
        private void BUsuarios_Click(object sender, EventArgs e)
        {
            AbrirFormularioHijo(new FormUsuarios());
        }
        private void BFunciones_Click(object sender, EventArgs e)
        {
            AbrirFormularioHijo(new FormFunciones());
        }
        private void BBeneficios_Click(object sender, EventArgs e)
        {
            AbrirFormularioHijo(new FormBeneficios());
        }
        private void BSala_Click(object sender, EventArgs e)
        {
            AbrirFormularioHijo(new FormSalas());
        }
        private void BPeliculas_Click(object sender, EventArgs e)
        {
            AbrirFormularioHijo(new FormPeliculas());
        }
        private void BInicio_Click(object sender, EventArgs e)
        {
            AbrirFormularioHijo(new FormInicio());
        }


        //Botones del menu lateral para el supervisor
        private void BInicio2_Click(object sender, EventArgs e)
        {
            AbrirFormularioHijo(new FormInicio2());
        }
        private void BVentas_Click(object sender, EventArgs e)
        {
            AbrirFormularioHijo(new FormVentas());
        }
        private void BClientes_Click(object sender, EventArgs e)
        {
            AbrirFormularioHijo(new FormClientes());
        }


        //Botones del menu lateral para el vendedor
        private void BInicio3_Click(object sender, EventArgs e)
        {
            AbrirFormularioHijo(new FormInicio3());
        }
        private void BRegistrarVenta_Click(object sender, EventArgs e)
        {
            AbrirFormularioHijo(new FormRegistrarVenta());
        }

        private Button botonActivo = null;

        private void ActivarBoton(Button btn)
        {
            if (btn == null) return;

            // Desactivar el botón anterior
            if (botonActivo != null)
            {
                botonActivo.BackColor = Color.Transparent;
                botonActivo.ForeColor = Color.FromArgb(200, 200, 200);
            }

            // Activar el botón presionado
            botonActivo = btn;
            botonActivo.BackColor = Color.FromArgb(42, 22, 59); // Morado oscuro de selección
            botonActivo.ForeColor = Color.White;
        }

       

        private void btnBoletos_Click(object sender, EventArgs e)
        {
            ActivarBoton((Button)sender);
            // AbrirFormularioHijo(new FormBoletos());
        }
        

        private void RedondearBoton(Button btn, PaintEventArgs e, int radio, Color colorFondo)
        {
            Graphics g = e.Graphics;
            // Activa el suavizado de bordes (Anti-aliasing)
            g.SmoothingMode = SmoothingMode.AntiAlias;

            Rectangle rect = new Rectangle(0, 0, btn.Width - 1, btn.Height - 1);

            using (GraphicsPath path = new GraphicsPath())
            {
                path.AddArc(rect.X, rect.Y, radio, radio, 180, 90);
                path.AddArc(rect.Width - radio, rect.Y, radio, radio, 270, 90);
                path.AddArc(rect.Width - radio, rect.Height - radio, radio, radio, 0, 90);
                path.AddArc(rect.X, rect.Height - radio, radio, radio, 90, 90);
                path.CloseAllFigures();

                // Rellena el fondo con esquinas suaves
                using (SolidBrush brush = new SolidBrush(colorFondo))
                {
                    g.FillPath(brush, path);
                }
            }
        }

        private void Button_Paint(object sender, PaintEventArgs e)
        {
            Button btn = (Button)sender;
            // Si el botón está seleccionado usá el morado, si no, el transparente/oscuro
            Color fondo = (btn == botonActivo) ? Color.FromArgb(42, 22, 59) : Color.Transparent;

            RedondearBoton(btn, e, 15, fondo);
        }

        private void BCerrar_sesion_Click(object sender, EventArgs e)
        {
            // Mostrar un mensaje de consulta para confirmar
            DialogResult ask = MessageBox.Show(
                "¿Está seguro que desea cerrar sesión?",
                "Cerrar Sesión",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question,
                MessageBoxDefaultButton.Button2 // Foco en "No" por seguridad
            );

            // Si el usuario confirma que "Sí"
            if (ask == DialogResult.Yes)
            {
                // Instanciar y mostrar el formulario de Login
                LoginForm login = new LoginForm();
                login.Show();

                // Cerrar el formulario principal actual
                this.Close();
            }
        }
    }
}
