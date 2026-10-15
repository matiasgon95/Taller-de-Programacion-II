namespace HardAdmin
{
    partial class FormMovimientosStock
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
            this.lbTitulo = new System.Windows.Forms.Label();
            this.gbDatosSeguimiento = new System.Windows.Forms.GroupBox();
            this.dtpFechaHasta = new System.Windows.Forms.DateTimePicker();
            this.dtpFechaDesde = new System.Windows.Forms.DateTimePicker();
            this.cmbProducto = new System.Windows.Forms.ComboBox();
            this.cmbCategoria = new System.Windows.Forms.ComboBox();
            this.btnMostrar = new System.Windows.Forms.Button();
            this.lbHasta = new System.Windows.Forms.Label();
            this.lbFecha = new System.Windows.Forms.Label();
            this.lbProducto = new System.Windows.Forms.Label();
            this.lbCategoria = new System.Windows.Forms.Label();
            this.lbFiltrar = new System.Windows.Forms.Label();
            this.dgvMovimientos = new System.Windows.Forms.DataGridView();
            this.colCategoria = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colProducto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colFecha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colUsuario = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTipoMovimiento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnCerrar = new System.Windows.Forms.Button();
            this.gbDatosSeguimiento.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMovimientos)).BeginInit();
            this.SuspendLayout();
            // 
            // lbTitulo
            // 
            this.lbTitulo.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lbTitulo.AutoSize = true;
            this.lbTitulo.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTitulo.Location = new System.Drawing.Point(245, 9);
            this.lbTitulo.Name = "lbTitulo";
            this.lbTitulo.Size = new System.Drawing.Size(303, 37);
            this.lbTitulo.TabIndex = 0;
            this.lbTitulo.Text = "Movimientos de Stock";
            // 
            // gbDatosSeguimiento
            // 
            this.gbDatosSeguimiento.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbDatosSeguimiento.Controls.Add(this.dtpFechaHasta);
            this.gbDatosSeguimiento.Controls.Add(this.dtpFechaDesde);
            this.gbDatosSeguimiento.Controls.Add(this.cmbProducto);
            this.gbDatosSeguimiento.Controls.Add(this.cmbCategoria);
            this.gbDatosSeguimiento.Controls.Add(this.btnMostrar);
            this.gbDatosSeguimiento.Controls.Add(this.lbHasta);
            this.gbDatosSeguimiento.Controls.Add(this.lbFecha);
            this.gbDatosSeguimiento.Controls.Add(this.lbProducto);
            this.gbDatosSeguimiento.Controls.Add(this.lbCategoria);
            this.gbDatosSeguimiento.Controls.Add(this.lbFiltrar);
            this.gbDatosSeguimiento.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbDatosSeguimiento.Location = new System.Drawing.Point(12, 62);
            this.gbDatosSeguimiento.Name = "gbDatosSeguimiento";
            this.gbDatosSeguimiento.Size = new System.Drawing.Size(750, 149);
            this.gbDatosSeguimiento.TabIndex = 1;
            this.gbDatosSeguimiento.TabStop = false;
            this.gbDatosSeguimiento.Text = "Datos de Seguimiento";
            // 
            // dtpFechaHasta
            // 
            this.dtpFechaHasta.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaHasta.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.dtpFechaHasta.Location = new System.Drawing.Point(388, 110);
            this.dtpFechaHasta.Name = "dtpFechaHasta";
            this.dtpFechaHasta.Size = new System.Drawing.Size(200, 23);
            this.dtpFechaHasta.TabIndex = 99;
            // 
            // dtpFechaDesde
            // 
            this.dtpFechaDesde.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaDesde.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.dtpFechaDesde.Location = new System.Drawing.Point(105, 110);
            this.dtpFechaDesde.Name = "dtpFechaDesde";
            this.dtpFechaDesde.Size = new System.Drawing.Size(178, 23);
            this.dtpFechaDesde.TabIndex = 99;
            this.dtpFechaDesde.TabStop = false;
            // 
            // cmbProducto
            // 
            this.cmbProducto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbProducto.FormattingEnabled = true;
            this.cmbProducto.Location = new System.Drawing.Point(388, 56);
            this.cmbProducto.Name = "cmbProducto";
            this.cmbProducto.Size = new System.Drawing.Size(200, 23);
            this.cmbProducto.TabIndex = 7;
            // 
            // cmbCategoria
            // 
            this.cmbCategoria.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCategoria.FormattingEnabled = true;
            this.cmbCategoria.Location = new System.Drawing.Point(105, 56);
            this.cmbCategoria.Name = "cmbCategoria";
            this.cmbCategoria.Size = new System.Drawing.Size(178, 23);
            this.cmbCategoria.TabIndex = 6;
            this.cmbCategoria.SelectedIndexChanged += new System.EventHandler(this.cmbCategoria_SelectedIndexChanged);
            // 
            // btnMostrar
            // 
            this.btnMostrar.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.btnMostrar.Location = new System.Drawing.Point(642, 110);
            this.btnMostrar.Name = "btnMostrar";
            this.btnMostrar.Size = new System.Drawing.Size(75, 23);
            this.btnMostrar.TabIndex = 5;
            this.btnMostrar.Text = "Mostrar";
            this.btnMostrar.UseVisualStyleBackColor = true;
            this.btnMostrar.Click += new System.EventHandler(this.btnMostrar_Click);
            // 
            // lbHasta
            // 
            this.lbHasta.AutoSize = true;
            this.lbHasta.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbHasta.Location = new System.Drawing.Point(323, 109);
            this.lbHasta.Name = "lbHasta";
            this.lbHasta.Size = new System.Drawing.Size(40, 15);
            this.lbHasta.TabIndex = 4;
            this.lbHasta.Text = "Hasta:";
            // 
            // lbFecha
            // 
            this.lbFecha.AutoSize = true;
            this.lbFecha.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbFecha.Location = new System.Drawing.Point(6, 109);
            this.lbFecha.Name = "lbFecha";
            this.lbFecha.Size = new System.Drawing.Size(76, 15);
            this.lbFecha.TabIndex = 3;
            this.lbFecha.Text = "Fecha Desde:";
            // 
            // lbProducto
            // 
            this.lbProducto.AutoSize = true;
            this.lbProducto.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbProducto.Location = new System.Drawing.Point(323, 56);
            this.lbProducto.Name = "lbProducto";
            this.lbProducto.Size = new System.Drawing.Size(59, 15);
            this.lbProducto.TabIndex = 2;
            this.lbProducto.Text = "Producto:";
            // 
            // lbCategoria
            // 
            this.lbCategoria.AutoSize = true;
            this.lbCategoria.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbCategoria.Location = new System.Drawing.Point(6, 56);
            this.lbCategoria.Name = "lbCategoria";
            this.lbCategoria.Size = new System.Drawing.Size(66, 15);
            this.lbCategoria.TabIndex = 1;
            this.lbCategoria.Text = "Categorias:";
            // 
            // lbFiltrar
            // 
            this.lbFiltrar.AutoSize = true;
            this.lbFiltrar.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbFiltrar.Location = new System.Drawing.Point(6, 26);
            this.lbFiltrar.Name = "lbFiltrar";
            this.lbFiltrar.Size = new System.Drawing.Size(61, 15);
            this.lbFiltrar.TabIndex = 0;
            this.lbFiltrar.Text = "Filtrar por:";
            // 
            // dgvMovimientos
            // 
            this.dgvMovimientos.AllowUserToAddRows = false;
            this.dgvMovimientos.AllowUserToDeleteRows = false;
            this.dgvMovimientos.AllowUserToResizeRows = false;
            this.dgvMovimientos.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvMovimientos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvMovimientos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvMovimientos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colCategoria,
            this.colProducto,
            this.colFecha,
            this.colUsuario,
            this.colTipoMovimiento});
            this.dgvMovimientos.Location = new System.Drawing.Point(13, 224);
            this.dgvMovimientos.MultiSelect = false;
            this.dgvMovimientos.Name = "dgvMovimientos";
            this.dgvMovimientos.ReadOnly = true;
            this.dgvMovimientos.RowHeadersVisible = false;
            this.dgvMovimientos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvMovimientos.Size = new System.Drawing.Size(748, 173);
            this.dgvMovimientos.TabIndex = 2;
            // 
            // colCategoria
            // 
            this.colCategoria.DataPropertyName = "Categoria";
            this.colCategoria.HeaderText = "Categoria";
            this.colCategoria.Name = "colCategoria";
            this.colCategoria.ReadOnly = true;
            // 
            // colProducto
            // 
            this.colProducto.DataPropertyName = "Producto";
            this.colProducto.HeaderText = "Producto";
            this.colProducto.Name = "colProducto";
            this.colProducto.ReadOnly = true;
            // 
            // colFecha
            // 
            this.colFecha.DataPropertyName = "Fecha";
            this.colFecha.HeaderText = "Fecha";
            this.colFecha.Name = "colFecha";
            this.colFecha.ReadOnly = true;
            // 
            // colUsuario
            // 
            this.colUsuario.DataPropertyName = "Usuario";
            this.colUsuario.HeaderText = "Usuario";
            this.colUsuario.Name = "colUsuario";
            this.colUsuario.ReadOnly = true;
            // 
            // colTipoMovimiento
            // 
            this.colTipoMovimiento.DataPropertyName = "TipoMovimiento";
            this.colTipoMovimiento.HeaderText = "Tipo de Movimiento";
            this.colTipoMovimiento.Name = "colTipoMovimiento";
            this.colTipoMovimiento.ReadOnly = true;
            // 
            // btnCerrar
            // 
            this.btnCerrar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCerrar.Location = new System.Drawing.Point(674, 403);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(87, 35);
            this.btnCerrar.TabIndex = 3;
            this.btnCerrar.Text = "Cerrar";
            this.btnCerrar.UseVisualStyleBackColor = true;
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            // 
            // FormMovimientosStock
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(774, 450);
            this.Controls.Add(this.btnCerrar);
            this.Controls.Add(this.dgvMovimientos);
            this.Controls.Add(this.gbDatosSeguimiento);
            this.Controls.Add(this.lbTitulo);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "FormMovimientosStock";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "HardAdmin - Movimientos de Stock";
            this.Load += new System.EventHandler(this.FormMovimientosStock_Load);
            this.gbDatosSeguimiento.ResumeLayout(false);
            this.gbDatosSeguimiento.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMovimientos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbTitulo;
        private System.Windows.Forms.GroupBox gbDatosSeguimiento;
        private System.Windows.Forms.Label lbHasta;
        private System.Windows.Forms.Label lbFecha;
        private System.Windows.Forms.Label lbProducto;
        private System.Windows.Forms.Label lbCategoria;
        private System.Windows.Forms.Label lbFiltrar;
        private System.Windows.Forms.DateTimePicker dtpFechaDesde;
        private System.Windows.Forms.ComboBox cmbProducto;
        private System.Windows.Forms.ComboBox cmbCategoria;
        private System.Windows.Forms.Button btnMostrar;
        private System.Windows.Forms.DateTimePicker dtpFechaHasta;
        private System.Windows.Forms.DataGridView dgvMovimientos;
        private System.Windows.Forms.Button btnCerrar;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCategoria;
        private System.Windows.Forms.DataGridViewTextBoxColumn colProducto;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFecha;
        private System.Windows.Forms.DataGridViewTextBoxColumn colUsuario;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTipoMovimiento;
    }
}