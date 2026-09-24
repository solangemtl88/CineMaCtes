namespace CinemaCtes
{
    partial class FormInicio
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.LPeliculas = new System.Windows.Forms.Label();
            this.PHeader = new System.Windows.Forms.Panel();
            this.LFecha = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.BProgramarFuncion = new System.Windows.Forms.Button();
            this.BRegistrarPelicula = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.DGVProximas = new System.Windows.Forms.DataGridView();
            this.CHoraInicio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CFin = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CPelicula = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CSala = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LProximasFunciones = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.PHeader.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGVProximas)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(30)))), ((int)(((byte)(55)))));
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.LPeliculas);
            this.panel1.Location = new System.Drawing.Point(40, 71);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(200, 100);
            this.panel1.TabIndex = 0;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(74, 54);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(45, 20);
            this.label3.TabIndex = 1;
            this.label3.Text = "( 6 )";
            // 
            // LPeliculas
            // 
            this.LPeliculas.AutoSize = true;
            this.LPeliculas.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LPeliculas.ForeColor = System.Drawing.Color.White;
            this.LPeliculas.Location = new System.Drawing.Point(14, 14);
            this.LPeliculas.Name = "LPeliculas";
            this.LPeliculas.Size = new System.Drawing.Size(169, 18);
            this.LPeliculas.TabIndex = 0;
            this.LPeliculas.Text = "PELICULAS ACTIVAS";
            // 
            // PHeader
            // 
            this.PHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(60)))));
            this.PHeader.Controls.Add(this.LFecha);
            this.PHeader.Controls.Add(this.label2);
            this.PHeader.Controls.Add(this.label1);
            this.PHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.PHeader.Location = new System.Drawing.Point(0, 0);
            this.PHeader.Name = "PHeader";
            this.PHeader.Size = new System.Drawing.Size(734, 65);
            this.PHeader.TabIndex = 4;
            // 
            // LFecha
            // 
            this.LFecha.AutoSize = true;
            this.LFecha.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.LFecha.ForeColor = System.Drawing.Color.White;
            this.LFecha.Location = new System.Drawing.Point(512, 21);
            this.LFecha.Name = "LFecha";
            this.LFecha.Size = new System.Drawing.Size(47, 15);
            this.LFecha.TabIndex = 1;
            this.LFecha.Text = "[Fecha]";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(12, 36);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(129, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Vista general - Dashboard";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(12, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(212, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "CinemaCtes - Panel Principal";
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(30)))), ((int)(((byte)(55)))));
            this.panel4.Controls.Add(this.label4);
            this.panel4.Controls.Add(this.label5);
            this.panel4.Location = new System.Drawing.Point(269, 71);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(200, 100);
            this.panel4.TabIndex = 2;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(74, 54);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(55, 20);
            this.label4.TabIndex = 1;
            this.label4.Text = "( 12 )";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(26, 14);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(145, 18);
            this.label5.TabIndex = 0;
            this.label5.Text = "FUNCIONES HOY";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(30)))), ((int)(((byte)(55)))));
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Location = new System.Drawing.Point(495, 71);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(200, 100);
            this.panel2.TabIndex = 2;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(81, 54);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(45, 20);
            this.label6.TabIndex = 1;
            this.label6.Text = "( 3 )";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(16, 14);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(166, 18);
            this.label7.TabIndex = 0;
            this.label7.Text = "SALAS OPERATIVAS";
            // 
            // BProgramarFuncion
            // 
            this.BProgramarFuncion.Location = new System.Drawing.Point(38, 209);
            this.BProgramarFuncion.Name = "BProgramarFuncion";
            this.BProgramarFuncion.Size = new System.Drawing.Size(119, 23);
            this.BProgramarFuncion.TabIndex = 5;
            this.BProgramarFuncion.Text = "Programar Funcion";
            this.BProgramarFuncion.UseVisualStyleBackColor = true;
            this.BProgramarFuncion.Click += new System.EventHandler(this.BProgramarFuncion_Click);
            // 
            // BRegistrarPelicula
            // 
            this.BRegistrarPelicula.Location = new System.Drawing.Point(199, 209);
            this.BRegistrarPelicula.Name = "BRegistrarPelicula";
            this.BRegistrarPelicula.Size = new System.Drawing.Size(119, 23);
            this.BRegistrarPelicula.TabIndex = 6;
            this.BRegistrarPelicula.Text = "Registrar Pelicula";
            this.BRegistrarPelicula.UseVisualStyleBackColor = true;
            this.BRegistrarPelicula.Click += new System.EventHandler(this.BRegistrarPelicula_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.label8.ForeColor = System.Drawing.Color.White;
            this.label8.Location = new System.Drawing.Point(38, 187);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(96, 15);
            this.label8.TabIndex = 7;
            this.label8.Text = "Accesos rapidos";
            // 
            // DGVProximas
            // 
            this.DGVProximas.AllowUserToAddRows = false;
            this.DGVProximas.AllowUserToDeleteRows = false;
            this.DGVProximas.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DGVProximas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGVProximas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CHoraInicio,
            this.CFin,
            this.CPelicula,
            this.CSala});
            this.DGVProximas.Location = new System.Drawing.Point(0, 271);
            this.DGVProximas.Name = "DGVProximas";
            this.DGVProximas.ReadOnly = true;
            this.DGVProximas.Size = new System.Drawing.Size(734, 188);
            this.DGVProximas.TabIndex = 8;
            // 
            // CHoraInicio
            // 
            this.CHoraInicio.HeaderText = "Hora Inicio";
            this.CHoraInicio.Name = "CHoraInicio";
            this.CHoraInicio.ReadOnly = true;
            // 
            // CFin
            // 
            this.CFin.HeaderText = "Hora Fin";
            this.CFin.Name = "CFin";
            this.CFin.ReadOnly = true;
            // 
            // CPelicula
            // 
            this.CPelicula.HeaderText = "Pelicula";
            this.CPelicula.Name = "CPelicula";
            this.CPelicula.ReadOnly = true;
            // 
            // CSala
            // 
            this.CSala.HeaderText = "Sala";
            this.CSala.Name = "CSala";
            this.CSala.ReadOnly = true;
            // 
            // LProximasFunciones
            // 
            this.LProximasFunciones.AutoSize = true;
            this.LProximasFunciones.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.LProximasFunciones.ForeColor = System.Drawing.Color.White;
            this.LProximasFunciones.Location = new System.Drawing.Point(38, 244);
            this.LProximasFunciones.Name = "LProximasFunciones";
            this.LProximasFunciones.Size = new System.Drawing.Size(236, 15);
            this.LProximasFunciones.TabIndex = 9;
            this.LProximasFunciones.Text = "Proximas funciones en cartelera para hoy:";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.Black;
            this.panel3.Location = new System.Drawing.Point(39, 70);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(202, 102);
            this.panel3.TabIndex = 2;
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.Black;
            this.panel5.Location = new System.Drawing.Point(268, 70);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(202, 102);
            this.panel5.TabIndex = 3;
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.Color.Black;
            this.panel6.Location = new System.Drawing.Point(494, 70);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(202, 102);
            this.panel6.TabIndex = 4;
            // 
            // FormInicio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(18)))), ((int)(((byte)(38)))));
            this.ClientSize = new System.Drawing.Size(734, 461);
            this.Controls.Add(this.LProximasFunciones);
            this.Controls.Add(this.DGVProximas);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.BRegistrarPelicula);
            this.Controls.Add(this.BProgramarFuncion);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.PHeader);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.panel6);
            this.Name = "FormInicio";
            this.Text = "FormInicio";
            this.Load += new System.EventHandler(this.FormInicio_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.PHeader.ResumeLayout(false);
            this.PHeader.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGVProximas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label LPeliculas;
        private System.Windows.Forms.Panel PHeader;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button BProgramarFuncion;
        private System.Windows.Forms.Button BRegistrarPelicula;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DataGridView DGVProximas;
        private System.Windows.Forms.DataGridViewTextBoxColumn CHoraInicio;
        private System.Windows.Forms.DataGridViewTextBoxColumn CFin;
        private System.Windows.Forms.DataGridViewTextBoxColumn CPelicula;
        private System.Windows.Forms.DataGridViewTextBoxColumn CSala;
        private System.Windows.Forms.Label LFecha;
        private System.Windows.Forms.Label LProximasFunciones;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel6;
    }
}