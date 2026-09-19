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
            this.lbFiltrar = new System.Windows.Forms.Label();
            this.lbCategoria = new System.Windows.Forms.Label();
            this.lbProducto = new System.Windows.Forms.Label();
            this.lbFecha = new System.Windows.Forms.Label();
            this.lbHasta = new System.Windows.Forms.Label();
            this.btnMostrar = new System.Windows.Forms.Button();
            this.cmbCategoria = new System.Windows.Forms.ComboBox();
            this.cmbProducto = new System.Windows.Forms.ComboBox();
            this.dtpFechaDesde = new System.Windows.Forms.DateTimePicker();
            this.dtpFechaHasta = new System.Windows.Forms.DateTimePicker();
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
            this.lbTitulo.AutoSize = true;
            this.lbTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTitulo.Location = new System.Drawing.Point(220, 28);
            this.lbTitulo.Name = "lbTitulo";
            this.lbTitulo.Size = new System.Drawing.Size(299, 31);
            this.lbTitulo.TabIndex = 0;
            this.lbTitulo.Text = "Movimientos de Stock";
            // 
            // gbDatosSeguimiento
            // 
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
            this.gbDatosSeguimiento.Location = new System.Drawing.Point(12, 62);
            this.gbDatosSeguimiento.Name = "gbDatosSeguimiento";
            this.gbDatosSeguimiento.Size = new System.Drawing.Size(750, 149);
            this.gbDatosSeguimiento.TabIndex = 1;
            this.gbDatosSeguimiento.TabStop = false;
            this.gbDatosSeguimiento.Text = "Datos de Seguimiento";
            // 
            // lbFiltrar
            // 
            this.lbFiltrar.AutoSize = true;
            this.lbFiltrar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbFiltrar.Location = new System.Drawing.Point(6, 31);
            this.lbFiltrar.Name = "lbFiltrar";
            this.lbFiltrar.Size = new System.Drawing.Size(66, 16);
            this.lbFiltrar.TabIndex = 0;
            this.lbFiltrar.Text = "Filtrar por:";
            // 
            // lbCategoria
            // 
            this.lbCategoria.AutoSize = true;
            this.lbCategoria.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbCategoria.Location = new System.Drawing.Point(6, 59);
            this.lbCategoria.Name = "lbCategoria";
            this.lbCategoria.Size = new System.Drawing.Size(76, 16);
            this.lbCategoria.TabIndex = 1;
            this.lbCategoria.Text = "Categorias:";
            // 
            // lbProducto
            // 
            this.lbProducto.AutoSize = true;
            this.lbProducto.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbProducto.Location = new System.Drawing.Point(410, 59);
            this.lbProducto.Name = "lbProducto";
            this.lbProducto.Size = new System.Drawing.Size(64, 16);
            this.lbProducto.TabIndex = 2;
            this.lbProducto.Text = "Producto:";
            // 
            // lbFecha
            // 
            this.lbFecha.AutoSize = true;
            this.lbFecha.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbFecha.Location = new System.Drawing.Point(6, 112);
            this.lbFecha.Name = "lbFecha";
            this.lbFecha.Size = new System.Drawing.Size(92, 16);
            this.lbFecha.TabIndex = 3;
            this.lbFecha.Text = "Fecha Desde:";
            // 
            // lbHasta
            // 
            this.lbHasta.AutoSize = true;
            this.lbHasta.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbHasta.Location = new System.Drawing.Point(318, 112);
            this.lbHasta.Name = "lbHasta";
            this.lbHasta.Size = new System.Drawing.Size(46, 16);
            this.lbHasta.TabIndex = 4;
            this.lbHasta.Text = "Hasta:";
            // 
            // btnMostrar
            // 
            this.btnMostrar.Location = new System.Drawing.Point(641, 107);
            this.btnMostrar.Name = "btnMostrar";
            this.btnMostrar.Size = new System.Drawing.Size(75, 23);
            this.btnMostrar.TabIndex = 5;
            this.btnMostrar.Text = "Mostrar";
            this.btnMostrar.UseVisualStyleBackColor = true;
            // 
            // cmbCategoria
            // 
            this.cmbCategoria.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCategoria.FormattingEnabled = true;
            this.cmbCategoria.Location = new System.Drawing.Point(105, 56);
            this.cmbCategoria.Name = "cmbCategoria";
            this.cmbCategoria.Size = new System.Drawing.Size(178, 21);
            this.cmbCategoria.TabIndex = 6;
            // 
            // cmbProducto
            // 
            this.cmbProducto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbProducto.FormattingEnabled = true;
            this.cmbProducto.Location = new System.Drawing.Point(480, 56);
            this.cmbProducto.Name = "cmbProducto";
            this.cmbProducto.Size = new System.Drawing.Size(236, 21);
            this.cmbProducto.TabIndex = 7;
            // 
            // dtpFechaDesde
            // 
            this.dtpFechaDesde.Enabled = false;
            this.dtpFechaDesde.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaDesde.Location = new System.Drawing.Point(105, 110);
            this.dtpFechaDesde.Name = "dtpFechaDesde";
            this.dtpFechaDesde.Size = new System.Drawing.Size(178, 20);
            this.dtpFechaDesde.TabIndex = 99;
            this.dtpFechaDesde.TabStop = false;
            // 
            // dtpFechaHasta
            // 
            this.dtpFechaHasta.Enabled = false;
            this.dtpFechaHasta.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaHasta.Location = new System.Drawing.Point(373, 110);
            this.dtpFechaHasta.Name = "dtpFechaHasta";
            this.dtpFechaHasta.Size = new System.Drawing.Size(200, 20);
            this.dtpFechaHasta.TabIndex = 99;
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
            this.colCategoria.HeaderText = "Categoria";
            this.colCategoria.Name = "colCategoria";
            this.colCategoria.ReadOnly = true;
            // 
            // colProducto
            // 
            this.colProducto.HeaderText = "Producto";
            this.colProducto.Name = "colProducto";
            this.colProducto.ReadOnly = true;
            // 
            // colFecha
            // 
            this.colFecha.HeaderText = "Fecha";
            this.colFecha.Name = "colFecha";
            this.colFecha.ReadOnly = true;
            // 
            // colUsuario
            // 
            this.colUsuario.HeaderText = "Usuario";
            this.colUsuario.Name = "colUsuario";
            this.colUsuario.ReadOnly = true;
            // 
            // colTipoMovimiento
            // 
            this.colTipoMovimiento.HeaderText = "Tipo de Movimiento";
            this.colTipoMovimiento.Name = "colTipoMovimiento";
            this.colTipoMovimiento.ReadOnly = true;
            // 
            // btnCerrar
            // 
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
            this.Name = "FormMovimientosStock";
            this.Text = "HardAdmin - Movimientos de Stock";
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
        private System.Windows.Forms.DataGridViewTextBoxColumn colCategoria;
        private System.Windows.Forms.DataGridViewTextBoxColumn colProducto;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFecha;
        private System.Windows.Forms.DataGridViewTextBoxColumn colUsuario;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTipoMovimiento;
        private System.Windows.Forms.Button btnCerrar;
    }
}