namespace SistemaGestionInventarios
{
    partial class FrmIngresos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmIngresos));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.btnProveedor = new System.Windows.Forms.ToolStripButton();
            this.btnDetalleIngresos = new System.Windows.Forms.ToolStripButton();
            this.dgvIngresos = new System.Windows.Forms.DataGridView();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cmbTrabajador = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.cmbProveedor = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.cmbTipoComprobante = new System.Windows.Forms.ComboBox();
            this.dateTimePickerIngresos = new System.Windows.Forms.DateTimePicker();
            this.txtSerie = new System.Windows.Forms.TextBox();
            this.txtEstado = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtCorrelativo = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.btnEditar = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvIngresos)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.Color.LightGray;
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton1,
            this.btnProveedor,
            this.btnDetalleIngresos});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1531, 52);
            this.toolStrip1.TabIndex = 2;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(84, 49);
            this.toolStripButton1.Text = "Ingresos";
            this.toolStripButton1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // btnProveedor
            // 
            this.btnProveedor.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnProveedor.Image = ((System.Drawing.Image)(resources.GetObject("btnProveedor.Image")));
            this.btnProveedor.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnProveedor.Name = "btnProveedor";
            this.btnProveedor.Size = new System.Drawing.Size(98, 49);
            this.btnProveedor.Text = "Proveedor";
            this.btnProveedor.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnProveedor.Click += new System.EventHandler(this.btnProveedor_Click);
            // 
            // btnDetalleIngresos
            // 
            this.btnDetalleIngresos.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDetalleIngresos.Image = ((System.Drawing.Image)(resources.GetObject("btnDetalleIngresos.Image")));
            this.btnDetalleIngresos.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnDetalleIngresos.Name = "btnDetalleIngresos";
            this.btnDetalleIngresos.Size = new System.Drawing.Size(168, 49);
            this.btnDetalleIngresos.Text = "Detalles de Ingreso";
            this.btnDetalleIngresos.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnDetalleIngresos.Click += new System.EventHandler(this.btnDetalleIngresos_Click);
            // 
            // dgvIngresos
            // 
            this.dgvIngresos.AllowUserToAddRows = false;
            this.dgvIngresos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvIngresos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvIngresos.Location = new System.Drawing.Point(24, 606);
            this.dgvIngresos.Name = "dgvIngresos";
            this.dgvIngresos.RowHeadersWidth = 51;
            this.dgvIngresos.RowTemplate.Height = 24;
            this.dgvIngresos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvIngresos.Size = new System.Drawing.Size(1260, 255);
            this.dgvIngresos.TabIndex = 6;
            this.dgvIngresos.Tag = "Ingresos";
            this.dgvIngresos.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvIngresos_CellContentClick);
            this.dgvIngresos.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvIngresos_CellContentClick);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Maroon;
            this.label3.Location = new System.Drawing.Point(548, 36);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(138, 36);
            this.label3.TabIndex = 7;
            this.label3.Text = "Ingresos";
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.White;
            this.groupBox1.Controls.Add(this.cmbTrabajador);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.cmbProveedor);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.cmbTipoComprobante);
            this.groupBox1.Controls.Add(this.dateTimePickerIngresos);
            this.groupBox1.Controls.Add(this.txtSerie);
            this.groupBox1.Controls.Add(this.txtEstado);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtCorrelativo);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.btnLimpiar);
            this.groupBox1.Controls.Add(this.btnEditar);
            this.groupBox1.Controls.Add(this.btnEliminar);
            this.groupBox1.Controls.Add(this.btnAgregar);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(24, 95);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1260, 505);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Ingresos";
            // 
            // cmbTrabajador
            // 
            this.cmbTrabajador.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.cmbTrabajador.FormattingEnabled = true;
            this.cmbTrabajador.Items.AddRange(new object[] {
            "TICKET",
            "FACTURA"});
            this.cmbTrabajador.Location = new System.Drawing.Point(769, 175);
            this.cmbTrabajador.Name = "cmbTrabajador";
            this.cmbTrabajador.Size = new System.Drawing.Size(246, 30);
            this.cmbTrabajador.TabIndex = 29;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(613, 178);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(103, 22);
            this.label8.TabIndex = 28;
            this.label8.Text = "Trabajador:";
            // 
            // cmbProveedor
            // 
            this.cmbProveedor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.cmbProveedor.FormattingEnabled = true;
            this.cmbProveedor.Items.AddRange(new object[] {
            "TICKET",
            "FACTURA"});
            this.cmbProveedor.Location = new System.Drawing.Point(253, 39);
            this.cmbProveedor.Name = "cmbProveedor";
            this.cmbProveedor.Size = new System.Drawing.Size(246, 30);
            this.cmbProveedor.TabIndex = 27;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(18, 47);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(98, 22);
            this.label7.TabIndex = 26;
            this.label7.Text = "Proveedor:";
            // 
            // cmbTipoComprobante
            // 
            this.cmbTipoComprobante.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.cmbTipoComprobante.FormattingEnabled = true;
            this.cmbTipoComprobante.Items.AddRange(new object[] {
            "TICKET",
            "FACTURA"});
            this.cmbTipoComprobante.Location = new System.Drawing.Point(253, 97);
            this.cmbTipoComprobante.Name = "cmbTipoComprobante";
            this.cmbTipoComprobante.Size = new System.Drawing.Size(246, 30);
            this.cmbTipoComprobante.TabIndex = 25;
            // 
            // dateTimePickerIngresos
            // 
            this.dateTimePickerIngresos.Location = new System.Drawing.Point(769, 36);
            this.dateTimePickerIngresos.Name = "dateTimePickerIngresos";
            this.dateTimePickerIngresos.Size = new System.Drawing.Size(246, 28);
            this.dateTimePickerIngresos.TabIndex = 17;
            // 
            // txtSerie
            // 
            this.txtSerie.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.txtSerie.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSerie.Location = new System.Drawing.Point(253, 172);
            this.txtSerie.Name = "txtSerie";
            this.txtSerie.Size = new System.Drawing.Size(246, 28);
            this.txtSerie.TabIndex = 16;
            // 
            // txtEstado
            // 
            this.txtEstado.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.txtEstado.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtEstado.Location = new System.Drawing.Point(253, 310);
            this.txtEstado.Name = "txtEstado";
            this.txtEstado.Size = new System.Drawing.Size(246, 28);
            this.txtEstado.TabIndex = 15;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 310);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 22);
            this.label1.TabIndex = 14;
            this.label1.Text = "Estado:";
            // 
            // txtCorrelativo
            // 
            this.txtCorrelativo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.txtCorrelativo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCorrelativo.Location = new System.Drawing.Point(253, 243);
            this.txtCorrelativo.Name = "txtCorrelativo";
            this.txtCorrelativo.Size = new System.Drawing.Size(246, 28);
            this.txtCorrelativo.TabIndex = 13;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 243);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(102, 22);
            this.label2.TabIndex = 12;
            this.label2.Text = "Correlativo:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(613, 41);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(129, 22);
            this.label6.TabIndex = 10;
            this.label6.Text = "Fecha Ingreso:";
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnLimpiar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLimpiar.Location = new System.Drawing.Point(499, 394);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(124, 64);
            this.btnLimpiar.TabIndex = 9;
            this.btnLimpiar.Text = "&Limpiar";
            this.btnLimpiar.UseVisualStyleBackColor = false;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // btnEditar
            // 
            this.btnEditar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnEditar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEditar.Location = new System.Drawing.Point(340, 394);
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(124, 64);
            this.btnEditar.TabIndex = 8;
            this.btnEditar.Text = "E&ditar";
            this.btnEditar.UseVisualStyleBackColor = false;
            this.btnEditar.Click += new System.EventHandler(this.btnEditar_Click);
            // 
            // btnEliminar
            // 
            this.btnEliminar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnEliminar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEliminar.Location = new System.Drawing.Point(175, 394);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(124, 64);
            this.btnEliminar.TabIndex = 7;
            this.btnEliminar.Text = "&Eliminar";
            this.btnEliminar.UseVisualStyleBackColor = false;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // btnAgregar
            // 
            this.btnAgregar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnAgregar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAgregar.Location = new System.Drawing.Point(19, 394);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(124, 64);
            this.btnAgregar.TabIndex = 6;
            this.btnAgregar.Text = "&Agregar";
            this.btnAgregar.UseVisualStyleBackColor = false;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(18, 174);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(57, 22);
            this.label5.TabIndex = 2;
            this.label5.Text = "Serie:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(14, 97);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(189, 22);
            this.label4.TabIndex = 1;
            this.label4.Text = "Tipo de Comprobante:";
            // 
            // FrmIngresos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1531, 938);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dgvIngresos);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.toolStrip1);
            this.Name = "FrmIngresos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmIngresos";
            this.Load += new System.EventHandler(this.FrmIngresos_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvIngresos)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btnProveedor;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.DataGridView dgvIngresos;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ToolStripButton btnDetalleIngresos;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cmbTipoComprobante;
        private System.Windows.Forms.DateTimePicker dateTimePickerIngresos;
        private System.Windows.Forms.TextBox txtSerie;
        private System.Windows.Forms.TextBox txtEstado;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtCorrelativo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.Button btnEditar;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmbProveedor;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cmbTrabajador;
    }
}