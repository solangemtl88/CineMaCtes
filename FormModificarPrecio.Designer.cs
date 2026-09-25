namespace CinemaCtes
{
    partial class FormModificarPrecio
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
            this.BConfirmar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.TPrecio = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // LAñadir
            // 
            this.LAñadir.AutoSize = true;
            this.LAñadir.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F);
            this.LAñadir.Location = new System.Drawing.Point(42, 24);
            this.LAñadir.Name = "LAñadir";
            this.LAñadir.Size = new System.Drawing.Size(199, 22);
            this.LAñadir.TabIndex = 15;
            this.LAñadir.Text = "Modificar precio boletos";
            // 
            // BCancelar
            // 
            this.BCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.BCancelar.Location = new System.Drawing.Point(166, 184);
            this.BCancelar.Name = "BCancelar";
            this.BCancelar.Size = new System.Drawing.Size(75, 23);
            this.BCancelar.TabIndex = 17;
            this.BCancelar.Text = "Cancelar";
            this.BCancelar.UseVisualStyleBackColor = true;
            this.BCancelar.Click += new System.EventHandler(this.BCancelar_Click);
            // 
            // BConfirmar
            // 
            this.BConfirmar.Location = new System.Drawing.Point(35, 184);
            this.BConfirmar.Name = "BConfirmar";
            this.BConfirmar.Size = new System.Drawing.Size(75, 23);
            this.BConfirmar.TabIndex = 16;
            this.BConfirmar.Text = "Confirmar";
            this.BConfirmar.UseVisualStyleBackColor = true;
            this.BConfirmar.Click += new System.EventHandler(this.BConfirmar_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(90, 73);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(99, 13);
            this.label1.TabIndex = 18;
            this.label1.Text = "Precio actual: 1300";
            // 
            // TPrecio
            // 
            this.TPrecio.Location = new System.Drawing.Point(126, 121);
            this.TPrecio.Name = "TPrecio";
            this.TPrecio.Size = new System.Drawing.Size(100, 20);
            this.TPrecio.TabIndex = 19;
            this.TPrecio.TextChanged += new System.EventHandler(this.TPrecio_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(50, 124);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 13);
            this.label2.TabIndex = 20;
            this.label2.Text = "Precio nuevo";
            // 
            // FormModificarPrecio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(280, 237);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.TPrecio);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.BCancelar);
            this.Controls.Add(this.BConfirmar);
            this.Controls.Add(this.LAñadir);
            this.Name = "FormModificarPrecio";
            this.Text = "FormModificarPrecio";
            this.Load += new System.EventHandler(this.FormModificarPrecio_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label LAñadir;
        private System.Windows.Forms.Button BCancelar;
        private System.Windows.Forms.Button BConfirmar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox TPrecio;
        private System.Windows.Forms.Label label2;
    }
}