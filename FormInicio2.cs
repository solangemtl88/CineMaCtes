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
    public partial class FormInicio2 : Form
    {
        public FormInicio2()
        {
            InitializeComponent();
            // Asociamos el evento Load al iniciar
            this.Load += FormInicio2_Load;
        }

        private void FormInicio2_Load(object sender, EventArgs e)
        {
            // Cargamos la fecha actual en la esquina superior derecha de forma dinámica
            LFecha.Text = DateTime.Now.ToString("dddd, dd 'de' MMMM 'de' yyyy");

            // Configuración inicial de la grilla de próximas funciones
            ClassEstilosHelper.AplicarEstiloTabla(DGVRecaudacionPelis);

            // Cargamos registros ficticios de prueba (Modo Maqueta)
            CargarDatosMaqueta();
        }

        private void CargarDatosMaqueta()
        {
            // Creamos un DataTable temporal para simular los registros de la base de datos
            DataTable dtMaqueta = new DataTable();

            // Definimos las columnas
            dtMaqueta.Columns.Add("Pelicula", typeof(string));
            dtMaqueta.Columns.Add("Ventas", typeof(int));
            dtMaqueta.Columns.Add("Recaudacion", typeof(decimal));

            // Agregamos filas de prueba (maqueta) acorde a la temática de cine
            dtMaqueta.Rows.Add("Intensamente 2", 1250, 4500000m);
            dtMaqueta.Rows.Add("Deadpool y Wolverine", 980, 3500000m);
            dtMaqueta.Rows.Add("Duna: Parte 2", 750, 2700000m);
            dtMaqueta.Rows.Add("Kung Fu Panda 4", 520, 1800000m);

            // Asignamos el DataTable como origen de datos del DataGridView
            DGVRecaudacionPelis.DataSource = dtMaqueta;

            // Damos un poco de formato a la columna de recaudación para que se vea como moneda
            DGVRecaudacionPelis.Columns["Recaudacion"].DefaultCellStyle.Format = "C2";
        }

        private void BCambiarButaca_Click(object sender, EventArgs e)
        {
            // Abrimos el formulario de manera modal
            using (FormModificarButaca formModificacion = new FormModificarButaca())
            {
                DialogResult resultado = formModificacion.ShowDialog();

                // Verificamos si el usuario completó la acción exitosamente
                if (resultado == DialogResult.OK)
                {
                    MessageBox.Show(
                        "La gestión de la butaca se completó correctamente en el sistema.",
                        "Aviso del Sistema",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information
                    );
                }
            }
        } 
    }
}
