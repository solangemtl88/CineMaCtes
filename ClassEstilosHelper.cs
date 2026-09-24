using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace CinemaCtes
{
    public static class ClassEstilosHelper
    {
        public static void AplicarEstiloTabla(DataGridView dgv)
        {
            // Opciones de comportamiento
            dgv.AllowUserToAddRows = false;
            dgv.AllowUserToDeleteRows = false;
            dgv.ReadOnly = true;
            dgv.RowHeadersVisible = false;
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv.MultiSelect = false;
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv.BorderStyle = BorderStyle.None;
            dgv.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgv.GridColor = Color.FromArgb(38, 42, 60);

            // Estilo de encabezados
            dgv.EnableHeadersVisualStyles = false;
            dgv.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dgv.ColumnHeadersHeight = 38;
            dgv.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(20, 24, 40);
            dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgv.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10.5F, FontStyle.Bold);
            dgv.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

            // Estilo de las filas
            dgv.BackgroundColor = Color.FromArgb(18, 20, 32);
            dgv.DefaultCellStyle.BackColor = Color.FromArgb(18, 20, 32);
            dgv.DefaultCellStyle.ForeColor = Color.FromArgb(210, 215, 230);
            dgv.DefaultCellStyle.Font = new Font("Segoe UI", 10F, FontStyle.Regular);
            dgv.DefaultCellStyle.SelectionBackColor = Color.FromArgb(48, 38, 75);
            dgv.DefaultCellStyle.SelectionForeColor = Color.White;
            dgv.RowTemplate.Height = 36;
        }
    }
}
