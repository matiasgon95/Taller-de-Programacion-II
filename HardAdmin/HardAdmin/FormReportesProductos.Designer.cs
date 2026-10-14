namespace HardAdmin
{
    partial class FormReporteProductos
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            this.dtpDesde = new System.Windows.Forms.DateTimePicker();
            this.dtpHasta = new System.Windows.Forms.DateTimePicker();
            this.lblDesde = new System.Windows.Forms.Label();
            this.lblHasta = new System.Windows.Forms.Label();
            this.cmbCategorias = new System.Windows.Forms.ComboBox();
            this.lblCategoria = new System.Windows.Forms.Label();
            this.btnFiltrar = new System.Windows.Forms.Button();
            this.btnCerrar = new System.Windows.Forms.Button();
            this.dgvProductos = new System.Windows.Forms.DataGridView();
            this.chartProductos = new System.Windows.Forms.DataVisualization.Charting.Chart();

            // Tarjetas KPI inferiores
            this.panelUnidades = new System.Windows.Forms.Panel();
            this.lblTituloUnidades = new System.Windows.Forms.Label();
            this.lblValorUnidades = new System.Windows.Forms.Label();

            this.panelRecaudacion = new System.Windows.Forms.Panel();
            this.lblTituloRecaudacion = new System.Windows.Forms.Label();
            this.lblValorRecaudacion = new System.Windows.Forms.Label();

            ((System.ComponentModel.ISupportInitialize)(this.dgvProductos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartProductos)).BeginInit();
            this.panelUnidades.SuspendLayout();
            this.panelRecaudacion.SuspendLayout();
            this.SuspendLayout();
            // 
            // dtpDesde
            // 
            this.dtpDesde.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDesde.Location = new System.Drawing.Point(70, 25);
            this.dtpDesde.Name = "dtpDesde";
            this.dtpDesde.Size = new System.Drawing.Size(100, 20);
            this.dtpDesde.TabIndex = 0;
            // 
            // dtpHasta
            // 
            this.dtpHasta.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpHasta.Location = new System.Drawing.Point(225, 25);
            this.dtpHasta.Name = "dtpHasta";
            this.dtpHasta.Size = new System.Drawing.Size(100, 20);
            this.dtpHasta.TabIndex = 1;
            // 
            // lblDesde
            // 
            this.lblDesde.AutoSize = true;
            this.lblDesde.Location = new System.Drawing.Point(25, 28);
            this.lblDesde.Name = "lblDesde";
            this.lblDesde.Size = new System.Drawing.Size(41, 13);
            this.lblDesde.TabIndex = 2;
            this.lblDesde.Text = "Desde:";
            // 
            // lblHasta
            // 
            this.lblHasta.AutoSize = true;
            this.lblHasta.Location = new System.Drawing.Point(185, 28);
            this.lblHasta.Name = "lblHasta";
            this.lblHasta.Size = new System.Drawing.Size(38, 13);
            this.lblHasta.TabIndex = 3;
            this.lblHasta.Text = "Hasta:";
            // 
            // cmbCategorias
            // 
            this.cmbCategorias.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCategorias.FormattingEnabled = true;
            this.cmbCategorias.Location = new System.Drawing.Point(395, 24);
            this.cmbCategorias.Name = "cmbCategorias";
            this.cmbCategorias.Size = new System.Drawing.Size(140, 21);
            this.cmbCategorias.TabIndex = 4;
            // 
            // lblCategoria
            // 
            this.lblCategoria.AutoSize = true;
            this.lblCategoria.Location = new System.Drawing.Point(340, 28);
            this.lblCategoria.Name = "lblCategoria";
            this.lblCategoria.Size = new System.Drawing.Size(55, 13);
            this.lblCategoria.TabIndex = 5;
            this.lblCategoria.Text = "Categoría:";
            // 
            // btnFiltrar
            // 
            this.btnFiltrar.Location = new System.Drawing.Point(550, 22);
            this.btnFiltrar.Name = "btnFiltrar";
            this.btnFiltrar.Size = new System.Drawing.Size(85, 24);
            this.btnFiltrar.TabIndex = 6;
            this.btnFiltrar.Text = "Filtrar";
            this.btnFiltrar.UseVisualStyleBackColor = true;
            this.btnFiltrar.Click += new System.EventHandler(this.btnFiltrar_Click);
            // 
            // btnCerrar
            // 
            this.btnCerrar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCerrar.Location = new System.Drawing.Point(845, 22);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(85, 24);
            this.btnCerrar.TabIndex = 7;
            this.btnCerrar.Text = "Cerrar";
            this.btnCerrar.UseVisualStyleBackColor = true;
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            // 
            // dgvProductos
            // 
            this.dgvProductos.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)));
            this.dgvProductos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProductos.Location = new System.Drawing.Point(25, 70);
            this.dgvProductos.Name = "dgvProductos";
            this.dgvProductos.Size = new System.Drawing.Size(460, 280);
            this.dgvProductos.TabIndex = 8;
            // 
            // chartProductos
            // 
            this.chartProductos.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            chartArea1.Name = "ChartArea1";
            this.chartProductos.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chartProductos.Legends.Add(legend1);
            this.chartProductos.Location = new System.Drawing.Point(505, 70);
            this.chartProductos.Name = "chartProductos";
            this.chartProductos.Size = new System.Drawing.Size(425, 280);
            this.chartProductos.TabIndex = 9;
            this.chartProductos.Text = "chart1";
            // 
            // panelUnidades (Tarjeta azul suave)
            // 
            this.panelUnidades.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.panelUnidades.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(242)))), ((int)(((byte)(255)))));
            this.panelUnidades.Controls.Add(this.lblValorUnidades);
            this.panelUnidades.Controls.Add(this.lblTituloUnidades);
            this.panelUnidades.Location = new System.Drawing.Point(25, 365);
            this.panelUnidades.Name = "panelUnidades";
            this.panelUnidades.Size = new System.Drawing.Size(220, 50);
            this.panelUnidades.TabIndex = 10;
            // 
            // lblTituloUnidades
            // 
            this.lblTituloUnidades.AutoSize = true;
            this.lblTituloUnidades.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTituloUnidades.ForeColor = System.Drawing.Color.MidnightBlue;
            this.lblTituloUnidades.Location = new System.Drawing.Point(10, 8);
            this.lblTituloUnidades.Name = "lblTituloUnidades";
            this.lblTituloUnidades.Size = new System.Drawing.Size(125, 13);
            this.lblTituloUnidades.TabIndex = 0;
            this.lblTituloUnidades.Text = "UNIDADES VENDIDAS";
            // 
            // lblValorUnidades
            // 
            this.lblValorUnidades.AutoSize = true;
            this.lblValorUnidades.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblValorUnidades.ForeColor = System.Drawing.Color.Navy;
            this.lblValorUnidades.Location = new System.Drawing.Point(10, 25);
            this.lblValorUnidades.Name = "lblValorUnidades";
            this.lblValorUnidades.Size = new System.Drawing.Size(17, 18);
            this.lblValorUnidades.TabIndex = 1;
            this.lblValorUnidades.Text = "0";
            // 
            // panelRecaudacion (Tarjeta verde suave)
            // 
            this.panelRecaudacion.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelRecaudacion.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(245)))), ((int)(((byte)(230)))));
            this.panelRecaudacion.Controls.Add(this.lblValorRecaudacion);
            this.panelRecaudacion.Controls.Add(this.lblTituloRecaudacion);
            this.panelRecaudacion.Location = new System.Drawing.Point(260, 365);
            this.panelRecaudacion.Name = "panelRecaudacion";
            this.panelRecaudacion.Size = new System.Drawing.Size(670, 50);
            this.panelRecaudacion.TabIndex = 11;
            // 
            // lblTituloRecaudacion
            // 
            this.lblTituloRecaudacion.AutoSize = true;
            this.lblTituloRecaudacion.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTituloRecaudacion.ForeColor = System.Drawing.Color.DarkGreen;
            this.lblTituloRecaudacion.Location = new System.Drawing.Point(10, 8);
            this.lblTituloRecaudacion.Name = "lblTituloRecaudacion";
            this.lblTituloRecaudacion.Size = new System.Drawing.Size(165, 13);
            this.lblTituloRecaudacion.TabIndex = 0;
            this.lblTituloRecaudacion.Text = "RECAUDACIÓN DEL TOP 10";
            // 
            // lblValorRecaudacion
            // 
            this.lblValorRecaudacion.AutoSize = true;
            this.lblValorRecaudacion.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblValorRecaudacion.ForeColor = System.Drawing.Color.Green;
            this.lblValorRecaudacion.Location = new System.Drawing.Point(10, 25);
            this.lblValorRecaudacion.Name = "lblValorRecaudacion";
            this.lblValorRecaudacion.Size = new System.Drawing.Size(44, 18);
            this.lblValorRecaudacion.TabIndex = 1;
            this.lblValorRecaudacion.Text = "$0,00";
            // 
            // FormReporteProductos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(950, 435);
            this.Controls.Add(this.panelRecaudacion);
            this.Controls.Add(this.panelUnidades);
            this.Controls.Add(this.chartProductos);
            this.Controls.Add(this.dgvProductos);
            this.Controls.Add(this.btnCerrar);
            this.Controls.Add(this.btnFiltrar);
            this.Controls.Add(this.lblCategoria);
            this.Controls.Add(this.cmbCategorias);
            this.Controls.Add(this.lblHasta);
            this.Controls.Add(this.lblDesde);
            this.Controls.Add(this.dtpHasta);
            this.Controls.Add(this.dtpDesde);
            this.Name = "FormReporteProductos";
            this.Text = "Reporte de Productos Más Vendidos";
            this.Load += new System.EventHandler(this.FormReporteProductos_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvProductos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartProductos)).EndInit();
            this.panelUnidades.ResumeLayout(false);
            this.panelUnidades.PerformLayout();
            this.panelRecaudacion.ResumeLayout(false);
            this.panelRecaudacion.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dtpDesde;
        private System.Windows.Forms.DateTimePicker dtpHasta;
        private System.Windows.Forms.Label lblDesde;
        private System.Windows.Forms.Label lblHasta;
        private System.Windows.Forms.ComboBox cmbCategorias;
        private System.Windows.Forms.Label lblCategoria;
        private System.Windows.Forms.Button btnFiltrar;
        private System.Windows.Forms.Button btnCerrar;
        private System.Windows.Forms.DataGridView dgvProductos;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartProductos;

        private System.Windows.Forms.Panel panelUnidades;
        private System.Windows.Forms.Label lblTituloUnidades;
        private System.Windows.Forms.Label lblValorUnidades;

        private System.Windows.Forms.Panel panelRecaudacion;
        private System.Windows.Forms.Label lblTituloRecaudacion;
        private System.Windows.Forms.Label lblValorRecaudacion;
    }
}