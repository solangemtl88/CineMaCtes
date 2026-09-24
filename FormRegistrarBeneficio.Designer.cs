namespace CinemaCtes
{
    partial class FormRegistrarBeneficio
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
            this.LTipo = new System.Windows.Forms.Label();
            this.LDescuento = new System.Windows.Forms.Label();
            this.LDescripcion = new System.Windows.Forms.Label();
            this.TDescripcion = new System.Windows.Forms.TextBox();
            this.TDescuento = new System.Windows.Forms.TextBox();
            this.BInsertar = new System.Windows.Forms.Button();
            this.BCancelar = new System.Windows.Forms.Button();
            this.CBTipo = new System.Windows.Forms.ComboBox();
            this.LAñadir = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // LTipo
            // 
            this.LTipo.AutoSize = true;
            this.LTipo.Location = new System.Drawing.Point(33, 189);
            this.LTipo.Name = "LTipo";
            this.LTipo.Size = new System.Drawing.Size(81, 13);
            this.LTipo.TabIndex = 0;
            this.LTipo.Text = "Tipo descuento";
            // 
            // LDescuento
            // 
            this.LDescuento.AutoSize = true;
            this.LDescuento.Location = new System.Drawing.Point(55, 130);
            this.LDescuento.Name = "LDescuento";
            this.LDescuento.Size = new System.Drawing.Size(59, 13);
            this.LDescuento.TabIndex = 1;
            this.LDescuento.Text = "Descuento";
            // 
            // LDescripcion
            // 
            this.LDescripcion.AutoSize = true;
            this.LDescripcion.Location = new System.Drawing.Point(55, 69);
            this.LDescripcion.Name = "LDescripcion";
            this.LDescripcion.Size = new System.Drawing.Size(63, 13);
            this.LDescripcion.TabIndex = 2;
            this.LDescripcion.Text = "Descripcion";
            // 
            // TDescripcion
            // 
            this.TDescripcion.Location = new System.Drawing.Point(124, 66);
            this.TDescripcion.MaxLength = 25;
            this.TDescripcion.Name = "TDescripcion";
            this.TDescripcion.Size = new System.Drawing.Size(129, 20);
            this.TDescripcion.TabIndex = 0;
            this.TDescripcion.TextChanged += new System.EventHandler(this.LimpiarEspacios_TextChanged);
            // 
            // TDescuento
            // 
            this.TDescuento.Location = new System.Drawing.Point(124, 127);
            this.TDescuento.MaxLength = 15;
            this.TDescuento.Name = "TDescuento";
            this.TDescuento.Size = new System.Drawing.Size(129, 20);
            this.TDescuento.TabIndex = 1;
            this.TDescuento.TextChanged += new System.EventHandler(this.LimpiarEspacios_TextChanged);
            // 
            // BInsertar
            // 
            this.BInsertar.Location = new System.Drawing.Point(59, 257);
            this.BInsertar.Name = "BInsertar";
            this.BInsertar.Size = new System.Drawing.Size(75, 23);
            this.BInsertar.TabIndex = 3;
            this.BInsertar.Text = "Insertar";
            this.BInsertar.UseVisualStyleBackColor = true;
            this.BInsertar.Click += new System.EventHandler(this.BInsertar_Click);
            // 
            // BCancelar
            // 
            this.BCancelar.Location = new System.Drawing.Point(190, 257);
            this.BCancelar.Name = "BCancelar";
            this.BCancelar.Size = new System.Drawing.Size(75, 23);
            this.BCancelar.TabIndex = 4;
            this.BCancelar.Text = "Cancelar";
            this.BCancelar.UseVisualStyleBackColor = true;
            this.BCancelar.Click += new System.EventHandler(this.BCancelar_Click);
            // 
            // CBTipo
            // 
            this.CBTipo.Cursor = System.Windows.Forms.Cursors.Default;
            this.CBTipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CBTipo.FormattingEnabled = true;
            this.CBTipo.Items.AddRange(new object[] {
            "Promoción",
            "Descuento"});
            this.CBTipo.Location = new System.Drawing.Point(124, 186);
            this.CBTipo.Name = "CBTipo";
            this.CBTipo.Size = new System.Drawing.Size(129, 21);
            this.CBTipo.TabIndex = 2;
            // 
            // LAñadir
            // 
            this.LAñadir.AutoSize = true;
            this.LAñadir.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F);
            this.LAñadir.Location = new System.Drawing.Point(49, 18);
            this.LAñadir.Name = "LAñadir";
            this.LAñadir.Size = new System.Drawing.Size(216, 22);
            this.LAñadir.TabIndex = 5;
            this.LAñadir.Text = "Añadir/Modificar beneficio";
            // 
            // FormRegistrarBeneficio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(312, 316);
            this.Controls.Add(this.LAñadir);
            this.Controls.Add(this.CBTipo);
            this.Controls.Add(this.BCancelar);
            this.Controls.Add(this.BInsertar);
            this.Controls.Add(this.TDescuento);
            this.Controls.Add(this.TDescripcion);
            this.Controls.Add(this.LDescripcion);
            this.Controls.Add(this.LDescuento);
            this.Controls.Add(this.LTipo);
            this.Name = "FormRegistrarBeneficio";
            this.Text = "FormRegistrarBeneficio";
            this.Load += new System.EventHandler(this.FormRegistrarBeneficio_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label LTipo;
        private System.Windows.Forms.Label LDescuento;
        private System.Windows.Forms.Label LDescripcion;
        private System.Windows.Forms.TextBox TDescripcion;
        private System.Windows.Forms.TextBox TDescuento;
        private System.Windows.Forms.Button BInsertar;
        private System.Windows.Forms.Button BCancelar;
        private System.Windows.Forms.ComboBox CBTipo;
        private System.Windows.Forms.Label LAñadir;
    }
}