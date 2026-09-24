namespace CinemaCtes
{
    partial class FormSalas
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.PHeader = new System.Windows.Forms.Panel();
            this.BAñadir = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.DGVSalas = new System.Windows.Forms.DataGridView();
            this.CNroSala = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CCapacidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CEstado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGVSalas)).BeginInit();
            this.SuspendLayout();
            // 
            // PHeader
            // 
            this.PHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(60)))));
            this.PHeader.Controls.Add(this.BAñadir);
            this.PHeader.Controls.Add(this.label2);
            this.PHeader.Controls.Add(this.label1);
            this.PHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.PHeader.Location = new System.Drawing.Point(0, 0);
            this.PHeader.Name = "PHeader";
            this.PHeader.Size = new System.Drawing.Size(734, 65);
            this.PHeader.TabIndex = 3;
            // 
            // BAñadir
            // 
            this.BAñadir.BackColor = System.Drawing.Color.AliceBlue;
            this.BAñadir.Location = new System.Drawing.Point(609, 22);
            this.BAñadir.Name = "BAñadir";
            this.BAñadir.Size = new System.Drawing.Size(113, 27);
            this.BAñadir.TabIndex = 1;
            this.BAñadir.Text = "Añadir Sala";
            this.BAñadir.UseVisualStyleBackColor = false;
            this.BAñadir.Click += new System.EventHandler(this.BAñadir_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(12, 36);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(179, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Administración de salas del complejo";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(12, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(109, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Gestión Salas";
            // 
            // DGVSalas
            // 
            this.DGVSalas.AllowUserToAddRows = false;
            this.DGVSalas.AllowUserToDeleteRows = false;
            this.DGVSalas.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DGVSalas.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(18)))), ((int)(((byte)(38)))));
            this.DGVSalas.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(27)))), ((int)(((byte)(56)))));
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DGVSalas.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.DGVSalas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGVSalas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CNroSala,
            this.CCapacidad,
            this.CEstado});
            this.DGVSalas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DGVSalas.EnableHeadersVisualStyles = false;
            this.DGVSalas.Location = new System.Drawing.Point(0, 65);
            this.DGVSalas.Name = "DGVSalas";
            this.DGVSalas.ReadOnly = true;
            this.DGVSalas.Size = new System.Drawing.Size(734, 396);
            this.DGVSalas.TabIndex = 5;
            this.DGVSalas.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGVSalas_CellContentClick);
            // 
            // CNroSala
            // 
            this.CNroSala.HeaderText = "Nro sala";
            this.CNroSala.Name = "CNroSala";
            this.CNroSala.ReadOnly = true;
            // 
            // CCapacidad
            // 
            this.CCapacidad.HeaderText = "Capacidad";
            this.CCapacidad.Name = "CCapacidad";
            this.CCapacidad.ReadOnly = true;
            // 
            // CEstado
            // 
            this.CEstado.HeaderText = "Estado";
            this.CEstado.Name = "CEstado";
            this.CEstado.ReadOnly = true;
            // 
            // FormSalas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(734, 461);
            this.Controls.Add(this.DGVSalas);
            this.Controls.Add(this.PHeader);
            this.Name = "FormSalas";
            this.Text = "FormSalas";
            this.Load += new System.EventHandler(this.FormSalas_Load);
            this.PHeader.ResumeLayout(false);
            this.PHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGVSalas)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel PHeader;
        private System.Windows.Forms.Button BAñadir;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView DGVSalas;
        private System.Windows.Forms.DataGridViewTextBoxColumn CNroSala;
        private System.Windows.Forms.DataGridViewTextBoxColumn CCapacidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn CEstado;
    }
}