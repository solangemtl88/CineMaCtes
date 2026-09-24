namespace CinemaCtes
{
    partial class FormInicio2
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
            this.lTitulo = new System.Windows.Forms.Label();
            this.pRecaudacion = new System.Windows.Forms.Panel();
            this.lMonto = new System.Windows.Forms.Label();
            this.lRecaudacion = new System.Windows.Forms.Label();
            this.pEntradas = new System.Windows.Forms.Panel();
            this.lBoletos = new System.Windows.Forms.Label();
            this.lEntradas = new System.Windows.Forms.Label();
            this.pPelicula = new System.Windows.Forms.Panel();
            this.lNombrePel = new System.Windows.Forms.Label();
            this.lPelicula = new System.Windows.Forms.Label();
            this.pBeneficio = new System.Windows.Forms.Panel();
            this.lBeneficioNombre = new System.Windows.Forms.Label();
            this.lBeneficio = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.LPeliculasRecaudacion1 = new System.Windows.Forms.Label();
            this.DGVRecaudacionPelis = new System.Windows.Forms.DataGridView();
            this.LPeliculasRecaudacion = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.BCambiarButaca = new System.Windows.Forms.Button();
            this.CPelicula = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CVentas = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CRecaudacion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PHeader = new System.Windows.Forms.Panel();
            this.LFecha = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.pRecaudacion.SuspendLayout();
            this.pEntradas.SuspendLayout();
            this.pPelicula.SuspendLayout();
            this.pBeneficio.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGVRecaudacionPelis)).BeginInit();
            this.PHeader.SuspendLayout();
            this.SuspendLayout();
            // 
            // lTitulo
            // 
            this.lTitulo.AutoSize = true;
            this.lTitulo.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lTitulo.ForeColor = System.Drawing.Color.White;
            this.lTitulo.Location = new System.Drawing.Point(11, 20);
            this.lTitulo.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lTitulo.Name = "lTitulo";
            this.lTitulo.Size = new System.Drawing.Size(0, 25);
            this.lTitulo.TabIndex = 0;
            // 
            // pRecaudacion
            // 
            this.pRecaudacion.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.pRecaudacion.Controls.Add(this.lMonto);
            this.pRecaudacion.Controls.Add(this.lRecaudacion);
            this.pRecaudacion.Location = new System.Drawing.Point(42, 70);
            this.pRecaudacion.Margin = new System.Windows.Forms.Padding(2);
            this.pRecaudacion.Name = "pRecaudacion";
            this.pRecaudacion.Size = new System.Drawing.Size(281, 61);
            this.pRecaudacion.TabIndex = 2;
            // 
            // lMonto
            // 
            this.lMonto.AutoSize = true;
            this.lMonto.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lMonto.Location = new System.Drawing.Point(142, 30);
            this.lMonto.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lMonto.Name = "lMonto";
            this.lMonto.Size = new System.Drawing.Size(94, 25);
            this.lMonto.TabIndex = 4;
            this.lMonto.Text = "$125.000";
            // 
            // lRecaudacion
            // 
            this.lRecaudacion.AutoSize = true;
            this.lRecaudacion.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lRecaudacion.Location = new System.Drawing.Point(31, 6);
            this.lRecaudacion.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lRecaudacion.Name = "lRecaudacion";
            this.lRecaudacion.Size = new System.Drawing.Size(205, 20);
            this.lRecaudacion.TabIndex = 3;
            this.lRecaudacion.Text = "💵 RECAUDACIÓN DEL DÍA";
            // 
            // pEntradas
            // 
            this.pEntradas.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.pEntradas.Controls.Add(this.lBoletos);
            this.pEntradas.Controls.Add(this.lEntradas);
            this.pEntradas.Location = new System.Drawing.Point(388, 70);
            this.pEntradas.Margin = new System.Windows.Forms.Padding(2);
            this.pEntradas.Name = "pEntradas";
            this.pEntradas.Size = new System.Drawing.Size(281, 61);
            this.pEntradas.TabIndex = 3;
            // 
            // lBoletos
            // 
            this.lBoletos.AutoSize = true;
            this.lBoletos.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lBoletos.Location = new System.Drawing.Point(90, 26);
            this.lBoletos.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lBoletos.Name = "lBoletos";
            this.lBoletos.Size = new System.Drawing.Size(105, 25);
            this.lBoletos.TabIndex = 4;
            this.lBoletos.Text = "45 boletos";
            // 
            // lEntradas
            // 
            this.lEntradas.AutoSize = true;
            this.lEntradas.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lEntradas.Location = new System.Drawing.Point(25, 6);
            this.lEntradas.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lEntradas.Name = "lEntradas";
            this.lEntradas.Size = new System.Drawing.Size(230, 20);
            this.lEntradas.TabIndex = 3;
            this.lEntradas.Text = "🎟️ ENTRADAS VENDIDAS HOY";
            // 
            // pPelicula
            // 
            this.pPelicula.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.pPelicula.Controls.Add(this.lNombrePel);
            this.pPelicula.Controls.Add(this.lPelicula);
            this.pPelicula.Location = new System.Drawing.Point(42, 145);
            this.pPelicula.Margin = new System.Windows.Forms.Padding(2);
            this.pPelicula.Name = "pPelicula";
            this.pPelicula.Size = new System.Drawing.Size(281, 61);
            this.pPelicula.TabIndex = 4;
            // 
            // lNombrePel
            // 
            this.lNombrePel.AutoSize = true;
            this.lNombrePel.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lNombrePel.Location = new System.Drawing.Point(91, 32);
            this.lNombrePel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lNombrePel.Name = "lNombrePel";
            this.lNombrePel.Size = new System.Drawing.Size(149, 25);
            this.lNombrePel.TabIndex = 4;
            this.lNombrePel.Text = "Intensamente 2";
            // 
            // lPelicula
            // 
            this.lPelicula.AutoSize = true;
            this.lPelicula.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lPelicula.Location = new System.Drawing.Point(19, 5);
            this.lPelicula.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lPelicula.Name = "lPelicula";
            this.lPelicula.Size = new System.Drawing.Size(217, 20);
            this.lPelicula.TabIndex = 3;
            this.lPelicula.Text = "🎬 PELÍCULA EN TENDENCIA";
            // 
            // pBeneficio
            // 
            this.pBeneficio.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.pBeneficio.Controls.Add(this.lBeneficioNombre);
            this.pBeneficio.Controls.Add(this.lBeneficio);
            this.pBeneficio.Location = new System.Drawing.Point(388, 145);
            this.pBeneficio.Margin = new System.Windows.Forms.Padding(2);
            this.pBeneficio.Name = "pBeneficio";
            this.pBeneficio.Size = new System.Drawing.Size(281, 61);
            this.pBeneficio.TabIndex = 5;
            // 
            // lBeneficioNombre
            // 
            this.lBeneficioNombre.AutoSize = true;
            this.lBeneficioNombre.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lBeneficioNombre.Location = new System.Drawing.Point(90, 32);
            this.lBeneficioNombre.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lBeneficioNombre.Name = "lBeneficioNombre";
            this.lBeneficioNombre.Size = new System.Drawing.Size(162, 25);
            this.lBeneficioNombre.TabIndex = 4;
            this.lBeneficioNombre.Text = "Estudiante (45%)";
            // 
            // lBeneficio
            // 
            this.lBeneficio.AutoSize = true;
            this.lBeneficio.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lBeneficio.Location = new System.Drawing.Point(25, 5);
            this.lBeneficio.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lBeneficio.Name = "lBeneficio";
            this.lBeneficio.Size = new System.Drawing.Size(224, 20);
            this.lBeneficio.TabIndex = 3;
            this.lBeneficio.Text = "⭐ BENEFICIO MÁS UTILIZADO";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(18)))), ((int)(((byte)(38)))));
            this.panel2.Controls.Add(this.LPeliculasRecaudacion1);
            this.panel2.Controls.Add(this.DGVRecaudacionPelis);
            this.panel2.Controls.Add(this.LPeliculasRecaudacion);
            this.panel2.Controls.Add(this.label8);
            this.panel2.Controls.Add(this.BCambiarButaca);
            this.panel2.Controls.Add(this.pBeneficio);
            this.panel2.Controls.Add(this.pEntradas);
            this.panel2.Controls.Add(this.pRecaudacion);
            this.panel2.Controls.Add(this.pPelicula);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(734, 461);
            this.panel2.TabIndex = 13;
            // 
            // LPeliculasRecaudacion1
            // 
            this.LPeliculasRecaudacion1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.LPeliculasRecaudacion1.AutoSize = true;
            this.LPeliculasRecaudacion1.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LPeliculasRecaudacion1.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.LPeliculasRecaudacion1.Location = new System.Drawing.Point(35, 276);
            this.LPeliculasRecaudacion1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.LPeliculasRecaudacion1.Name = "LPeliculasRecaudacion1";
            this.LPeliculasRecaudacion1.Size = new System.Drawing.Size(281, 20);
            this.LPeliculasRecaudacion1.TabIndex = 15;
            this.LPeliculasRecaudacion1.Text = "Peliculas con mas recaudacion del mes:";
            // 
            // DGVRecaudacionPelis
            // 
            this.DGVRecaudacionPelis.AllowUserToAddRows = false;
            this.DGVRecaudacionPelis.AllowUserToDeleteRows = false;
            this.DGVRecaudacionPelis.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DGVRecaudacionPelis.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGVRecaudacionPelis.Location = new System.Drawing.Point(0, 299);
            this.DGVRecaudacionPelis.Name = "DGVRecaudacionPelis";
            this.DGVRecaudacionPelis.ReadOnly = true;
            this.DGVRecaudacionPelis.Size = new System.Drawing.Size(734, 162);
            this.DGVRecaudacionPelis.TabIndex = 14;
            // 
            // LPeliculasRecaudacion
            // 
            this.LPeliculasRecaudacion.AutoSize = true;
            this.LPeliculasRecaudacion.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.LPeliculasRecaudacion.ForeColor = System.Drawing.Color.White;
            this.LPeliculasRecaudacion.Location = new System.Drawing.Point(39, 263);
            this.LPeliculasRecaudacion.Name = "LPeliculasRecaudacion";
            this.LPeliculasRecaudacion.Size = new System.Drawing.Size(0, 15);
            this.LPeliculasRecaudacion.TabIndex = 13;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.label8.ForeColor = System.Drawing.Color.White;
            this.label8.Location = new System.Drawing.Point(39, 217);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(96, 15);
            this.label8.TabIndex = 12;
            this.label8.Text = "Accesos rapidos";
            // 
            // BCambiarButaca
            // 
            this.BCambiarButaca.Location = new System.Drawing.Point(39, 235);
            this.BCambiarButaca.Name = "BCambiarButaca";
            this.BCambiarButaca.Size = new System.Drawing.Size(154, 23);
            this.BCambiarButaca.TabIndex = 10;
            this.BCambiarButaca.Text = "Activar/desactivar butaca";
            this.BCambiarButaca.UseVisualStyleBackColor = true;
            this.BCambiarButaca.Click += new System.EventHandler(this.BCambiarButaca_Click);
            // 
            // CPelicula
            // 
            this.CPelicula.HeaderText = "Pelicula";
            this.CPelicula.Name = "CPelicula";
            this.CPelicula.Width = 230;
            // 
            // CVentas
            // 
            this.CVentas.HeaderText = "Ventas";
            this.CVentas.Name = "CVentas";
            this.CVentas.ReadOnly = true;
            // 
            // CRecaudacion
            // 
            this.CRecaudacion.HeaderText = "Recaudacion";
            this.CRecaudacion.Name = "CRecaudacion";
            this.CRecaudacion.ReadOnly = true;
            // 
            // PHeader
            // 
            this.PHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(60)))));
            this.PHeader.Controls.Add(this.LFecha);
            this.PHeader.Controls.Add(this.label2);
            this.PHeader.Controls.Add(this.label1);
            this.PHeader.Controls.Add(this.lTitulo);
            this.PHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.PHeader.Location = new System.Drawing.Point(0, 0);
            this.PHeader.Name = "PHeader";
            this.PHeader.Size = new System.Drawing.Size(734, 65);
            this.PHeader.TabIndex = 3;
            // 
            // LFecha
            // 
            this.LFecha.AutoSize = true;
            this.LFecha.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.LFecha.ForeColor = System.Drawing.Color.White;
            this.LFecha.Location = new System.Drawing.Point(512, 21);
            this.LFecha.Name = "LFecha";
            this.LFecha.Size = new System.Drawing.Size(47, 15);
            this.LFecha.TabIndex = 3;
            this.LFecha.Text = "[Fecha]";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(16, 36);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(129, 13);
            this.label2.TabIndex = 1;
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
            this.label1.TabIndex = 2;
            this.label1.Text = "CinemaCtes - Panel Principal";
            // 
            // FormInicio2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(734, 461);
            this.Controls.Add(this.PHeader);
            this.Controls.Add(this.panel2);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "FormInicio2";
            this.Text = "Inicio";
            this.Load += new System.EventHandler(this.FormInicio2_Load);
            this.pRecaudacion.ResumeLayout(false);
            this.pRecaudacion.PerformLayout();
            this.pEntradas.ResumeLayout(false);
            this.pEntradas.PerformLayout();
            this.pPelicula.ResumeLayout(false);
            this.pPelicula.PerformLayout();
            this.pBeneficio.ResumeLayout(false);
            this.pBeneficio.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGVRecaudacionPelis)).EndInit();
            this.PHeader.ResumeLayout(false);
            this.PHeader.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lTitulo;
        private System.Windows.Forms.Panel pRecaudacion;
        private System.Windows.Forms.Label lMonto;
        private System.Windows.Forms.Label lRecaudacion;
        private System.Windows.Forms.Panel pEntradas;
        private System.Windows.Forms.Label lBoletos;
        private System.Windows.Forms.Label lEntradas;
        private System.Windows.Forms.Panel pPelicula;
        private System.Windows.Forms.Label lNombrePel;
        private System.Windows.Forms.Label lPelicula;
        private System.Windows.Forms.Panel pBeneficio;
        private System.Windows.Forms.Label lBeneficioNombre;
        private System.Windows.Forms.Label lBeneficio;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel PHeader;
        private System.Windows.Forms.Label LPeliculasRecaudacion;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button BCambiarButaca;
        private System.Windows.Forms.DataGridView DGVRecaudacionPelis;
        private System.Windows.Forms.DataGridViewTextBoxColumn CPelicula;
        private System.Windows.Forms.DataGridViewTextBoxColumn CVentas;
        private System.Windows.Forms.DataGridViewTextBoxColumn CRecaudacion;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label LFecha;
        private System.Windows.Forms.Label LPeliculasRecaudacion1;
    }
}

