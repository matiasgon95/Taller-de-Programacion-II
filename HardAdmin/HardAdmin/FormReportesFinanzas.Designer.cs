namespace HardAdmin
{
    partial class FormReportesFinanzas
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
            this.gbFiltros = new System.Windows.Forms.GroupBox();
            this.lbTitulo = new System.Windows.Forms.Label();
            this.lbDesde = new System.Windows.Forms.Label();
            this.lbHasta = new System.Windows.Forms.Label();
            this.dtpDesde = new System.Windows.Forms.DateTimePicker();
            this.dtpHasta = new System.Windows.Forms.DateTimePicker();
            this.lbMetodoPago = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.btnGenerar = new System.Windows.Forms.Button();
            this.gbTotalVentas = new System.Windows.Forms.GroupBox();
            this.gbCantidadVentas = new System.Windows.Forms.GroupBox();
            this.gbPromedio = new System.Windows.Forms.GroupBox();
            this.gbMayorVenta = new System.Windows.Forms.GroupBox();
            this.lbTotalVentas = new System.Windows.Forms.Label();
            this.lbPromedioVentas = new System.Windows.Forms.Label();
            this.lbMayorVenta = new System.Windows.Forms.Label();
            this.lbCantidadVentas = new System.Windows.Forms.Label();
            this.dtgReporteFinanzas = new System.Windows.Forms.DataGridView();
            this.colMes = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colVentas = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnExportar = new System.Windows.Forms.Button();
            this.gbFiltros.SuspendLayout();
            this.gbTotalVentas.SuspendLayout();
            this.gbCantidadVentas.SuspendLayout();
            this.gbPromedio.SuspendLayout();
            this.gbMayorVenta.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgReporteFinanzas)).BeginInit();
            this.SuspendLayout();
            // 
            // gbFiltros
            // 
            this.gbFiltros.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbFiltros.Controls.Add(this.gbMayorVenta);
            this.gbFiltros.Controls.Add(this.gbPromedio);
            this.gbFiltros.Controls.Add(this.gbCantidadVentas);
            this.gbFiltros.Controls.Add(this.gbTotalVentas);
            this.gbFiltros.Controls.Add(this.btnGenerar);
            this.gbFiltros.Controls.Add(this.comboBox1);
            this.gbFiltros.Controls.Add(this.lbMetodoPago);
            this.gbFiltros.Controls.Add(this.dtpHasta);
            this.gbFiltros.Controls.Add(this.dtpDesde);
            this.gbFiltros.Controls.Add(this.lbHasta);
            this.gbFiltros.Controls.Add(this.lbDesde);
            this.gbFiltros.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbFiltros.Location = new System.Drawing.Point(12, 41);
            this.gbFiltros.Name = "gbFiltros";
            this.gbFiltros.Size = new System.Drawing.Size(776, 196);
            this.gbFiltros.TabIndex = 0;
            this.gbFiltros.TabStop = false;
            this.gbFiltros.Text = "Filtros";
            // 
            // lbTitulo
            // 
            this.lbTitulo.AutoSize = true;
            this.lbTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTitulo.Location = new System.Drawing.Point(254, 9);
            this.lbTitulo.Name = "lbTitulo";
            this.lbTitulo.Size = new System.Drawing.Size(280, 31);
            this.lbTitulo.TabIndex = 1;
            this.lbTitulo.Text = "Reportes de Finanzas";
            // 
            // lbDesde
            // 
            this.lbDesde.AutoSize = true;
            this.lbDesde.Location = new System.Drawing.Point(49, 33);
            this.lbDesde.Name = "lbDesde";
            this.lbDesde.Size = new System.Drawing.Size(55, 18);
            this.lbDesde.TabIndex = 0;
            this.lbDesde.Text = "Desde:";
            // 
            // lbHasta
            // 
            this.lbHasta.AutoSize = true;
            this.lbHasta.Location = new System.Drawing.Point(481, 33);
            this.lbHasta.Name = "lbHasta";
            this.lbHasta.Size = new System.Drawing.Size(51, 18);
            this.lbHasta.TabIndex = 1;
            this.lbHasta.Text = "Hasta:";
            // 
            // dtpDesde
            // 
            this.dtpDesde.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDesde.Location = new System.Drawing.Point(110, 33);
            this.dtpDesde.Name = "dtpDesde";
            this.dtpDesde.Size = new System.Drawing.Size(200, 24);
            this.dtpDesde.TabIndex = 2;
            // 
            // dtpHasta
            // 
            this.dtpHasta.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpHasta.Location = new System.Drawing.Point(538, 33);
            this.dtpHasta.Name = "dtpHasta";
            this.dtpHasta.Size = new System.Drawing.Size(200, 24);
            this.dtpHasta.TabIndex = 3;
            // 
            // lbMetodoPago
            // 
            this.lbMetodoPago.AutoSize = true;
            this.lbMetodoPago.Location = new System.Drawing.Point(49, 88);
            this.lbMetodoPago.Name = "lbMetodoPago";
            this.lbMetodoPago.Size = new System.Drawing.Size(120, 18);
            this.lbMetodoPago.TabIndex = 4;
            this.lbMetodoPago.Text = "Metodo de pago:";
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(189, 85);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(162, 26);
            this.comboBox1.TabIndex = 5;
            // 
            // btnGenerar
            // 
            this.btnGenerar.Location = new System.Drawing.Point(606, 75);
            this.btnGenerar.Name = "btnGenerar";
            this.btnGenerar.Size = new System.Drawing.Size(132, 45);
            this.btnGenerar.TabIndex = 6;
            this.btnGenerar.Text = "Generar Reporte";
            this.btnGenerar.UseVisualStyleBackColor = true;
            // 
            // gbTotalVentas
            // 
            this.gbTotalVentas.Controls.Add(this.lbTotalVentas);
            this.gbTotalVentas.Location = new System.Drawing.Point(34, 126);
            this.gbTotalVentas.Name = "gbTotalVentas";
            this.gbTotalVentas.Size = new System.Drawing.Size(164, 48);
            this.gbTotalVentas.TabIndex = 7;
            this.gbTotalVentas.TabStop = false;
            this.gbTotalVentas.Text = "Total Ventas";
            // 
            // gbCantidadVentas
            // 
            this.gbCantidadVentas.Controls.Add(this.lbCantidadVentas);
            this.gbCantidadVentas.Location = new System.Drawing.Point(222, 126);
            this.gbCantidadVentas.Name = "gbCantidadVentas";
            this.gbCantidadVentas.Size = new System.Drawing.Size(164, 48);
            this.gbCantidadVentas.TabIndex = 8;
            this.gbCantidadVentas.TabStop = false;
            this.gbCantidadVentas.Text = "Cantidad de Ventas";
            // 
            // gbPromedio
            // 
            this.gbPromedio.Controls.Add(this.lbPromedioVentas);
            this.gbPromedio.Location = new System.Drawing.Point(403, 126);
            this.gbPromedio.Name = "gbPromedio";
            this.gbPromedio.Size = new System.Drawing.Size(164, 48);
            this.gbPromedio.TabIndex = 9;
            this.gbPromedio.TabStop = false;
            this.gbPromedio.Text = "Promedio de Ventas";
            // 
            // gbMayorVenta
            // 
            this.gbMayorVenta.Controls.Add(this.lbMayorVenta);
            this.gbMayorVenta.Location = new System.Drawing.Point(588, 126);
            this.gbMayorVenta.Name = "gbMayorVenta";
            this.gbMayorVenta.Size = new System.Drawing.Size(164, 48);
            this.gbMayorVenta.TabIndex = 10;
            this.gbMayorVenta.TabStop = false;
            this.gbMayorVenta.Text = "Mayor Venta";
            // 
            // lbTotalVentas
            // 
            this.lbTotalVentas.AutoSize = true;
            this.lbTotalVentas.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTotalVentas.Location = new System.Drawing.Point(6, 20);
            this.lbTotalVentas.Name = "lbTotalVentas";
            this.lbTotalVentas.Size = new System.Drawing.Size(20, 18);
            this.lbTotalVentas.TabIndex = 0;
            this.lbTotalVentas.Text = "...";
            // 
            // lbPromedioVentas
            // 
            this.lbPromedioVentas.AutoSize = true;
            this.lbPromedioVentas.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbPromedioVentas.Location = new System.Drawing.Point(6, 20);
            this.lbPromedioVentas.Name = "lbPromedioVentas";
            this.lbPromedioVentas.Size = new System.Drawing.Size(20, 18);
            this.lbPromedioVentas.TabIndex = 0;
            this.lbPromedioVentas.Text = "...";
            // 
            // lbMayorVenta
            // 
            this.lbMayorVenta.AutoSize = true;
            this.lbMayorVenta.Location = new System.Drawing.Point(6, 20);
            this.lbMayorVenta.Name = "lbMayorVenta";
            this.lbMayorVenta.Size = new System.Drawing.Size(20, 18);
            this.lbMayorVenta.TabIndex = 0;
            this.lbMayorVenta.Text = "...";
            // 
            // lbCantidadVentas
            // 
            this.lbCantidadVentas.AutoSize = true;
            this.lbCantidadVentas.Location = new System.Drawing.Point(6, 20);
            this.lbCantidadVentas.Name = "lbCantidadVentas";
            this.lbCantidadVentas.Size = new System.Drawing.Size(20, 18);
            this.lbCantidadVentas.TabIndex = 0;
            this.lbCantidadVentas.Text = "...";
            // 
            // dtgReporteFinanzas
            // 
            this.dtgReporteFinanzas.AllowUserToAddRows = false;
            this.dtgReporteFinanzas.AllowUserToDeleteRows = false;
            this.dtgReporteFinanzas.AllowUserToResizeRows = false;
            this.dtgReporteFinanzas.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dtgReporteFinanzas.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgReporteFinanzas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dtgReporteFinanzas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colMes,
            this.colVentas,
            this.colTotal});
            this.dtgReporteFinanzas.Location = new System.Drawing.Point(15, 243);
            this.dtgReporteFinanzas.MultiSelect = false;
            this.dtgReporteFinanzas.Name = "dtgReporteFinanzas";
            this.dtgReporteFinanzas.ReadOnly = true;
            this.dtgReporteFinanzas.RowHeadersVisible = false;
            this.dtgReporteFinanzas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgReporteFinanzas.Size = new System.Drawing.Size(772, 160);
            this.dtgReporteFinanzas.TabIndex = 2;
            // 
            // colMes
            // 
            this.colMes.HeaderText = "Mes";
            this.colMes.Name = "colMes";
            this.colMes.ReadOnly = true;
            // 
            // colVentas
            // 
            this.colVentas.HeaderText = "Cantidad de Ventas";
            this.colVentas.Name = "colVentas";
            this.colVentas.ReadOnly = true;
            // 
            // colTotal
            // 
            this.colTotal.HeaderText = "Total";
            this.colTotal.Name = "colTotal";
            this.colTotal.ReadOnly = true;
            // 
            // btnExportar
            // 
            this.btnExportar.Location = new System.Drawing.Point(712, 409);
            this.btnExportar.Name = "btnExportar";
            this.btnExportar.Size = new System.Drawing.Size(75, 29);
            this.btnExportar.TabIndex = 3;
            this.btnExportar.Text = "Exportar";
            this.btnExportar.UseVisualStyleBackColor = true;
            // 
            // FormReportesFinanzas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 454);
            this.Controls.Add(this.btnExportar);
            this.Controls.Add(this.dtgReporteFinanzas);
            this.Controls.Add(this.lbTitulo);
            this.Controls.Add(this.gbFiltros);
            this.Name = "FormReportesFinanzas";
            this.Text = "HardAdmin - Reportes de Finanzas";
            this.gbFiltros.ResumeLayout(false);
            this.gbFiltros.PerformLayout();
            this.gbTotalVentas.ResumeLayout(false);
            this.gbTotalVentas.PerformLayout();
            this.gbCantidadVentas.ResumeLayout(false);
            this.gbCantidadVentas.PerformLayout();
            this.gbPromedio.ResumeLayout(false);
            this.gbPromedio.PerformLayout();
            this.gbMayorVenta.ResumeLayout(false);
            this.gbMayorVenta.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgReporteFinanzas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox gbFiltros;
        private System.Windows.Forms.Label lbTitulo;
        private System.Windows.Forms.DateTimePicker dtpHasta;
        private System.Windows.Forms.DateTimePicker dtpDesde;
        private System.Windows.Forms.Label lbHasta;
        private System.Windows.Forms.Label lbDesde;
        private System.Windows.Forms.GroupBox gbPromedio;
        private System.Windows.Forms.GroupBox gbCantidadVentas;
        private System.Windows.Forms.GroupBox gbTotalVentas;
        private System.Windows.Forms.Button btnGenerar;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label lbMetodoPago;
        private System.Windows.Forms.GroupBox gbMayorVenta;
        private System.Windows.Forms.Label lbMayorVenta;
        private System.Windows.Forms.Label lbPromedioVentas;
        private System.Windows.Forms.Label lbCantidadVentas;
        private System.Windows.Forms.Label lbTotalVentas;
        private System.Windows.Forms.DataGridView dtgReporteFinanzas;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMes;
        private System.Windows.Forms.DataGridViewTextBoxColumn colVentas;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTotal;
        private System.Windows.Forms.Button btnExportar;
    }
}