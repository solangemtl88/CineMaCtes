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
    public partial class FormRegistrarVenta : Form
    {
        public FormRegistrarVenta()
        {
            InitializeComponent();
        }

        private void FormRegistrarVenta_Load(object sender, EventArgs e)
        {
            CargarDatosMaquetaComboBoxes();
            CargarGrillaVentasMaqueta();
        }

        private void CargarDatosMaquetaComboBoxes()
        {
            // 1. Películas de prueba
            CBPelicula.Items.Add("Intensamente 2");
            CBPelicula.Items.Add("Deadpool y Wolverine");
            CBPelicula.Items.Add("Duna: Parte 2");
            CBPelicula.SelectedIndex = 0; // Selecciona la primera por defecto

            // 2. Horarios de prueba
            CBHorario.Items.Add("16:00 hs");
            CBHorario.Items.Add("19:00 hs");
            CBHorario.Items.Add("22:30 hs");
            CBHorario.SelectedIndex = 0;

            // 4. Método de pago
            CBMetodoPago.Items.Add("Efectivo");
            CBMetodoPago.Items.Add("Tarjeta de Débito");
            CBMetodoPago.Items.Add("Mercado Pago");
            CBMetodoPago.SelectedIndex = 0;

            // 5. Beneficios / Descuentos
            CBBeneficio.Items.Add("Ninguno");
            CBBeneficio.Items.Add("Estudiante (45%)");
            CBBeneficio.Items.Add("Jubilados (30%)");
            CBBeneficio.SelectedIndex = 0;
        }

        private void CargarGrillaVentasMaqueta()
        {
            // Creamos una tabla temporal en memoria para la grilla inferior
            DataTable dtVentas = new DataTable();
            dtVentas.Columns.Add("NroVenta", typeof(int));
            dtVentas.Columns.Add("butacas", typeof(string));
            dtVentas.Columns.Add("Monto Total", typeof(decimal));

            // Agregamos un par de ventas ficticias realizadas en el día
            dtVentas.Rows.Add(101, "A1, A2", 9000.00m);
            dtVentas.Rows.Add(102, "B4", 4500.00m);
            dtVentas.Rows.Add(103, "C1, C2, C3", 13500.00m);

            DGVVentas.DataSource = dtVentas;
            DGVVentas.Columns["Monto Total"].DefaultCellStyle.Format = "C2";
        }

        private void BConfirmarVenta_Click(object sender, EventArgs e)
        {
            // VALIDACIONES
            // Verificar que se haya seleccionado al menos una butaca en el CheckedListBox
            if (CLBButaca.CheckedItems.Count == 0)
            {
                MessageBox.Show(
                    "Debe seleccionar al menos una butaca para realizar la venta.",
                    "Error de validación",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
                return;
            }

            // Validar el campo DNI (No vacío y longitud correcta)
            string dniTexto = TDni.Text.Trim(); 

            if (string.IsNullOrWhiteSpace(dniTexto))
            {
                MessageBox.Show(
                    "El campo DNI es obligatorio.",
                    "Error de validación",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
                TDni.Focus();
                return;
            }

            if (dniTexto.Length < 7 || dniTexto.Length > 8)
            {
                MessageBox.Show(
                    "El DNI ingresado no es válido. Debe tener entre 7 y 8 dígitos.",
                    "Longitud incorrecta",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                TDni.Focus();
                return;
            }

            // Verificar que los ComboBox tengan una selección válida
            if (CBPelicula.SelectedItem == null || CBHorario.SelectedItem == null || CBMetodoPago.SelectedItem == null)
            {
                MessageBox.Show(
                    "Por favor, complete todos los campos obligatorios de la venta.",
                    "Campos incompletos",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return;
            }

            // Recopilar las butacas tildadas para el mensaje
            string butacasSeleccionadas = "";
            foreach (var item in CLBButaca.CheckedItems)
            {
                butacasSeleccionadas += item.ToString() + " ";
            }

            // MENSAJE DE CONFIRMACIÓN
            DialogResult confirmacion = MessageBox.Show(
                $"¿Desea confirmar la venta para la película '{CBPelicula.Text}'?\n" +
                $"Horario: {CBHorario.Text}\n" +
                $"Butacas: {butacasSeleccionadas.Trim()}\n" +
                $"Método de Pago: {CBMetodoPago.Text}",
                "Confirmar Venta",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (confirmacion == DialogResult.Yes)
            {
                //SIMULACIÓN DE CÁLCULO DE MONTO (ej: $4500 por cada butaca seleccionada)
                int cantidadBoletos = CLBButaca.CheckedItems.Count;
                decimal montoTotal = cantidadBoletos * 4500.00m;

                //REFRESCAR LA GRILLA INFERIOR (Añadir la venta al DataTable actual)
               
                if (DGVVentas.DataSource is DataTable dtVentas)
                {
                    int nuevoNroVenta = dtVentas.Rows.Count + 101; // Generamos un número de venta ficticio consecutivo
                    dtVentas.Rows.Add(nuevoNroVenta, butacasSeleccionadas.Trim(), montoTotal);
                }

                MessageBox.Show(
                    "¡Venta registrada con éxito en el sistema!",
                    "Operación Exitosa",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );

                // LIMPIAR SELECCIÓN DE BUTACAS PARA LA PRÓXIMA VENTA
                for (int i = 0; i < CLBButaca.Items.Count; i++)
                {
                    CLBButaca.SetItemChecked(i, false);
                }
            }
        }

        private void TDni_TextChanged(object sender, EventArgs e)
        {
            // Guardamos la posición actual del cursor
            int cursorPosition = TDni.SelectionStart;

            // Filtramos el texto actual para conservar únicamente los dígitos numéricos
            string textoFiltrado = new string(TDni.Text.Where(char.IsDigit).ToArray());

            // Si el texto contenía letras o símbolos no permitidos, lo actualizamos
            if (TDni.Text != textoFiltrado)
            {
                TDni.Text = textoFiltrado;

                // Restauramos la posición del cursor de forma segura
                TDni.SelectionStart = Math.Min(cursorPosition, TDni.Text.Length);
            }
        }
    }
}
