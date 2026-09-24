namespace CinemaCtes
{
    partial class FormModificarCorreo
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
            this.LCorreo = new System.Windows.Forms.Label();
            this.TCorreo = new System.Windows.Forms.TextBox();
            this.BCancelar = new System.Windows.Forms.Button();
            this.BConfirmar = new System.Windows.Forms.Button();
            this.LAñadir = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // LCorreo
            // 
            this.LCorreo.AutoSize = true;
            this.LCorreo.Location = new System.Drawing.Point(50, 100);
            this.LCorreo.Name = "LCorreo";
            this.LCorreo.Size = new System.Drawing.Size(71, 13);
            this.LCorreo.TabIndex = 26;
            this.LCorreo.Text = "Correo nuevo";
            // 
            // TCorreo
            // 
            this.TCorreo.Location = new System.Drawing.Point(126, 97);
            this.TCorreo.Name = "TCorreo";
            this.TCorreo.Size = new System.Drawing.Size(100, 20);
            this.TCorreo.TabIndex = 25;
            // 
            // BCancelar
            // 
            this.BCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.BCancelar.Location = new System.Drawing.Point(168, 173);
            this.BCancelar.Name = "BCancelar";
            this.BCancelar.Size = new System.Drawing.Size(75, 23);
            this.BCancelar.TabIndex = 23;
            this.BCancelar.Text = "Cancelar";
            this.BCancelar.UseVisualStyleBackColor = true;
            this.BCancelar.Click += new System.EventHandler(this.BCancelar_Click);
            // 
            // BConfirmar
            // 
            this.BConfirmar.Location = new System.Drawing.Point(37, 173);
            this.BConfirmar.Name = "BConfirmar";
            this.BConfirmar.Size = new System.Drawing.Size(75, 23);
            this.BConfirmar.TabIndex = 22;
            this.BConfirmar.Text = "Confirmar";
            this.BConfirmar.UseVisualStyleBackColor = true;
            this.BConfirmar.Click += new System.EventHandler(this.BConfirmar_Click);
            // 
            // LAñadir
            // 
            this.LAñadir.AutoSize = true;
            this.LAñadir.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F);
            this.LAñadir.Location = new System.Drawing.Point(67, 26);
            this.LAñadir.Name = "LAñadir";
            this.LAñadir.Size = new System.Drawing.Size(142, 22);
            this.LAñadir.TabIndex = 21;
            this.LAñadir.Text = "Modificar Correo";
            // 
            // FormModificarCorreo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(280, 237);
            this.Controls.Add(this.LCorreo);
            this.Controls.Add(this.TCorreo);
            this.Controls.Add(this.BCancelar);
            this.Controls.Add(this.BConfirmar);
            this.Controls.Add(this.LAñadir);
            this.Name = "FormModificarCorreo";
            this.Text = "FormModificarCorreo";
            this.Load += new System.EventHandler(this.FormModificarCorreo_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label LCorreo;
        private System.Windows.Forms.TextBox TCorreo;
        private System.Windows.Forms.Button BCancelar;
        private System.Windows.Forms.Button BConfirmar;
        private System.Windows.Forms.Label LAñadir;
    }
}