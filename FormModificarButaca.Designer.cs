namespace CinemaCtes
{
    partial class FormModificarButaca
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
            this.LButaca = new System.Windows.Forms.Label();
            this.TButaca = new System.Windows.Forms.TextBox();
            this.BCancelar = new System.Windows.Forms.Button();
            this.BConfirmar = new System.Windows.Forms.Button();
            this.LAñadir = new System.Windows.Forms.Label();
            this.CBSala = new System.Windows.Forms.ComboBox();
            this.LSala = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // LButaca
            // 
            this.LButaca.AutoSize = true;
            this.LButaca.Location = new System.Drawing.Point(63, 131);
            this.LButaca.Name = "LButaca";
            this.LButaca.Size = new System.Drawing.Size(41, 13);
            this.LButaca.TabIndex = 32;
            this.LButaca.Text = "Butaca";
            this.LButaca.Click += new System.EventHandler(this.LCorreo_Click);
            // 
            // TButaca
            // 
            this.TButaca.Location = new System.Drawing.Point(123, 128);
            this.TButaca.Name = "TButaca";
            this.TButaca.Size = new System.Drawing.Size(100, 20);
            this.TButaca.TabIndex = 31;
            // 
            // BCancelar
            // 
            this.BCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.BCancelar.Location = new System.Drawing.Point(170, 185);
            this.BCancelar.Name = "BCancelar";
            this.BCancelar.Size = new System.Drawing.Size(75, 23);
            this.BCancelar.TabIndex = 29;
            this.BCancelar.Text = "Cancelar";
            this.BCancelar.UseVisualStyleBackColor = true;
            this.BCancelar.Click += new System.EventHandler(this.BCancelar_Click);
            // 
            // BConfirmar
            // 
            this.BConfirmar.Location = new System.Drawing.Point(39, 185);
            this.BConfirmar.Name = "BConfirmar";
            this.BConfirmar.Size = new System.Drawing.Size(75, 23);
            this.BConfirmar.TabIndex = 28;
            this.BConfirmar.Text = "Confirmar";
            this.BConfirmar.UseVisualStyleBackColor = true;
            this.BConfirmar.Click += new System.EventHandler(this.BConfirmar_Click);
            // 
            // LAñadir
            // 
            this.LAñadir.AutoSize = true;
            this.LAñadir.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F);
            this.LAñadir.Location = new System.Drawing.Point(69, 24);
            this.LAñadir.Name = "LAñadir";
            this.LAñadir.Size = new System.Drawing.Size(143, 22);
            this.LAñadir.TabIndex = 27;
            this.LAñadir.Text = "Modificar Butaca";
            // 
            // CBSala
            // 
            this.CBSala.FormattingEnabled = true;
            this.CBSala.Items.AddRange(new object[] {
            "1",
            "2",
            "3"});
            this.CBSala.Location = new System.Drawing.Point(123, 89);
            this.CBSala.Name = "CBSala";
            this.CBSala.Size = new System.Drawing.Size(100, 21);
            this.CBSala.TabIndex = 33;
            // 
            // LSala
            // 
            this.LSala.AutoSize = true;
            this.LSala.Location = new System.Drawing.Point(63, 92);
            this.LSala.Name = "LSala";
            this.LSala.Size = new System.Drawing.Size(28, 13);
            this.LSala.TabIndex = 34;
            this.LSala.Text = "Sala";
            // 
            // FormModificarButaca
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(280, 237);
            this.Controls.Add(this.LSala);
            this.Controls.Add(this.CBSala);
            this.Controls.Add(this.LButaca);
            this.Controls.Add(this.TButaca);
            this.Controls.Add(this.BCancelar);
            this.Controls.Add(this.BConfirmar);
            this.Controls.Add(this.LAñadir);
            this.Name = "FormModificarButaca";
            this.Text = "FormModificarButaca";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label LButaca;
        private System.Windows.Forms.TextBox TButaca;
        private System.Windows.Forms.Button BCancelar;
        private System.Windows.Forms.Button BConfirmar;
        private System.Windows.Forms.Label LAñadir;
        private System.Windows.Forms.ComboBox CBSala;
        private System.Windows.Forms.Label LSala;
    }
}