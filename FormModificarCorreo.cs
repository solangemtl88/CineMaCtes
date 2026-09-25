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
    public partial class FormModificarCorreo : Form
    {
        public string NuevoCorreoIngresado { get; private set; }

        public FormModificarCorreo(string correoActual)
        {
            InitializeComponent();
            TCorreo.Text = correoActual; // Precargamos el correo actual para comodidad del supervisor
        }


        private void BConfirmar_Click(object sender, EventArgs e)
        {
            // Validar que ningún campo esté vacío
            if (!ClassValidacionesHelper.ValidarCampoVacio(TCorreo, "correo electrónico")) return;

            // Validar formato básico de correo electrónico
            if (!ClassValidacionesHelper.ValidarEmail(TCorreo)) return;

            NuevoCorreoIngresado = TCorreo.Text.Trim();
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void BCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void FormModificarCorreo_Load(object sender, EventArgs e)
        {

        }
    }
}