namespace HardAdmin
{
    partial class FormReporteFinanzas
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
            this.dtpDesde1 = new System.Windows.Forms.DateTimePicker();
            this.dtpHasta1 = new System.Windows.Forms.DateTimePicker();
            this.lblDesde1 = new System.Windows.Forms.Label();
            this.lblHasta1 = new System.Windows.Forms.Label();
            this.dtpDesde2 = new System.Windows.Forms.DateTimePicker();
            this.dtpHasta2 = new System.Windows.Forms.DateTimePicker();
            this.lblDesde2 = new System.Windows.Forms.Label();
            this.lblHasta2 = new System.Windows.Forms.Label();
            this.btnFiltrar = new System.Windows.Forms.Button();
            this.btnCerrar = new System.Windows.Forms.Button();
            this.dgvFinanzas = new System.Windows.Forms.DataGridView();
            this.chartFinanzas = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.panelAcumulado = new System.Windows.Forms.Panel();
            this.lblValorAcumulado = new System.Windows.Forms.Label();
            this.lblTituloAcumulado = new System.Windows.Forms.Label();
            this.panelOperaciones = new System.Windows.Forms.Panel();
            this.lblValorOperaciones = new System.Windows.Forms.Label();
            this.lblTituloOperaciones = new System.Windows.Forms.Label();
            this.panelTicket = new System.Windows.Forms.Panel();
            this.lblValorTicket = new System.Windows.Forms.Label();
            this.lblTituloTicket = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFinanzas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartFinanzas)).BeginInit();
            this.panelAcumulado.SuspendLayout();
            this.panelOperaciones.SuspendLayout();
            this.panelTicket.SuspendLayout();
            this.SuspendLayout();
            // 
            // dtpDesde1
            // 
            this.dtpDesde1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDesde1.Location = new System.Drawing.Point(90, 14);
            this.dtpDesde1.Name = "dtpDesde1";
            this.dtpDesde1.Size = new System.Drawing.Size(95, 20);
            this.dtpDesde1.TabIndex = 1;
            // 
            // dtpHasta1
            // 
            this.dtpHasta1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpHasta1.Location = new System.Drawing.Point(232, 14);
            this.dtpHasta1.Name = "dtpHasta1";
            this.dtpHasta1.Size = new System.Drawing.Size(95, 20);
            this.dtpHasta1.TabIndex = 3;
            // 
            // lblDesde1
            // 
            this.lblDesde1.AutoSize = true;
            this.lblDesde1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDesde1.Location = new System.Drawing.Point(22, 17);
            this.lblDesde1.Name = "lblDesde1";
            this.lblDesde1.Size = new System.Drawing.Size(67, 13);
            this.lblDesde1.TabIndex = 0;
            this.lblDesde1.Text = "Período 1:";
            // 
            // lblHasta1
            // 
            this.lblHasta1.AutoSize = true;
            this.lblHasta1.Location = new System.Drawing.Point(192, 17);
            this.lblHasta1.Name = "lblHasta1";
            this.lblHasta1.Size = new System.Drawing.Size(36, 13);
            this.lblHasta1.TabIndex = 2;
            this.lblHasta1.Text = "hasta:";
            // 
            // dtpDesde2
            // 
            this.dtpDesde2.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDesde2.Location = new System.Drawing.Point(90, 42);
            this.dtpDesde2.Name = "dtpDesde2";
            this.dtpDesde2.Size = new System.Drawing.Size(95, 20);
            this.dtpDesde2.TabIndex = 5;
            // 
            // dtpHasta2
            // 
            this.dtpHasta2.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpHasta2.Location = new System.Drawing.Point(232, 42);
            this.dtpHasta2.Name = "dtpHasta2";
            this.dtpHasta2.Size = new System.Drawing.Size(95, 20);
            this.dtpHasta2.TabIndex = 7;
            // 
            // lblDesde2
            // 
            this.lblDesde2.AutoSize = true;
            this.lblDesde2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDesde2.Location = new System.Drawing.Point(22, 45);
            this.lblDesde2.Name = "lblDesde2";
            this.lblDesde2.Size = new System.Drawing.Size(67, 13);
            this.lblDesde2.TabIndex = 4;
            this.lblDesde2.Text = "Período 2:";
            // 
            // lblHasta2
            // 
            this.lblHasta2.AutoSize = true;
            this.lblHasta2.Location = new System.Drawing.Point(192, 45);
            this.lblHasta2.Name = "lblHasta2";
            this.lblHasta2.Size = new System.Drawing.Size(36, 13);
            this.lblHasta2.TabIndex = 6;
            this.lblHasta2.Text = "hasta:";
            // 
            // btnFiltrar
            // 
            this.btnFiltrar.Location = new System.Drawing.Point(345, 26);
            this.btnFiltrar.Name = "btnFiltrar";
            this.btnFiltrar.Size = new System.Drawing.Size(85, 28);
            this.btnFiltrar.TabIndex = 8;
            this.btnFiltrar.Text = "Filtrar";
            this.btnFiltrar.UseVisualStyleBackColor = true;
            this.btnFiltrar.Click += new System.EventHandler(this.btnFiltrar_Click);
            // 
            // btnCerrar
            // 
            this.btnCerrar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCerrar.Location = new System.Drawing.Point(845, 26);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(85, 28);
            this.btnCerrar.TabIndex = 9;
            this.btnCerrar.Text = "Cerrar";
            this.btnCerrar.UseVisualStyleBackColor = true;
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            // 
            // dgvFinanzas
            // 
            this.dgvFinanzas.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.dgvFinanzas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvFinanzas.Location = new System.Drawing.Point(25, 80);
            this.dgvFinanzas.Name = "dgvFinanzas";
            this.dgvFinanzas.Size = new System.Drawing.Size(430, 270);
            this.dgvFinanzas.TabIndex = 10;
            // 
            // chartFinanzas
            // 
            this.chartFinanzas.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            chartArea1.Name = "ChartArea1";
            this.chartFinanzas.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chartFinanzas.Legends.Add(legend1);
            this.chartFinanzas.Location = new System.Drawing.Point(475, 80);
            this.chartFinanzas.Name = "chartFinanzas";
            this.chartFinanzas.Size = new System.Drawing.Size(455, 270);
            this.chartFinanzas.TabIndex = 11;
            this.chartFinanzas.Text = "chart1";
            // 
            // panelAcumulado
            // 
            this.panelAcumulado.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.panelAcumulado.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(245)))), ((int)(((byte)(230)))));
            this.panelAcumulado.Controls.Add(this.lblValorAcumulado);
            this.panelAcumulado.Controls.Add(this.lblTituloAcumulado);
            this.panelAcumulado.Location = new System.Drawing.Point(25, 365);
            this.panelAcumulado.Name = "panelAcumulado";
            this.panelAcumulado.Size = new System.Drawing.Size(290, 50);
            this.panelAcumulado.TabIndex = 12;
            // 
            // lblValorAcumulado
            // 
            this.lblValorAcumulado.AutoSize = true;
            this.lblValorAcumulado.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblValorAcumulado.ForeColor = System.Drawing.Color.Green;
            this.lblValorAcumulado.Location = new System.Drawing.Point(10, 25);
            this.lblValorAcumulado.Name = "lblValorAcumulado";
            this.lblValorAcumulado.Size = new System.Drawing.Size(49, 18);
            this.lblValorAcumulado.TabIndex = 1;
            this.lblValorAcumulado.Text = "$0,00";
            // 
            // lblTituloAcumulado
            // 
            this.lblTituloAcumulado.AutoSize = true;
            this.lblTituloAcumulado.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTituloAcumulado.ForeColor = System.Drawing.Color.DarkGreen;
            this.lblTituloAcumulado.Location = new System.Drawing.Point(10, 8);
            this.lblTituloAcumulado.Name = "lblTituloAcumulado";
            this.lblTituloAcumulado.Size = new System.Drawing.Size(118, 13);
            this.lblTituloAcumulado.TabIndex = 0;
            this.lblTituloAcumulado.Text = "TOTAL PERÍODO 1";
            // 
            // panelOperaciones
            // 
            this.panelOperaciones.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.panelOperaciones.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(242)))), ((int)(((byte)(255)))));
            this.panelOperaciones.Controls.Add(this.lblValorOperaciones);
            this.panelOperaciones.Controls.Add(this.lblTituloOperaciones);
            this.panelOperaciones.Location = new System.Drawing.Point(330, 365);
            this.panelOperaciones.Name = "panelOperaciones";
            this.panelOperaciones.Size = new System.Drawing.Size(290, 50);
            this.panelOperaciones.TabIndex = 13;
            // 
            // lblValorOperaciones
            // 
            this.lblValorOperaciones.AutoSize = true;
            this.lblValorOperaciones.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblValorOperaciones.ForeColor = System.Drawing.Color.Navy;
            this.lblValorOperaciones.Location = new System.Drawing.Point(10, 25);
            this.lblValorOperaciones.Name = "lblValorOperaciones";
            this.lblValorOperaciones.Size = new System.Drawing.Size(49, 18);
            this.lblValorOperaciones.TabIndex = 1;
            this.lblValorOperaciones.Text = "$0,00";
            // 
            // lblTituloOperaciones
            // 
            this.lblTituloOperaciones.AutoSize = true;
            this.lblTituloOperaciones.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTituloOperaciones.ForeColor = System.Drawing.Color.MidnightBlue;
            this.lblTituloOperaciones.Location = new System.Drawing.Point(10, 8);
            this.lblTituloOperaciones.Name = "lblTituloOperaciones";
            this.lblTituloOperaciones.Size = new System.Drawing.Size(118, 13);
            this.lblTituloOperaciones.TabIndex = 0;
            this.lblTituloOperaciones.Text = "TOTAL PERÍODO 2";
            // 
            // panelTicket
            // 
            this.panelTicket.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelTicket.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(243)))), ((int)(((byte)(230)))));
            this.panelTicket.Controls.Add(this.lblValorTicket);
            this.panelTicket.Controls.Add(this.lblTituloTicket);
            this.panelTicket.Location = new System.Drawing.Point(635, 365);
            this.panelTicket.Name = "panelTicket";
            this.panelTicket.Size = new System.Drawing.Size(295, 50);
            this.panelTicket.TabIndex = 14;
            // 
            // lblValorTicket
            // 
            this.lblValorTicket.AutoSize = true;
            this.lblValorTicket.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblValorTicket.ForeColor = System.Drawing.Color.SaddleBrown;
            this.lblValorTicket.Location = new System.Drawing.Point(10, 25);
            this.lblValorTicket.Name = "lblValorTicket";
            this.lblValorTicket.Size = new System.Drawing.Size(31, 18);
            this.lblValorTicket.TabIndex = 1;
            this.lblValorTicket.Text = "0%";
            // 
            // lblTituloTicket
            // 
            this.lblTituloTicket.AutoSize = true;
            this.lblTituloTicket.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTituloTicket.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.lblTituloTicket.Location = new System.Drawing.Point(10, 8);
            this.lblTituloTicket.Name = "lblTituloTicket";
            this.lblTituloTicket.Size = new System.Drawing.Size(162, 13);
            this.lblTituloTicket.TabIndex = 0;
            this.lblTituloTicket.Text = "VARIACIÓN / DIFERENCIA";
            // 
            // FormReporteFinanzas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(950, 435);
            this.Controls.Add(this.panelTicket);
            this.Controls.Add(this.panelOperaciones);
            this.Controls.Add(this.panelAcumulado);
            this.Controls.Add(this.chartFinanzas);
            this.Controls.Add(this.dgvFinanzas);
            this.Controls.Add(this.btnCerrar);
            this.Controls.Add(this.btnFiltrar);
            this.Controls.Add(this.dtpHasta2);
            this.Controls.Add(this.lblHasta2);
            this.Controls.Add(this.dtpDesde2);
            this.Controls.Add(this.lblDesde2);
            this.Controls.Add(this.dtpHasta1);
            this.Controls.Add(this.lblHasta1);
            this.Controls.Add(this.dtpDesde1);
            this.Controls.Add(this.lblDesde1);
            this.Name = "FormReporteFinanzas";
            this.Text = "HardAdmin - Reporte Financiero: Comparativa de Períodos";
            this.Load += new System.EventHandler(this.FormReporteFinanzas_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvFinanzas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartFinanzas)).EndInit();
            this.panelAcumulado.ResumeLayout(false);
            this.panelAcumulado.PerformLayout();
            this.panelOperaciones.ResumeLayout(false);
            this.panelOperaciones.PerformLayout();
            this.panelTicket.ResumeLayout(false);
            this.panelTicket.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dtpDesde1;
        private System.Windows.Forms.DateTimePicker dtpHasta1;
        private System.Windows.Forms.Label lblDesde1;
        private System.Windows.Forms.Label lblHasta1;

        private System.Windows.Forms.DateTimePicker dtpDesde2;
        private System.Windows.Forms.DateTimePicker dtpHasta2;
        private System.Windows.Forms.Label lblDesde2;
        private System.Windows.Forms.Label lblHasta2;

        private System.Windows.Forms.Button btnFiltrar;
        private System.Windows.Forms.Button btnCerrar;
        private System.Windows.Forms.DataGridView dgvFinanzas;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartFinanzas;

        private System.Windows.Forms.Panel panelAcumulado;
        private System.Windows.Forms.Label lblTituloAcumulado;
        private System.Windows.Forms.Label lblValorAcumulado;

        private System.Windows.Forms.Panel panelOperaciones;
        private System.Windows.Forms.Label lblTituloOperaciones;
        private System.Windows.Forms.Label lblValorOperaciones;

        private System.Windows.Forms.Panel panelTicket;
        private System.Windows.Forms.Label lblTituloTicket;
        private System.Windows.Forms.Label lblValorTicket;
    }
}