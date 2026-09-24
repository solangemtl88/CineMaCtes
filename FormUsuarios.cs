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
using CinemaCtes; 

namespace CinemaCtes
{
    public partial class FormUsuarios : Form
    {
        public FormUsuarios()
        {
            InitializeComponent();
        }

        private string placeholderTexto = "Buscar usuario...";

        private void FormUsuarios_Load(object sender, EventArgs e)
        {

            // Configuración inicial del buscador
            TBuscar.Text = placeholderTexto;
            TBuscar.ForeColor = Color.Gray;

            // Configuración del DataGridView
            ClassEstilosHelper.AplicarEstiloTabla(DGVUsuarios);

            CBEstado.SelectedIndex = 0; // Por defecto en "Todos"

            CBTipo.SelectedIndex = 0; // Por defecto en "Todos"

            // Crear las columnas de botones solo si no existen ya
            if (!DGVUsuarios.Columns.Contains("CModificar"))
            {
                DataGridViewButtonColumn CModificar = new DataGridViewButtonColumn();
                CModificar.Name = "CModificar";
                CModificar.HeaderText = "Acción 1";
                CModificar.Text = "Modificar";
                CModificar.UseColumnTextForButtonValue = true;
                DGVUsuarios.Columns.Add(CModificar);
            }

            if (!DGVUsuarios.Columns.Contains("CEliminar"))
            {
                DataGridViewButtonColumn CEliminar = new DataGridViewButtonColumn();
                CEliminar.Name = "CEliminar";
                CEliminar.HeaderText = "Acción 2";
                CEliminar.Text = "Desactivar";
                CEliminar.UseColumnTextForButtonValue = true;
                DGVUsuarios.Columns.Add(CEliminar);
            }

            CargarTablaUsuarios();
        }

