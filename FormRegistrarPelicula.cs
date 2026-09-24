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
    public partial class FormRegistrarPelicula : Form
    {
        // Propiedades públicas para exponer los datos al formulario principal
        public string Titulo => TTitulo.Text.Trim();
        public int Duracion => int.TryParse(TDuracion.Text.Trim(), out int dur) ? dur : 0;

        // Exponemos los valores de los DateTimePicker
        public DateTime Desde => DTPDesde.Value;
        public DateTime Hasta => DTPHasta.Value;

        public string Sinopsis => RTBSinopsis.Text.Trim();
        public string EtiquetaSeleccionada => CBEtiqueta.SelectedItem?.ToString() ?? "";

        public FormRegistrarPelicula()
        {
            InitializeComponent();
            CargarEtiquetasMaqueta();

            // Configuramos fechas iniciales por defecto lógicas
            DTPDesde.Value = DateTime.Now;
            DTPHasta.Value = DateTime.Now.AddDays(30);
        }

        // Método para cargar etiquetas de ejemplo en el ComboBox (Modo Maqueta)
        private void CargarEtiquetasMaqueta()
        {
            // Opciones de etiquetas de ejemplo (Modo Maqueta)
            // Cuando conectes a la BD, harás un SELECT id_etiqueta, descripcion FROM etiqueta
            CBEtiqueta.Items.Clear();
            CBEtiqueta.Items.Add("Acción");
            CBEtiqueta.Items.Add("Comedia");
            CBEtiqueta.Items.Add("Drama");
            CBEtiqueta.Items.Add("Terror");
            CBEtiqueta.Items.Add("Ciencia Ficción");
            CBEtiqueta.Items.Add("Animación");

            if (CBEtiqueta.Items.Count > 0)
                CBEtiqueta.SelectedIndex = 0;
        }

        // Validación para permitir solo números en el campo de duración
        private void TDuracion_TextChanged(object sender, EventArgs e)
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

        // Botón Insertar: Validación de campos y cierre del formulario con DialogResult
        // Botón Insertar: Validación de campos y cierre del formulario con DialogResult
        private void BInsertar_Click(object sender, EventArgs e)
        {
            // Validación de campos obligatorios
            if (string.IsNullOrWhiteSpace(TTitulo.Text) || string.IsNullOrWhiteSpace(TDuracion.Text) || string.IsNullOrWhiteSpace(RTBSinopsis.Text))
            {
                MessageBox.Show("Por favor, complete los campos obligatorios (Título, Duración y Sinopsis).", "Campos vacíos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Validación de duración mínima (mayor a 0)
            if (Duracion <= 0) 
            {
                MessageBox.Show("La duración en minutos debe ser mayor a 0.", "Valor inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                TDuracion.Focus();
                TDuracion.SelectAll();
                return;
            }

            // Validación de duración máxima (hasta 400 minutos)
            if (Duracion > 400)
            {
                MessageBox.Show("La duración no puede superar los 400 minutos.", "Valor inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                TDuracion.Focus();
                TDuracion.SelectAll();
                return;
            }

            // Validación: La fecha 'Desde' no puede ser menor a hoy
            if (DTPDesde.Value.Date < DateTime.Now.Date)
            {
                MessageBox.Show("La fecha 'Desde' no puede ser anterior a la fecha actual.", "Fechas inválidas", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Validación: La fecha 'Hasta' no puede ser menor a la fecha 'Desde'
            if (DTPHasta.Value < DTPDesde.Value)
            {
                MessageBox.Show("La fecha 'Hasta' no puede ser anterior a la fecha 'Desde'.", "Fechas inválidas", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        // Botón Cancelar: Cierra el formulario sin guardar cambios
        private void BCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        // Método para cargar datos al modificar una película existente
        public void CargarDatos(string titulo, int duracion, DateTime desde, DateTime hasta, string sinopsis, string etiqueta)
        {
            TTitulo.Text = titulo;
            TDuracion.Text = duracion.ToString();
            DTPDesde.Value = desde;
            DTPHasta.Value = hasta;
            RTBSinopsis.Text = sinopsis;
            CBEtiqueta.SelectedItem = etiqueta;

            this.Text = "Modificar Película";
        }

        private void FormRegistrarPelicula_Load(object sender, EventArgs e)
        {

        }
    }
}
