namespace CinemaCtes
{
    partial class LoginForm
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
            this.BIngresar = new System.Windows.Forms.Button();
            this.BSalir = new System.Windows.Forms.Button();
            this.TCorreo = new System.Windows.Forms.TextBox();
            this.TContraseña = new System.Windows.Forms.TextBox();
            this.LCorreo = new System.Windows.Forms.Label();
            this.LContraseña = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // BIngresar
            // 
            this.BIngresar.Location = new System.Drawing.Point(43, 258);
            this.BIngresar.Name = "BIngresar";
            this.BIngresar.Size = new System.Drawing.Size(78, 24);
            this.BIngresar.TabIndex = 0;
            this.BIngresar.Text = "Ingresar";
            this.BIngresar.UseVisualStyleBackColor = true;
            this.BIngresar.Click += new System.EventHandler(this.BIngresar_Click);
            // 
            // BSalir
            // 
            this.BSalir.Location = new System.Drawing.Point(184, 259);
            this.BSalir.Name = "BSalir";
            this.BSalir.Size = new System.Drawing.Size(75, 23);
            this.BSalir.TabIndex = 1;
            this.BSalir.Text = "Salir";
            this.BSalir.UseVisualStyleBackColor = true;
            this.BSalir.Click += new System.EventHandler(this.BSalir_Click);
            // 
            // TCorreo
            // 
            this.TCorreo.Location = new System.Drawing.Point(93, 82);
            this.TCorreo.Name = "TCorreo";
            this.TCorreo.Size = new System.Drawing.Size(138, 20);
            this.TCorreo.TabIndex = 2;
            // 
            // TContraseña
            // 
            this.TContraseña.Location = new System.Drawing.Point(93, 167);
            this.TContraseña.Name = "TContraseña";
            this.TContraseña.PasswordChar = '*';
            this.TContraseña.Size = new System.Drawing.Size(138, 20);
            this.TContraseña.TabIndex = 3;
            // 
            // LCorreo
            // 
            this.LCorreo.AutoSize = true;
            this.LCorreo.Location = new System.Drawing.Point(40, 85);
            this.LCorreo.Name = "LCorreo";
            this.LCorreo.Size = new System.Drawing.Size(38, 13);
            this.LCorreo.TabIndex = 4;
            this.LCorreo.Text = "Correo";
            // 
            // LContraseña
            // 
            this.LContraseña.AutoSize = true;
            this.LContraseña.Location = new System.Drawing.Point(26, 170);
            this.LContraseña.Name = "LContraseña";
            this.LContraseña.Size = new System.Drawing.Size(61, 13);
            this.LContraseña.TabIndex = 5;
            this.LContraseña.Text = "Contraseña";
            // 
            // LoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(315, 324);
            this.Controls.Add(this.LContraseña);
            this.Controls.Add(this.LCorreo);
            this.Controls.Add(this.TContraseña);
            this.Controls.Add(this.TCorreo);
            this.Controls.Add(this.BSalir);
            this.Controls.Add(this.BIngresar);
            this.Name = "LoginForm";
            this.Text = "LoginForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BIngresar;
        private System.Windows.Forms.Button BSalir;
        private System.Windows.Forms.TextBox TCorreo;
        private System.Windows.Forms.TextBox TContraseña;
        private System.Windows.Forms.Label LCorreo;
        private System.Windows.Forms.Label LContraseña;
    }
}