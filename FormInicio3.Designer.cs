namespace CinemaCtes
{
    partial class FormInicio3
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblSaludo = new System.Windows.Forms.Label();
            this.pnlTotal = new System.Windows.Forms.Panel();
            this.lblTotalMonto = new System.Windows.Forms.Label();
            this.lblTotalTitulo = new System.Windows.Forms.Label();
            this.btnNuevaVenta = new System.Windows.Forms.Button();
            this.lCartelera = new System.Windows.Forms.Label();
            this.dgvFunciones = new System.Windows.Forms.DataGridView();
            this.colPelicula = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSala = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colHorario = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colButacas = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PHeader = new System.Windows.Forms.Panel();
            this.LFecha = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.pnlTotal.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFunciones)).BeginInit();
            this.PHeader.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblSaludo
            // 
            this.lblSaludo.AutoSize = true;
            this.lblSaludo.Font = new System.Drawing.Font("Segoe UI", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSaludo.ForeColor = System.Drawing.Color.White;
            this.lblSaludo.Location = new System.Drawing.Point(272, 83);
            this.lblSaludo.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblSaludo.Name = "lblSaludo";
            this.lblSaludo.Size = new System.Drawing.Size(177, 30);
            this.lblSaludo.TabIndex = 1;
            this.lblSaludo.Text = "¡Hola, Vendedor!";
            // 
            // pnlTotal
            // 
            this.pnlTotal.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(30)))), ((int)(((byte)(55)))));
            this.pnlTotal.Controls.Add(this.lblTotalMonto);
            this.pnlTotal.Controls.Add(this.lblTotalTitulo);
            this.pnlTotal.Location = new System.Drawing.Point(44, 125);
            this.pnlTotal.Margin = new System.Windows.Forms.Padding(2);
            this.pnlTotal.Name = "pnlTotal";
            this.pnlTotal.Size = new System.Drawing.Size(165, 57);
            this.pnlTotal.TabIndex = 2;
            // 
            // lblTotalMonto
            // 
            this.lblTotalMonto.AutoSize = true;
            this.lblTotalMonto.Font = new System.Drawing.Font("Segoe UI", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalMonto.ForeColor = System.Drawing.Color.White;
            this.lblTotalMonto.Location = new System.Drawing.Point(34, 21);
            this.lblTotalMonto.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTotalMonto.Name = "lblTotalMonto";
            this.lblTotalMonto.Size = new System.Drawing.Size(129, 30);
            this.lblTotalMonto.TabIndex = 3;
            this.lblTotalMonto.Text = "$ 10000,00";
            // 
            // lblTotalTitulo
            // 
            this.lblTotalTitulo.AutoSize = true;
            this.lblTotalTitulo.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalTitulo.ForeColor = System.Drawing.Color.White;
            this.lblTotalTitulo.Location = new System.Drawing.Point(10, 7);
            this.lblTotalTitulo.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTotalTitulo.Name = "lblTotalTitulo";
            this.lblTotalTitulo.Size = new System.Drawing.Size(137, 13);
            this.lblTotalTitulo.TabIndex = 3;
            this.lblTotalTitulo.Text = "TOTAL RECAUDADO HOY";
            // 
            // btnNuevaVenta
            // 
            this.btnNuevaVenta.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNuevaVenta.Font = new System.Drawing.Font("Segoe UI", 13.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNuevaVenta.ForeColor = System.Drawing.Color.White;
            this.btnNuevaVenta.Location = new System.Drawing.Point(486, 132);
            this.btnNuevaVenta.Margin = new System.Windows.Forms.Padding(2);
            this.btnNuevaVenta.Name = "btnNuevaVenta";
            this.btnNuevaVenta.Size = new System.Drawing.Size(182, 47);
            this.btnNuevaVenta.TabIndex = 3;
            this.btnNuevaVenta.Text = "🎬 NUEVA VENTA ";
            this.btnNuevaVenta.UseVisualStyleBackColor = true;
            // 
            // lCartelera
            // 
            this.lCartelera.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lCartelera.AutoSize = true;
            this.lCartelera.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lCartelera.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.lCartelera.Location = new System.Drawing.Point(12, 213);
            this.lCartelera.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lCartelera.Name = "lCartelera";
            this.lCartelera.Size = new System.Drawing.Size(338, 20);
            this.lCartelera.TabIndex = 4;
            this.lCartelera.Text = "Funciones Próximas a Iniciar (Cartelera Activa):";
            // 
            // dgvFunciones
            // 
            this.dgvFunciones.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvFunciones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvFunciones.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colPelicula,
            this.colSala,
            this.colHorario,
            this.colButacas});
            this.dgvFunciones.Location = new System.Drawing.Point(0, 235);
            this.dgvFunciones.Margin = new System.Windows.Forms.Padding(2);
            this.dgvFunciones.Name = "dgvFunciones";
            this.dgvFunciones.ReadOnly = true;
            this.dgvFunciones.RowHeadersVisible = false;
            this.dgvFunciones.RowHeadersWidth = 51;
            this.dgvFunciones.RowTemplate.Height = 24;
            this.dgvFunciones.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvFunciones.Size = new System.Drawing.Size(734, 226);
            this.dgvFunciones.TabIndex = 5;
            // 
            // colPelicula
            // 
            this.colPelicula.HeaderText = "Pelicula";
            this.colPelicula.MinimumWidth = 6;
            this.colPelicula.Name = "colPelicula";
            this.colPelicula.ReadOnly = true;
            // 
            // colSala
            // 
            this.colSala.HeaderText = "Sala";
            this.colSala.MinimumWidth = 6;
            this.colSala.Name = "colSala";
            this.colSala.ReadOnly = true;
            // 
            // colHorario
            // 
            this.colHorario.HeaderText = "Horario";
            this.colHorario.MinimumWidth = 6;
            this.colHorario.Name = "colHorario";
            this.colHorario.ReadOnly = true;
            // 
            // colButacas
            // 
            this.colButacas.HeaderText = "Butacas";
            this.colButacas.MinimumWidth = 6;
            this.colButacas.Name = "colButacas";
            this.colButacas.ReadOnly = true;
            // 
            // PHeader
            // 
            this.PHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(60)))));
            this.PHeader.Controls.Add(this.LFecha);
            this.PHeader.Controls.Add(this.label2);
            this.PHeader.Controls.Add(this.label1);
            this.PHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.PHeader.Location = new System.Drawing.Point(0, 0);
            this.PHeader.Name = "PHeader";
            this.PHeader.Size = new System.Drawing.Size(734, 65);
            this.PHeader.TabIndex = 6;
            // 
            // LFecha
            // 
            this.LFecha.AutoSize = true;
            this.LFecha.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.LFecha.ForeColor = System.Drawing.Color.White;
            this.LFecha.Location = new System.Drawing.Point(512, 21);
            this.LFecha.Name = "LFecha";
            this.LFecha.Size = new System.Drawing.Size(47, 15);
            this.LFecha.TabIndex = 1;
            this.LFecha.Text = "[Fecha]";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(12, 36);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(129, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Vista general - Dashboard";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(12, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(212, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "CinemaCtes - Panel Principal";
            // 
            // FormInicio3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(18)))), ((int)(((byte)(38)))));
            this.ClientSize = new System.Drawing.Size(734, 461);
            this.Controls.Add(this.PHeader);
            this.Controls.Add(this.dgvFunciones);
            this.Controls.Add(this.lCartelera);
            this.Controls.Add(this.btnNuevaVenta);
            this.Controls.Add(this.pnlTotal);
            this.Controls.Add(this.lblSaludo);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "FormInicio3";
            this.Text = "CineMaCtes - Panel de Venta";
            this.Load += new System.EventHandler(this.lblCartelera_Load);
            this.pnlTotal.ResumeLayout(false);
            this.pnlTotal.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFunciones)).EndInit();
            this.PHeader.ResumeLayout(false);
            this.PHeader.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblSaludo;
        private System.Windows.Forms.Panel pnlTotal;
        private System.Windows.Forms.Label lblTotalTitulo;
        private System.Windows.Forms.Label lblTotalMonto;
        private System.Windows.Forms.Button btnNuevaVenta;
        private System.Windows.Forms.Label lCartelera;
        private System.Windows.Forms.DataGridView dgvFunciones;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPelicula;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSala;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHorario;
        private System.Windows.Forms.DataGridViewTextBoxColumn colButacas;
        private System.Windows.Forms.Panel PHeader;
        private System.Windows.Forms.Label LFecha;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}

