namespace CinemaCtes
{
    partial class FormPeliculas
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
            this.LBuscar = new System.Windows.Forms.Label();
            this.LEstado = new System.Windows.Forms.Label();
            this.LEtiqueta = new System.Windows.Forms.Label();
            this.CBEtiqueta = new System.Windows.Forms.ComboBox();
            this.CBEstado = new System.Windows.Forms.ComboBox();
            this.TBuscar = new System.Windows.Forms.TextBox();
            this.DGVPeliculas = new System.Windows.Forms.DataGridView();
            this.CTitulo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CDuracion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CSinopsis = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CDesde = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CHasta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CEtiqueta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CEstado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CIdPelicula = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PHeader.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGVPeliculas)).BeginInit();
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
            this.BAñadir.Location = new System.Drawing.Point(609, 22);
            this.BAñadir.Name = "BAñadir";
            this.BAñadir.Size = new System.Drawing.Size(113, 27);
            this.BAñadir.TabIndex = 1;
            this.BAñadir.Text = "Añadir pelicula";
            this.BAñadir.UseVisualStyleBackColor = false;
            this.BAñadir.Click += new System.EventHandler(this.BAnadirPelicula_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(12, 36);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(196, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Administra catálogo general de peliculas";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(12, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(131, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Gestión Peliculas";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(18)))), ((int)(((byte)(38)))));
            this.panel3.Controls.Add(this.LBuscar);
            this.panel3.Controls.Add(this.LEstado);
            this.panel3.Controls.Add(this.LEtiqueta);
            this.panel3.Controls.Add(this.CBEtiqueta);
            this.panel3.Controls.Add(this.CBEstado);
            this.panel3.Controls.Add(this.TBuscar);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 65);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(734, 51);
            this.panel3.TabIndex = 4;
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
            // LEtiqueta
            // 
            this.LEtiqueta.AutoSize = true;
            this.LEtiqueta.ForeColor = System.Drawing.Color.White;
            this.LEtiqueta.Location = new System.Drawing.Point(509, 7);
            this.LEtiqueta.Name = "LEtiqueta";
            this.LEtiqueta.Size = new System.Drawing.Size(46, 13);
            this.LEtiqueta.TabIndex = 3;
            this.LEtiqueta.Text = "Etiqueta";
            // 
            // CBEtiqueta
            // 
            this.CBEtiqueta.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CBEtiqueta.FormattingEnabled = true;
            this.CBEtiqueta.Items.AddRange(new object[] {
            "Todos",
            "Promoción",
            "Descuento"});
            this.CBEtiqueta.Location = new System.Drawing.Point(474, 23);
            this.CBEtiqueta.Name = "CBEtiqueta";
            this.CBEtiqueta.Size = new System.Drawing.Size(121, 21);
            this.CBEtiqueta.TabIndex = 2;
            this.CBEtiqueta.SelectedIndexChanged += new System.EventHandler(this.CBEtiqueta_SelectedIndexChanged);
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
            this.TBuscar.Location = new System.Drawing.Point(41, 24);
            this.TBuscar.Name = "TBuscar";
            this.TBuscar.Size = new System.Drawing.Size(350, 20);
            this.TBuscar.TabIndex = 0;
            this.TBuscar.TextChanged += new System.EventHandler(this.TBuscar_TextChanged);
            this.TBuscar.Enter += new System.EventHandler(this.TBuscar_Enter);
            this.TBuscar.Leave += new System.EventHandler(this.TBuscar_Leave);
            // 
            // DGVPeliculas
            // 
            this.DGVPeliculas.AllowUserToAddRows = false;
            this.DGVPeliculas.AllowUserToDeleteRows = false;
            this.DGVPeliculas.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DGVPeliculas.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(18)))), ((int)(((byte)(38)))));
            this.DGVPeliculas.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(27)))), ((int)(((byte)(56)))));
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DGVPeliculas.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.DGVPeliculas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGVPeliculas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CTitulo,
            this.CDuracion,
            this.CSinopsis,
            this.CDesde,
            this.CHasta,
            this.CEtiqueta,
            this.CEstado,
            this.CIdPelicula});
            this.DGVPeliculas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DGVPeliculas.EnableHeadersVisualStyles = false;
            this.DGVPeliculas.Location = new System.Drawing.Point(0, 116);
            this.DGVPeliculas.Name = "DGVPeliculas";
            this.DGVPeliculas.ReadOnly = true;
            this.DGVPeliculas.Size = new System.Drawing.Size(734, 345);
            this.DGVPeliculas.TabIndex = 5;
            this.DGVPeliculas.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGVPeliculas_CellContentClick);
            // 
            // CTitulo
            // 
            this.CTitulo.HeaderText = "Titulo";
            this.CTitulo.Name = "CTitulo";
            this.CTitulo.ReadOnly = true;
            // 
            // CDuracion
            // 
            this.CDuracion.HeaderText = "Duracion";
            this.CDuracion.Name = "CDuracion";
            this.CDuracion.ReadOnly = true;
            // 
            // CSinopsis
            // 
            this.CSinopsis.HeaderText = "Sinopsis";
            this.CSinopsis.Name = "CSinopsis";
            this.CSinopsis.ReadOnly = true;
            // 
            // CDesde
            // 
            this.CDesde.HeaderText = "Desde";
            this.CDesde.Name = "CDesde";
            this.CDesde.ReadOnly = true;
            // 
            // CHasta
            // 
            this.CHasta.HeaderText = "Hasta";
            this.CHasta.Name = "CHasta";
            this.CHasta.ReadOnly = true;
            // 
            // CEtiqueta
            // 
            this.CEtiqueta.HeaderText = "Etiqueta";
            this.CEtiqueta.Name = "CEtiqueta";
            this.CEtiqueta.ReadOnly = true;
            // 
            // CEstado
            // 
            this.CEstado.HeaderText = "Estado";
            this.CEstado.Name = "CEstado";
            this.CEstado.ReadOnly = true;
            // 
            // CIdPelicula
            // 
            this.CIdPelicula.HeaderText = "IdPelicula";
            this.CIdPelicula.Name = "CIdPelicula";
            this.CIdPelicula.ReadOnly = true;
            this.CIdPelicula.Visible = false;
            // 
            // FormPeliculas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(734, 461);
            this.Controls.Add(this.DGVPeliculas);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.PHeader);
            this.Name = "FormPeliculas";
            this.Text = "FormPeliculas";
            this.Load += new System.EventHandler(this.FormPeliculas_Load);
            this.PHeader.ResumeLayout(false);
            this.PHeader.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGVPeliculas)).EndInit();
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
        private System.Windows.Forms.Label LEtiqueta;
        private System.Windows.Forms.ComboBox CBEtiqueta;
        private System.Windows.Forms.ComboBox CBEstado;
        private System.Windows.Forms.TextBox TBuscar;
        private System.Windows.Forms.DataGridView DGVPeliculas;
        private System.Windows.Forms.DataGridViewTextBoxColumn CTitulo;
        private System.Windows.Forms.DataGridViewTextBoxColumn CDuracion;
        private System.Windows.Forms.DataGridViewTextBoxColumn CSinopsis;
        private System.Windows.Forms.DataGridViewTextBoxColumn CDesde;
        private System.Windows.Forms.DataGridViewTextBoxColumn CHasta;
        private System.Windows.Forms.DataGridViewTextBoxColumn CEtiqueta;
        private System.Windows.Forms.DataGridViewTextBoxColumn CEstado;
        private System.Windows.Forms.DataGridViewTextBoxColumn CIdPelicula;
    }
}