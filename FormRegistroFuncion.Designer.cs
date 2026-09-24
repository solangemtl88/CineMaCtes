namespace CinemaCtes
{
    partial class FormRegistroFuncion
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
            this.LAñadir = new System.Windows.Forms.Label();
            this.BCancelar = new System.Windows.Forms.Button();
            this.BInsertar = new System.Windows.Forms.Button();
            this.LPelicula = new System.Windows.Forms.Label();
            this.CBPelicula = new System.Windows.Forms.ComboBox();
            this.LFecha = new System.Windows.Forms.Label();
            this.LSala = new System.Windows.Forms.Label();
            this.CBSala = new System.Windows.Forms.ComboBox();
            this.Linicio = new System.Windows.Forms.Label();
            this.DTPFecha = new System.Windows.Forms.DateTimePicker();
            this.DTPInicio = new System.Windows.Forms.DateTimePicker();
            this.SuspendLayout();
            // 
            // LAñadir
            // 
            this.LAñadir.AutoSize = true;
            this.LAñadir.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F);
            this.LAñadir.Location = new System.Drawing.Point(136, 44);
            this.LAñadir.Name = "LAñadir";
            this.LAñadir.Size = new System.Drawing.Size(208, 22);
            this.LAñadir.TabIndex = 15;
            this.LAñadir.Text = "Añadir/Modificar Funcion";
            // 
            // BCancelar
            // 
            this.BCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.BCancelar.Location = new System.Drawing.Point(256, 258);
            this.BCancelar.Name = "BCancelar";
            this.BCancelar.Size = new System.Drawing.Size(75, 23);
            this.BCancelar.TabIndex = 7;
            this.BCancelar.Text = "Cancelar";
            this.BCancelar.UseVisualStyleBackColor = true;
            this.BCancelar.Click += new System.EventHandler(this.BCancelar_Click);
            // 
            // BInsertar
            // 
            this.BInsertar.Location = new System.Drawing.Point(125, 258);
            this.BInsertar.Name = "BInsertar";
            this.BInsertar.Size = new System.Drawing.Size(75, 23);
            this.BInsertar.TabIndex = 6;
            this.BInsertar.Text = "Insertar";
            this.BInsertar.UseVisualStyleBackColor = true;
            this.BInsertar.Click += new System.EventHandler(this.BInsertar_Click);
            // 
            // LPelicula
            // 
            this.LPelicula.AutoSize = true;
            this.LPelicula.Location = new System.Drawing.Point(36, 118);
            this.LPelicula.Name = "LPelicula";
            this.LPelicula.Size = new System.Drawing.Size(44, 13);
            this.LPelicula.TabIndex = 0;
            this.LPelicula.Text = "Pelicula";
            // 
            // CBPelicula
            // 
            this.CBPelicula.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CBPelicula.FormattingEnabled = true;
            this.CBPelicula.Items.AddRange(new object[] {
            "Administrador",
            "Supervisor",
            "Vendedor"});
            this.CBPelicula.Location = new System.Drawing.Point(95, 115);
            this.CBPelicula.Name = "CBPelicula";
            this.CBPelicula.Size = new System.Drawing.Size(128, 21);
            this.CBPelicula.TabIndex = 0;
            // 
            // LFecha
            // 
            this.LFecha.AutoSize = true;
            this.LFecha.Location = new System.Drawing.Point(266, 118);
            this.LFecha.Name = "LFecha";
            this.LFecha.Size = new System.Drawing.Size(43, 13);
            this.LFecha.TabIndex = 23;
            this.LFecha.Text = "Fecha2";
            // 
            // LSala
            // 
            this.LSala.AutoSize = true;
            this.LSala.Location = new System.Drawing.Point(36, 177);
            this.LSala.Name = "LSala";
            this.LSala.Size = new System.Drawing.Size(28, 13);
            this.LSala.TabIndex = 25;
            this.LSala.Text = "Sala";
            // 
            // CBSala
            // 
            this.CBSala.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CBSala.FormattingEnabled = true;
            this.CBSala.Items.AddRange(new object[] {
            "Administrador",
            "Supervisor",
            "Vendedor"});
            this.CBSala.Location = new System.Drawing.Point(95, 174);
            this.CBSala.Name = "CBSala";
            this.CBSala.Size = new System.Drawing.Size(128, 21);
            this.CBSala.TabIndex = 1;
            // 
            // Linicio
            // 
            this.Linicio.AutoSize = true;
            this.Linicio.Location = new System.Drawing.Point(266, 180);
            this.Linicio.Name = "Linicio";
            this.Linicio.Size = new System.Drawing.Size(32, 13);
            this.Linicio.TabIndex = 20;
            this.Linicio.Text = "Inicio";
            // 
            // DTPFecha
            // 
            this.DTPFecha.Location = new System.Drawing.Point(318, 115);
            this.DTPFecha.Name = "DTPFecha";
            this.DTPFecha.Size = new System.Drawing.Size(128, 20);
            this.DTPFecha.TabIndex = 3;
            // 
            // DTPInicio
            // 
            this.DTPInicio.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.DTPInicio.Location = new System.Drawing.Point(318, 175);
            this.DTPInicio.Name = "DTPInicio";
            this.DTPInicio.ShowUpDown = true;
            this.DTPInicio.Size = new System.Drawing.Size(128, 20);
            this.DTPInicio.TabIndex = 26;
            // 
            // FormRegistroFuncion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(469, 325);
            this.Controls.Add(this.DTPInicio);
            this.Controls.Add(this.DTPFecha);
            this.Controls.Add(this.Linicio);
            this.Controls.Add(this.LSala);
            this.Controls.Add(this.CBSala);
            this.Controls.Add(this.LFecha);
            this.Controls.Add(this.LPelicula);
            this.Controls.Add(this.CBPelicula);
            this.Controls.Add(this.BCancelar);
            this.Controls.Add(this.BInsertar);
            this.Controls.Add(this.LAñadir);
            this.Name = "FormRegistroFuncion";
            this.Text = "FormRegistroFuncion";
            this.Load += new System.EventHandler(this.FormRegistroFuncion_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label LAñadir;
        private System.Windows.Forms.Button BCancelar;
        private System.Windows.Forms.Button BInsertar;
        private System.Windows.Forms.Label LPelicula;
        private System.Windows.Forms.ComboBox CBPelicula;
        private System.Windows.Forms.Label LFecha;
        private System.Windows.Forms.Label LSala;
        private System.Windows.Forms.ComboBox CBSala;
        private System.Windows.Forms.Label Linicio;
        private System.Windows.Forms.DateTimePicker DTPFecha;
        private System.Windows.Forms.DateTimePicker DTPInicio;
    }
}