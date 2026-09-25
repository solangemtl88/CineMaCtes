namespace CinemaCtes
{
    partial class FormFunciones
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
            this.LSala = new System.Windows.Forms.Label();
            this.CBSala = new System.Windows.Forms.ComboBox();
            this.LBuscar = new System.Windows.Forms.Label();
            this.LEstado = new System.Windows.Forms.Label();
            this.LFecha = new System.Windows.Forms.Label();
            this.CBEstado = new System.Windows.Forms.ComboBox();
            this.TBuscar = new System.Windows.Forms.TextBox();
            this.DGVFunciones = new System.Windows.Forms.DataGridView();
            this.CFecha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CPelicula = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CInicio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CFin = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CNroSala = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CEstado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CIdFuncion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PHeader.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGVFunciones)).BeginInit();
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
            this.PHeader.Enter += new System.EventHandler(this.BAnadirFuncion_Click);
            // 
            // BAñadir
            // 
            this.BAñadir.BackColor = System.Drawing.Color.AliceBlue;
            this.BAñadir.Location = new System.Drawing.Point(609, 22);
            this.BAñadir.Name = "BAñadir";
            this.BAñadir.Size = new System.Drawing.Size(113, 27);
            this.BAñadir.TabIndex = 0;
            this.BAñadir.Text = "Añadir Funcion";
            this.BAñadir.UseVisualStyleBackColor = false;
            this.BAñadir.Click += new System.EventHandler(this.BAnadirFuncion_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(12, 36);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(228, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Administra proyecciones y horarios de cartelera";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(12, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(143, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Gestión Funciones";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(18)))), ((int)(((byte)(38)))));
            this.panel3.Controls.Add(this.DTPFecha);
            this.panel3.Controls.Add(this.LSala);
            this.panel3.Controls.Add(this.CBSala);
            this.panel3.Controls.Add(this.LBuscar);
            this.panel3.Controls.Add(this.LEstado);
            this.panel3.Controls.Add(this.LFecha);
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
            this.DTPFecha.Location = new System.Drawing.Point(284, 22);
            this.DTPFecha.Name = "DTPFecha";
            this.DTPFecha.Size = new System.Drawing.Size(135, 20);
            this.DTPFecha.TabIndex = 8;
            this.DTPFecha.ValueChanged += new System.EventHandler(this.DTPFecha_ValueChanged);
            // 
            // LSala
            // 
            this.LSala.AutoSize = true;
            this.LSala.ForeColor = System.Drawing.Color.White;
            this.LSala.Location = new System.Drawing.Point(502, 7);
            this.LSala.Name = "LSala";
            this.LSala.Size = new System.Drawing.Size(28, 13);
            this.LSala.TabIndex = 7;
            this.LSala.Text = "Sala";
            // 
            // CBSala
            // 
            this.CBSala.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CBSala.FormattingEnabled = true;
            this.CBSala.Items.AddRange(new object[] {
            "Todos",
            "Activo",
            "Inactivo"});
            this.CBSala.Location = new System.Drawing.Point(455, 22);
            this.CBSala.Name = "CBSala";
            this.CBSala.Size = new System.Drawing.Size(121, 21);
            this.CBSala.TabIndex = 6;
            this.CBSala.SelectedIndexChanged += new System.EventHandler(this.CBSalaFiltro_SelectedIndexChanged);
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
            // LFecha
            // 
            this.LFecha.AutoSize = true;
            this.LFecha.ForeColor = System.Drawing.Color.White;
            this.LFecha.Location = new System.Drawing.Point(334, 7);
            this.LFecha.Name = "LFecha";
            this.LFecha.Size = new System.Drawing.Size(37, 13);
            this.LFecha.TabIndex = 3;
            this.LFecha.Text = "Fecha";
            // 
            // CBEstado
            // 
            this.CBEstado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CBEstado.FormattingEnabled = true;
            this.CBEstado.Items.AddRange(new object[] {
            "Todos",
            "Activo",
            "Inactivo"});
            this.CBEstado.Location = new System.Drawing.Point(601, 22);
            this.CBEstado.Name = "CBEstado";
            this.CBEstado.Size = new System.Drawing.Size(121, 21);
            this.CBEstado.TabIndex = 1;
            this.CBEstado.SelectedIndexChanged += new System.EventHandler(this.CBEstadoFiltro_SelectedIndexChanged);
            // 
            // TBuscar
            // 
            this.TBuscar.ForeColor = System.Drawing.Color.Black;
            this.TBuscar.Location = new System.Drawing.Point(16, 23);
            this.TBuscar.Name = "TBuscar";
            this.TBuscar.Size = new System.Drawing.Size(232, 20);
            this.TBuscar.TabIndex = 0;
            this.TBuscar.TextChanged += new System.EventHandler(this.TBuscar_TextChanged);
            // 
            // DGVFunciones
            // 
            this.DGVFunciones.AllowUserToAddRows = false;
            this.DGVFunciones.AllowUserToDeleteRows = false;
            this.DGVFunciones.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DGVFunciones.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(18)))), ((int)(((byte)(38)))));
            this.DGVFunciones.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(27)))), ((int)(((byte)(56)))));
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DGVFunciones.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.DGVFunciones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGVFunciones.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CFecha,
            this.CPelicula,
            this.CInicio,
            this.CFin,
            this.CNroSala,
            this.CEstado,
            this.CIdFuncion});
            this.DGVFunciones.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DGVFunciones.EnableHeadersVisualStyles = false;
            this.DGVFunciones.Location = new System.Drawing.Point(0, 116);
            this.DGVFunciones.Name = "DGVFunciones";
            this.DGVFunciones.ReadOnly = true;
            this.DGVFunciones.Size = new System.Drawing.Size(734, 345);
            this.DGVFunciones.TabIndex = 5;
            this.DGVFunciones.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGVFunciones_CellContentClick);
            // 
            // CFecha
            // 
            this.CFecha.HeaderText = "Fecha";
            this.CFecha.Name = "CFecha";
            this.CFecha.ReadOnly = true;
            // 
            // CPelicula
            // 
            this.CPelicula.HeaderText = "Pelicula";
            this.CPelicula.Name = "CPelicula";
            this.CPelicula.ReadOnly = true;
            // 
            // CInicio
            // 
            this.CInicio.HeaderText = "Inicio";
            this.CInicio.Name = "CInicio";
            this.CInicio.ReadOnly = true;
            // 
            // CFin
            // 
            this.CFin.HeaderText = "Fin";
            this.CFin.Name = "CFin";
            this.CFin.ReadOnly = true;
            // 
            // CNroSala
            // 
            this.CNroSala.HeaderText = "Nro Sala";
            this.CNroSala.Name = "CNroSala";
            this.CNroSala.ReadOnly = true;
            // 
            // CEstado
            // 
            this.CEstado.HeaderText = "Estado";
            this.CEstado.Name = "CEstado";
            this.CEstado.ReadOnly = true;
            // 
            // CIdFuncion
            // 
            this.CIdFuncion.HeaderText = "IdFuncion";
            this.CIdFuncion.Name = "CIdFuncion";
            this.CIdFuncion.ReadOnly = true;
            this.CIdFuncion.Visible = false;
            // 
            // FormFunciones
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(734, 461);
            this.Controls.Add(this.DGVFunciones);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.PHeader);
            this.Name = "FormFunciones";
            this.Text = "FormFunciones";
            this.Load += new System.EventHandler(this.FormFunciones_Load);
            this.PHeader.ResumeLayout(false);
            this.PHeader.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGVFunciones)).EndInit();
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
        private System.Windows.Forms.Label LFecha;
        private System.Windows.Forms.ComboBox CBEstado;
        private System.Windows.Forms.TextBox TBuscar;
        private System.Windows.Forms.DataGridView DGVFunciones;
        private System.Windows.Forms.DataGridViewTextBoxColumn CFecha;
        private System.Windows.Forms.DataGridViewTextBoxColumn CPelicula;
        private System.Windows.Forms.DataGridViewTextBoxColumn CInicio;
        private System.Windows.Forms.Label LSala;
        private System.Windows.Forms.ComboBox CBSala;
        private System.Windows.Forms.DataGridViewTextBoxColumn CFin;
        private System.Windows.Forms.DataGridViewTextBoxColumn CNroSala;
        private System.Windows.Forms.DataGridViewTextBoxColumn CEstado;
        private System.Windows.Forms.DataGridViewTextBoxColumn CIdFuncion;
        private System.Windows.Forms.DateTimePicker DTPFecha;
    }
}