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
    public partial class FormBeneficios : Form
    {

        public FormBeneficios()
        {
            InitializeComponent();

            CBTipo.SelectedIndex = 0; // Seleccionar "Todos" por defecto

            CBEstado.SelectedIndex = 0; 
        }


        private string placeholderTexto = "Buscar beneficio...";
        private void FormBeneficios_Load(object sender, EventArgs e)
        {

            // Evento de Configuración inicial del buscador y manejo del placeholder del TextBox de búsqueda
            ClassEstilosHelper.ConfigurarPlaceholder(TBuscar, placeholderTexto);

            // Configuración del DataGridView
            ClassEstilosHelper.AplicarEstiloTabla(DGVBeneficios);

            // Crear las columnas de botones solo si no existen ya
            ClassEstilosHelper.AgregarBotonesAccion(DGVBeneficios);
        }

        // Evento para abrir el formulario de registro de beneficios y agregar un nuevo beneficio
        private void BAñadir_Click(object sender, EventArgs e)
        {
            // Usamos 'using' para liberar memoria del formulario al cerrarlo
            using (FormRegistrarBeneficio formRegistro = new FormRegistrarBeneficio())
            {
                // Mostrar como ventana modal (bloquea el fondo hasta cerrar)
                DialogResult resultado = formRegistro.ShowDialog();

                // Si el usuario guardó/insertó exitosamente
                if (resultado == DialogResult.OK)
                {
                    string descripcion = formRegistro.Descripcion;
                    string tipoBeneficio = formRegistro.TipoBeneficio;
                    string descuento = formRegistro.Descuento;
                    string estado = "Inactivo";

                    // Agregamos la fila a la tabla
                    DGVBeneficios.Rows.Add(descripcion, tipoBeneficio, descuento, estado);

                    // Mensaje con detalles del registro recién creado
                    MessageBox.Show(
                        $"Se registró con éxito el beneficio:\n\n• Descripción: {descripcion}\n• Tipo: {tipoBeneficio}\n• Descuento: {descuento}",
                        "Registro Guardado",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information
                    );
                }
            }
        }

        // Evento para manejar los clics en las celdas del DataGridView
        private void DGVBeneficios_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            // Validamos que sea una fila válida y no la cabecera ni la última fila vacía
            if (e.RowIndex >= 0 && !DGVBeneficios.Rows[e.RowIndex].IsNewRow)
            {
                // Obtenemos el nombre de la columna en la que se hizo clic
                string nombreColumna = DGVBeneficios.Columns[e.ColumnIndex].Name;

                if (nombreColumna == "CModificar")
                {
                    // Lógica para Modificar
                    string descActual = DGVBeneficios.Rows[e.RowIndex].Cells[0].Value?.ToString() ?? "";
                    string tipoActual = DGVBeneficios.Rows[e.RowIndex].Cells[1].Value?.ToString() ?? "";
                    string descUsoActual = DGVBeneficios.Rows[e.RowIndex].Cells[2].Value?.ToString() ?? "";

                    using (FormRegistrarBeneficio formModificar = new FormRegistrarBeneficio())
                    {
                        formModificar.CargarDatos(descActual, tipoActual, descUsoActual);
                        DialogResult resultado = formModificar.ShowDialog();

                        if (resultado == DialogResult.OK)
                        {
                            DGVBeneficios.Rows[e.RowIndex].Cells[0].Value = formModificar.Descripcion;
                            DGVBeneficios.Rows[e.RowIndex].Cells[1].Value = formModificar.TipoBeneficio;
                            DGVBeneficios.Rows[e.RowIndex].Cells[2].Value = formModificar.Descuento;

                            MessageBox.Show("Beneficio modificado correctamente.", "Modificado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
                else if (nombreColumna == "CEliminar")
                {
                    // Capturamos información clave de la fila seleccionada
                    string descripcionBeneficio = DGVBeneficios.Rows[e.RowIndex].Cells[0].Value?.ToString() ?? "Sin descripción";
                    string tipoBeneficio = DGVBeneficios.Rows[e.RowIndex].Cells[1].Value?.ToString() ?? "";
                    string estadoActual = DGVBeneficios.Rows[e.RowIndex].Cells[3].Value?.ToString() ?? "Activo";

                    if (estadoActual == "Activo")
                    {
                        // Cambiamos a Inactivo y mostramos la información en el mensaje
                        DGVBeneficios.Rows[e.RowIndex].Cells[3].Value = "Inactivo";

                        MessageBox.Show(
                            $"El beneficio '{descripcionBeneficio}' ({tipoBeneficio}) ha sido desactivado correctamente.",
                            "Estado Actualizado",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information
                        );
                    }
                    else
                    {
                        // Cambiamos a Activo y mostramos la información en el mensaje
                        DGVBeneficios.Rows[e.RowIndex].Cells[3].Value = "Activo";

                        MessageBox.Show(
                            $"El beneficio '{descripcionBeneficio}' ({tipoBeneficio}) ha sido activado correctamente.",
                            "Estado Actualizado",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information
                        );
                    }
                }
            }
        }


        //Evento de filtrado de tabla
        private void FiltrarTabla()
        {
            string textoBusqueda = TBuscar.Text.Trim().ToLower();

            // Si el texto es exactamente el placeholder, lo tratamos como vacío
            if (textoBusqueda == placeholderTexto.ToLower())
            {
                textoBusqueda = "";
            }

            string tipoSeleccionado = CBTipo.SelectedItem?.ToString() ?? "Todos";
            string estadoSeleccionado = CBEstado.SelectedItem?.ToString() ?? "Todos";

            foreach (DataGridViewRow row in DGVBeneficios.Rows)
            {
                // Omitir la fila de nueva entrada si estuviera habilitada (aunque la tengamos bloqueada)
                if (row.IsNewRow) continue;

                // Asumimos el orden de columnas: 
                // 0: Descripción, 1: Tipo de beneficio, 2: Descuento, 3: Estado
                string descripcion = row.Cells[0].Value?.ToString().ToLower() ?? "";
                string tipo = row.Cells[1].Value?.ToString() ?? "";
                string estado = row.Cells[3].Value?.ToString() ?? "";

                // Validar filtro de texto (busca coincidencia en la descripción)
                bool coincideTexto = string.IsNullOrEmpty(textoBusqueda) || descripcion.Contains(textoBusqueda);

                // Validar filtro de tipo
                bool coincideTipo = (tipoSeleccionado == "Todos") || (tipo == tipoSeleccionado);

                // Validar filtro de estado
                bool coincideEstado = (estadoSeleccionado == "Todos") || (estado == estadoSeleccionado);

                // Si cumple con los tres criterios, la fila se muestra; de lo contrario, se oculta
                bool mostrar = coincideTexto && coincideTipo && coincideEstado;
                row.Visible = mostrar;
            }
        }

        // Eventos para disparar el filtrado cuando cambian los controles
        private void TBuscar_TextChanged(object sender, EventArgs e)
        {
            FiltrarTabla();
        }

        private void CBTipo_SelectedIndexChanged(object sender, EventArgs e)
        {
            FiltrarTabla();
        }

        private void CBEstado_SelectedIndexChanged(object sender, EventArgs e)
        {
            FiltrarTabla();
        }

        // Evento para cambiar el texto del botón según el estado del beneficio
        private void DGVBeneficios_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            // Verificamos si estamos en la columna de nuestro botón de acción
            if (DGVBeneficios.Columns[e.ColumnIndex].Name == "CEliminar" && e.RowIndex >= 0)
            {
                // Leemos el valor del estado de esa misma fila 
                string estado = DGVBeneficios.Rows[e.RowIndex].Cells[3].Value?.ToString() ?? "Activo";

                // Cambiamos el texto del botón según el estado
                if (estado == "Activo")
                {
                    e.Value = "Desactivar";
                }
                else
                {
                    e.Value = "Activar";
                }
            }
        }
    }
}
