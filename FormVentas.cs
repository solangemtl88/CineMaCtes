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
    public partial class FormVentas : Form
    {
        public FormVentas()
        {
            InitializeComponent();
        }

        private string placeholderTexto = "Buscar DNI...";
        private bool cargandoFormulario = true; // Bandera para evitar filtrados prematuros

        private void FormVentas_Load(object sender, EventArgs e)
        {
            // Configuración de la grilla
            ClassEstilosHelper.AplicarEstiloTabla(DGVVentas);

            // Evento de Configuración inicial del buscador y manejo del placeholder del TextBox de búsqueda
            ClassEstilosHelper.ConfigurarPlaceholder(TBuscar, placeholderTexto);

            //  Crear la columna de botón Switch si no existe
            if (!DGVVentas.Columns.Contains("CEliminar"))
            {
                DataGridViewButtonColumn CEliminar = new DataGridViewButtonColumn();
                CEliminar.Name = "CEliminar";
                CEliminar.HeaderText = "Acción";
                CEliminar.Text = "Cambiar Estado";
                CEliminar.UseColumnTextForButtonValue = true;
                DGVVentas.Columns.Add(CEliminar);
            }

            // Inicializamos los desplegables
            InicializarComboBoxFiltros();

            // Cargamos datos de prueba (incluyendo el estado inicial "Activo")
            CargarVentasFicticias();

            cargandoFormulario = false; // Ya terminó de cargar, los filtros ya pueden operar normal
        }

        private void InicializarComboBoxFiltros()
        {
            CBPelicula.Items.Clear();
            CBPelicula.Items.Add("Todas");
            CBPelicula.Items.Add("Intensamente 2");
            CBPelicula.Items.Add("Avengers: Endgame");
            CBPelicula.Items.Add("Dune: Parte Dos");
            CBPelicula.SelectedIndex = 0;

            CBBeneficio.Items.Clear();
            CBBeneficio.Items.Add("Todos");
            CBBeneficio.Items.Add("General");
            CBBeneficio.Items.Add("Estudiante");
            CBBeneficio.Items.Add("Jubilados");
            CBBeneficio.SelectedIndex = 0;

            CBEstado.Items.Clear();
            CBEstado.Items.Add("Todos");
            CBEstado.Items.Add("Activo");
            CBEstado.Items.Add("Inactivo");
            CBEstado.SelectedIndex = 0;
        }

        private void CargarVentasFicticias()
        {
            DGVVentas.Rows.Clear();

            // Orden: Nro Venta, Fecha/Hora, DNI Cliente, Película, Sala, Beneficio, Monto Total, Estado
            DGVVentas.Rows.Add("1001", "22/09/2026 16:10", "44123456", "Intensamente 2", "Sala 2", "Estudiante", "$ 3.500", "Activo");
            DGVVentas.Rows.Add("1002", "22/09/2026 17:45", "38999888", "Avengers: Endgame", "Sala 1", "General", "$ 5.000", "Activo");
            DGVVentas.Rows.Add("1003", "22/09/2026 19:00", "41555444", "Dune: Parte Dos", "Sala 3", "Jubilados", "$ 3.000", "Inactivo");
        }

        // Evento de clic en la grilla para que el botón funcione como Switch
        // Evento de clic en la grilla para que el botón funcione como Switch
        private void DGVVentas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Verificamos que se hizo clic en el botón de la columna "CEliminar" y que no sea la cabecera
            if (e.RowIndex >= 0 && DGVVentas.Columns[e.ColumnIndex].Name == "CEliminar")
            {
                DataGridViewRow fila = DGVVentas.Rows[e.RowIndex];

                // Obtenemos el índice de la columna de estado (llamada "CEstado")
                int indiceColumnaEstado = DGVVentas.Columns["CEstado"].Index;
                string estadoActual = fila.Cells[indiceColumnaEstado].Value?.ToString() ?? "Activo";
                string nroVenta = fila.Cells[0].Value?.ToString() ?? "N/D";

                // Alternamos el estado
                string nuevoEstado = (estadoActual == "Activo") ? "Inactivo" : "Activo";

                DialogResult resultado = MessageBox.Show(
                    $"¿Desea cambiar el estado de la venta N° {nroVenta} a '{nuevoEstado}'?",
                    "Confirmar cambio de estado",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (resultado == DialogResult.Yes)
                {
                    fila.Cells[indiceColumnaEstado].Value = nuevoEstado;

                    // Refrescamos el filtro por si el usuario estaba filtrando por estado
                    FiltrarVentas();

                    MessageBox.Show($"La venta N° {nroVenta} ahora se encuentra '{nuevoEstado}'.",
                        "Estado actualizado",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }
            }
        }

        private void BtnModificarPrecios_Click(object sender, EventArgs e)
        {
            using (FormModificarPrecio formPrecios = new FormModificarPrecio())
            {
                formPrecios.ShowDialog();
            }
        }

        private void FiltrarVentas()
        {
            // Si el formulario se está cargando, ignoramos el filtrado
            if (cargandoFormulario) return;

            string filtroDni = TBuscar.Text.Trim().ToLower();
            if (filtroDni == placeholderTexto.ToLower()) filtroDni = ""; // Si tiene el placeholder, no filtra por texto

            string peliculaSeleccionada = CBPelicula.SelectedItem?.ToString() ?? "";
            string beneficioSeleccionado = CBBeneficio.SelectedItem?.ToString() ?? "";
            string estadoSeleccionado = CBEstado.SelectedItem?.ToString() ?? "";

            // Obtenemos la fecha seleccionada en el DateTimePicker formateada como "dd/MM/yyyy"
            string fechaSeleccionada = DTPFecha.Value.ToString("dd/MM/yyyy");

            foreach (DataGridViewRow fila in DGVVentas.Rows)
            {
                if (fila.IsNewRow) continue;

                // Orden de columnas: 0: Nro Venta, 1: Fecha/Hora, 2: DNI Cliente, 3: Película, 4: Sala, 5: Beneficio, 6: Monto, CEstado
                string fechaHoraFila = fila.Cells[1].Value?.ToString() ?? "";
                string dniFila = fila.Cells[2].Value?.ToString().ToLower() ?? "";
                string peliculaFila = fila.Cells[3].Value?.ToString() ?? "";
                string beneficioFila = fila.Cells[5].Value?.ToString() ?? "";
                string estadoFila = fila.Cells["CEstado"].Value?.ToString() ?? "";

                // Evaluamos si cumple con todos los filtros activos (incluyendo la fecha)
                bool cumpleFecha = fechaHoraFila.Contains(fechaSeleccionada);
                bool cumpleDni = string.IsNullOrEmpty(filtroDni) || dniFila.Contains(filtroDni);
                bool cumplePelicula = string.IsNullOrEmpty(peliculaSeleccionada) || peliculaSeleccionada == "Todas" || peliculaFila == peliculaSeleccionada;
                bool cumpleBeneficio = string.IsNullOrEmpty(beneficioSeleccionado) || beneficioSeleccionado == "Todos" || beneficioFila == beneficioSeleccionado;
                bool cumpleEstado = string.IsNullOrEmpty(estadoSeleccionado) || estadoSeleccionado == "Todos" || estadoFila == estadoSeleccionado;

                if (cumpleFecha && cumpleDni && cumplePelicula && cumpleBeneficio && cumpleEstado)
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
            FiltrarVentas();
        }

        private void CBPelicula_SelectedIndexChanged(object sender, EventArgs e)
        {
            FiltrarVentas();
        }

        private void CBBeneficio_SelectedIndexChanged(object sender, EventArgs e)
        {
            FiltrarVentas();
        }

        private void CBEstado_SelectedIndexChanged(object sender, EventArgs e)
        {
            FiltrarVentas();
        }

        private void DTPFecha_ValueChanged(object sender, EventArgs e)
        {
            FiltrarVentas();
        }
    }
}
