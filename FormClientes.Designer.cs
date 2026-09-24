namespace CinemaCtes
{
    partial class FormClientes
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.PHeader = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.LBuscar = new System.Windows.Forms.Label();
            this.LEstado = new System.Windows.Forms.Label();
            this.CBEstado = new System.Windows.Forms.ComboBox();
            this.TBuscar = new System.Windows.Forms.TextBox();
            this.DGVClientes = new System.Windows.Forms.DataGridView();
            this.CDni = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CNombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CApellido = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CCorreo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CCompras = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CEstado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PHeader.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGVClientes)).BeginInit();
            this.SuspendLayout();
            // 
            // PHeader
            // 
            this.PHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(60)))));
            this.PHeader.Controls.Add(this.label2);
            this.PHeader.Controls.Add(this.label1);
            this.PHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.PHeader.Location = new System.Drawing.Point(0, 0);
            this.PHeader.Name = "PHeader";
            this.PHeader.Size = new System.Drawing.Size(734, 65);
            this.PHeader.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(12, 36);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(189, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Administra y consulta datos de clientes";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(12, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(126, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Gestión Clientes";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(18)))), ((int)(((byte)(38)))));
            this.panel3.Controls.Add(this.LBuscar);
            this.panel3.Controls.Add(this.LEstado);
            this.panel3.Controls.Add(this.CBEstado);
            this.panel3.Controls.Add(this.TBuscar);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 65);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(734, 51);
            this.panel3.TabIndex = 4;
            // 
            // LBuscar
            // 
            this.LBuscar.Location = new System.Drawing.Point(-3, 0);
            this.LBuscar.Name = "LBuscar";
            this.LBuscar.Size = new System.Drawing.Size(100, 23);
            this.LBuscar.TabIndex = 0;
            // 
            // LEstado
            // 
            this.LEstado.AutoSize = true;
            this.LEstado.ForeColor = System.Drawing.Color.White;
            this.LEstado.Location = new System.Drawing.Point(640, 7);
            this.LEstado.Name = "LEstado";
            this.LEstado.Size = new System.Drawing.Size(40, 13);
            this.LEstado.TabIndex = 4;
            this.LEstado.Text = "Estado";
            // 
            // CBEstado
            // 
            this.CBEstado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CBEstado.FormattingEnabled = true;
            this.CBEstado.Items.AddRange(new object[] {
            "Todos",
            "Activo",
            "Inactivo"});
            this.CBEstado.Location = new System.Drawing.Point(601, 23);
            this.CBEstado.Name = "CBEstado";
            this.CBEstado.Size = new System.Drawing.Size(121, 21);
            this.CBEstado.TabIndex = 1;
            this.CBEstado.SelectedIndexChanged += new System.EventHandler(this.CBEstado_SelectedIndexChanged);
            // 
            // TBuscar
            // 
            this.TBuscar.ForeColor = System.Drawing.Color.Black;
            this.TBuscar.Location = new System.Drawing.Point(41, 24);
            this.TBuscar.Name = "TBuscar";
            this.TBuscar.Size = new System.Drawing.Size(350, 20);
            this.TBuscar.TabIndex = 0;
            this.TBuscar.TextChanged += new System.EventHandler(this.TBuscar_TextChanged);
            this.TBuscar.Enter += new System.EventHandler(this.TBuscar_Enter);
            this.TBuscar.Leave += new System.EventHandler(this.TBuscar_Leave);
            // 
            // DGVClientes
            // 
            this.DGVClientes.AllowUserToAddRows = false;
            this.DGVClientes.AllowUserToDeleteRows = false;
            this.DGVClientes.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DGVClientes.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(18)))), ((int)(((byte)(38)))));
            this.DGVClientes.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(27)))), ((int)(((byte)(56)))));
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DGVClientes.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.DGVClientes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGVClientes.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CDni,
            this.CNombre,
            this.CApellido,
            this.CCorreo,
            this.CCompras,
            this.CEstado});
            this.DGVClientes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DGVClientes.EnableHeadersVisualStyles = false;
            this.DGVClientes.Location = new System.Drawing.Point(0, 116);
            this.DGVClientes.Name = "DGVClientes";
            this.DGVClientes.ReadOnly = true;
            this.DGVClientes.Size = new System.Drawing.Size(734, 345);
            this.DGVClientes.TabIndex = 5;
            this.DGVClientes.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGVClientes_CellClick);
            // 
            // CDni
            // 
            this.CDni.HeaderText = "DNI";
            this.CDni.Name = "CDni";
            this.CDni.ReadOnly = true;
            // 
            // CNombre
            // 
            this.CNombre.HeaderText = "Nombre";
            this.CNombre.Name = "CNombre";
            this.CNombre.ReadOnly = true;
            // 
            // CApellido
            // 
            this.CApellido.HeaderText = "Apellido";
            this.CApellido.Name = "CApellido";
            this.CApellido.ReadOnly = true;
            // 
            // CCorreo
            // 
            this.CCorreo.HeaderText = "Correo";
            this.CCorreo.Name = "CCorreo";
            this.CCorreo.ReadOnly = true;
            // 
            // CCompras
            // 
            this.CCompras.HeaderText = "Compras";
            this.CCompras.Name = "CCompras";
            this.CCompras.ReadOnly = true;
            // 
            // CEstado
            // 
            this.CEstado.HeaderText = "Estado";
            this.CEstado.Name = "CEstado";
            this.CEstado.ReadOnly = true;
            // 
            // FormClientes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(734, 461);
            this.Controls.Add(this.DGVClientes);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.PHeader);
            this.Name = "FormClientes";
            this.Text = "FormClientes";
            this.Load += new System.EventHandler(this.FormClientes_Load);
            this.PHeader.ResumeLayout(false);
            this.PHeader.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGVClientes)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel PHeader;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label LBuscar;
        private System.Windows.Forms.Label LEstado;
        private System.Windows.Forms.ComboBox CBEstado;
        private System.Windows.Forms.TextBox TBuscar;
        private System.Windows.Forms.DataGridView DGVClientes;
        private System.Windows.Forms.DataGridViewTextBoxColumn CDni;
        private System.Windows.Forms.DataGridViewTextBoxColumn CNombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn CApellido;
        private System.Windows.Forms.DataGridViewTextBoxColumn CCorreo;
        private System.Windows.Forms.DataGridViewTextBoxColumn CCompras;
        private System.Windows.Forms.DataGridViewTextBoxColumn CEstado;
    }
}