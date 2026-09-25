using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace CinemaCtes
{
    public partial class FormSalas : Form
    {
        public FormSalas()
        {
            InitializeComponent();
        }

        private void FormSalas_Load(object sender, EventArgs e)
        {
            // Aplicamos estilos a la grilla de salas
            ClassEstilosHelper.AplicarEstiloTabla(DGVSalas);

            // Crear las columnas de botones solo si no existen ya
            ClassEstilosHelper.AgregarBotonesAccion(DGVSalas);

            CargarTablaSalas();
        }

        private void CargarTablaSalas()
        {
            DGVSalas.Rows.Clear();

            // MAQUETADO:

            // Fila de ejemplo para ver cómo queda visualmente:
            int n1 = DGVSalas.Rows.Add();
            DGVSalas.Rows[n1].Cells[0].Value = 1;         // Nro sala
            DGVSalas.Rows[n1].Cells[1].Value = 120;       // Capacidad
            DGVSalas.Rows[n1].Cells[2].Value = "Activo";  // Estado  

            int n2 = DGVSalas.Rows.Add();
            DGVSalas.Rows[n2].Cells[0].Value = 2;
            DGVSalas.Rows[n2].Cells[1].Value = 150;
            DGVSalas.Rows[n2].Cells[2].Value = "Activo";

            /* --- CÓDIGO REAL PARA CUANDO CONECTE A LA BASE DE DATOS ---
            ConexionBD conexionBD = new ConexionBD();
            try
            {
                using (SqlConnection conexion = conexionBD.ObtenerConexión())
                {
                    string query = "SELECT nro_sala, capacidad, estado FROM sala";

                    using (SqlCommand comando = new SqlCommand(query, conexion))
                    {
                        using (SqlDataReader lector = comando.ExecuteReader())
                        {
                            while (lector.Read())
                            {
                                int n = DGVSalas.Rows.Add();
                                DGVSalas.Rows[n].Cells[0].Value = lector["nro_sala"];
                                DGVSalas.Rows[n].Cells[1].Value = lector["capacidad"];
                                DGVSalas.Rows[n].Cells[2].Value = lector["estado"];
                                DGVSalas.Rows[n].Cells[3].Value = lector["nro_sala"]; // Columna oculta ID
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar las salas: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            ----------------------------------------------------------- */
        }

        private void DGVSalas_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && !DGVSalas.Rows[e.RowIndex].IsNewRow)
            {
                string nombreColumna = DGVSalas.Columns[e.ColumnIndex].Name;

                // LEEMOS EL NÚMERO DE SALA DIRECTAMENTE DE LA CELDA 0 (Visible)
                int nroSala = Convert.ToInt32(DGVSalas.Rows[e.RowIndex].Cells[0].Value);
                int capacidadActual = Convert.ToInt32(DGVSalas.Rows[e.RowIndex].Cells[1].Value);
                string estadoActual = DGVSalas.Rows[e.RowIndex].Cells[2].Value?.ToString() ?? "Activo";

                if (nombreColumna == "CModificar")
                {
                    using (FormRegistrarSala formModificar = new FormRegistrarSala())
                    {
                        formModificar.CargarDatos(nroSala, capacidadActual);
                        DialogResult resultado = formModificar.ShowDialog();

                        if (resultado == DialogResult.OK)
                        {
                            int nuevaCapacidad = formModificar.Capacidad;

                            // Actualizamos la celda de capacidad visualmente en la maqueta
                            DGVSalas.Rows[e.RowIndex].Cells[1].Value = nuevaCapacidad;

                            /* 
                             * CUANDO CONECTES A LA BASE DE DATOS MÁS ADELANTE:
                             * string query = "UPDATE sala SET capacidad = @Capacidad WHERE nro_sala = @NroSala";
                             */

                            MessageBox.Show("Sala modificada correctamente.", "Modificado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
                else if (nombreColumna == "CEliminar") // O botón de cambiar estado
                {
                    string nuevoEstado = (estadoActual == "Activo") ? "Inactivo" : "Activo";

                    // Actualizamos el estado visualmente en la maqueta
                    DGVSalas.Rows[e.RowIndex].Cells[2].Value = nuevoEstado;

                    /* 
                     * CUANDO CONECTES A LA BASE DE DATOS MÁS ADELANTE:
                     * string query = "UPDATE sala SET estado = @Estado WHERE nro_sala = @NroSala";
                     */

                    MessageBox.Show($"La sala {nroSala} ha sido cambiada a estado '{nuevoEstado}'.", "Estado Actualizado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void BAñadir_Click(object sender, EventArgs e)
        {
            // Abrimos el formulario de registro de sala
            using (FormRegistrarSala formRegistrar = new FormRegistrarSala())
            {
                DialogResult resultado = formRegistrar.ShowDialog();

                if (resultado == DialogResult.OK)
                {
                    // Capturamos los datos que vienen del formulario hijo
                    int nroSala = formRegistrar.NroSala;
                    int capacidad = formRegistrar.Capacidad;

                    // AGREGAMOS LA NUEVA SALA DIRECTAMENTE A LA GRILLA (Modo Maqueta)
                    int n = DGVSalas.Rows.Add();
                    DGVSalas.Rows[n].Cells[0].Value = nroSala;
                    DGVSalas.Rows[n].Cells[1].Value = capacidad;
                    DGVSalas.Rows[n].Cells[2].Value = "Activo"; // Estado por defecto

                    MessageBox.Show($"Sala {nroSala} agregada correctamente (Capacidad: {capacidad}).", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }


    }
}