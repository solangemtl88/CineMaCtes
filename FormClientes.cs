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
    public partial class FormClientes : Form
    {
        public FormClientes()
        {
            InitializeComponent();
        }

        private bool cargandoFormulario = true;
        private string placeholderTexto = "Buscar por DNI, nombre o apellido...";
        private void FormClientes_Load(object sender, EventArgs e)
        {
            // Aplicar estilos a los DataGridViews
            ClassEstilosHelper.AplicarEstiloTabla(DGVClientes);

            // Evento de Configuración inicial del buscador y manejo del placeholder del TextBox de búsqueda
            ClassEstilosHelper.ConfigurarPlaceholder(TBuscar, placeholderTexto);

            //  Crear la columna de botón para Modificar Correo si no existe
            if (!DGVClientes.Columns.Contains("CModificar"))
            {
                DataGridViewButtonColumn ctnModificar = new DataGridViewButtonColumn();
                ctnModificar.Name = "CModificar";
                ctnModificar.HeaderText = "Acción";
                ctnModificar.Text = "Modificar Correo";
                ctnModificar.UseColumnTextForButtonValue = true;
                DGVClientes.Columns.Add(ctnModificar);
            }

            // Inicializar ComboBox de Estado (asumiendo que se llama cmbEstado o CBEstado)
            CBEstado.Items.Clear();
            CBEstado.Items.Add("Todos");
            CBEstado.Items.Add("Activo");
            CBEstado.Items.Add("Inactivo");
            CBEstado.SelectedIndex = 0;

            // Cargamos los datos de maqueta en la grilla
            CargarClientesFicticios();

            cargandoFormulario = false; // Fin de la carga inicial
        }

        private void CargarClientesFicticios()
        {
            DGVClientes.Rows.Clear();

            // Orden de columnas según tu diseño: DNI, Nombre, Apellido, Correo, Compras, Estado
            DGVClientes.Rows.Add("44123456", "Carlos", "Gómez", "carlos.gomez@gmail.com", "5", "Activo");
            DGVClientes.Rows.Add("38999888", "María", "Pérez", "maria.perez@yahoo.com", "2", "Activo");
            DGVClientes.Rows.Add("41555444", "Lucas", "Martínez", "lucas.m@hotmail.com", "8", "Inactivo");
        }

        private void DGVClientes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Reemplazá el MessageBox por este bloque dentro de tu DGVClientes_CellClick:
            if (e.RowIndex >= 0 && DGVClientes.Columns[e.ColumnIndex].Name == "CModificar")
            {
                DataGridViewRow fila = DGVClientes.Rows[e.RowIndex];
                
                string dniCliente = fila.Cells["CDni"].Value?.ToString() ?? "";
                string correoActual = fila.Cells["CCorreo"].Value?.ToString() ?? "";

                // Abrimos un formulario modal para editar el correo (pasándole el correo actual)
                using (FormModificarCorreo formCorreo = new FormModificarCorreo(correoActual))
                {
                    // Si el usuario confirma en el formulario secundario
                    if (formCorreo.ShowDialog() == DialogResult.OK)
                    {
                        string nuevoCorreo = formCorreo.NuevoCorreoIngresado;

                        // Actualizamos la celda en la grilla visualmente
                        fila.Cells["CCorreo"].Value = nuevoCorreo;

                        // Aquí agregarías tu sentencia SQL para actualizar en la base de datos (ej: UPDATE Clientes SET Correo = ... WHERE DNI = ...)

                        MessageBox.Show($"El correo del cliente DNI {dniCliente} fue actualizado con éxito.",
                            "Actualización Exitosa",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
                    }
                }
            }
        }

        private void FiltrarClientes()
        {
            if (cargandoFormulario) return;

            string filtroBusqueda = TBuscar.Text.Trim().ToLower();
            if (filtroBusqueda == placeholderTexto.ToLower()) filtroBusqueda = "";

            string estadoSeleccionado = CBEstado.SelectedItem?.ToString() ?? "Todos";

            foreach (DataGridViewRow fila in DGVClientes.Rows)
            {
                if (fila.IsNewRow) continue;

                // Suponiendo el orden: 0: DNI, 1: Nombre, 2: Apellido, 3: Correo, 4: Compras, 5: Estado
                string dniFila = fila.Cells[0].Value?.ToString().ToLower() ?? "";
                string nombreFila = fila.Cells[1].Value?.ToString().ToLower() ?? "";
                string apellidoFila = fila.Cells[2].Value?.ToString().ToLower() ?? "";
                string estadoFila = fila.Cells[5].Value?.ToString() ?? "";

                // El buscador filtra si coincide con DNI, Nombre o Apellido
                bool cumpleBusqueda = string.IsNullOrEmpty(filtroBusqueda) ||
                                      dniFila.Contains(filtroBusqueda) ||
                                      nombreFila.Contains(filtroBusqueda) ||
                                      apellidoFila.Contains(filtroBusqueda);

                bool cumpleEstado = string.IsNullOrEmpty(estadoSeleccionado) ||
                                    estadoSeleccionado == "Todos" ||
                                    estadoFila == estadoSeleccionado;

                if (cumpleBusqueda && cumpleEstado)
                {
                    fila.Visible = true;
                }
                else
                {
                    fila.Visible = false;
                }
            }
        }

        private void TBuscar_TextChanged(object sender, EventArgs e)
        {
            FiltrarClientes();
        }

        private void CBEstado_SelectedIndexChanged(object sender, EventArgs e)
        {
            FiltrarClientes();
        }

    }
}
