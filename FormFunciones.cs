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
    public partial class FormFunciones : Form
    {
        public FormFunciones()
        {
            InitializeComponent();
        }

        private string placeholderTexto = "Buscar Función...";

        private void FormFunciones_Load(object sender, EventArgs e)
        {

            // Evento de Configuración inicial del buscador y manejo del placeholder del TextBox de búsqueda
            ClassEstilosHelper.ConfigurarPlaceholder(TBuscar, placeholderTexto);

            // Configuración del DataGridView
            ClassEstilosHelper.AplicarEstiloTabla(DGVFunciones);

            // Crear las columnas de botones solo si no existen ya
            ClassEstilosHelper.AgregarBotonesAccion(DGVFunciones);

            // Cargamos los ComboBox de filtros superiores
            CargarCombosFiltros();

            // Cargamos datos de ejemplo (Modo Maqueta)
            CargarTablaFunciones();
        }

        // Método para cargar los ComboBox de filtros superiores con opciones de ejemplo
        private void CargarCombosFiltros()
        {
            // Filtro de Sala
            CBSala.Items.Clear();
            CBSala.Items.Add("Todas");
            CBSala.Items.Add("1");
            CBSala.Items.Add("2");
            CBSala.Items.Add("3");
            CBSala.SelectedIndex = 0;

            // Filtro de Estado
            CBEstado.Items.Clear();
            CBEstado.Items.Add("Todos");
            CBEstado.Items.Add("Activo");
            CBEstado.Items.Add("Inactivo");
            CBEstado.SelectedIndex = 0;

            // Configuración del selector de fecha de filtro si es DateTimePicker
            // (Si usas un DateTimePicker para filtrar por día)
        }

        // Método para cargar datos de ejemplo en el DataGridView (Modo Maqueta)
        private void CargarTablaFunciones()
        {
            DGVFunciones.Rows.Clear();

            // Filas de ejemplo (Modo Maqueta)
            AgregarFilaMaqueta(DateTime.Now.Date, "Avengers: Endgame", DateTime.Now.Date.AddHours(18), DateTime.Now.Date.AddHours(20).AddMinutes(45), 1, "Activo", 1);
            AgregarFilaMaqueta(DateTime.Now.Date, "Intensamente 2", DateTime.Now.Date.AddHours(15), DateTime.Now.Date.AddHours(16).AddMinutes(36), 2, "Activo", 2);
        }

        // Método auxiliar para agregar una fila de ejemplo al DataGridView
        private void AgregarFilaMaqueta(DateTime fecha, string pelicula, DateTime inicio, DateTime fin, int nroSala, string estado, int id)
        {
            int n = DGVFunciones.Rows.Add();
            DGVFunciones.Rows[n].Cells[0].Value = fecha.ToShortDateString();
            DGVFunciones.Rows[n].Cells[1].Value = pelicula;
            DGVFunciones.Rows[n].Cells[2].Value = inicio.ToString("HH:mm");
            DGVFunciones.Rows[n].Cells[3].Value = fin.ToString("HH:mm");
            DGVFunciones.Rows[n].Cells[4].Value = nroSala;
            DGVFunciones.Rows[n].Cells[5].Value = estado;
            DGVFunciones.Rows[n].Cells[6].Value = id; // ID Oculto de la función
        }

        // Evento del botón "Añadir Función" para abrir el formulario de registro
        private void BAnadirFuncion_Click(object sender, EventArgs e)
        {
            using (FormRegistroFuncion formRegistro = new FormRegistroFuncion())
            {
                DialogResult resultado = formRegistro.ShowDialog();

                if (resultado == DialogResult.OK)
                {
                    int nuevoId = DGVFunciones.Rows.Count + 1;

                    int n = DGVFunciones.Rows.Add();
                    DGVFunciones.Rows[n].Cells[0].Value = formRegistro.FechaFuncion.ToShortDateString();
                    DGVFunciones.Rows[n].Cells[1].Value = formRegistro.PeliculaSeleccionada;
                    DGVFunciones.Rows[n].Cells[2].Value = formRegistro.InicioFuncion.ToString("HH:mm");
                    DGVFunciones.Rows[n].Cells[3].Value = formRegistro.FinFuncion.ToString("HH:mm");
                    DGVFunciones.Rows[n].Cells[4].Value = formRegistro.NroSalaSeleccionada;
                    DGVFunciones.Rows[n].Cells[5].Value = "Activo";
                    DGVFunciones.Rows[n].Cells[6].Value = nuevoId;

                    MessageBox.Show("Función programada con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        // Evento del DataGridView para manejar los clics en las columnas de botones
        private void DGVFunciones_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && !DGVFunciones.Rows[e.RowIndex].IsNewRow)
            {
                string nombreColumna = DGVFunciones.Columns[e.ColumnIndex].Name;
                int idFuncion = Convert.ToInt32(DGVFunciones.Rows[e.RowIndex].Cells[6].Value);
                string peliculaActual = DGVFunciones.Rows[e.RowIndex].Cells[1].Value?.ToString() ?? "";
                string estadoActual = DGVFunciones.Rows[e.RowIndex].Cells[5].Value?.ToString() ?? "Activo";

                if (nombreColumna == "CEliminar")
                {
                    string nuevoEstado = (estadoActual == "Activo") ? "Inactivo" : "Activo";
                    DGVFunciones.Rows[e.RowIndex].Cells[5].Value = nuevoEstado;

                    MessageBox.Show($"La función de '{peliculaActual}' cambió su estado a '{nuevoEstado}'.", "Estado Actualizado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (nombreColumna == "CModificar")
                {
                    // Leemos los datos actuales de la fila seleccionada
                    string peliculaActualAUX = DGVFunciones.Rows[e.RowIndex].Cells[1].Value?.ToString() ?? "";

                    int.TryParse(DGVFunciones.Rows[e.RowIndex].Cells[4].Value?.ToString(), out int salaActual);

                    DateTime fechaActual = Convert.ToDateTime(DGVFunciones.Rows[e.RowIndex].Cells[0].Value);

                    // Parseamos la hora de inicio (columna 2)
                    string horaInicioStr = DGVFunciones.Rows[e.RowIndex].Cells[2].Value?.ToString() ?? "00:00";
                    TimeSpan horaInicio = TimeSpan.Parse(horaInicioStr);
                    DateTime inicioCompleto = fechaActual.Date.Add(horaInicio);

                    using (FormRegistroFuncion formModificar = new FormRegistroFuncion())
                    {
                        // Le pasamos los datos actuales al formulario
                        formModificar.CargarDatos(peliculaActualAUX, salaActual, fechaActual, inicioCompleto);

                        DialogResult resultado = formModificar.ShowDialog();

                        if (resultado == DialogResult.OK)
                        {
                            // Actualizamos la grilla visualmente con los nuevos valores del formulario
                            DGVFunciones.Rows[e.RowIndex].Cells[0].Value = formModificar.FechaFuncion.ToShortDateString();
                            DGVFunciones.Rows[e.RowIndex].Cells[1].Value = formModificar.PeliculaSeleccionada;
                            DGVFunciones.Rows[e.RowIndex].Cells[2].Value = formModificar.InicioFuncion.ToString("HH:mm");
                            DGVFunciones.Rows[e.RowIndex].Cells[3].Value = formModificar.FinFuncion.ToString("HH:mm");
                            DGVFunciones.Rows[e.RowIndex].Cells[4].Value = formModificar.NroSalaSeleccionada;

                            MessageBox.Show("Función modificada correctamente.", "Modificado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
            }
        
        }

        private void AplicarFiltros()
        {
            string textoBusqueda = TBuscar?.Text.Trim().ToLower() ?? "";

            if (textoBusqueda == placeholderTexto.ToLower())
            {
                textoBusqueda = "";
            }

            string salaFiltro = CBSala?.SelectedItem?.ToString() ?? "Todas";
            string estadoFiltro = CBEstado?.SelectedItem?.ToString() ?? "Todos";

            // Obtenemos la fecha seleccionada en el DateTimePicker superior (solo la fecha, sin horas)
            DateTime fechaFiltro = DTPFecha.Value.Date;

            foreach (DataGridViewRow row in DGVFunciones.Rows)
            {
                if (row.IsNewRow) continue;

                // Obtenemos los valores de las celdas
                string fechaCeldaStr = row.Cells[0].Value?.ToString() ?? "";
                string pelicula = row.Cells[1].Value?.ToString().ToLower() ?? "";
                string sala = row.Cells[4].Value?.ToString().Trim() ?? "";
                string estado = row.Cells[5].Value?.ToString().Trim() ?? "";

                // Parseamos la fecha de la celda para compararla
                bool cumpleFecha = true;
                if (DateTime.TryParse(fechaCeldaStr, out DateTime fechaFila))
                {
                    cumpleFecha = (fechaFila.Date == fechaFiltro);
                }

                // Evaluamos las condiciones de todos los filtros juntos
                bool cumpleTexto = string.IsNullOrEmpty(textoBusqueda) || pelicula.Contains(textoBusqueda);

                bool cumpleSala = salaFiltro.Equals("Todas", StringComparison.OrdinalIgnoreCase) ||
                                  sala.Equals(salaFiltro, StringComparison.OrdinalIgnoreCase);

                bool cumpleEstado = estadoFiltro.Equals("Todos", StringComparison.OrdinalIgnoreCase) ||
                                    estado.Equals(estadoFiltro, StringComparison.OrdinalIgnoreCase);

                // La fila se muestra solo si cumple con absolutamente todos los criterios
                row.Visible = cumpleFecha && cumpleTexto && cumpleSala && cumpleEstado;
            }
        }

        // Evento del buscador de texto 
        private void TBuscar_TextChanged(object sender, EventArgs e)
        {
            AplicarFiltros();
        }

        // Evento del ComboBox de Sala
        private void CBSalaFiltro_SelectedIndexChanged(object sender, EventArgs e)
        {
            AplicarFiltros();
        }

        // Evento del ComboBox de Estado
        private void CBEstadoFiltro_SelectedIndexChanged(object sender, EventArgs e)
        {
            AplicarFiltros();
        }

        // Evento del DateTimePicker de fecha
        private void DTPFecha_ValueChanged(object sender, EventArgs e)
        {
            AplicarFiltros();
        }
    }
}
