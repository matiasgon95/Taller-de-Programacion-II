namespace HardAdmin
{
    partial class FormGestionProductos
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
            this.lblTitulo = new System.Windows.Forms.Label();
            this.dgvProductos = new System.Windows.Forms.DataGridView();
            this.colCodigo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCategoria = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colStock = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colStockMinimo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPrecio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colActivo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnAgregarProducto = new System.Windows.Forms.Button();
            this.btnMovimientos = new System.Windows.Forms.Button();
            this.btnModificarFila = new System.Windows.Forms.Button();
            this.gbProducto = new System.Windows.Forms.GroupBox();
            this.lbDescripcionInfo = new System.Windows.Forms.Label();
            this.lbPrecioInfo = new System.Windows.Forms.Label();
            this.lbStockMinimoInfo = new System.Windows.Forms.Label();
            this.lbStockInfo = new System.Windows.Forms.Label();
            this.lbCategoriaInfo = new System.Windows.Forms.Label();
            this.lbCodigoInfo = new System.Windows.Forms.Label();
            this.lbNombreInfo = new System.Windows.Forms.Label();
            this.lbDescripcion = new System.Windows.Forms.Label();
            this.lbPrecio = new System.Windows.Forms.Label();
            this.lbStockMinimo = new System.Windows.Forms.Label();
            this.lbStock = new System.Windows.Forms.Label();
            this.lbCategoria = new System.Windows.Forms.Label();
            this.lbNombre = new System.Windows.Forms.Label();
            this.lbCodigo = new System.Windows.Forms.Label();
            this.pbImagen = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProductos)).BeginInit();
            this.gbProducto.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbImagen)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitulo
            // 
            this.lblTitulo.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitulo.Location = new System.Drawing.Point(270, 20);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(305, 31);
            this.lblTitulo.TabIndex = 1;
            this.lblTitulo.Text = "Listado de Productos";
            this.lblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dgvProductos
            // 
            this.dgvProductos.AllowUserToAddRows = false;
            this.dgvProductos.AllowUserToDeleteRows = false;
            this.dgvProductos.AllowUserToResizeRows = false;
            this.dgvProductos.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvProductos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvProductos.ColumnHeadersHeight = 34;
            this.dgvProductos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvProductos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colCodigo,
            this.colNombre,
            this.colCategoria,
            this.colStock,
            this.colStockMinimo,
            this.colPrecio,
            this.colActivo});
            this.dgvProductos.Location = new System.Drawing.Point(35, 70);
            this.dgvProductos.MultiSelect = false;
            this.dgvProductos.Name = "dgvProductos";
            this.dgvProductos.ReadOnly = true;
            this.dgvProductos.RowHeadersVisible = false;
            this.dgvProductos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvProductos.Size = new System.Drawing.Size(740, 192);
            this.dgvProductos.TabIndex = 2;
            this.dgvProductos.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvProductos_CellDoubleClick);
            this.dgvProductos.SelectionChanged += new System.EventHandler(this.dgvProductos_SelectionChanged);
            // 
            // colCodigo
            // 
            this.colCodigo.DataPropertyName = "codigo";
            this.colCodigo.HeaderText = "Código";
            this.colCodigo.Name = "colCodigo";
            this.colCodigo.ReadOnly = true;
            // 
            // colNombre
            // 
            this.colNombre.DataPropertyName = "nombre_producto";
            this.colNombre.HeaderText = "Nombre";
            this.colNombre.Name = "colNombre";
            this.colNombre.ReadOnly = true;
            // 
            // colCategoria
            // 
            this.colCategoria.DataPropertyName = "nombre_categoria";
            this.colCategoria.HeaderText = "Categoría";
            this.colCategoria.Name = "colCategoria";
            this.colCategoria.ReadOnly = true;
            // 
            // colStock
            // 
            this.colStock.DataPropertyName = "stock";
            this.colStock.HeaderText = "Stock";
            this.colStock.Name = "colStock";
            this.colStock.ReadOnly = true;
            // 
            // colStockMinimo
            // 
            this.colStockMinimo.DataPropertyName = "stock_minimo";
            this.colStockMinimo.HeaderText = "Stock Mínimo";
            this.colStockMinimo.Name = "colStockMinimo";
            this.colStockMinimo.ReadOnly = true;
            // 
            // colPrecio
            // 
            this.colPrecio.DataPropertyName = "precio";
            this.colPrecio.HeaderText = "Precio";
            this.colPrecio.Name = "colPrecio";
            this.colPrecio.ReadOnly = true;
            // 
            // colActivo
            // 
            this.colActivo.DataPropertyName = "activo";
            this.colActivo.HeaderText = "Activo";
            this.colActivo.Name = "colActivo";
            this.colActivo.ReadOnly = true;
            // 
            // btnAgregarProducto
            // 
            this.btnAgregarProducto.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnAgregarProducto.Location = new System.Drawing.Point(35, 450);
            this.btnAgregarProducto.Name = "btnAgregarProducto";
            this.btnAgregarProducto.Size = new System.Drawing.Size(120, 50);
            this.btnAgregarProducto.TabIndex = 3;
            this.btnAgregarProducto.Text = "Agregar Producto";
            this.btnAgregarProducto.UseVisualStyleBackColor = true;
            this.btnAgregarProducto.Click += new System.EventHandler(this.btnAgregarProducto_Click);
            // 
            // btnMovimientos
            // 
            this.btnMovimientos.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMovimientos.Location = new System.Drawing.Point(655, 450);
            this.btnMovimientos.Name = "btnMovimientos";
            this.btnMovimientos.Size = new System.Drawing.Size(120, 50);
            this.btnMovimientos.TabIndex = 5;
            this.btnMovimientos.Text = "Movimientos de Stock";
            this.btnMovimientos.UseVisualStyleBackColor = true;
            this.btnMovimientos.Click += new System.EventHandler(this.btnMovimientos_Click);
            // 
            // btnModificarFila
            // 
            this.btnModificarFila.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnModificarFila.Location = new System.Drawing.Point(165, 450);
            this.btnModificarFila.Name = "btnModificarFila";
            this.btnModificarFila.Size = new System.Drawing.Size(120, 50);
            this.btnModificarFila.TabIndex = 4;
            this.btnModificarFila.Text = "Modificar Producto";
            this.btnModificarFila.UseVisualStyleBackColor = true;
            this.btnModificarFila.Click += new System.EventHandler(this.btnModificarFila_Click);
            // 
            // gbProducto
            // 
            this.gbProducto.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbProducto.Controls.Add(this.lbDescripcionInfo);
            this.gbProducto.Controls.Add(this.lbPrecioInfo);
            this.gbProducto.Controls.Add(this.lbStockMinimoInfo);
            this.gbProducto.Controls.Add(this.lbStockInfo);
            this.gbProducto.Controls.Add(this.lbCategoriaInfo);
            this.gbProducto.Controls.Add(this.lbCodigoInfo);
            this.gbProducto.Controls.Add(this.lbNombreInfo);
            this.gbProducto.Controls.Add(this.lbDescripcion);
            this.gbProducto.Controls.Add(this.lbPrecio);
            this.gbProducto.Controls.Add(this.lbStockMinimo);
            this.gbProducto.Controls.Add(this.lbStock);
            this.gbProducto.Controls.Add(this.lbCategoria);
            this.gbProducto.Controls.Add(this.lbNombre);
            this.gbProducto.Controls.Add(this.lbCodigo);
            this.gbProducto.Controls.Add(this.pbImagen);
            this.gbProducto.Location = new System.Drawing.Point(35, 268);
            this.gbProducto.Name = "gbProducto";
            this.gbProducto.Size = new System.Drawing.Size(739, 169);
            this.gbProducto.TabIndex = 6;
            this.gbProducto.TabStop = false;
            this.gbProducto.Text = "Informacion del Producto";
            // 
            // lbDescripcionInfo
            // 
            this.lbDescripcionInfo.AutoSize = true;
            this.lbDescripcionInfo.Location = new System.Drawing.Point(470, 46);
            this.lbDescripcionInfo.Name = "lbDescripcionInfo";
            this.lbDescripcionInfo.Size = new System.Drawing.Size(16, 13);
            this.lbDescripcionInfo.TabIndex = 14;
            this.lbDescripcionInfo.Text = "...";
            // 
            // lbPrecioInfo
            // 
            this.lbPrecioInfo.AutoSize = true;
            this.lbPrecioInfo.Location = new System.Drawing.Point(226, 144);
            this.lbPrecioInfo.Name = "lbPrecioInfo";
            this.lbPrecioInfo.Size = new System.Drawing.Size(16, 13);
            this.lbPrecioInfo.TabIndex = 13;
            this.lbPrecioInfo.Text = "...";
            // 
            // lbStockMinimoInfo
            // 
            this.lbStockMinimoInfo.AutoSize = true;
            this.lbStockMinimoInfo.Location = new System.Drawing.Point(265, 122);
            this.lbStockMinimoInfo.Name = "lbStockMinimoInfo";
            this.lbStockMinimoInfo.Size = new System.Drawing.Size(16, 13);
            this.lbStockMinimoInfo.TabIndex = 12;
            this.lbStockMinimoInfo.Text = "...";
            // 
            // lbStockInfo
            // 
            this.lbStockInfo.AutoSize = true;
            this.lbStockInfo.Location = new System.Drawing.Point(223, 96);
            this.lbStockInfo.Name = "lbStockInfo";
            this.lbStockInfo.Size = new System.Drawing.Size(16, 13);
            this.lbStockInfo.TabIndex = 11;
            this.lbStockInfo.Text = "...";
            // 
            // lbCategoriaInfo
            // 
            this.lbCategoriaInfo.AutoSize = true;
            this.lbCategoriaInfo.Location = new System.Drawing.Point(245, 71);
            this.lbCategoriaInfo.Name = "lbCategoriaInfo";
            this.lbCategoriaInfo.Size = new System.Drawing.Size(16, 13);
            this.lbCategoriaInfo.TabIndex = 10;
            this.lbCategoriaInfo.Text = "...";
            // 
            // lbCodigoInfo
            // 
            this.lbCodigoInfo.AutoSize = true;
            this.lbCodigoInfo.Location = new System.Drawing.Point(233, 21);
            this.lbCodigoInfo.Name = "lbCodigoInfo";
            this.lbCodigoInfo.Size = new System.Drawing.Size(16, 13);
            this.lbCodigoInfo.TabIndex = 9;
            this.lbCodigoInfo.Text = "...";
            // 
            // lbNombreInfo
            // 
            this.lbNombreInfo.AutoSize = true;
            this.lbNombreInfo.Location = new System.Drawing.Point(236, 46);
            this.lbNombreInfo.Name = "lbNombreInfo";
            this.lbNombreInfo.Size = new System.Drawing.Size(16, 13);
            this.lbNombreInfo.TabIndex = 8;
            this.lbNombreInfo.Text = "...";
            // 
            // lbDescripcion
            // 
            this.lbDescripcion.AutoSize = true;
            this.lbDescripcion.Location = new System.Drawing.Point(470, 21);
            this.lbDescripcion.Name = "lbDescripcion";
            this.lbDescripcion.Size = new System.Drawing.Size(70, 13);
            this.lbDescripcion.TabIndex = 7;
            this.lbDescripcion.Text = "Descripcion:";
            // 
            // lbPrecio
            // 
            this.lbPrecio.AutoSize = true;
            this.lbPrecio.Location = new System.Drawing.Point(179, 144);
            this.lbPrecio.Name = "lbPrecio";
            this.lbPrecio.Size = new System.Drawing.Size(41, 13);
            this.lbPrecio.TabIndex = 6;
            this.lbPrecio.Text = "Precio:";
            // 
            // lbStockMinimo
            // 
            this.lbStockMinimo.AutoSize = true;
            this.lbStockMinimo.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbStockMinimo.Location = new System.Drawing.Point(179, 122);
            this.lbStockMinimo.Name = "lbStockMinimo";
            this.lbStockMinimo.Size = new System.Drawing.Size(80, 13);
            this.lbStockMinimo.TabIndex = 5;
            this.lbStockMinimo.Text = "Stock Minimo:";
            // 
            // lbStock
            // 
            this.lbStock.AutoSize = true;
            this.lbStock.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbStock.Location = new System.Drawing.Point(179, 96);
            this.lbStock.Name = "lbStock";
            this.lbStock.Size = new System.Drawing.Size(38, 13);
            this.lbStock.TabIndex = 4;
            this.lbStock.Text = "Stock:";
            // 
            // lbCategoria
            // 
            this.lbCategoria.AutoSize = true;
            this.lbCategoria.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbCategoria.Location = new System.Drawing.Point(179, 71);
            this.lbCategoria.Name = "lbCategoria";
            this.lbCategoria.Size = new System.Drawing.Size(60, 13);
            this.lbCategoria.TabIndex = 3;
            this.lbCategoria.Text = "Categoria:";
            // 
            // lbNombre
            // 
            this.lbNombre.AutoSize = true;
            this.lbNombre.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbNombre.Location = new System.Drawing.Point(179, 46);
            this.lbNombre.Name = "lbNombre";
            this.lbNombre.Size = new System.Drawing.Size(51, 13);
            this.lbNombre.TabIndex = 2;
            this.lbNombre.Text = "Nombre:";
            // 
            // lbCodigo
            // 
            this.lbCodigo.AutoSize = true;
            this.lbCodigo.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbCodigo.Location = new System.Drawing.Point(179, 21);
            this.lbCodigo.Name = "lbCodigo";
            this.lbCodigo.Size = new System.Drawing.Size(48, 13);
            this.lbCodigo.TabIndex = 1;
            this.lbCodigo.Text = "Codigo:";
            // 
            // pbImagen
            // 
            this.pbImagen.Location = new System.Drawing.Point(17, 21);
            this.pbImagen.Name = "pbImagen";
            this.pbImagen.Size = new System.Drawing.Size(144, 136);
            this.pbImagen.TabIndex = 0;
            this.pbImagen.TabStop = false;
            // 
            // FormGestionProductos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(804, 511);
            this.Controls.Add(this.gbProducto);
            this.Controls.Add(this.btnModificarFila);
            this.Controls.Add(this.btnMovimientos);
            this.Controls.Add(this.btnAgregarProducto);
            this.Controls.Add(this.dgvProductos);
            this.Controls.Add(this.lblTitulo);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "FormGestionProductos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "HardAdmin - Gestión de Productos";
            this.Load += new System.EventHandler(this.FormGestionProductos_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvProductos)).EndInit();
            this.gbProducto.ResumeLayout(false);
            this.gbProducto.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbImagen)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.DataGridView dgvProductos;
        private System.Windows.Forms.Button btnAgregarProducto;
        private System.Windows.Forms.Button btnMovimientos;
        private System.Windows.Forms.Button btnModificarFila;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCodigo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCategoria;
        private System.Windows.Forms.DataGridViewTextBoxColumn colStock;
        private System.Windows.Forms.DataGridViewTextBoxColumn colStockMinimo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPrecio;
        private System.Windows.Forms.DataGridViewTextBoxColumn colActivo;
        private System.Windows.Forms.GroupBox gbProducto;
        private System.Windows.Forms.Label lbNombre;
        private System.Windows.Forms.Label lbCodigo;
        private System.Windows.Forms.PictureBox pbImagen;
        private System.Windows.Forms.Label lbNombreInfo;
        private System.Windows.Forms.Label lbDescripcion;
        private System.Windows.Forms.Label lbPrecio;
        private System.Windows.Forms.Label lbStockMinimo;
        private System.Windows.Forms.Label lbStock;
        private System.Windows.Forms.Label lbCategoria;
        private System.Windows.Forms.Label lbDescripcionInfo;
        private System.Windows.Forms.Label lbPrecioInfo;
        private System.Windows.Forms.Label lbStockMinimoInfo;
        private System.Windows.Forms.Label lbStockInfo;
        private System.Windows.Forms.Label lbCategoriaInfo;
        private System.Windows.Forms.Label lbCodigoInfo;
    }
}