namespace HardAdmin
{
    partial class FormReportesProductos
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
            this.btnGenerar = new System.Windows.Forms.Button();
            this.rbInactivos = new System.Windows.Forms.RadioButton();
            this.rbActivos = new System.Windows.Forms.RadioButton();
            this.rbTodos = new System.Windows.Forms.RadioButton();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.cmbCategoria = new System.Windows.Forms.ComboBox();
            this.lbEstado = new System.Windows.Forms.Label();
            this.lbStock = new System.Windows.Forms.Label();
            this.lbCodigo = new System.Windows.Forms.Label();
            this.lbCategoria = new System.Windows.Forms.Label();
            this.lbTitulo = new System.Windows.Forms.Label();
            this.dtgReporteProductos = new System.Windows.Forms.DataGridView();
            this.colCodigo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colProducto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCategoria = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colStock = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colStockMinimo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEstado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnExportar = new System.Windows.Forms.Button();
            this.gbFiltros.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgReporteProductos)).BeginInit();
            this.SuspendLayout();
            // 
            // gbFiltros
            // 
            this.gbFiltros.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbFiltros.Controls.Add(this.btnGenerar);
            this.gbFiltros.Controls.Add(this.rbInactivos);
            this.gbFiltros.Controls.Add(this.rbActivos);
            this.gbFiltros.Controls.Add(this.rbTodos);
            this.gbFiltros.Controls.Add(this.numericUpDown1);
            this.gbFiltros.Controls.Add(this.textBox1);
            this.gbFiltros.Controls.Add(this.cmbCategoria);
            this.gbFiltros.Controls.Add(this.lbEstado);
            this.gbFiltros.Controls.Add(this.lbStock);
            this.gbFiltros.Controls.Add(this.lbCodigo);
            this.gbFiltros.Controls.Add(this.lbCategoria);
            this.gbFiltros.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbFiltros.Location = new System.Drawing.Point(12, 51);
            this.gbFiltros.Name = "gbFiltros";
            this.gbFiltros.Size = new System.Drawing.Size(776, 181);
            this.gbFiltros.TabIndex = 0;
            this.gbFiltros.TabStop = false;
            this.gbFiltros.Text = "Filtros";
            // 
            // btnGenerar
            // 
            this.btnGenerar.Location = new System.Drawing.Point(607, 131);
            this.btnGenerar.Name = "btnGenerar";
            this.btnGenerar.Size = new System.Drawing.Size(151, 46);
            this.btnGenerar.TabIndex = 10;
            this.btnGenerar.Text = "Generar Reporte";
            this.btnGenerar.UseVisualStyleBackColor = true;
            // 
            // rbInactivos
            // 
            this.rbInactivos.AutoSize = true;
            this.rbInactivos.Location = new System.Drawing.Point(414, 91);
            this.rbInactivos.Name = "rbInactivos";
            this.rbInactivos.Size = new System.Drawing.Size(119, 22);
            this.rbInactivos.TabIndex = 9;
            this.rbInactivos.TabStop = true;
            this.rbInactivos.Text = "Solo Inactivos";
            this.rbInactivos.UseVisualStyleBackColor = true;
            // 
            // rbActivos
            // 
            this.rbActivos.AutoSize = true;
            this.rbActivos.Location = new System.Drawing.Point(414, 63);
            this.rbActivos.Name = "rbActivos";
            this.rbActivos.Size = new System.Drawing.Size(109, 22);
            this.rbActivos.TabIndex = 8;
            this.rbActivos.TabStop = true;
            this.rbActivos.Text = "Solo Activos";
            this.rbActivos.UseVisualStyleBackColor = true;
            // 
            // rbTodos
            // 
            this.rbTodos.AutoSize = true;
            this.rbTodos.Location = new System.Drawing.Point(414, 35);
            this.rbTodos.Name = "rbTodos";
            this.rbTodos.Size = new System.Drawing.Size(69, 22);
            this.rbTodos.TabIndex = 7;
            this.rbTodos.TabStop = true;
            this.rbTodos.Text = "Todos";
            this.rbTodos.UseVisualStyleBackColor = true;
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(129, 106);
            this.numericUpDown1.Maximum = new decimal(new int[] {
            276447231,
            23283,
            0,
            0});
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(175, 24);
            this.numericUpDown1.TabIndex = 6;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(129, 71);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(175, 24);
            this.textBox1.TabIndex = 5;
            // 
            // cmbCategoria
            // 
            this.cmbCategoria.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCategoria.FormattingEnabled = true;
            this.cmbCategoria.Location = new System.Drawing.Point(129, 34);
            this.cmbCategoria.Name = "cmbCategoria";
            this.cmbCategoria.Size = new System.Drawing.Size(175, 26);
            this.cmbCategoria.TabIndex = 4;
            // 
            // lbEstado
            // 
            this.lbEstado.AutoSize = true;
            this.lbEstado.Location = new System.Drawing.Point(334, 37);
            this.lbEstado.Name = "lbEstado";
            this.lbEstado.Size = new System.Drawing.Size(59, 18);
            this.lbEstado.TabIndex = 3;
            this.lbEstado.Text = "Estado:";
            // 
            // lbStock
            // 
            this.lbStock.AutoSize = true;
            this.lbStock.Location = new System.Drawing.Point(33, 106);
            this.lbStock.Name = "lbStock";
            this.lbStock.Size = new System.Drawing.Size(51, 18);
            this.lbStock.TabIndex = 2;
            this.lbStock.Text = "Stock:";
            // 
            // lbCodigo
            // 
            this.lbCodigo.AutoSize = true;
            this.lbCodigo.Location = new System.Drawing.Point(33, 74);
            this.lbCodigo.Name = "lbCodigo";
            this.lbCodigo.Size = new System.Drawing.Size(60, 18);
            this.lbCodigo.TabIndex = 1;
            this.lbCodigo.Text = "Codigo:";
            // 
            // lbCategoria
            // 
            this.lbCategoria.AutoSize = true;
            this.lbCategoria.Location = new System.Drawing.Point(33, 37);
            this.lbCategoria.Name = "lbCategoria";
            this.lbCategoria.Size = new System.Drawing.Size(76, 18);
            this.lbCategoria.TabIndex = 0;
            this.lbCategoria.Text = "Categoria:";
            // 
            // lbTitulo
            // 
            this.lbTitulo.AutoSize = true;
            this.lbTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTitulo.Location = new System.Drawing.Point(249, 17);
            this.lbTitulo.Name = "lbTitulo";
            this.lbTitulo.Size = new System.Drawing.Size(278, 31);
            this.lbTitulo.TabIndex = 1;
            this.lbTitulo.Text = "Reportes de Producto";
            // 
            // dtgReporteProductos
            // 
            this.dtgReporteProductos.AllowUserToAddRows = false;
            this.dtgReporteProductos.AllowUserToDeleteRows = false;
            this.dtgReporteProductos.AllowUserToResizeRows = false;
            this.dtgReporteProductos.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dtgReporteProductos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgReporteProductos.ColumnHeadersHeight = 34;
            this.dtgReporteProductos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dtgReporteProductos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colCodigo,
            this.colProducto,
            this.colCategoria,
            this.colStock,
            this.colStockMinimo,
            this.colEstado});
            this.dtgReporteProductos.Location = new System.Drawing.Point(13, 238);
            this.dtgReporteProductos.MultiSelect = false;
            this.dtgReporteProductos.Name = "dtgReporteProductos";
            this.dtgReporteProductos.ReadOnly = true;
            this.dtgReporteProductos.RowHeadersVisible = false;
            this.dtgReporteProductos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgReporteProductos.Size = new System.Drawing.Size(774, 160);
            this.dtgReporteProductos.TabIndex = 3;
            // 
            // colCodigo
            // 
            this.colCodigo.HeaderText = "Codigo";
            this.colCodigo.Name = "colCodigo";
            this.colCodigo.ReadOnly = true;
            // 
            // colProducto
            // 
            this.colProducto.HeaderText = "Producto";
            this.colProducto.Name = "colProducto";
            this.colProducto.ReadOnly = true;
            // 
            // colCategoria
            // 
            this.colCategoria.HeaderText = "Categoria";
            this.colCategoria.Name = "colCategoria";
            this.colCategoria.ReadOnly = true;
            // 
            // colStock
            // 
            this.colStock.HeaderText = "Stock";
            this.colStock.Name = "colStock";
            this.colStock.ReadOnly = true;
            // 
            // colStockMinimo
            // 
            this.colStockMinimo.HeaderText = "Stock Minimo";
            this.colStockMinimo.Name = "colStockMinimo";
            this.colStockMinimo.ReadOnly = true;
            // 
            // colEstado
            // 
            this.colEstado.HeaderText = "Estado";
            this.colEstado.Name = "colEstado";
            this.colEstado.ReadOnly = true;
            // 
            // btnExportar
            // 
            this.btnExportar.Location = new System.Drawing.Point(712, 408);
            this.btnExportar.Name = "btnExportar";
            this.btnExportar.Size = new System.Drawing.Size(75, 30);
            this.btnExportar.TabIndex = 4;
            this.btnExportar.Text = "Exportar";
            this.btnExportar.UseVisualStyleBackColor = true;
            // 
            // FormReportesProductos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnExportar);
            this.Controls.Add(this.dtgReporteProductos);
            this.Controls.Add(this.lbTitulo);
            this.Controls.Add(this.gbFiltros);
            this.Name = "FormReportesProductos";
            this.Text = "HardAdmin - Reportes de Productos";
            this.gbFiltros.ResumeLayout(false);
            this.gbFiltros.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgReporteProductos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox gbFiltros;
        private System.Windows.Forms.Label lbStock;
        private System.Windows.Forms.Label lbCodigo;
        private System.Windows.Forms.Label lbCategoria;
        private System.Windows.Forms.Label lbTitulo;
        private System.Windows.Forms.ComboBox cmbCategoria;
        private System.Windows.Forms.Label lbEstado;
        private System.Windows.Forms.RadioButton rbTodos;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button btnGenerar;
        private System.Windows.Forms.RadioButton rbInactivos;
        private System.Windows.Forms.RadioButton rbActivos;
        private System.Windows.Forms.DataGridView dtgReporteProductos;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCodigo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colProducto;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCategoria;
        private System.Windows.Forms.DataGridViewTextBoxColumn colStock;
        private System.Windows.Forms.DataGridViewTextBoxColumn colStockMinimo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colEstado;
        private System.Windows.Forms.Button btnExportar;
    }
}