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
    public partial class FormPeliculas : Form
    {
        public FormPeliculas()
        {
            InitializeComponent();
        }

        private string placeholderTexto = "Buscar Pelicula...";
        private void FormPeliculas_Load(object sender, EventArgs e)
        {

            // Configuración inicial del buscador
            TBuscar.Text = placeholderTexto;
            TBuscar.ForeColor = Color.Gray;

            // Configuración del DataGridView
            DGVPeliculas.AllowUserToAddRows = false;
            DGVPeliculas.ReadOnly = true;
            DGVPeliculas.AllowUserToDeleteRows = false;

            // Creamos los botones de acción por código
            ConfigurarColumnasBotones();

            CargarCombosFiltros(); // Cargamos las opciones para los filtros superiores

            // Cargamos datos de ejemplo (Modo Maqueta)
            CargarTablaPeliculas();
        }

        // Método para configurar las columnas de botones en el DataGridView
        private void ConfigurarColumnasBotones()
        {
            if (!DGVPeliculas.Columns.Contains("CModificar"))
            {
                DataGridViewButtonColumn CModificar = new DataGridViewButtonColumn();
                CModificar.Name = "CModificar";
                CModificar.HeaderText = "Modificar";
                CModificar.Text = "Editar";
                CModificar.UseColumnTextForButtonValue = true;
                DGVPeliculas.Columns.Add(CModificar);
            }

            if (!DGVPeliculas.Columns.Contains("CEliminar"))
            {
                DataGridViewButtonColumn CEliminar = new DataGridViewButtonColumn();
                CEliminar.Name = "CEliminar";
                CEliminar.HeaderText = "Acciones";
                CEliminar.Text = "Eliminar";
                CEliminar.UseColumnTextForButtonValue = true;
                DGVPeliculas.Columns.Add(CEliminar);
            }
        }

        // Método para cargar los combos de filtros con opciones predefinidas
        private void CargarCombosFiltros()
        {
            // Filtro de Etiqueta / Género (Agregamos opción "Todos" para resetear el filtro)
            CBEtiqueta.Items.Clear();
            CBEtiqueta.Items.Add("Todas");
            CBEtiqueta.Items.Add("Acción");
            CBEtiqueta.Items.Add("Comedia");
            CBEtiqueta.Items.Add("Drama");
            CBEtiqueta.Items.Add("Terror");
            CBEtiqueta.Items.Add("Ciencia Ficción");
            CBEtiqueta.Items.Add("Animación");
            CBEtiqueta.SelectedIndex = 0;

            // Filtro de Estado
            CBEstado.Items.Clear();
            CBEstado.Items.Add("Todos");
            CBEstado.Items.Add("Activo");
            CBEstado.Items.Add("Inactivo");
            CBEstado.SelectedIndex = 0;
        }


        // Método para cargar datos de ejemplo en el DataGridView (Modo Maqueta)
        private void CargarTablaPeliculas()
        {
            DGVPeliculas.Rows.Clear();

            // Filas de ejemplo (Modo Maqueta)
            AgregarFilaMaqueta("Avengers: Endgame", 181, "Los Vengadores se reúnen para deshacer las acciones de Thanos.", DateTime.Now, DateTime.Now.AddDays(30), "Acción", "Activo", 1);
            AgregarFilaMaqueta("Intensamente 2", 96, "Alegría y Tristeza se enfrentan a una nueva etapa.", DateTime.Now, DateTime.Now.AddDays(30), "Animación", "Activo", 2);
        }


        // Método auxiliar para agregar una fila de ejemplo al DataGridView
        private void AgregarFilaMaqueta(string titulo, int duracion, string sinopsis, DateTime desde, DateTime hasta, string etiqueta, string estado, int id)
        {
            int n = DGVPeliculas.Rows.Add();
            DGVPeliculas.Rows[n].Cells[0].Value = titulo;   // Columna 0: Título
            DGVPeliculas.Rows[n].Cells[1].Value = duracion + " min"; // Columna 1: Duración
            DGVPeliculas.Rows[n].Cells[2].Value = sinopsis; // Columna 2: Sinopsis
            DGVPeliculas.Rows[n].Cells[3].Value = desde.ToShortDateString();
            DGVPeliculas.Rows[n].Cells[4].Value = hasta.ToShortDateString();
            DGVPeliculas.Rows[n].Cells[5].Value = etiqueta;
            DGVPeliculas.Rows[n].Cells[6].Value = estado;
            DGVPeliculas.Rows[n].Cells[7].Value = id; // ID Oculto
        }


        // Evento para abrir el formulario de registro de película y agregar una nueva película al DataGridView
        private void BAnadirPelicula_Click(object sender, EventArgs e)
        {
            using (FormRegistrarPelicula formRegistrar = new FormRegistrarPelicula())
            {
                DialogResult resultado = formRegistrar.ShowDialog();

                if (resultado == DialogResult.OK)
                {
                    int nuevoId = DGVPeliculas.Rows.Count + 1;

                    int n = DGVPeliculas.Rows.Add();
                    DGVPeliculas.Rows[n].Cells[0].Value = formRegistrar.Titulo;
                    DGVPeliculas.Rows[n].Cells[1].Value = formRegistrar.Duracion + " min"; 
                    DGVPeliculas.Rows[n].Cells[2].Value = formRegistrar.Sinopsis; 
                    DGVPeliculas.Rows[n].Cells[3].Value = formRegistrar.Desde.ToShortDateString();
                    DGVPeliculas.Rows[n].Cells[4].Value = formRegistrar.Hasta.ToShortDateString();
                    DGVPeliculas.Rows[n].Cells[5].Value = formRegistrar.EtiquetaSeleccionada;
                    DGVPeliculas.Rows[n].Cells[6].Value = "Activo";
                    DGVPeliculas.Rows[n].Cells[7].Value = nuevoId; // ID Oculto

                    MessageBox.Show($"Película '{formRegistrar.Titulo}' agregada con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }


        // Evento para manejar los clics en los botones de modificar y eliminar dentro del DataGridView
        private void DGVPeliculas_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && !DGVPeliculas.Rows[e.RowIndex].IsNewRow)
            {
                string nombreColumna = DGVPeliculas.Columns[e.ColumnIndex].Name;

                // Leemos los datos actuales de la fila seleccionada
                int idPelicula = Convert.ToInt32(DGVPeliculas.Rows[e.RowIndex].Cells[7].Value);
                string tituloActual = DGVPeliculas.Rows[e.RowIndex].Cells[0].Value?.ToString() ?? "";

                // Limpiamos el texto " min" para pasarlo como número entero al formulario de modificación
                string duracionTexto = DGVPeliculas.Rows[e.RowIndex].Cells[1].Value?.ToString().Replace(" min", "") ?? "0"; // Columna 1
                int.TryParse(duracionTexto, out int duracionActual);

                string sinopsisActual = DGVPeliculas.Rows[e.RowIndex].Cells[2].Value?.ToString() ?? ""; 
                DateTime desdeActual = Convert.ToDateTime(DGVPeliculas.Rows[e.RowIndex].Cells[3].Value);
                DateTime hastaActual = Convert.ToDateTime(DGVPeliculas.Rows[e.RowIndex].Cells[4].Value);
                string etiquetaActual = DGVPeliculas.Rows[e.RowIndex].Cells[5].Value?.ToString() ?? "";
                string estadoActual = DGVPeliculas.Rows[e.RowIndex].Cells[6].Value?.ToString() ?? "Activo";

                if (nombreColumna == "CModificar")
                {
                    using (FormRegistrarPelicula formModificar = new FormRegistrarPelicula())
                    {
                        formModificar.CargarDatos(tituloActual, duracionActual, desdeActual, hastaActual, sinopsisActual, etiquetaActual);
                        DialogResult resultado = formModificar.ShowDialog();

                        if (resultado == DialogResult.OK)
                        {
                            // Actualizamos la grilla visualmente
                            DGVPeliculas.Rows[e.RowIndex].Cells[0].Value = formModificar.Titulo;
                            DGVPeliculas.Rows[e.RowIndex].Cells[1].Value = formModificar.Duracion + " min";
                            DGVPeliculas.Rows[e.RowIndex].Cells[2].Value = formModificar.Sinopsis;
                            DGVPeliculas.Rows[e.RowIndex].Cells[3].Value = formModificar.Desde.ToShortDateString();
                            DGVPeliculas.Rows[e.RowIndex].Cells[4].Value = formModificar.Hasta.ToShortDateString();
                            DGVPeliculas.Rows[e.RowIndex].Cells[5].Value = formModificar.EtiquetaSeleccionada;
                            

                            MessageBox.Show("Película modificada correctamente.", "Modificado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
                else if (nombreColumna == "CEliminar")
                {
                    string nuevoEstado = (estadoActual == "Activo") ? "Inactivo" : "Activo";
                    DGVPeliculas.Rows[e.RowIndex].Cells[6].Value = nuevoEstado;

                    MessageBox.Show($"La película '{tituloActual}' cambió su estado a '{nuevoEstado}'.", "Estado Actualizado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        // Método para aplicar los filtros de búsqueda y selección en el DataGridView
        private void AplicarFiltros()
        {
            string textoBusqueda = TBuscar?.Text.Trim().ToLower() ?? "";

            // Si el texto es el placeholder, lo tratamos como vacío para que no filtre por esas palabras
            if (textoBusqueda == placeholderTexto.ToLower())
            {
                textoBusqueda = "";
            }

            string etiquetaFiltro = CBEtiqueta?.SelectedItem?.ToString() ?? "Todas";
            string estadoFiltro = CBEstado?.SelectedItem?.ToString() ?? "Todos";

            foreach (DataGridViewRow row in DGVPeliculas.Rows)
            {
                if (row.IsNewRow) continue;

                // Obtenemos los valores de forma segura
                string titulo = row.Cells[0].Value?.ToString().ToLower() ?? "";
                string etiqueta = row.Cells[5].Value?.ToString().Trim() ?? "";
                string estado = row.Cells[6].Value?.ToString().Trim() ?? "";

                // Evaluamos las condiciones
                bool cumpleTexto = string.IsNullOrEmpty(textoBusqueda) || titulo.Contains(textoBusqueda);

                bool cumpleEtiqueta = etiquetaFiltro.Equals("Todas", StringComparison.OrdinalIgnoreCase) ||
                                      etiqueta.Equals(etiquetaFiltro, StringComparison.OrdinalIgnoreCase);

                bool cumpleEstado = estadoFiltro.Equals("Todos", StringComparison.OrdinalIgnoreCase) ||
                                    estado.Equals(estadoFiltro, StringComparison.OrdinalIgnoreCase);

                // Mostramos u ocultamos la fila
                row.Visible = cumpleTexto && cumpleEtiqueta && cumpleEstado;
            }
        }

        // Eventos para disparar el filtro automáticamente
        private void TBuscar_TextChanged(object sender, EventArgs e)
        {
            AplicarFiltros();
        }

        private void CBEtiqueta_SelectedIndexChanged(object sender, EventArgs e)
        {
            AplicarFiltros();
        }

        private void CBEstado_SelectedIndexChanged(object sender, EventArgs e)
        {
            AplicarFiltros();
        }

        // Evento para manejar el placeholder en el TextBox de búsqueda
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
