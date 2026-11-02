namespace HardAdmin
{
    partial class FormReportesFinanzas
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

        #region Código generado por el Diseñador de Windows Forms

        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            this.cmbTipoReporte = new System.Windows.Forms.ComboBox();
            this.lblDesde = new System.Windows.Forms.Label();
            this.dtpMesDesde = new System.Windows.Forms.DateTimePicker();
            this.lblHasta = new System.Windows.Forms.Label();
            this.dtpMesHasta = new System.Windows.Forms.DateTimePicker();
            this.lblAnio1 = new System.Windows.Forms.Label();
            this.cmbAnio1 = new System.Windows.Forms.ComboBox();
            this.lblAnio2 = new System.Windows.Forms.Label();
            this.cmbAnio2 = new System.Windows.Forms.ComboBox();
            this.btnFiltrar = new System.Windows.Forms.Button();
            this.btnCerrar = new System.Windows.Forms.Button();
            this.dgvFinanzas = new System.Windows.Forms.DataGridView();
            this.chartFinanzas = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.lblValorAcumulado = new System.Windows.Forms.Label();
            this.lblValorOperaciones = new System.Windows.Forms.Label();
            this.lblValorTicket = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFinanzas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartFinanzas)).BeginInit();
            this.SuspendLayout();
            // 
            // cmbTipoReporte
            // 
            this.cmbTipoReporte.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTipoReporte.FormattingEnabled = true;
            this.cmbTipoReporte.Location = new System.Drawing.Point(12, 15);
            this.cmbTipoReporte.Name = "cmbTipoReporte";
            this.cmbTipoReporte.Size = new System.Drawing.Size(200, 21);
            this.cmbTipoReporte.TabIndex = 0;
            this.cmbTipoReporte.SelectedIndexChanged += new System.EventHandler(this.cmbTipoReporte_SelectedIndexChanged);
            // 
            // lblDesde
            // 
            this.lblDesde.AutoSize = true;
            this.lblDesde.Location = new System.Drawing.Point(225, 18);
            this.lblDesde.Name = "lblDesde";
            this.lblDesde.Size = new System.Drawing.Size(41, 13);
            this.lblDesde.TabIndex = 1;
            this.lblDesde.Text = "Desde:";
            // 
            // dtpMesDesde
            // 
            this.dtpMesDesde.Location = new System.Drawing.Point(272, 15);
            this.dtpMesDesde.Name = "dtpMesDesde";
            this.dtpMesDesde.Size = new System.Drawing.Size(110, 20);
            this.dtpMesDesde.TabIndex = 2;
            // 
            // lblHasta
            // 
            this.lblHasta.AutoSize = true;
            this.lblHasta.Location = new System.Drawing.Point(392, 18);
            this.lblHasta.Name = "lblHasta";
            this.lblHasta.Size = new System.Drawing.Size(38, 13);
            this.lblHasta.TabIndex = 3;
            this.lblHasta.Text = "Hasta:";
            // 
            // dtpMesHasta
            // 
            this.dtpMesHasta.Location = new System.Drawing.Point(436, 15);
            this.dtpMesHasta.Name = "dtpMesHasta";
            this.dtpMesHasta.Size = new System.Drawing.Size(110, 20);
            this.dtpMesHasta.TabIndex = 4;
            // 
            // lblAnio1
            // 
            this.lblAnio1.AutoSize = true;
            this.lblAnio1.Location = new System.Drawing.Point(225, 18);
            this.lblAnio1.Name = "lblAnio1";
            this.lblAnio1.Size = new System.Drawing.Size(56, 13);
            this.lblAnio1.TabIndex = 5;
            this.lblAnio1.Text = "Año Base:";
            this.lblAnio1.Visible = false;
            // 
            // cmbAnio1
            // 
            this.cmbAnio1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbAnio1.FormattingEnabled = true;
            this.cmbAnio1.Location = new System.Drawing.Point(277, 15);
            this.cmbAnio1.Name = "cmbAnio1";
            this.cmbAnio1.Size = new System.Drawing.Size(75, 21);
            this.cmbAnio1.TabIndex = 6;
            this.cmbAnio1.Visible = false;
            // 
            // lblAnio2
            // 
            this.lblAnio2.AutoSize = true;
            this.lblAnio2.Location = new System.Drawing.Point(365, 18);
            this.lblAnio2.Name = "lblAnio2";
            this.lblAnio2.Size = new System.Drawing.Size(69, 13);
            this.lblAnio2.TabIndex = 7;
            this.lblAnio2.Text = "Comparar vs:";
            this.lblAnio2.Visible = false;
            // 
            // cmbAnio2
            // 
            this.cmbAnio2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbAnio2.FormattingEnabled = true;
            this.cmbAnio2.Location = new System.Drawing.Point(436, 15);
            this.cmbAnio2.Name = "cmbAnio2";
            this.cmbAnio2.Size = new System.Drawing.Size(75, 21);
            this.cmbAnio2.TabIndex = 8;
            this.cmbAnio2.Visible = false;
            // 
            // btnFiltrar
            // 
            this.btnFiltrar.Location = new System.Drawing.Point(560, 13);
            this.btnFiltrar.Name = "btnFiltrar";
            this.btnFiltrar.Size = new System.Drawing.Size(75, 23);
            this.btnFiltrar.TabIndex = 9;
            this.btnFiltrar.Text = "Filtrar";
            this.btnFiltrar.UseVisualStyleBackColor = true;
            this.btnFiltrar.Click += new System.EventHandler(this.btnFiltrar_Click);
            // 
            // btnCerrar
            // 
            this.btnCerrar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCerrar.Location = new System.Drawing.Point(885, 13);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(75, 23);
            this.btnCerrar.TabIndex = 10;
            this.btnCerrar.Text = "Cerrar";
            this.btnCerrar.UseVisualStyleBackColor = true;
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            // 
            // dgvFinanzas
            // 
            this.dgvFinanzas.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.dgvFinanzas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvFinanzas.Location = new System.Drawing.Point(12, 50);
            this.dgvFinanzas.Name = "dgvFinanzas";
            this.dgvFinanzas.Size = new System.Drawing.Size(400, 430);
            this.dgvFinanzas.TabIndex = 11;
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
            this.chartFinanzas.Location = new System.Drawing.Point(424, 50);
            this.chartFinanzas.Name = "chartFinanzas";
            this.chartFinanzas.Size = new System.Drawing.Size(536, 430);
            this.chartFinanzas.TabIndex = 12;
            this.chartFinanzas.Text = "chartFinanzas";
            // 
            // lblValorAcumulado
            // 
            this.lblValorAcumulado.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblValorAcumulado.AutoSize = true;
            this.lblValorAcumulado.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblValorAcumulado.Location = new System.Drawing.Point(12, 500);
            this.lblValorAcumulado.Name = "lblValorAcumulado";
            this.lblValorAcumulado.Size = new System.Drawing.Size(59, 20);
            this.lblValorAcumulado.TabIndex = 13;
            this.lblValorAcumulado.Text = "$ 0,00";
            // 
            // lblValorOperaciones
            // 
            this.lblValorOperaciones.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblValorOperaciones.AutoSize = true;
            this.lblValorOperaciones.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblValorOperaciones.Location = new System.Drawing.Point(220, 500);
            this.lblValorOperaciones.Name = "lblValorOperaciones";
            this.lblValorOperaciones.Size = new System.Drawing.Size(19, 20);
            this.lblValorOperaciones.TabIndex = 14;
            this.lblValorOperaciones.Text = "0";
            // 
            // lblValorTicket
            // 
            this.lblValorTicket.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblValorTicket.AutoSize = true;
            this.lblValorTicket.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblValorTicket.Location = new System.Drawing.Point(420, 500);
            this.lblValorTicket.Name = "lblValorTicket";
            this.lblValorTicket.Size = new System.Drawing.Size(59, 20);
            this.lblValorTicket.TabIndex = 15;
            this.lblValorTicket.Text = "$ 0,00";
            // 
            // FormReportesFinanzas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(972, 540);
            this.Controls.Add(this.lblValorTicket);
            this.Controls.Add(this.lblValorOperaciones);
            this.Controls.Add(this.lblValorAcumulado);
            this.Controls.Add(this.chartFinanzas);
            this.Controls.Add(this.dgvFinanzas);
            this.Controls.Add(this.btnCerrar);
            this.Controls.Add(this.btnFiltrar);
            this.Controls.Add(this.cmbAnio2);
            this.Controls.Add(this.lblAnio2);
            this.Controls.Add(this.cmbAnio1);
            this.Controls.Add(this.lblAnio1);
            this.Controls.Add(this.dtpMesHasta);
            this.Controls.Add(this.lblHasta);
            this.Controls.Add(this.dtpMesDesde);
            this.Controls.Add(this.lblDesde);
            this.Controls.Add(this.cmbTipoReporte);
            this.Name = "FormReportesFinanzas";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "HardAdmin - Reporte de Finanzas";
            ((System.ComponentModel.ISupportInitialize)(this.dgvFinanzas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartFinanzas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbTipoReporte;
        private System.Windows.Forms.Label lblDesde;
        private System.Windows.Forms.DateTimePicker dtpMesDesde;
        private System.Windows.Forms.Label lblHasta;
        private System.Windows.Forms.DateTimePicker dtpMesHasta;
        private System.Windows.Forms.Label lblAnio1;
        private System.Windows.Forms.ComboBox cmbAnio1;
        private System.Windows.Forms.Label lblAnio2;
        private System.Windows.Forms.ComboBox cmbAnio2;
        private System.Windows.Forms.Button btnFiltrar;
        private System.Windows.Forms.Button btnCerrar;
        private System.Windows.Forms.DataGridView dgvFinanzas;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartFinanzas;
        private System.Windows.Forms.Label lblValorAcumulado;
        private System.Windows.Forms.Label lblValorOperaciones;
        private System.Windows.Forms.Label lblValorTicket;
    }
}