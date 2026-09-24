namespace CinemaCtes
{
    partial class FormMenuPrincipal
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMenuPrincipal));
            this.PLateral = new System.Windows.Forms.Panel();
            this.FLPMenu = new System.Windows.Forms.FlowLayoutPanel();
            this.BInicio = new System.Windows.Forms.Button();
            this.BUsuarios = new System.Windows.Forms.Button();
            this.BPeliculas = new System.Windows.Forms.Button();
            this.BFunciones = new System.Windows.Forms.Button();
            this.BBeneficios = new System.Windows.Forms.Button();
            this.BSala = new System.Windows.Forms.Button();
            this.BInicio2 = new System.Windows.Forms.Button();
            this.BVentas = new System.Windows.Forms.Button();
            this.BClientes = new System.Windows.Forms.Button();
            this.BCerrar_sesion = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.PContenido = new System.Windows.Forms.Panel();
            this.BInicio3 = new System.Windows.Forms.Button();
            this.BRegistrarVenta = new System.Windows.Forms.Button();
            this.PLateral.SuspendLayout();
            this.FLPMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // PLateral
            // 
            this.PLateral.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(11)))), ((int)(((byte)(24)))));
            this.PLateral.Controls.Add(this.FLPMenu);
            this.PLateral.Controls.Add(this.BCerrar_sesion);
            this.PLateral.Controls.Add(this.pictureBox1);
            this.PLateral.Controls.Add(this.label1);
            this.PLateral.Controls.Add(this.panel3);
            this.PLateral.Dock = System.Windows.Forms.DockStyle.Left;
            this.PLateral.Location = new System.Drawing.Point(0, 0);
            this.PLateral.Name = "PLateral";
            this.PLateral.Size = new System.Drawing.Size(155, 461);
            this.PLateral.TabIndex = 0;
            // 
            // FLPMenu
            // 
            this.FLPMenu.Controls.Add(this.BInicio);
            this.FLPMenu.Controls.Add(this.BUsuarios);
            this.FLPMenu.Controls.Add(this.BPeliculas);
            this.FLPMenu.Controls.Add(this.BFunciones);
            this.FLPMenu.Controls.Add(this.BBeneficios);
            this.FLPMenu.Controls.Add(this.BSala);
            this.FLPMenu.Controls.Add(this.BInicio2);
            this.FLPMenu.Controls.Add(this.BVentas);
            this.FLPMenu.Controls.Add(this.BClientes);
            this.FLPMenu.Controls.Add(this.BInicio3);
            this.FLPMenu.Controls.Add(this.BRegistrarVenta);
            this.FLPMenu.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.FLPMenu.Location = new System.Drawing.Point(0, 106);
            this.FLPMenu.Name = "FLPMenu";
            this.FLPMenu.Size = new System.Drawing.Size(157, 305);
            this.FLPMenu.TabIndex = 0;
            this.FLPMenu.WrapContents = false;
            // 
            // BInicio
            // 
            this.BInicio.FlatAppearance.BorderSize = 0;
            this.BInicio.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BInicio.ForeColor = System.Drawing.Color.White;
            this.BInicio.Location = new System.Drawing.Point(3, 3);
            this.BInicio.Name = "BInicio";
            this.BInicio.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.BInicio.Size = new System.Drawing.Size(157, 44);
            this.BInicio.TabIndex = 0;
            this.BInicio.Text = "Inicio";
            this.BInicio.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BInicio.UseVisualStyleBackColor = true;
            this.BInicio.Click += new System.EventHandler(this.BInicio_Click);
            this.BInicio.Paint += new System.Windows.Forms.PaintEventHandler(this.Button_Paint);
            // 
            // BUsuarios
            // 
            this.BUsuarios.FlatAppearance.BorderSize = 0;
            this.BUsuarios.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BUsuarios.ForeColor = System.Drawing.Color.White;
            this.BUsuarios.Location = new System.Drawing.Point(3, 53);
            this.BUsuarios.Name = "BUsuarios";
            this.BUsuarios.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.BUsuarios.Size = new System.Drawing.Size(157, 44);
            this.BUsuarios.TabIndex = 1;
            this.BUsuarios.Text = "Usuarios";
            this.BUsuarios.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BUsuarios.UseVisualStyleBackColor = true;
            this.BUsuarios.Click += new System.EventHandler(this.BUsuarios_Click);
            this.BUsuarios.Paint += new System.Windows.Forms.PaintEventHandler(this.Button_Paint);
            // 
            // BPeliculas
            // 
            this.BPeliculas.FlatAppearance.BorderSize = 0;
            this.BPeliculas.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BPeliculas.ForeColor = System.Drawing.Color.White;
            this.BPeliculas.Location = new System.Drawing.Point(3, 103);
            this.BPeliculas.Name = "BPeliculas";
            this.BPeliculas.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.BPeliculas.Size = new System.Drawing.Size(157, 44);
            this.BPeliculas.TabIndex = 4;
            this.BPeliculas.Text = "Peliculas";
            this.BPeliculas.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BPeliculas.UseVisualStyleBackColor = true;
            this.BPeliculas.Click += new System.EventHandler(this.BPeliculas_Click);
            // 
            // BFunciones
            // 
            this.BFunciones.FlatAppearance.BorderSize = 0;
            this.BFunciones.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BFunciones.ForeColor = System.Drawing.Color.White;
            this.BFunciones.Location = new System.Drawing.Point(3, 153);
            this.BFunciones.Name = "BFunciones";
            this.BFunciones.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.BFunciones.Size = new System.Drawing.Size(157, 44);
            this.BFunciones.TabIndex = 2;
            this.BFunciones.Text = "Funciones";
            this.BFunciones.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BFunciones.UseVisualStyleBackColor = true;
            this.BFunciones.Click += new System.EventHandler(this.BFunciones_Click);
            this.BFunciones.Paint += new System.Windows.Forms.PaintEventHandler(this.Button_Paint);
            // 
            // BBeneficios
            // 
            this.BBeneficios.FlatAppearance.BorderSize = 0;
            this.BBeneficios.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BBeneficios.ForeColor = System.Drawing.Color.White;
            this.BBeneficios.Location = new System.Drawing.Point(3, 203);
            this.BBeneficios.Name = "BBeneficios";
            this.BBeneficios.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.BBeneficios.Size = new System.Drawing.Size(157, 44);
            this.BBeneficios.TabIndex = 3;
            this.BBeneficios.Text = "Beneficios";
            this.BBeneficios.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BBeneficios.UseVisualStyleBackColor = true;
            this.BBeneficios.Click += new System.EventHandler(this.BBeneficios_Click);
            this.BBeneficios.Paint += new System.Windows.Forms.PaintEventHandler(this.Button_Paint);
            // 
            // BSala
            // 
            this.BSala.FlatAppearance.BorderSize = 0;
            this.BSala.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BSala.ForeColor = System.Drawing.Color.White;
            this.BSala.Location = new System.Drawing.Point(3, 253);
            this.BSala.Name = "BSala";
            this.BSala.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.BSala.Size = new System.Drawing.Size(157, 44);
            this.BSala.TabIndex = 5;
            this.BSala.Text = "Salas";
            this.BSala.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BSala.UseVisualStyleBackColor = true;
            this.BSala.Click += new System.EventHandler(this.BSala_Click);
            // 
            // BInicio2
            // 
            this.BInicio2.FlatAppearance.BorderSize = 0;
            this.BInicio2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BInicio2.ForeColor = System.Drawing.Color.White;
            this.BInicio2.Location = new System.Drawing.Point(3, 303);
            this.BInicio2.Name = "BInicio2";
            this.BInicio2.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.BInicio2.Size = new System.Drawing.Size(157, 44);
            this.BInicio2.TabIndex = 9;
            this.BInicio2.Text = "Inicio";
            this.BInicio2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BInicio2.UseVisualStyleBackColor = true;
            this.BInicio2.Click += new System.EventHandler(this.BInicio2_Click);
            // 
            // BVentas
            // 
            this.BVentas.FlatAppearance.BorderSize = 0;
            this.BVentas.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BVentas.ForeColor = System.Drawing.Color.White;
            this.BVentas.Location = new System.Drawing.Point(3, 353);
            this.BVentas.Name = "BVentas";
            this.BVentas.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.BVentas.Size = new System.Drawing.Size(157, 44);
            this.BVentas.TabIndex = 7;
            this.BVentas.Text = "Ventas";
            this.BVentas.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BVentas.UseVisualStyleBackColor = true;
            this.BVentas.Click += new System.EventHandler(this.BVentas_Click);
            // 
            // BClientes
            // 
            this.BClientes.FlatAppearance.BorderSize = 0;
            this.BClientes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BClientes.ForeColor = System.Drawing.Color.White;
            this.BClientes.Location = new System.Drawing.Point(3, 403);
            this.BClientes.Name = "BClientes";
            this.BClientes.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.BClientes.Size = new System.Drawing.Size(157, 44);
            this.BClientes.TabIndex = 8;
            this.BClientes.Text = "Clientes";
            this.BClientes.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BClientes.UseVisualStyleBackColor = true;
            this.BClientes.Click += new System.EventHandler(this.BClientes_Click);
            // 
            // BCerrar_sesion
            // 
            this.BCerrar_sesion.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.BCerrar_sesion.FlatAppearance.BorderSize = 0;
            this.BCerrar_sesion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BCerrar_sesion.ForeColor = System.Drawing.Color.White;
            this.BCerrar_sesion.Location = new System.Drawing.Point(0, 417);
            this.BCerrar_sesion.Name = "BCerrar_sesion";
            this.BCerrar_sesion.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.BCerrar_sesion.Size = new System.Drawing.Size(155, 44);
            this.BCerrar_sesion.TabIndex = 6;
            this.BCerrar_sesion.Text = "Cerrar sesion";
            this.BCerrar_sesion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BCerrar_sesion.UseVisualStyleBackColor = true;
            this.BCerrar_sesion.Click += new System.EventHandler(this.BCerrar_sesion_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(21, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(117, 68);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(158)))));
            this.label1.Location = new System.Drawing.Point(18, 74);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(120, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Panel de Administracion";
            // 
            // panel3
            // 
            this.panel3.Location = new System.Drawing.Point(176, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(410, 222);
            this.panel3.TabIndex = 2;
            // 
            // PContenido
            // 
            this.PContenido.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(245)))));
            this.PContenido.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PContenido.Location = new System.Drawing.Point(155, 0);
            this.PContenido.Name = "PContenido";
            this.PContenido.Size = new System.Drawing.Size(729, 461);
            this.PContenido.TabIndex = 2;
            // 
            // BInicio3
            // 
            this.BInicio3.FlatAppearance.BorderSize = 0;
            this.BInicio3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BInicio3.ForeColor = System.Drawing.Color.White;
            this.BInicio3.Location = new System.Drawing.Point(3, 453);
            this.BInicio3.Name = "BInicio3";
            this.BInicio3.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.BInicio3.Size = new System.Drawing.Size(157, 44);
            this.BInicio3.TabIndex = 10;
            this.BInicio3.Text = "Inicio";
            this.BInicio3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BInicio3.UseVisualStyleBackColor = true;
            this.BInicio3.Click += new System.EventHandler(this.BInicio3_Click);
            // 
            // BRegistrarVenta
            // 
            this.BRegistrarVenta.FlatAppearance.BorderSize = 0;
            this.BRegistrarVenta.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BRegistrarVenta.ForeColor = System.Drawing.Color.White;
            this.BRegistrarVenta.Location = new System.Drawing.Point(3, 503);
            this.BRegistrarVenta.Name = "BRegistrarVenta";
            this.BRegistrarVenta.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.BRegistrarVenta.Size = new System.Drawing.Size(157, 44);
            this.BRegistrarVenta.TabIndex = 11;
            this.BRegistrarVenta.Text = "Registrar Venta";
            this.BRegistrarVenta.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BRegistrarVenta.UseVisualStyleBackColor = true;
            this.BRegistrarVenta.Click += new System.EventHandler(this.BRegistrarVenta_Click);
            // 
            // FormMenuPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(884, 461);
            this.Controls.Add(this.PContenido);
            this.Controls.Add(this.PLateral);
            this.Name = "FormMenuPrincipal";
            this.Text = "Menu";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormMenuPrincipal_FormClosed);
            this.Load += new System.EventHandler(this.FormMenuPrincipal_Load);
            this.PLateral.ResumeLayout(false);
            this.PLateral.PerformLayout();
            this.FLPMenu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel PLateral;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel PContenido;
        private System.Windows.Forms.Button BBeneficios;
        private System.Windows.Forms.Button BFunciones;
        private System.Windows.Forms.Button BUsuarios;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button BInicio;
        private System.Windows.Forms.Button BCerrar_sesion;
        private System.Windows.Forms.Button BSala;
        private System.Windows.Forms.Button BPeliculas;
        private System.Windows.Forms.Button BVentas;
        private System.Windows.Forms.FlowLayoutPanel FLPMenu;
        private System.Windows.Forms.Button BClientes;
        private System.Windows.Forms.Button BInicio2;
        private System.Windows.Forms.Button BInicio3;
        private System.Windows.Forms.Button BRegistrarVenta;
    }
}

