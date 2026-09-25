namespace CinemaCtes
{
    partial class FormVentas
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.PHeader = new System.Windows.Forms.Panel();
            this.BAñadir = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.DTPFecha = new System.Windows.Forms.DateTimePicker();
            this.LFecha = new System.Windows.Forms.Label();
            this.LBeneficio = new System.Windows.Forms.Label();
            this.CBBeneficio = new System.Windows.Forms.ComboBox();
            this.LBuscar = new System.Windows.Forms.Label();
            this.LEstado = new System.Windows.Forms.Label();
            this.LPelicula = new System.Windows.Forms.Label();
            this.CBPelicula = new System.Windows.Forms.ComboBox();
            this.CBEstado = new System.Windows.Forms.ComboBox();
            this.TBuscar = new System.Windows.Forms.TextBox();
            this.DGVVentas = new System.Windows.Forms.DataGridView();
            this.CIdVenta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CFecha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CDni = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CPelicula = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CSala = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CBeneficio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CMonto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CEstado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PHeader.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGVVentas)).BeginInit();
            this.SuspendLayout();
            // 
            // PHeader
            // 
            this.PHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(60)))));
            this.PHeader.Controls.Add(this.BAñadir);
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
            this.BAñadir.Location = new System.Drawing.Point(574, 22);
            this.BAñadir.Name = "BAñadir";
            this.BAñadir.Size = new System.Drawing.Size(148, 27);
            this.BAñadir.TabIndex = 1;
            this.BAñadir.Text = "Modificar precio de boletos";
            this.BAñadir.UseVisualStyleBackColor = false;
            this.BAñadir.Click += new System.EventHandler(this.BtnModificarPrecios_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(12, 36);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(177, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Administra beneficios y promociones";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(12, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(322, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Historial General de Ventas y Transacciones";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(18)))), ((int)(((byte)(38)))));
            this.panel3.Controls.Add(this.DTPFecha);
            this.panel3.Controls.Add(this.LFecha);
            this.panel3.Controls.Add(this.LBeneficio);
            this.panel3.Controls.Add(this.CBBeneficio);
            this.panel3.Controls.Add(this.LBuscar);
            this.panel3.Controls.Add(this.LEstado);
            this.panel3.Controls.Add(this.LPelicula);
            this.panel3.Controls.Add(this.CBPelicula);
            this.panel3.Controls.Add(this.CBEstado);
            this.panel3.Controls.Add(this.TBuscar);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 65);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(734, 51);
            this.panel3.TabIndex = 4;
            // 
            // DTPFecha
            // 
            this.DTPFecha.Location = new System.Drawing.Point(222, 23);
            this.DTPFecha.Name = "DTPFecha";
            this.DTPFecha.Size = new System.Drawing.Size(112, 20);
            this.DTPFecha.TabIndex = 9;
            this.DTPFecha.ValueChanged += new System.EventHandler(this.DTPFecha_ValueChanged);
            // 
            // LFecha
            // 
            this.LFecha.AutoSize = true;
            this.LFecha.ForeColor = System.Drawing.Color.White;
            this.LFecha.Location = new System.Drawing.Point(257, 7);
            this.LFecha.Name = "LFecha";
            this.LFecha.Size = new System.Drawing.Size(37, 13);
            this.LFecha.TabIndex = 8;
            this.LFecha.Text = "Fecha";
            // 
            // LBeneficio
            // 
            this.LBeneficio.AutoSize = true;
            this.LBeneficio.ForeColor = System.Drawing.Color.White;
            this.LBeneficio.Location = new System.Drawing.Point(384, 7);
            this.LBeneficio.Name = "LBeneficio";
            this.LBeneficio.Size = new System.Drawing.Size(51, 13);
            this.LBeneficio.TabIndex = 6;
            this.LBeneficio.Text = "Beneficio";
            // 
            // CBBeneficio
            // 
            this.CBBeneficio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CBBeneficio.FormattingEnabled = true;
            this.CBBeneficio.Items.AddRange(new object[] {
            "Todos",
            "Promoción",
            "Descuento"});
            this.CBBeneficio.Location = new System.Drawing.Point(347, 23);
            this.CBBeneficio.Name = "CBBeneficio";
            this.CBBeneficio.Size = new System.Drawing.Size(121, 21);
            this.CBBeneficio.TabIndex = 5;
            this.CBBeneficio.SelectedIndexChanged += new System.EventHandler(this.CBBeneficio_SelectedIndexChanged);
            // 
            // LBuscar
            // 
            this.LBuscar.Location = new System.Drawing.Point(-3, 0);
            this.LBuscar.Name = "LBuscar";
            this.LBuscar.Size = new System.Drawing.Size(100, 23);
            this.LBuscar.TabIndex = 0;
            // 
            // LEstado
            // 
            this.LEstado.AutoSize = true;
            this.LEstado.ForeColor = System.Drawing.Color.White;
            this.LEstado.Location = new System.Drawing.Point(640, 7);
            this.LEstado.Name = "LEstado";
            this.LEstado.Size = new System.Drawing.Size(40, 13);
            this.LEstado.TabIndex = 4;
            this.LEstado.Text = "Estado";
            // 
            // LPelicula
            // 
            this.LPelicula.AutoSize = true;
            this.LPelicula.ForeColor = System.Drawing.Color.White;
            this.LPelicula.Location = new System.Drawing.Point(511, 7);
            this.LPelicula.Name = "LPelicula";
            this.LPelicula.Size = new System.Drawing.Size(44, 13);
            this.LPelicula.TabIndex = 3;
            this.LPelicula.Text = "Pelicula";
            // 
            // CBPelicula
            // 
            this.CBPelicula.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CBPelicula.FormattingEnabled = true;
            this.CBPelicula.Items.AddRange(new object[] {
            "Todos",
            "Promoción",
            "Descuento"});
            this.CBPelicula.Location = new System.Drawing.Point(474, 23);
            this.CBPelicula.Name = "CBPelicula";
            this.CBPelicula.Size = new System.Drawing.Size(121, 21);
            this.CBPelicula.TabIndex = 2;
            this.CBPelicula.SelectedIndexChanged += new System.EventHandler(this.CBPelicula_SelectedIndexChanged);
            // 
            // CBEstado
            // 
            this.CBEstado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CBEstado.FormattingEnabled = true;
            this.CBEstado.Items.AddRange(new object[] {
            "Todos",
            "Activo",
            "Inactivo"});
            this.CBEstado.Location = new System.Drawing.Point(601, 23);
            this.CBEstado.Name = "CBEstado";
            this.CBEstado.Size = new System.Drawing.Size(121, 21);
            this.CBEstado.TabIndex = 1;
            this.CBEstado.SelectedIndexChanged += new System.EventHandler(this.CBEstado_SelectedIndexChanged);
            // 
            // TBuscar
            // 
            this.TBuscar.ForeColor = System.Drawing.Color.Black;
            this.TBuscar.Location = new System.Drawing.Point(16, 23);
            this.TBuscar.Name = "TBuscar";
            this.TBuscar.Size = new System.Drawing.Size(173, 20);
            this.TBuscar.TabIndex = 0;
            this.TBuscar.TextChanged += new System.EventHandler(this.TBuscar_TextChanged);
            // 
            // DGVVentas
            // 
            this.DGVVentas.AllowUserToAddRows = false;
            this.DGVVentas.AllowUserToDeleteRows = false;
            this.DGVVentas.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DGVVentas.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(18)))), ((int)(((byte)(38)))));
            this.DGVVentas.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(27)))), ((int)(((byte)(56)))));
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DGVVentas.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.DGVVentas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGVVentas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CIdVenta,
            this.CFecha,
            this.CDni,
            this.CPelicula,
            this.CSala,
            this.CBeneficio,
            this.CMonto,
            this.CEstado});
            this.DGVVentas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DGVVentas.EnableHeadersVisualStyles = false;
            this.DGVVentas.Location = new System.Drawing.Point(0, 116);
            this.DGVVentas.Name = "DGVVentas";
            this.DGVVentas.ReadOnly = true;
            this.DGVVentas.Size = new System.Drawing.Size(734, 345);
            this.DGVVentas.TabIndex = 5;
            this.DGVVentas.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGVVentas_CellClick);
            // 
            // CIdVenta
            // 
            this.CIdVenta.HeaderText = "Nro Venta";
            this.CIdVenta.Name = "CIdVenta";
            this.CIdVenta.ReadOnly = true;
            // 
            // CFecha
            // 
            this.CFecha.HeaderText = "Fecha/Hora";
            this.CFecha.Name = "CFecha";
            this.CFecha.ReadOnly = true;
            // 
            // CDni
            // 
            this.CDni.HeaderText = "DNI Cliente";
            this.CDni.Name = "CDni";
            this.CDni.ReadOnly = true;
            // 
            // CPelicula
            // 
            this.CPelicula.HeaderText = "Pelicula";
            this.CPelicula.Name = "CPelicula";
            this.CPelicula.ReadOnly = true;
            // 
            // CSala
            // 
            this.CSala.HeaderText = "Sala";
            this.CSala.Name = "CSala";
            this.CSala.ReadOnly = true;
            // 
            // CBeneficio
            // 
            this.CBeneficio.HeaderText = "Beneficio";
            this.CBeneficio.Name = "CBeneficio";
            this.CBeneficio.ReadOnly = true;
            // 
            // CMonto
            // 
            this.CMonto.HeaderText = "Monto Total";
            this.CMonto.Name = "CMonto";
            this.CMonto.ReadOnly = true;
            // 
            // CEstado
            // 
            this.CEstado.HeaderText = "Estado";
            this.CEstado.Name = "CEstado";
            this.CEstado.ReadOnly = true;
            // 
            // FormVentas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(734, 461);
            this.Controls.Add(this.DGVVentas);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.PHeader);
            this.Name = "FormVentas";
            this.Text = "FormVentas";
            this.Load += new System.EventHandler(this.FormVentas_Load);
            this.PHeader.ResumeLayout(false);
            this.PHeader.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGVVentas)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel PHeader;
        private System.Windows.Forms.Button BAñadir;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label LBuscar;
        private System.Windows.Forms.Label LEstado;
        private System.Windows.Forms.Label LPelicula;
        private System.Windows.Forms.ComboBox CBPelicula;
        private System.Windows.Forms.ComboBox CBEstado;
        private System.Windows.Forms.TextBox TBuscar;
        private System.Windows.Forms.Label LFecha;
        private System.Windows.Forms.Label LBeneficio;
        private System.Windows.Forms.ComboBox CBBeneficio;
        private System.Windows.Forms.DataGridView DGVVentas;
        private System.Windows.Forms.DataGridViewTextBoxColumn CIdVenta;
        private System.Windows.Forms.DataGridViewTextBoxColumn CFecha;
        private System.Windows.Forms.DataGridViewTextBoxColumn CDni;
        private System.Windows.Forms.DataGridViewTextBoxColumn CPelicula;
        private System.Windows.Forms.DataGridViewTextBoxColumn CSala;
        private System.Windows.Forms.DataGridViewTextBoxColumn CBeneficio;
        private System.Windows.Forms.DataGridViewTextBoxColumn CMonto;
        private System.Windows.Forms.DateTimePicker DTPFecha;
        private System.Windows.Forms.DataGridViewTextBoxColumn CEstado;
    }
}