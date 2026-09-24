namespace CinemaCtes
{
    partial class FormRegistrarPelicula
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
            this.LDesde = new System.Windows.Forms.Label();
            this.TDuracion = new System.Windows.Forms.TextBox();
            this.TTitulo = new System.Windows.Forms.TextBox();
            this.LTitulo = new System.Windows.Forms.Label();
            this.LDuracion = new System.Windows.Forms.Label();
            this.BCancelar = new System.Windows.Forms.Button();
            this.BInsertar = new System.Windows.Forms.Button();
            this.LEtiqueta = new System.Windows.Forms.Label();
            this.CBEtiqueta = new System.Windows.Forms.ComboBox();
            this.LAñadir = new System.Windows.Forms.Label();
            this.LHasta = new System.Windows.Forms.Label();
            this.LSinopsis = new System.Windows.Forms.Label();
            this.RTBSinopsis = new System.Windows.Forms.RichTextBox();
            this.DTPDesde = new System.Windows.Forms.DateTimePicker();
            this.DTPHasta = new System.Windows.Forms.DateTimePicker();
            this.SuspendLayout();
            // 
            // LDesde
            // 
            this.LDesde.AutoSize = true;
            this.LDesde.Location = new System.Drawing.Point(38, 158);
            this.LDesde.Name = "LDesde";
            this.LDesde.Size = new System.Drawing.Size(38, 13);
            this.LDesde.TabIndex = 21;
            this.LDesde.Text = "Desde";
            // 
            // TDuracion
            // 
            this.TDuracion.Location = new System.Drawing.Point(106, 119);
            this.TDuracion.MaxLength = 25;
            this.TDuracion.Name = "TDuracion";
            this.TDuracion.Size = new System.Drawing.Size(129, 20);
            this.TDuracion.TabIndex = 1;
            this.TDuracion.TextChanged += new System.EventHandler(this.TDuracion_TextChanged);
            // 
            // TTitulo
            // 
            this.TTitulo.Location = new System.Drawing.Point(106, 83);
            this.TTitulo.MaxLength = 100;
            this.TTitulo.Name = "TTitulo";
            this.TTitulo.Size = new System.Drawing.Size(129, 20);
            this.TTitulo.TabIndex = 0;
            // 
            // LTitulo
            // 
            this.LTitulo.AutoSize = true;
            this.LTitulo.Location = new System.Drawing.Point(37, 86);
            this.LTitulo.Name = "LTitulo";
            this.LTitulo.Size = new System.Drawing.Size(33, 13);
            this.LTitulo.TabIndex = 20;
            this.LTitulo.Text = "Titulo";
            // 
            // LDuracion
            // 
            this.LDuracion.AutoSize = true;
            this.LDuracion.Location = new System.Drawing.Point(38, 122);
            this.LDuracion.Name = "LDuracion";
            this.LDuracion.Size = new System.Drawing.Size(50, 13);
            this.LDuracion.TabIndex = 19;
            this.LDuracion.Text = "Duracion";
            // 
            // BCancelar
            // 
            this.BCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.BCancelar.Location = new System.Drawing.Point(293, 259);
            this.BCancelar.Name = "BCancelar";
            this.BCancelar.Size = new System.Drawing.Size(75, 23);
            this.BCancelar.TabIndex = 7;
            this.BCancelar.Text = "Cancelar";
            this.BCancelar.UseVisualStyleBackColor = true;
            this.BCancelar.Click += new System.EventHandler(this.BCancelar_Click);
            // 
            // BInsertar
            // 
            this.BInsertar.Location = new System.Drawing.Point(162, 259);
            this.BInsertar.Name = "BInsertar";
            this.BInsertar.Size = new System.Drawing.Size(75, 23);
            this.BInsertar.TabIndex = 6;
            this.BInsertar.Text = "Insertar";
            this.BInsertar.UseVisualStyleBackColor = true;
            this.BInsertar.Click += new System.EventHandler(this.BInsertar_Click);
            // 
            // LEtiqueta
            // 
            this.LEtiqueta.AutoSize = true;
            this.LEtiqueta.Location = new System.Drawing.Point(265, 195);
            this.LEtiqueta.Name = "LEtiqueta";
            this.LEtiqueta.Size = new System.Drawing.Size(46, 13);
            this.LEtiqueta.TabIndex = 25;
            this.LEtiqueta.Text = "Etiqueta";
            // 
            // CBEtiqueta
            // 
            this.CBEtiqueta.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CBEtiqueta.FormattingEnabled = true;
            this.CBEtiqueta.Items.AddRange(new object[] {
            "Administrador",
            "Supervisor",
            "Vendedor"});
            this.CBEtiqueta.Location = new System.Drawing.Point(335, 192);
            this.CBEtiqueta.Name = "CBEtiqueta";
            this.CBEtiqueta.Size = new System.Drawing.Size(128, 21);
            this.CBEtiqueta.TabIndex = 5;
            // 
            // LAñadir
            // 
            this.LAñadir.AutoSize = true;
            this.LAñadir.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F);
            this.LAñadir.Location = new System.Drawing.Point(161, 22);
            this.LAñadir.Name = "LAñadir";
            this.LAñadir.Size = new System.Drawing.Size(207, 22);
            this.LAñadir.TabIndex = 26;
            this.LAñadir.Text = "Añadir/Modificar Pelicula";
            // 
            // LHasta
            // 
            this.LHasta.AutoSize = true;
            this.LHasta.Location = new System.Drawing.Point(38, 195);
            this.LHasta.Name = "LHasta";
            this.LHasta.Size = new System.Drawing.Size(35, 13);
            this.LHasta.TabIndex = 28;
            this.LHasta.Text = "Hasta";
            // 
            // LSinopsis
            // 
            this.LSinopsis.AutoSize = true;
            this.LSinopsis.Location = new System.Drawing.Point(265, 119);
            this.LSinopsis.Name = "LSinopsis";
            this.LSinopsis.Size = new System.Drawing.Size(46, 13);
            this.LSinopsis.TabIndex = 30;
            this.LSinopsis.Text = "Sinopsis";
            // 
            // RTBSinopsis
            // 
            this.RTBSinopsis.Location = new System.Drawing.Point(335, 83);
            this.RTBSinopsis.MaxLength = 1000;
            this.RTBSinopsis.Name = "RTBSinopsis";
            this.RTBSinopsis.Size = new System.Drawing.Size(128, 92);
            this.RTBSinopsis.TabIndex = 4;
            this.RTBSinopsis.Text = "";
            // 
            // DTPDesde
            // 
            this.DTPDesde.Location = new System.Drawing.Point(106, 155);
            this.DTPDesde.Name = "DTPDesde";
            this.DTPDesde.Size = new System.Drawing.Size(129, 20);
            this.DTPDesde.TabIndex = 2;
            // 
            // DTPHasta
            // 
            this.DTPHasta.Location = new System.Drawing.Point(106, 192);
            this.DTPHasta.Name = "DTPHasta";
            this.DTPHasta.Size = new System.Drawing.Size(129, 20);
            this.DTPHasta.TabIndex = 3;
            // 
            // FormRegistrarPelicula
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(514, 322);
            this.Controls.Add(this.DTPHasta);
            this.Controls.Add(this.DTPDesde);
            this.Controls.Add(this.RTBSinopsis);
            this.Controls.Add(this.LSinopsis);
            this.Controls.Add(this.LHasta);
            this.Controls.Add(this.LAñadir);
            this.Controls.Add(this.LEtiqueta);
            this.Controls.Add(this.CBEtiqueta);
            this.Controls.Add(this.BCancelar);
            this.Controls.Add(this.BInsertar);
            this.Controls.Add(this.LDesde);
            this.Controls.Add(this.TDuracion);
            this.Controls.Add(this.TTitulo);
            this.Controls.Add(this.LTitulo);
            this.Controls.Add(this.LDuracion);
            this.Name = "FormRegistrarPelicula";
            this.Text = "FormRegistrarPelicula";
            this.Load += new System.EventHandler(this.FormRegistrarPelicula_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label LDesde;
        private System.Windows.Forms.TextBox TDuracion;
        private System.Windows.Forms.TextBox TTitulo;
        private System.Windows.Forms.Label LTitulo;
        private System.Windows.Forms.Label LDuracion;
        private System.Windows.Forms.Button BCancelar;
        private System.Windows.Forms.Button BInsertar;
        private System.Windows.Forms.Label LEtiqueta;
        private System.Windows.Forms.ComboBox CBEtiqueta;
        private System.Windows.Forms.Label LAñadir;
        private System.Windows.Forms.Label LHasta;
        private System.Windows.Forms.Label LSinopsis;
        private System.Windows.Forms.RichTextBox RTBSinopsis;
        private System.Windows.Forms.DateTimePicker DTPDesde;
        private System.Windows.Forms.DateTimePicker DTPHasta;
    }
}