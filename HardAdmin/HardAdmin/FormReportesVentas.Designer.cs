namespace HardAdmin
{
    partial class FormReportesVentas
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
            this.gbVentas = new System.Windows.Forms.GroupBox();
            this.lbTitulo = new System.Windows.Forms.Label();
            this.lbDesde = new System.Windows.Forms.Label();
            this.lbHasta = new System.Windows.Forms.Label();
            this.dtpDesde = new System.Windows.Forms.DateTimePicker();
            this.dtpHasta = new System.Windows.Forms.DateTimePicker();
            this.lbCliente = new System.Windows.Forms.Label();
            this.txtCliente = new System.Windows.Forms.TextBox();
            this.lbUsuario = new System.Windows.Forms.Label();
            this.txtUsuario = new System.Windows.Forms.TextBox();
            this.lbProducto = new System.Windows.Forms.Label();
            this.txtProducto = new System.Windows.Forms.TextBox();
            this.btnGenerar = new System.Windows.Forms.Button();
            this.dtgReportesVentas = new System.Windows.Forms.DataGridView();
            this.colFecha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNroVenta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCliente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colVendedor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gbResumen = new System.Windows.Forms.GroupBox();
            this.lbVentasTotal = new System.Windows.Forms.Label();
            this.lbProdTotal = new System.Windows.Forms.Label();
            this.lbTotal = new System.Windows.Forms.Label();
            this.lbVentasTotalResultado = new System.Windows.Forms.Label();
            this.lbProductosTotalResultado = new System.Windows.Forms.Label();
            this.lbTotalResultado = new System.Windows.Forms.Label();
            this.btnExportar = new System.Windows.Forms.Button();
            this.gbVentas.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgReportesVentas)).BeginInit();
            this.gbResumen.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbVentas
            // 
            this.gbVentas.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbVentas.Controls.Add(this.gbResumen);
            this.gbVentas.Controls.Add(this.btnGenerar);
            this.gbVentas.Controls.Add(this.txtProducto);
            this.gbVentas.Controls.Add(this.lbProducto);
            this.gbVentas.Controls.Add(this.txtUsuario);
            this.gbVentas.Controls.Add(this.lbUsuario);
            this.gbVentas.Controls.Add(this.txtCliente);
            this.gbVentas.Controls.Add(this.lbCliente);
            this.gbVentas.Controls.Add(this.dtpHasta);
            this.gbVentas.Controls.Add(this.dtpDesde);
            this.gbVentas.Controls.Add(this.lbHasta);
            this.gbVentas.Controls.Add(this.lbDesde);
            this.gbVentas.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbVentas.Location = new System.Drawing.Point(12, 44);
            this.gbVentas.Name = "gbVentas";
            this.gbVentas.Size = new System.Drawing.Size(776, 181);
            this.gbVentas.TabIndex = 0;
            this.gbVentas.TabStop = false;
            this.gbVentas.Text = "Filtros ";
            // 
            // lbTitulo
            // 
            this.lbTitulo.AutoSize = true;
            this.lbTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTitulo.Location = new System.Drawing.Point(267, 10);
            this.lbTitulo.Name = "lbTitulo";
            this.lbTitulo.Size = new System.Drawing.Size(254, 31);
            this.lbTitulo.TabIndex = 1;
            this.lbTitulo.Text = "Reportes de Ventas";
            // 
            // lbDesde
            // 
            this.lbDesde.AutoSize = true;
            this.lbDesde.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbDesde.Location = new System.Drawing.Point(22, 32);
            this.lbDesde.Name = "lbDesde";
            this.lbDesde.Size = new System.Drawing.Size(55, 18);
            this.lbDesde.TabIndex = 0;
            this.lbDesde.Text = "Desde:";
            // 
            // lbHasta
            // 
            this.lbHasta.AutoSize = true;
            this.lbHasta.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbHasta.Location = new System.Drawing.Point(215, 32);
            this.lbHasta.Name = "lbHasta";
            this.lbHasta.Size = new System.Drawing.Size(51, 18);
            this.lbHasta.TabIndex = 1;
            this.lbHasta.Text = "Hasta:";
            // 
            // dtpDesde
            // 
            this.dtpDesde.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDesde.Location = new System.Drawing.Point(83, 32);
            this.dtpDesde.Name = "dtpDesde";
            this.dtpDesde.Size = new System.Drawing.Size(114, 24);
            this.dtpDesde.TabIndex = 0;
            // 
            // dtpHasta
            // 
            this.dtpHasta.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpHasta.Location = new System.Drawing.Point(272, 32);
            this.dtpHasta.Name = "dtpHasta";
            this.dtpHasta.Size = new System.Drawing.Size(114, 24);
            this.dtpHasta.TabIndex = 2;
            // 
            // lbCliente
            // 
            this.lbCliente.AutoSize = true;
            this.lbCliente.Location = new System.Drawing.Point(22, 110);
            this.lbCliente.Name = "lbCliente";
            this.lbCliente.Size = new System.Drawing.Size(106, 18);
            this.lbCliente.TabIndex = 3;
            this.lbCliente.Text = "Nro de Cliente:";
            // 
            // txtCliente
            // 
            this.txtCliente.Location = new System.Drawing.Point(157, 107);
            this.txtCliente.Name = "txtCliente";
            this.txtCliente.Size = new System.Drawing.Size(171, 24);
            this.txtCliente.TabIndex = 4;
            // 
            // lbUsuario
            // 
            this.lbUsuario.AutoSize = true;
            this.lbUsuario.Location = new System.Drawing.Point(22, 71);
            this.lbUsuario.Name = "lbUsuario";
            this.lbUsuario.Size = new System.Drawing.Size(113, 18);
            this.lbUsuario.TabIndex = 5;
            this.lbUsuario.Text = "Nro de Usuario:";
            // 
            // txtUsuario
            // 
            this.txtUsuario.Location = new System.Drawing.Point(157, 68);
            this.txtUsuario.Name = "txtUsuario";
            this.txtUsuario.Size = new System.Drawing.Size(171, 24);
            this.txtUsuario.TabIndex = 6;
            // 
            // lbProducto
            // 
            this.lbProducto.AutoSize = true;
            this.lbProducto.Location = new System.Drawing.Point(22, 147);
            this.lbProducto.Name = "lbProducto";
            this.lbProducto.Size = new System.Drawing.Size(129, 18);
            this.lbProducto.TabIndex = 7;
            this.lbProducto.Text = "Cod. de Producto:";
            // 
            // txtProducto
            // 
            this.txtProducto.Location = new System.Drawing.Point(157, 144);
            this.txtProducto.Name = "txtProducto";
            this.txtProducto.Size = new System.Drawing.Size(171, 24);
            this.txtProducto.TabIndex = 8;
            // 
            // btnGenerar
            // 
            this.btnGenerar.Location = new System.Drawing.Point(358, 96);
            this.btnGenerar.Name = "btnGenerar";
            this.btnGenerar.Size = new System.Drawing.Size(151, 46);
            this.btnGenerar.TabIndex = 9;
            this.btnGenerar.Text = "Generar Reporte";
            this.btnGenerar.UseVisualStyleBackColor = true;
            // 
            // dtgReportesVentas
            // 
            this.dtgReportesVentas.AllowUserToAddRows = false;
            this.dtgReportesVentas.AllowUserToDeleteRows = false;
            this.dtgReportesVentas.AllowUserToResizeRows = false;
            this.dtgReportesVentas.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dtgReportesVentas.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgReportesVentas.ColumnHeadersHeight = 34;
            this.dtgReportesVentas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dtgReportesVentas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colFecha,
            this.colNroVenta,
            this.colCliente,
            this.colVendedor,
            this.colTotal});
            this.dtgReportesVentas.Location = new System.Drawing.Point(13, 231);
            this.dtgReportesVentas.MultiSelect = false;
            this.dtgReportesVentas.Name = "dtgReportesVentas";
            this.dtgReportesVentas.ReadOnly = true;
            this.dtgReportesVentas.RowHeadersVisible = false;
            this.dtgReportesVentas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgReportesVentas.Size = new System.Drawing.Size(774, 174);
            this.dtgReportesVentas.TabIndex = 3;
            // 
            // colFecha
            // 
            this.colFecha.HeaderText = "Dia/Mes/Año";
            this.colFecha.Name = "colFecha";
            this.colFecha.ReadOnly = true;
            // 
            // colNroVenta
            // 
            this.colNroVenta.HeaderText = "Nro de Venta";
            this.colNroVenta.Name = "colNroVenta";
            this.colNroVenta.ReadOnly = true;
            // 
            // colCliente
            // 
            this.colCliente.HeaderText = "Cliente";
            this.colCliente.Name = "colCliente";
            this.colCliente.ReadOnly = true;
            // 
            // colVendedor
            // 
            this.colVendedor.HeaderText = "Vendedor";
            this.colVendedor.Name = "colVendedor";
            this.colVendedor.ReadOnly = true;
            // 
            // colTotal
            // 
            this.colTotal.HeaderText = "Total";
            this.colTotal.Name = "colTotal";
            this.colTotal.ReadOnly = true;
            // 
            // gbResumen
            // 
            this.gbResumen.Controls.Add(this.lbTotalResultado);
            this.gbResumen.Controls.Add(this.lbProductosTotalResultado);
            this.gbResumen.Controls.Add(this.lbVentasTotalResultado);
            this.gbResumen.Controls.Add(this.lbTotal);
            this.gbResumen.Controls.Add(this.lbProdTotal);
            this.gbResumen.Controls.Add(this.lbVentasTotal);
            this.gbResumen.Location = new System.Drawing.Point(527, 32);
            this.gbResumen.Name = "gbResumen";
            this.gbResumen.Size = new System.Drawing.Size(233, 135);
            this.gbResumen.TabIndex = 10;
            this.gbResumen.TabStop = false;
            this.gbResumen.Text = "Resumen";
            // 
            // lbVentasTotal
            // 
            this.lbVentasTotal.AutoSize = true;
            this.lbVentasTotal.Location = new System.Drawing.Point(21, 36);
            this.lbVentasTotal.Name = "lbVentasTotal";
            this.lbVentasTotal.Size = new System.Drawing.Size(57, 18);
            this.lbVentasTotal.TabIndex = 0;
            this.lbVentasTotal.Text = "Ventas:";
            // 
            // lbProdTotal
            // 
            this.lbProdTotal.AutoSize = true;
            this.lbProdTotal.Location = new System.Drawing.Point(21, 64);
            this.lbProdTotal.Name = "lbProdTotal";
            this.lbProdTotal.Size = new System.Drawing.Size(81, 18);
            this.lbProdTotal.TabIndex = 1;
            this.lbProdTotal.Text = "Productos:";
            // 
            // lbTotal
            // 
            this.lbTotal.AutoSize = true;
            this.lbTotal.Location = new System.Drawing.Point(21, 92);
            this.lbTotal.Name = "lbTotal";
            this.lbTotal.Size = new System.Drawing.Size(102, 18);
            this.lbTotal.TabIndex = 2;
            this.lbTotal.Text = "Total Vendido:";
            // 
            // lbVentasTotalResultado
            // 
            this.lbVentasTotalResultado.AutoSize = true;
            this.lbVentasTotalResultado.Location = new System.Drawing.Point(84, 36);
            this.lbVentasTotalResultado.Name = "lbVentasTotalResultado";
            this.lbVentasTotalResultado.Size = new System.Drawing.Size(20, 18);
            this.lbVentasTotalResultado.TabIndex = 3;
            this.lbVentasTotalResultado.Text = "...";
            // 
            // lbProductosTotalResultado
            // 
            this.lbProductosTotalResultado.AutoSize = true;
            this.lbProductosTotalResultado.Location = new System.Drawing.Point(108, 64);
            this.lbProductosTotalResultado.Name = "lbProductosTotalResultado";
            this.lbProductosTotalResultado.Size = new System.Drawing.Size(20, 18);
            this.lbProductosTotalResultado.TabIndex = 4;
            this.lbProductosTotalResultado.Text = "...";
            // 
            // lbTotalResultado
            // 
            this.lbTotalResultado.AutoSize = true;
            this.lbTotalResultado.Location = new System.Drawing.Point(129, 92);
            this.lbTotalResultado.Name = "lbTotalResultado";
            this.lbTotalResultado.Size = new System.Drawing.Size(20, 18);
            this.lbTotalResultado.TabIndex = 5;
            this.lbTotalResultado.Text = "...";
            // 
            // btnExportar
            // 
            this.btnExportar.Location = new System.Drawing.Point(699, 411);
            this.btnExportar.Name = "btnExportar";
            this.btnExportar.Size = new System.Drawing.Size(88, 33);
            this.btnExportar.TabIndex = 4;
            this.btnExportar.Text = "Exportar";
            this.btnExportar.UseVisualStyleBackColor = true;
            // 
            // FormReportesVentas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnExportar);
            this.Controls.Add(this.dtgReportesVentas);
            this.Controls.Add(this.lbTitulo);
            this.Controls.Add(this.gbVentas);
            this.Name = "FormReportesVentas";
            this.Text = "HardAdmin - Reportes de Ventas";
            this.gbVentas.ResumeLayout(false);
            this.gbVentas.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgReportesVentas)).EndInit();
            this.gbResumen.ResumeLayout(false);
            this.gbResumen.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox gbVentas;
        private System.Windows.Forms.Label lbDesde;
        private System.Windows.Forms.Label lbTitulo;
        private System.Windows.Forms.Label lbHasta;
        private System.Windows.Forms.DateTimePicker dtpDesde;
        private System.Windows.Forms.Label lbCliente;
        private System.Windows.Forms.DateTimePicker dtpHasta;
        private System.Windows.Forms.TextBox txtUsuario;
        private System.Windows.Forms.Label lbUsuario;
        private System.Windows.Forms.TextBox txtCliente;
        private System.Windows.Forms.TextBox txtProducto;
        private System.Windows.Forms.Label lbProducto;
        private System.Windows.Forms.Button btnGenerar;
        private System.Windows.Forms.DataGridView dtgReportesVentas;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFecha;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNroVenta;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCliente;
        private System.Windows.Forms.DataGridViewTextBoxColumn colVendedor;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTotal;
        private System.Windows.Forms.GroupBox gbResumen;
        private System.Windows.Forms.Label lbVentasTotal;
        private System.Windows.Forms.Label lbProdTotal;
        private System.Windows.Forms.Label lbTotalResultado;
        private System.Windows.Forms.Label lbProductosTotalResultado;
        private System.Windows.Forms.Label lbVentasTotalResultado;
        private System.Windows.Forms.Label lbTotal;
        private System.Windows.Forms.Button btnExportar;
    }
}