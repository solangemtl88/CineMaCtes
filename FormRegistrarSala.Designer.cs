namespace CinemaCtes
{
    partial class FormRegistrarSala
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
            this.TCapacidad = new System.Windows.Forms.TextBox();
            this.TNroSala = new System.Windows.Forms.TextBox();
            this.LNombre = new System.Windows.Forms.Label();
            this.LCapacidad = new System.Windows.Forms.Label();
            this.LAñadir = new System.Windows.Forms.Label();
            this.BCancelar = new System.Windows.Forms.Button();
            this.BInsertar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // TCapacidad
            // 
            this.TCapacidad.Location = new System.Drawing.Point(118, 142);
            this.TCapacidad.MaxLength = 25;
            this.TCapacidad.Name = "TCapacidad";
            this.TCapacidad.Size = new System.Drawing.Size(129, 20);
            this.TCapacidad.TabIndex = 1;
            this.TCapacidad.TextChanged += new System.EventHandler(this.TCapacidad_TextChanged);
            // 
            // TNroSala
            // 
            this.TNroSala.Location = new System.Drawing.Point(118, 91);
            this.TNroSala.MaxLength = 25;
            this.TNroSala.Name = "TNroSala";
            this.TNroSala.Size = new System.Drawing.Size(129, 20);
            this.TNroSala.TabIndex = 0;
            this.TNroSala.TextChanged += new System.EventHandler(this.TNroSala_TextChanged);
            // 
            // LNombre
            // 
            this.LNombre.AutoSize = true;
            this.LNombre.Location = new System.Drawing.Point(49, 94);
            this.LNombre.Name = "LNombre";
            this.LNombre.Size = new System.Drawing.Size(61, 13);
            this.LNombre.TabIndex = 20;
            this.LNombre.Text = "Nro de sala";
            // 
            // LCapacidad
            // 
            this.LCapacidad.AutoSize = true;
            this.LCapacidad.Location = new System.Drawing.Point(50, 145);
            this.LCapacidad.Name = "LCapacidad";
            this.LCapacidad.Size = new System.Drawing.Size(58, 13);
            this.LCapacidad.TabIndex = 10;
            this.LCapacidad.Text = "Capacidad";
            // 
            // LAñadir
            // 
            this.LAñadir.AutoSize = true;
            this.LAñadir.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F);
            this.LAñadir.Location = new System.Drawing.Point(67, 25);
            this.LAñadir.Name = "LAñadir";
            this.LAñadir.Size = new System.Drawing.Size(180, 22);
            this.LAñadir.TabIndex = 22;
            this.LAñadir.Text = "Añadir/Modificar Sala";
            // 
            // BCancelar
            // 
            this.BCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.BCancelar.Location = new System.Drawing.Point(190, 205);
            this.BCancelar.Name = "BCancelar";
            this.BCancelar.Size = new System.Drawing.Size(75, 23);
            this.BCancelar.TabIndex = 3;
            this.BCancelar.Text = "Cancelar";
            this.BCancelar.UseVisualStyleBackColor = true;
            this.BCancelar.Click += new System.EventHandler(this.BCancelar_Click);
            // 
            // BInsertar
            // 
            this.BInsertar.Location = new System.Drawing.Point(59, 205);
            this.BInsertar.Name = "BInsertar";
            this.BInsertar.Size = new System.Drawing.Size(75, 23);
            this.BInsertar.TabIndex = 2;
            this.BInsertar.Text = "Insertar";
            this.BInsertar.UseVisualStyleBackColor = true;
            this.BInsertar.Click += new System.EventHandler(this.BInsertar_Click);
            // 
            // FormRegistrarSala
            // 
            this.AcceptButton = this.BInsertar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.BCancelar;
            this.ClientSize = new System.Drawing.Size(315, 284);
            this.Controls.Add(this.BCancelar);
            this.Controls.Add(this.BInsertar);
            this.Controls.Add(this.LAñadir);
            this.Controls.Add(this.TCapacidad);
            this.Controls.Add(this.TNroSala);
            this.Controls.Add(this.LNombre);
            this.Controls.Add(this.LCapacidad);
            this.Name = "FormRegistrarSala";
            this.Text = "Registrar sala";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox TCapacidad;
        private System.Windows.Forms.TextBox TNroSala;
        private System.Windows.Forms.Label LNombre;
        private System.Windows.Forms.Label LCapacidad;
        private System.Windows.Forms.Label LAñadir;
        private System.Windows.Forms.Button BCancelar;
        private System.Windows.Forms.Button BInsertar;
    }
}