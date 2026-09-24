namespace CinemaCtes
{
    partial class FormRegistrarUsuario
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
            this.TApellido = new System.Windows.Forms.TextBox();
            this.TNombre = new System.Windows.Forms.TextBox();
            this.LNombre = new System.Windows.Forms.Label();
            this.LApellido = new System.Windows.Forms.Label();
            this.LContraseña = new System.Windows.Forms.Label();
            this.TDni = new System.Windows.Forms.TextBox();
            this.LDni = new System.Windows.Forms.Label();
            this.TCorreo = new System.Windows.Forms.TextBox();
            this.Lcorreo = new System.Windows.Forms.Label();
            this.TContraseña = new System.Windows.Forms.TextBox();
            this.LConf_contraseña = new System.Windows.Forms.Label();
            this.TConf_contraseña = new System.Windows.Forms.TextBox();
            this.CBTipo = new System.Windows.Forms.ComboBox();
            this.LTipo = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // LAñadir
            // 
            this.LAñadir.AutoSize = true;
            this.LAñadir.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F);
            this.LAñadir.Location = new System.Drawing.Point(161, 22);
            this.LAñadir.Name = "LAñadir";
            this.LAñadir.Size = new System.Drawing.Size(206, 22);
            this.LAñadir.TabIndex = 14;
            this.LAñadir.Text = "Añadir/Modificar Usuario";
            // 
            // BCancelar
            // 
            this.BCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.BCancelar.Location = new System.Drawing.Point(292, 247);
            this.BCancelar.Name = "BCancelar";
            this.BCancelar.Size = new System.Drawing.Size(75, 23);
            this.BCancelar.TabIndex = 9;
            this.BCancelar.Text = "Cancelar";
            this.BCancelar.UseVisualStyleBackColor = true;
            this.BCancelar.Click += new System.EventHandler(this.BCancelar_Click);
            // 
            // BInsertar
            // 
            this.BInsertar.Location = new System.Drawing.Point(161, 247);
            this.BInsertar.Name = "BInsertar";
            this.BInsertar.Size = new System.Drawing.Size(75, 23);
            this.BInsertar.TabIndex = 8;
            this.BInsertar.Text = "Insertar";
            this.BInsertar.UseVisualStyleBackColor = true;
            this.BInsertar.Click += new System.EventHandler(this.BInsertar_Click);
            // 
            // TApellido
            // 
            this.TApellido.Location = new System.Drawing.Point(81, 113);
            this.TApellido.MaxLength = 25;
            this.TApellido.Name = "TApellido";
            this.TApellido.Size = new System.Drawing.Size(129, 20);
            this.TApellido.TabIndex = 2;
            this.TApellido.TextChanged += new System.EventHandler(this.TTextoSoloLetras_TextChanged);
            this.TApellido.Leave += new System.EventHandler(this.FormatearNombreApellido_Leave);
            // 
            // TNombre
            // 
            this.TNombre.Location = new System.Drawing.Point(81, 77);
            this.TNombre.MaxLength = 25;
            this.TNombre.Name = "TNombre";
            this.TNombre.Size = new System.Drawing.Size(129, 20);
            this.TNombre.TabIndex = 0;
            this.TNombre.TextChanged += new System.EventHandler(this.TTextoSoloLetras_TextChanged);
            this.TNombre.Leave += new System.EventHandler(this.FormatearNombreApellido_Leave);
            // 
            // LNombre
            // 
            this.LNombre.AutoSize = true;
            this.LNombre.Location = new System.Drawing.Point(12, 80);
            this.LNombre.Name = "LNombre";
            this.LNombre.Size = new System.Drawing.Size(44, 13);
            this.LNombre.TabIndex = 11;
            this.LNombre.Text = "Nombre";
            // 
            // LApellido
            // 
            this.LApellido.AutoSize = true;
            this.LApellido.Location = new System.Drawing.Point(13, 116);
            this.LApellido.Name = "LApellido";
            this.LApellido.Size = new System.Drawing.Size(44, 13);
            this.LApellido.TabIndex = 9;
            this.LApellido.Text = "Apellido";
            // 
            // LContraseña
            // 
            this.LContraseña.AutoSize = true;
            this.LContraseña.Location = new System.Drawing.Point(289, 116);
            this.LContraseña.Name = "LContraseña";
            this.LContraseña.Size = new System.Drawing.Size(61, 13);
            this.LContraseña.TabIndex = 7;
            this.LContraseña.Text = "Contraseña";
            // 
            // TDni
            // 
            this.TDni.Location = new System.Drawing.Point(81, 149);
            this.TDni.MaxLength = 15;
            this.TDni.Name = "TDni";
            this.TDni.Size = new System.Drawing.Size(129, 20);
            this.TDni.TabIndex = 3;
            this.TDni.TextChanged += new System.EventHandler(this.TDni_TextChanged);
            // 
            // LDni
            // 
            this.LDni.AutoSize = true;
            this.LDni.Location = new System.Drawing.Point(13, 152);
            this.LDni.Name = "LDni";
            this.LDni.Size = new System.Drawing.Size(26, 13);
            this.LDni.TabIndex = 15;
            this.LDni.Text = "DNI";
            // 
            // TCorreo
            // 
            this.TCorreo.Location = new System.Drawing.Point(357, 77);
            this.TCorreo.MaxLength = 40;
            this.TCorreo.Name = "TCorreo";
            this.TCorreo.Size = new System.Drawing.Size(129, 20);
            this.TCorreo.TabIndex = 4;
            this.TCorreo.TextChanged += new System.EventHandler(this.LimpiarEspacios_TextChanged);
            // 
            // Lcorreo
            // 
            this.Lcorreo.AutoSize = true;
            this.Lcorreo.Location = new System.Drawing.Point(289, 80);
            this.Lcorreo.Name = "Lcorreo";
            this.Lcorreo.Size = new System.Drawing.Size(38, 13);
            this.Lcorreo.TabIndex = 17;
            this.Lcorreo.Text = "Correo";
            // 
            // TContraseña
            // 
            this.TContraseña.Location = new System.Drawing.Point(356, 113);
            this.TContraseña.MaxLength = 30;
            this.TContraseña.Name = "TContraseña";
            this.TContraseña.PasswordChar = '*';
            this.TContraseña.Size = new System.Drawing.Size(129, 20);
            this.TContraseña.TabIndex = 5;
            this.TContraseña.UseSystemPasswordChar = true;
            this.TContraseña.TextChanged += new System.EventHandler(this.LimpiarEspacios_TextChanged);
            // 
            // LConf_contraseña
            // 
            this.LConf_contraseña.AutoSize = true;
            this.LConf_contraseña.Location = new System.Drawing.Point(243, 152);
            this.LConf_contraseña.Name = "LConf_contraseña";
            this.LConf_contraseña.Size = new System.Drawing.Size(108, 13);
            this.LConf_contraseña.TabIndex = 18;
            this.LConf_contraseña.Text = "Confirmar Contraseña";
            // 
            // TConf_contraseña
            // 
            this.TConf_contraseña.Location = new System.Drawing.Point(357, 149);
            this.TConf_contraseña.MaxLength = 30;
            this.TConf_contraseña.Name = "TConf_contraseña";
            this.TConf_contraseña.PasswordChar = '*';
            this.TConf_contraseña.Size = new System.Drawing.Size(129, 20);
            this.TConf_contraseña.TabIndex = 6;
            this.TConf_contraseña.UseSystemPasswordChar = true;
            this.TConf_contraseña.TextChanged += new System.EventHandler(this.LimpiarEspacios_TextChanged);
            // 
            // CBTipo
            // 
            this.CBTipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CBTipo.FormattingEnabled = true;
            this.CBTipo.Items.AddRange(new object[] {
            "Administrador",
            "Supervisor",
            "Vendedor"});
            this.CBTipo.Location = new System.Drawing.Point(233, 196);
            this.CBTipo.Name = "CBTipo";
            this.CBTipo.Size = new System.Drawing.Size(128, 21);
            this.CBTipo.TabIndex = 7;
            // 
            // LTipo
            // 
            this.LTipo.AutoSize = true;
            this.LTipo.Location = new System.Drawing.Point(158, 199);
            this.LTipo.Name = "LTipo";
            this.LTipo.Size = new System.Drawing.Size(67, 13);
            this.LTipo.TabIndex = 19;
            this.LTipo.Text = "Tipo Usuario";
            // 
            // FormRegistrarUsuario
            // 
            this.AcceptButton = this.BInsertar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.BCancelar;
            this.ClientSize = new System.Drawing.Size(518, 299);
            this.Controls.Add(this.LTipo);
            this.Controls.Add(this.CBTipo);
            this.Controls.Add(this.TConf_contraseña);
            this.Controls.Add(this.LConf_contraseña);
            this.Controls.Add(this.TContraseña);
            this.Controls.Add(this.Lcorreo);
            this.Controls.Add(this.TCorreo);
            this.Controls.Add(this.LDni);
            this.Controls.Add(this.TDni);
            this.Controls.Add(this.LAñadir);
            this.Controls.Add(this.BCancelar);
            this.Controls.Add(this.BInsertar);
            this.Controls.Add(this.TApellido);
            this.Controls.Add(this.TNombre);
            this.Controls.Add(this.LNombre);
            this.Controls.Add(this.LApellido);
            this.Controls.Add(this.LContraseña);
            this.Name = "FormRegistrarUsuario";
            this.Text = "FormRegistrarUsuario";
            this.Load += new System.EventHandler(this.FormRegistrarUsuario_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label LAñadir;
        private System.Windows.Forms.Button BCancelar;
        private System.Windows.Forms.Button BInsertar;
        private System.Windows.Forms.TextBox TApellido;
        private System.Windows.Forms.TextBox TNombre;
        private System.Windows.Forms.Label LNombre;
        private System.Windows.Forms.Label LApellido;
        private System.Windows.Forms.Label LContraseña;
        private System.Windows.Forms.TextBox TDni;
        private System.Windows.Forms.Label LDni;
        private System.Windows.Forms.TextBox TCorreo;
        private System.Windows.Forms.Label Lcorreo;
        private System.Windows.Forms.TextBox TContraseña;
        private System.Windows.Forms.Label LConf_contraseña;
        private System.Windows.Forms.TextBox TConf_contraseña;
        private System.Windows.Forms.ComboBox CBTipo;
        private System.Windows.Forms.Label LTipo;
    }
}