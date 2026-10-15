namespace HardAdmin
{
    partial class FormReporteVentas
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
            this.lblAgrupacion = new System.Windows.Forms.Label();
            this.cmbAgrupacion = new System.Windows.Forms.ComboBox();
            this.btnFiltrar = new System.Windows.Forms.Button();
            this.dgvVentas = new System.Windows.Forms.DataGridView();
            this.chartVentas = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.btnCerrar = new System.Windows.Forms.Button();
            this.panelRecaudado = new System.Windows.Forms.Panel();
            this.lblValorRecaudado = new System.Windows.Forms.Label();
            this.lblTituloRecaudado = new System.Windows.Forms.Label();
            this.panelOperaciones = new System.Windows.Forms.Panel();
            this.lblValorOperaciones = new System.Windows.Forms.Label();
            this.lblTituloOperaciones = new System.Windows.Forms.Label();
            this.panelTicket = new System.Windows.Forms.Panel();
            this.lblValorTicket = new System.Windows.Forms.Label();
            this.lblTituloTicket = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvVentas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartVentas)).BeginInit();
            this.panelRecaudado.SuspendLayout();
            this.panelOperaciones.SuspendLayout();
            this.panelTicket.SuspendLayout();
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
            // lblAgrupacion
            // 
            this.lblAgrupacion.AutoSize = true;
            this.lblAgrupacion.Location = new System.Drawing.Point(340, 28);
            this.lblAgrupacion.Name = "lblAgrupacion";
            this.lblAgrupacion.Size = new System.Drawing.Size(65, 13);
            this.lblAgrupacion.TabIndex = 4;
            this.lblAgrupacion.Text = "Agrupar por:";
            // 
            // cmbAgrupacion
            // 
            this.cmbAgrupacion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbAgrupacion.FormattingEnabled = true;
            this.cmbAgrupacion.Location = new System.Drawing.Point(400, 24);
            this.cmbAgrupacion.Name = "cmbAgrupacion";
            this.cmbAgrupacion.Size = new System.Drawing.Size(90, 21);
            this.cmbAgrupacion.TabIndex = 5;
            // 
            // btnFiltrar
            // 
            this.btnFiltrar.Location = new System.Drawing.Point(510, 22);
            this.btnFiltrar.Name = "btnFiltrar";
            this.btnFiltrar.Size = new System.Drawing.Size(85, 24);
            this.btnFiltrar.TabIndex = 6;
            this.btnFiltrar.Text = "Filtrar";
            this.btnFiltrar.UseVisualStyleBackColor = true;
            this.btnFiltrar.Click += new System.EventHandler(this.btnFiltrar_Click);
            // 
            // dgvVentas
            // 
            this.dgvVentas.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.dgvVentas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvVentas.Location = new System.Drawing.Point(25, 70);
            this.dgvVentas.Name = "dgvVentas";
            this.dgvVentas.Size = new System.Drawing.Size(425, 280);
            this.dgvVentas.TabIndex = 8;
            // 
            // chartVentas
            // 
            this.chartVentas.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            chartArea1.Name = "ChartArea1";
            this.chartVentas.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chartVentas.Legends.Add(legend1);
            this.chartVentas.Location = new System.Drawing.Point(470, 70);
            this.chartVentas.Name = "chartVentas";
            this.chartVentas.Size = new System.Drawing.Size(460, 280);
            this.chartVentas.TabIndex = 9;
            this.chartVentas.Text = "chart1";
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
            // panelRecaudado
            // 
            this.panelRecaudado.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.panelRecaudado.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(245)))), ((int)(((byte)(230)))));
            this.panelRecaudado.Controls.Add(this.lblValorRecaudado);
            this.panelRecaudado.Controls.Add(this.lblTituloRecaudado);
            this.panelRecaudado.Location = new System.Drawing.Point(25, 365);
            this.panelRecaudado.Name = "panelRecaudado";
            this.panelRecaudado.Size = new System.Drawing.Size(290, 50);
            this.panelRecaudado.TabIndex = 10;
            // 
            // lblValorRecaudado
            // 
            this.lblValorRecaudado.AutoSize = true;
            this.lblValorRecaudado.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblValorRecaudado.ForeColor = System.Drawing.Color.Green;
            this.lblValorRecaudado.Location = new System.Drawing.Point(10, 25);
            this.lblValorRecaudado.Name = "lblValorRecaudado";
            this.lblValorRecaudado.Size = new System.Drawing.Size(49, 18);
            this.lblValorRecaudado.TabIndex = 1;
            this.lblValorRecaudado.Text = "$0,00";
            // 
            // lblTituloRecaudado
            // 
            this.lblTituloRecaudado.AutoSize = true;
            this.lblTituloRecaudado.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTituloRecaudado.ForeColor = System.Drawing.Color.DarkGreen;
            this.lblTituloRecaudado.Location = new System.Drawing.Point(10, 8);
            this.lblTituloRecaudado.Name = "lblTituloRecaudado";
            this.lblTituloRecaudado.Size = new System.Drawing.Size(128, 13);
            this.lblTituloRecaudado.TabIndex = 0;
            this.lblTituloRecaudado.Text = "TOTAL RECAUDADO";
            // 
            // panelOperaciones
            // 
            this.panelOperaciones.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.panelOperaciones.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(242)))), ((int)(((byte)(255)))));
            this.panelOperaciones.Controls.Add(this.lblValorOperaciones);
            this.panelOperaciones.Controls.Add(this.lblTituloOperaciones);
            this.panelOperaciones.Location = new System.Drawing.Point(330, 365);
            this.panelOperaciones.Name = "panelOperaciones";
            this.panelOperaciones.Size = new System.Drawing.Size(200, 50);
            this.panelOperaciones.TabIndex = 11;
            // 
            // lblValorOperaciones
            // 
            this.lblValorOperaciones.AutoSize = true;
            this.lblValorOperaciones.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblValorOperaciones.ForeColor = System.Drawing.Color.Navy;
            this.lblValorOperaciones.Location = new System.Drawing.Point(10, 25);
            this.lblValorOperaciones.Name = "lblValorOperaciones";
            this.lblValorOperaciones.Size = new System.Drawing.Size(17, 18);
            this.lblValorOperaciones.TabIndex = 1;
            this.lblValorOperaciones.Text = "0";
            // 
            // lblTituloOperaciones
            // 
            this.lblTituloOperaciones.AutoSize = true;
            this.lblTituloOperaciones.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTituloOperaciones.ForeColor = System.Drawing.Color.MidnightBlue;
            this.lblTituloOperaciones.Location = new System.Drawing.Point(10, 8);
            this.lblTituloOperaciones.Name = "lblTituloOperaciones";
            this.lblTituloOperaciones.Size = new System.Drawing.Size(95, 13);
            this.lblTituloOperaciones.TabIndex = 0;
            this.lblTituloOperaciones.Text = "OPERACIONES";
            // 
            // panelTicket
            // 
            this.panelTicket.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelTicket.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(248)))), ((int)(((byte)(220)))));
            this.panelTicket.Controls.Add(this.lblValorTicket);
            this.panelTicket.Controls.Add(this.lblTituloTicket);
            this.panelTicket.Location = new System.Drawing.Point(545, 365);
            this.panelTicket.Name = "panelTicket";
            this.panelTicket.Size = new System.Drawing.Size(385, 50);
            this.panelTicket.TabIndex = 12;
            // 
            // lblValorTicket
            // 
            this.lblValorTicket.AutoSize = true;
            this.lblValorTicket.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblValorTicket.ForeColor = System.Drawing.Color.SaddleBrown;
            this.lblValorTicket.Location = new System.Drawing.Point(10, 25);
            this.lblValorTicket.Name = "lblValorTicket";
            this.lblValorTicket.Size = new System.Drawing.Size(49, 18);
            this.lblValorTicket.TabIndex = 1;
            this.lblValorTicket.Text = "$0,00";
            // 
            // lblTituloTicket
            // 
            this.lblTituloTicket.AutoSize = true;
            this.lblTituloTicket.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTituloTicket.ForeColor = System.Drawing.Color.DarkGoldenrod;
            this.lblTituloTicket.Location = new System.Drawing.Point(10, 8);
            this.lblTituloTicket.Name = "lblTituloTicket";
            this.lblTituloTicket.Size = new System.Drawing.Size(121, 13);
            this.lblTituloTicket.TabIndex = 0;
            this.lblTituloTicket.Text = "TICKET PROMEDIO";
            // 
            // FormReporteVentas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(950, 435);
            this.Controls.Add(this.panelTicket);
            this.Controls.Add(this.panelOperaciones);
            this.Controls.Add(this.panelRecaudado);
            this.Controls.Add(this.btnCerrar);
            this.Controls.Add(this.chartVentas);
            this.Controls.Add(this.dgvVentas);
            this.Controls.Add(this.btnFiltrar);
            this.Controls.Add(this.cmbAgrupacion);
            this.Controls.Add(this.lblAgrupacion);
            this.Controls.Add(this.lblHasta);
            this.Controls.Add(this.lblDesde);
            this.Controls.Add(this.dtpHasta);
            this.Controls.Add(this.dtpDesde);
            this.Name = "FormReporteVentas";
            this.Text = "HardAdmin - Reporte de Evolución de ventas";
            this.Load += new System.EventHandler(this.FormReporteVentas_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvVentas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartVentas)).EndInit();
            this.panelRecaudado.ResumeLayout(false);
            this.panelRecaudado.PerformLayout();
            this.panelOperaciones.ResumeLayout(false);
            this.panelOperaciones.PerformLayout();
            this.panelTicket.ResumeLayout(false);
            this.panelTicket.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dtpDesde;
        private System.Windows.Forms.DateTimePicker dtpHasta;
        private System.Windows.Forms.Label lblDesde;
        private System.Windows.Forms.Label lblHasta;
        private System.Windows.Forms.Label lblAgrupacion;
        private System.Windows.Forms.ComboBox cmbAgrupacion;
        private System.Windows.Forms.Button btnFiltrar;
        private System.Windows.Forms.Button btnCerrar;
        private System.Windows.Forms.DataGridView dgvVentas;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartVentas;

        private System.Windows.Forms.Panel panelRecaudado;
        private System.Windows.Forms.Label lblTituloRecaudado;
        private System.Windows.Forms.Label lblValorRecaudado;

        private System.Windows.Forms.Panel panelOperaciones;
        private System.Windows.Forms.Label lblTituloOperaciones;
        private System.Windows.Forms.Label lblValorOperaciones;

        private System.Windows.Forms.Panel panelTicket;
        private System.Windows.Forms.Label lblTituloTicket;
        private System.Windows.Forms.Label lblValorTicket;
    }
}