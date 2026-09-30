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

            // Crear las columnas de acción
            ClassEstilosHelper.AgregarBotonesAccion(DGVSalas);

            CargarTablaSalas();
        }

        private void CargarTablaSalas()
        {
            DGVSalas.Rows.Clear();

            ConexionBD conexionBD = new ConexionBD();
            try
            {
                using (SqlConnection conexion = conexionBD.ObtenerConexión())
                {
                    using (SqlCommand comando = new SqlCommand("SP_ListarSalas", conexion))
                    {
                        comando.CommandType = CommandType.StoredProcedure;

                        using (SqlDataReader lector = comando.ExecuteReader())
                        {
                            while (lector.Read())
                            {
                                int n = DGVSalas.Rows.Add();
                                DGVSalas.Rows[n].Cells[0].Value = lector["nro_sala"];
                                DGVSalas.Rows[n].Cells[1].Value = lector["capacidad"];
                                DGVSalas.Rows[n].Cells[2].Value = lector["estado"];
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar las salas: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DGVSalas_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && !DGVSalas.Rows[e.RowIndex].IsNewRow)
            {
                string nombreColumna = DGVSalas.Columns[e.ColumnIndex].Name;

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

                            ConexionBD conexionBD = new ConexionBD();
                            try
                            {
                                using (SqlConnection conexion = conexionBD.ObtenerConexión())
                                {
                                    using (SqlCommand comando = new SqlCommand("SP_ActualizarSala", conexion))
                                    {
                                        comando.CommandType = CommandType.StoredProcedure;
                                        comando.Parameters.AddWithValue("@NroSala", nroSala);
                                        comando.Parameters.AddWithValue("@Capacidad", nuevaCapacidad);

                                        comando.ExecuteNonQuery();
                                    }
                                }

                                CargarTablaSalas(); // Refrescamos la grilla
                                MessageBox.Show("Sala modificada correctamente.", "Modificado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show("Error al actualizar la sala: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                }
                else if (nombreColumna == "CEliminar")
                {
                    string nuevoEstado = (estadoActual == "Activo") ? "Inactivo" : "Activo";

                    ConexionBD conexionBD = new ConexionBD();
                    try
                    {
                        using (SqlConnection conexion = conexionBD.ObtenerConexión())
                        {
                            using (SqlCommand comando = new SqlCommand("SP_CambiarEstadoSala", conexion))
                            {
                                comando.CommandType = CommandType.StoredProcedure;
                                comando.Parameters.AddWithValue("@NroSala", nroSala);
                                comando.Parameters.AddWithValue("@Estado", nuevoEstado);

                                comando.ExecuteNonQuery();
                            }
                        }

                        CargarTablaSalas(); // Refrescamos la grilla
                        MessageBox.Show($"La sala {nroSala} ha sido cambiada a estado '{nuevoEstado}'.", "Estado Actualizado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error al cambiar el estado: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void BAñadir_Click(object sender, EventArgs e)
        {
            using (FormRegistrarSala formRegistrar = new FormRegistrarSala())
            {
                DialogResult resultado = formRegistrar.ShowDialog();

                if (resultado == DialogResult.OK)
                {
                    int nroSala = formRegistrar.NroSala;
                    int capacidad = formRegistrar.Capacidad;

                    ConexionBD conexionBD = new ConexionBD();
                    try
                    {
                        using (SqlConnection conexion = conexionBD.ObtenerConexión())
                        {
                            using (SqlCommand comando = new SqlCommand("SP_InsertarSala", conexion))
                            {
                                comando.CommandType = CommandType.StoredProcedure;
                                comando.Parameters.AddWithValue("@NroSala", nroSala);
                                comando.Parameters.AddWithValue("@Capacidad", capacidad);

                                comando.ExecuteNonQuery();
                            }
                        }

                        CargarTablaSalas(); // Refrescamos la grilla
                        MessageBox.Show($"Sala {nroSala} agregada correctamente (Capacidad: {capacidad}).", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (SqlException ex)
                    {
                        MessageBox.Show(ex.Message, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error al registrar la sala: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
    }
}