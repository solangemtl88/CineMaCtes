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
                    ConexionBD conexionBD = new ConexionBD();
                    int estadoDiagnostico = 0;

                    // Diagnóstico previo ANTES de abrir el formulario de modificación
                    try
                    {
                        using (SqlConnection conexion = conexionBD.ObtenerConexión())
                        {
                            using (SqlCommand comando = new SqlCommand("SP_VerificarEstadoSalaParaModificar", conexion))
                            {
                                comando.CommandType = CommandType.StoredProcedure;
                                comando.Parameters.AddWithValue("@NroSala", nroSala);

                                SqlParameter paramDiag = new SqlParameter("@EstadoDiagnostico", SqlDbType.Int);
                                paramDiag.Direction = ParameterDirection.Output;
                                comando.Parameters.Add(paramDiag);

                                comando.ExecuteNonQuery();
                                estadoDiagnostico = Convert.ToInt32(paramDiag.Value);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error al verificar el estado de la sala: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    // Evaluamos los resultados del diagnóstico previo:
                    if (estadoDiagnostico == 1)
                    {
                        // BLOQUEANTE: Hay una función transcurriendo AHORA
                        MessageBox.Show(
                            $"No se puede modificar la sala {nroSala} porque hay una función transcurriendo en este momento.",
                            "Acción Bloqueada",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error
                        );
                        return; // Sale y no abre nada
                    }
                    else if (estadoDiagnostico == 2)
                    {
                        // ADVERTENCIA CON ESPERA DE CONFIRMACIÓN: Tiene funciones activas futuras
                        DialogResult respuesta = MessageBox.Show(
                            $"La sala {nroSala} tiene funciones activas programadas.\n¿Está seguro de que desea continuar con la modificación?",
                            "Advertencia de Funciones Activas",
                            MessageBoxButtons.YesNo,
                            MessageBoxIcon.Warning
                        );

                        if (respuesta == DialogResult.No)
                        {
                            return; // El usuario canceló
                        }
                    }

                    // Si pasó los filtros previos, abrimos el formulario para modificar
                    using (FormRegistrarSala formModificar = new FormRegistrarSala())
                    {
                        formModificar.CargarDatos(nroSala, capacidadActual);
                        DialogResult resultadoForm = formModificar.ShowDialog();

                        if (resultadoForm == DialogResult.OK)
                        {
                            int nuevaCapacidad = formModificar.Capacidad;

                            // 3. Verificación final de Overbooking al intentar guardar
                            try
                            {
                                bool tieneOverbooking = false;

                                using (SqlConnection conexion = conexionBD.ObtenerConexión())
                                {
                                    using (SqlCommand comando = new SqlCommand("SP_ActualizarSalaConValidacionOverbooking", conexion))
                                    {
                                        comando.CommandType = CommandType.StoredProcedure;
                                        comando.Parameters.AddWithValue("@NroSala", nroSala);
                                        comando.Parameters.AddWithValue("@Capacidad", nuevaCapacidad);

                                        SqlParameter paramOverbooking = new SqlParameter("@TieneOverbooking", SqlDbType.Bit);
                                        paramOverbooking.Direction = ParameterDirection.Output;
                                        comando.Parameters.Add(paramOverbooking);

                                        comando.ExecuteNonQuery();
                                        tieneOverbooking = Convert.ToBoolean(paramOverbooking.Value);
                                    }
                                }

                                if (tieneOverbooking)
                                {
                                    // BLOQUEANTE: Overbooking detectado
                                    MessageBox.Show(
                                        $"No se puede guardar la modificación.\nLa nueva capacidad ({nuevaCapacidad}) es menor a la cantidad de tickets ya vendidos en funciones activas.",
                                        "Error de Overbooking",
                                        MessageBoxButtons.OK,
                                        MessageBoxIcon.Error
                                    );
                                }
                                else
                                {
                                    // ÉXITO
                                    CargarTablaSalas();
                                    MessageBox.Show("Sala modificada correctamente.", "Modificado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
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
                        bool ejecutarCambio = true;
                        bool forzarAccion = false;

                        // Bucle por si necesitamos reintentar forzando la acción
                        while (ejecutarCambio)
                        {
                            using (SqlConnection conexion = conexionBD.ObtenerConexión())
                            {
                                using (SqlCommand comando = new SqlCommand("SP_CambiarEstadoSala", conexion))
                                {
                                    comando.CommandType = CommandType.StoredProcedure;
                                    comando.Parameters.AddWithValue("@NroSala", nroSala);
                                    comando.Parameters.AddWithValue("@Estado", nuevoEstado);
                                    comando.Parameters.AddWithValue("@Forzar", forzarAccion);

                                    // Parámetro de salida que viene de SQL
                                    SqlParameter paramTieneFunciones = new SqlParameter("@TieneFuncionesActivas", SqlDbType.Bit);
                                    paramTieneFunciones.Direction = ParameterDirection.Output;
                                    comando.Parameters.Add(paramTieneFunciones);

                                    comando.ExecuteNonQuery();

                                    // Leemos el valor que devolvió SQL
                                    bool hayFunciones = Convert.ToBoolean(paramTieneFunciones.Value);

                                    if (hayFunciones && !forzarAccion)
                                    {
                                        // ¡Alerta con espera de confirmación!
                                        DialogResult respuesta = MessageBox.Show(
                                            $"La sala {nroSala} tiene funciones activas programadas.\n¿Está seguro de que desea desactivarla de todas formas?",
                                            "Advertencia de Funciones Activas",
                                            MessageBoxButtons.YesNo,
                                            MessageBoxIcon.Warning
                                        );

                                        if (respuesta == DialogResult.Yes)
                                        {
                                            // El usuario quiso seguir igual, activamos el flag de forzar y repite el while
                                            forzarAccion = true;
                                            continue;
                                        }
                                        else
                                        {
                                            // El usuario canceló, salimos de todo
                                            ejecutarCambio = false;
                                            return;
                                        }
                                    }
                                    else
                                    {
                                        // Si no hay funciones o ya se forzó, se completó con éxito
                                        ejecutarCambio = false;
                                    }
                                }
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