        // Evento para abrir el formulario de registro de beneficios y agregar un nuevo beneficio
        private void BAñadir_Click(object sender, EventArgs e)
        {
            using (FormRegistrarUsuario formUsuario = new FormRegistrarUsuario())
            {
                DialogResult resultado = formUsuario.ShowDialog();

                if (resultado == DialogResult.OK)
                {
                    ConexionBD conexionBD = new ConexionBD();
                    try
                    {
                        using (SqlConnection conexion = conexionBD.ObtenerConexión())
                        {
                            string query = "INSERT INTO usuario (nombre, apellido, correo, contraseña, dni, id_tipo_usuario) VALUES (@Nombre, @Apellido, @Correo, @Contrasena, @Dni, @IdTipoUsuario)";

                            using (SqlCommand comando = new SqlCommand(query, conexion))
                            {
                                comando.Parameters.AddWithValue("@Nombre", formUsuario.Nombre);
                                comando.Parameters.AddWithValue("@Apellido", formUsuario.Apellido);
                                comando.Parameters.AddWithValue("@Dni", formUsuario.Dni);
                                comando.Parameters.AddWithValue("@Correo", formUsuario.Correo);
                                comando.Parameters.AddWithValue("@Contrasena", formUsuario.Contrasena);
                                comando.Parameters.AddWithValue("@IdTipoUsuario", formUsuario.IdTipoUsuario);

                                comando.ExecuteNonQuery();
                            }
                        }

                        // Recargamos la tabla para ver reflejado el nuevo registro
                        CargarTablaUsuarios();

                        MessageBox.Show(
                            $"Se registró con éxito el usuario:\n\n• Nombre: {formUsuario.Nombre} {formUsuario.Apellido}\n• DNI: {formUsuario.Dni}",
                            "Usuario Guardado",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information
                        );
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error al guardar en la base de datos: " + ex.Message, "Error de BD", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        // Método para cargar los usuarios desde la base de datos y mostrarlos en el DataGridView
        private void CargarTablaUsuarios(string busqueda = "", string tipoFiltro = "Todos", string estadoFiltro = "Todos")
        {
            DGVUsuarios.Rows.Clear();

            ConexionBD conexionBD = new ConexionBD();
            try
            {
                using (SqlConnection conexion = conexionBD.ObtenerConexión())
                {
                    // Consulta base con filtros dinámicos (WHERE 1=1 permite concatenar condiciones fácilmente)
                    string query = @"SELECT u.id_usuario, u.nombre, u.apellido, u.correo, u.dni, u.estado, tu.descripcion AS tipo_usuario, u.id_tipo_usuario 
                             FROM usuario u 
                             INNER JOIN tipo_usuario tu ON u.id_tipo_usuario = tu.id_tipo_usuario
                             WHERE 1=1";

                    // Filtro por texto (Buscador general: busca en nombre, apellido, correo o DNI)
                    if (!string.IsNullOrWhiteSpace(busqueda))
                    {
                        query += " AND (u.nombre LIKE @Busqueda OR u.apellido LIKE @Busqueda OR u.correo LIKE @Busqueda OR CAST(u.dni AS VARCHAR) LIKE @Busqueda)";
                    }

                    // Filtro por Tipo de Usuario
                    if (tipoFiltro != "Todos" && !string.IsNullOrEmpty(tipoFiltro))
                    {
                        query += " AND tu.descripcion = @TipoFiltro";
                    }

                    // Filtro por Estado
                    if (estadoFiltro != "Todos" && !string.IsNullOrEmpty(estadoFiltro))
                    {
                        query += " AND u.estado = @EstadoFiltro";
                    }

                    using (SqlCommand comando = new SqlCommand(query, conexion))
                    {
                        // Agregamos los parámetros si se están utilizando
                        if (!string.IsNullOrWhiteSpace(busqueda))
                        {
                            comando.Parameters.AddWithValue("@Busqueda", "%" + busqueda.Trim() + "%");
                        }
                        if (tipoFiltro != "Todos" && !string.IsNullOrEmpty(tipoFiltro))
                        {
                            comando.Parameters.AddWithValue("@TipoFiltro", tipoFiltro);
                        }
                        if (estadoFiltro != "Todos" && !string.IsNullOrEmpty(estadoFiltro))
                        {
                            comando.Parameters.AddWithValue("@EstadoFiltro", estadoFiltro);
                        }

                        using (SqlDataReader lector = comando.ExecuteReader())
                        {
                            while (lector.Read())
                            {
                                int n = DGVUsuarios.Rows.Add(
                                    lector["nombre"],           // 0: Nombre
                                    lector["apellido"],         // 1: Apellido
                                    lector["correo"],           // 2: Correo
                                    lector["dni"],              // 3: DNI
                                    lector["estado"],           // 4: Estado
                                    lector["tipo_usuario"],     // 5: Tipo
                                    lector["id_usuario"],       // 6: ID Oculto
                                    lector["id_tipo_usuario"]   // 7: ID Tipo Oculto
                                );
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al filtrar los usuarios: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        // Evento para manejar los clics en las celdas del DataGridView, especialmente en los botones de acción
        private void DGVUsuarios_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Validamos que sea una fila válida
            if (e.RowIndex >= 0 && !DGVUsuarios.Rows[e.RowIndex].IsNewRow)
            {
                string nombreColumna = DGVUsuarios.Columns[e.ColumnIndex].Name;

                // 1. LEEMOS LOS IDs DIRECTAMENTE DE LAS COLUMNAS OCULTAS (Índices 6 y 7)
                int idUsuario = Convert.ToInt32(DGVUsuarios.Rows[e.RowIndex].Cells[6].Value);
                int idTipoUsuarioActual = Convert.ToInt32(DGVUsuarios.Rows[e.RowIndex].Cells[7].Value);

                // 2. LEEMOS LOS DATOS VISIBLES SEGÚN TU ORDEN DE COLUMNAS EXACTO
                string nombreActual = DGVUsuarios.Rows[e.RowIndex].Cells[0].Value?.ToString() ?? "";
                string apellidoActual = DGVUsuarios.Rows[e.RowIndex].Cells[1].Value?.ToString() ?? "";
                string correoActual = DGVUsuarios.Rows[e.RowIndex].Cells[2].Value?.ToString() ?? "";
                string dniActual = DGVUsuarios.Rows[e.RowIndex].Cells[3].Value?.ToString() ?? "";
                string estadoActual = DGVUsuarios.Rows[e.RowIndex].Cells[4].Value?.ToString() ?? "Activo";

                if (nombreColumna == "CModificar")
                {
                    using (FormRegistrarUsuario formModificar = new FormRegistrarUsuario())
                    {
                        // Pasamos los datos actuales al formulario de edición
                        formModificar.CargarDatos(nombreActual, apellidoActual, dniActual, correoActual, idTipoUsuarioActual);
                        DialogResult resultado = formModificar.ShowDialog();

                        if (resultado == DialogResult.OK)
                        {
                            ConexionBD conexionBD = new ConexionBD();
                            try
                            {
                                using (SqlConnection conexion = conexionBD.ObtenerConexión())
                                {
                                    string query = "UPDATE usuario SET nombre = @Nombre, apellido = @Apellido, dni = @Dni, correo = @Correo, id_tipo_usuario = @IdTipoUsuario WHERE id_usuario = @Id";

                                    using (SqlCommand comando = new SqlCommand(query, conexion))
                                    {
                                        comando.Parameters.AddWithValue("@Id", idUsuario);
                                        comando.Parameters.AddWithValue("@Nombre", formModificar.Nombre);
                                        comando.Parameters.AddWithValue("@Apellido", formModificar.Apellido);
                                        comando.Parameters.AddWithValue("@Dni", Convert.ToInt32(formModificar.Dni));
                                        comando.Parameters.AddWithValue("@Correo", formModificar.Correo);
                                        comando.Parameters.AddWithValue("@IdTipoUsuario", formModificar.IdTipoUsuario);

                                        comando.ExecuteNonQuery();
                                    }
                                }

                                CargarTablaUsuarios(); // Refrescamos la grilla con los cambios
                                MessageBox.Show("Usuario modificado correctamente en la base de datos.", "Modificado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show("Error al actualizar: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                        int filasAfectadas = 0;
                        using (SqlConnection conexion = conexionBD.ObtenerConexión())
                        {
                            string query = "UPDATE usuario SET estado = @Estado WHERE id_usuario = @Id";
                            using (SqlCommand comando = new SqlCommand(query, conexion))
                            {
                                comando.Parameters.AddWithValue("@Estado", nuevoEstado);
                                comando.Parameters.AddWithValue("@Id", idUsuario);

                                // Ejecutamos la consulta de actualización de estado
                                filasAfectadas = comando.ExecuteNonQuery();
                            }
                        }

                        if (filasAfectadas > 0)
                        {
                            // Actualizamos visualmente la celda 4 (Estado)
                            DGVUsuarios.Rows[e.RowIndex].Cells[4].Value = nuevoEstado;

                            MessageBox.Show(
                                $"El usuario '{nombreActual}' ha sido cambiado a '{nuevoEstado}' en la base de datos.",
                                "Estado Actualizado",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information
                            );
                        }
                        else
                        {
                            MessageBox.Show("No se pudo actualizar el registro (Filas afectadas: 0). Verificá el ID.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error al cambiar el estado: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }



        // Evento cuando se escribe en la barra de búsqueda (TextBox, ej: TxtBuscador)
        private void TBuscar_TextChanged(object sender, EventArgs e)
        {
            AplicarFiltros();
        }

        // Evento cuando se cambia la selección en el ComboBox de Tipo
        private void CBTipo_SelectedIndexChanged(object sender, EventArgs e)
        {
            AplicarFiltros();
        }

        // Evento cuando se cambia la selección en el ComboBox de Estado
        private void CBEstado_SelectedIndexChanged(object sender, EventArgs e)
        {
            AplicarFiltros();
        }

        // Método auxiliar que junta los valores actuales de los 3 controles y llama a la recarga
        private void AplicarFiltros()
        {
            // Evitamos que se ejecute si los ComboBox aún no tienen elementos cargados
            if (CBTipo.SelectedItem == null || CBEstado.SelectedItem == null)
                return;

            string textoBusqueda = TBuscar.Text.Trim();
            // Si el texto es el placeholder por defecto, lo tratamos como vacío
            if (textoBusqueda == "Buscar usuario...")
            {
                textoBusqueda = "";
            }

            string tipoSeleccionado = CBTipo.SelectedItem?.ToString() ?? "Todos";
            string estadoSeleccionado = CBEstado.SelectedItem?.ToString() ?? "Todos";

            CargarTablaUsuarios(textoBusqueda, tipoSeleccionado, estadoSeleccionado);
        }

        // Evento para manejar el placeholder del TextBox de búsqueda
        private void TBuscar_Enter(object sender, EventArgs e)
        {
            // Si el texto actual es el placeholder, lo borramos y ponemos el color de texto normal
            if (TBuscar.Text == placeholderTexto)
            {
                TBuscar.Text = "";
                TBuscar.ForeColor = Color.Black;
            }
        }


        // Evento para restaurar el placeholder si el usuario deja el campo vacío
        private void TBuscar_Leave(object sender, EventArgs e)
        {
            // Si el usuario salió del campo y lo dejó vacío, restauramos el placeholder
            if (string.IsNullOrWhiteSpace(TBuscar.Text))
            {
                TBuscar.Text = placeholderTexto;
                TBuscar.ForeColor = Color.Gray;
            }
        }
    }
}
