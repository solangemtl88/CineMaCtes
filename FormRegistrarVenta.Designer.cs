namespace CinemaCtes
{
    partial class FormRegistrarVenta
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.CBPelicula = new System.Windows.Forms.ComboBox();
            this.CLBButaca = new System.Windows.Forms.CheckedListBox();
            this.PHeader = new System.Windows.Forms.Panel();
            this.BAñadir = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.DGVVentas = new System.Windows.Forms.DataGridView();
            this.CBHorario = new System.Windows.Forms.ComboBox();
            this.LPelicula = new System.Windows.Forms.Label();
            this.LDni = new System.Windows.Forms.Label();
            this.LHorario = new System.Windows.Forms.Label();
            this.DTPFecha = new System.Windows.Forms.DateTimePicker();
            this.LFecha = new System.Windows.Forms.Label();
            this.LButaca = new System.Windows.Forms.Label();
            this.LMetodoPago = new System.Windows.Forms.Label();
            this.LBeneficio = new System.Windows.Forms.Label();
            this.CBBeneficio = new System.Windows.Forms.ComboBox();
            this.CBMetodoPago = new System.Windows.Forms.ComboBox();
            this.TDni = new System.Windows.Forms.TextBox();
            this.PHeader.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGVVentas)).BeginInit();
            this.SuspendLayout();
            // 
            // CBPelicula
            // 
            this.CBPelicula.FormattingEnabled = true;
            this.CBPelicula.Location = new System.Drawing.Point(52, 32);
            this.CBPelicula.Name = "CBPelicula";
            this.CBPelicula.Size = new System.Drawing.Size(121, 21);
            this.CBPelicula.TabIndex = 0;
            // 
            // CLBButaca
            // 
            this.CLBButaca.FormattingEnabled = true;
            this.CLBButaca.Items.AddRange(new object[] {
            "A1",
            "A2",
            "A3",
            "A4",
            "A5",
            "A6"});
            this.CLBButaca.Location = new System.Drawing.Point(354, 43);
            this.CLBButaca.Name = "CLBButaca";
            this.CLBButaca.Size = new System.Drawing.Size(120, 94);
            this.CLBButaca.TabIndex = 2;
            // 
            // PHeader
            // 
            this.PHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(60)))));
            this.PHeader.Controls.Add(this.label2);
            this.PHeader.Controls.Add(this.label1);
            this.PHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.PHeader.Location = new System.Drawing.Point(0, 0);
            this.PHeader.Name = "PHeader";
            this.PHeader.Size = new System.Drawing.Size(734, 65);
            this.PHeader.TabIndex = 3;
            // 
            // BAñadir
            // 
            this.BAñadir.BackColor = System.Drawing.Color.AliceBlue;
            this.BAñadir.Location = new System.Drawing.Point(559, 77);
            this.BAñadir.Name = "BAñadir";
            this.BAñadir.Size = new System.Drawing.Size(113, 27);
            this.BAñadir.TabIndex = 1;
            this.BAñadir.Text = "Añadir beneficio";
            this.BAñadir.UseVisualStyleBackColor = false;
            this.BAñadir.Click += new System.EventHandler(this.BConfirmarVenta_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(12, 36);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(166, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Registra y consulta ventas del dia";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(12, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(146, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Registro de Ventas";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(18)))), ((int)(((byte)(38)))));
            this.panel3.Controls.Add(this.TDni);
            this.panel3.Controls.Add(this.LMetodoPago);
            this.panel3.Controls.Add(this.LBeneficio);
            this.panel3.Controls.Add(this.CBBeneficio);
            this.panel3.Controls.Add(this.CBMetodoPago);
            this.panel3.Controls.Add(this.LButaca);
            this.panel3.Controls.Add(this.LFecha);
            this.panel3.Controls.Add(this.DTPFecha);
            this.panel3.Controls.Add(this.LHorario);
            this.panel3.Controls.Add(this.LDni);
            this.panel3.Controls.Add(this.LPelicula);
            this.panel3.Controls.Add(this.CBHorario);
            this.panel3.Controls.Add(this.BAñadir);
            this.panel3.Controls.Add(this.CLBButaca);
            this.panel3.Controls.Add(this.CBPelicula);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 65);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(734, 206);
            this.panel3.TabIndex = 5;
            // 
            // DGVVentas
            // 
            this.DGVVentas.AllowUserToAddRows = false;
            this.DGVVentas.AllowUserToDeleteRows = false;
            this.DGVVentas.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DGVVentas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGVVentas.Location = new System.Drawing.Point(0, 277);
            this.DGVVentas.Name = "DGVVentas";
            this.DGVVentas.ReadOnly = true;
            this.DGVVentas.Size = new System.Drawing.Size(734, 188);
            this.DGVVentas.TabIndex = 9;
            // 
            // CBHorario
            // 
            this.CBHorario.FormattingEnabled = true;
            this.CBHorario.Location = new System.Drawing.Point(52, 83);
            this.CBHorario.Name = "CBHorario";
            this.CBHorario.Size = new System.Drawing.Size(121, 21);
            this.CBHorario.TabIndex = 3;
            // 
            // LPelicula
            // 
            this.LPelicula.AutoSize = true;
            this.LPelicula.ForeColor = System.Drawing.Color.White;
            this.LPelicula.Location = new System.Drawing.Point(90, 16);
            this.LPelicula.Name = "LPelicula";
            this.LPelicula.Size = new System.Drawing.Size(44, 13);
            this.LPelicula.TabIndex = 6;
            this.LPelicula.Text = "Pelicula";
            // 
            // LDni
            // 
            this.LDni.AutoSize = true;
            this.LDni.ForeColor = System.Drawing.Color.White;
            this.LDni.Location = new System.Drawing.Point(240, 67);
            this.LDni.Name = "LDni";
            this.LDni.Size = new System.Drawing.Size(26, 13);
            this.LDni.TabIndex = 7;
            this.LDni.Text = "DNI";
            // 
            // LHorario
            // 
            this.LHorario.AutoSize = true;
            this.LHorario.ForeColor = System.Drawing.Color.White;
            this.LHorario.Location = new System.Drawing.Point(91, 67);
            this.LHorario.Name = "LHorario";
            this.LHorario.Size = new System.Drawing.Size(41, 13);
            this.LHorario.TabIndex = 8;
            this.LHorario.Text = "Horario";
            // 
            // DTPFecha
            // 
            this.DTPFecha.Location = new System.Drawing.Point(195, 33);
            this.DTPFecha.Name = "DTPFecha";
            this.DTPFecha.Size = new System.Drawing.Size(121, 20);
            this.DTPFecha.TabIndex = 9;
            // 
            // LFecha
            // 
            this.LFecha.AutoSize = true;
            this.LFecha.ForeColor = System.Drawing.Color.White;
            this.LFecha.Location = new System.Drawing.Point(234, 16);
            this.LFecha.Name = "LFecha";
            this.LFecha.Size = new System.Drawing.Size(37, 13);
            this.LFecha.TabIndex = 10;
            this.LFecha.Text = "Fecha";
            // 
            // LButaca
            // 
            this.LButaca.AutoSize = true;
            this.LButaca.ForeColor = System.Drawing.Color.White;
            this.LButaca.Location = new System.Drawing.Point(365, 27);
            this.LButaca.Name = "LButaca";
            this.LButaca.Size = new System.Drawing.Size(96, 13);
            this.LButaca.TabIndex = 11;
            this.LButaca.Text = "Butaca disponibles";
            // 
            // LMetodoPago
            // 
            this.LMetodoPago.AutoSize = true;
            this.LMetodoPago.ForeColor = System.Drawing.Color.White;
            this.LMetodoPago.Location = new System.Drawing.Point(69, 118);
            this.LMetodoPago.Name = "LMetodoPago";
            this.LMetodoPago.Size = new System.Drawing.Size(86, 13);
            this.LMetodoPago.TabIndex = 15;
            this.LMetodoPago.Text = "Metodo de Pago";
            // 
            // LBeneficio
            // 
            this.LBeneficio.AutoSize = true;
            this.LBeneficio.ForeColor = System.Drawing.Color.White;
            this.LBeneficio.Location = new System.Drawing.Point(230, 118);
            this.LBeneficio.Name = "LBeneficio";
            this.LBeneficio.Size = new System.Drawing.Size(51, 13);
            this.LBeneficio.TabIndex = 14;
            this.LBeneficio.Text = "Beneficio";
            // 
            // CBBeneficio
            // 
            this.CBBeneficio.FormattingEnabled = true;
            this.CBBeneficio.Location = new System.Drawing.Point(195, 134);
            this.CBBeneficio.Name = "CBBeneficio";
            this.CBBeneficio.Size = new System.Drawing.Size(121, 21);
            this.CBBeneficio.TabIndex = 13;
            // 
            // CBMetodoPago
            // 
            this.CBMetodoPago.FormattingEnabled = true;
            this.CBMetodoPago.Location = new System.Drawing.Point(52, 134);
            this.CBMetodoPago.Name = "CBMetodoPago";
            this.CBMetodoPago.Size = new System.Drawing.Size(121, 21);
            this.CBMetodoPago.TabIndex = 12;
            // 
            // TDni
            // 
            this.TDni.Location = new System.Drawing.Point(195, 83);
            this.TDni.Name = "TDni";
            this.TDni.Size = new System.Drawing.Size(121, 20);
            this.TDni.TabIndex = 16;
            this.TDni.TextChanged += new System.EventHandler(this.TDni_TextChanged);
            // 
            // FormRegistrarVenta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(734, 461);
            this.Controls.Add(this.DGVVentas);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.PHeader);
            this.Name = "FormRegistrarVenta";
            this.Text = "FormRegistrarVenta";
            this.Load += new System.EventHandler(this.FormRegistrarVenta_Load);
            this.PHeader.ResumeLayout(false);
            this.PHeader.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGVVentas)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox CBPelicula;
        private System.Windows.Forms.CheckedListBox CLBButaca;
        private System.Windows.Forms.Panel PHeader;
        private System.Windows.Forms.Button BAñadir;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.DataGridView DGVVentas;
        private System.Windows.Forms.ComboBox CBHorario;
        private System.Windows.Forms.Label LHorario;
        private System.Windows.Forms.Label LDni;
        private System.Windows.Forms.Label LPelicula;
        private System.Windows.Forms.Label LFecha;
        private System.Windows.Forms.DateTimePicker DTPFecha;
        private System.Windows.Forms.Label LMetodoPago;
        private System.Windows.Forms.Label LBeneficio;
        private System.Windows.Forms.ComboBox CBBeneficio;
        private System.Windows.Forms.ComboBox CBMetodoPago;
        private System.Windows.Forms.Label LButaca;
        private System.Windows.Forms.TextBox TDni;
    }
}