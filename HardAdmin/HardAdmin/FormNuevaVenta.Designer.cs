namespace HardAdmin
{
    partial class FormNuevaVenta
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle21 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle22 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle23 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle24 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pnlTitulo = new System.Windows.Forms.Panel();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.gbDatosVenta = new System.Windows.Forms.GroupBox();
            this.txtDni = new System.Windows.Forms.TextBox();
            this.cmbMetodoPago = new System.Windows.Forms.ComboBox();
            this.lblMetodoPago = new System.Windows.Forms.Label();
            this.dtpFecha = new System.Windows.Forms.DateTimePicker();
            this.txtNroComprobante = new System.Windows.Forms.TextBox();
            this.lblComprobante = new System.Windows.Forms.Label();
            this.lblFecha = new System.Windows.Forms.Label();
            this.lblDni = new System.Windows.Forms.Label();
            this.btnNuevoCliente = new System.Windows.Forms.Button();
            this.btnBuscarCliente = new System.Windows.Forms.Button();
            this.txtCliente = new System.Windows.Forms.TextBox();
            this.lblCliente = new System.Windows.Forms.Label();
            this.gbDetalleProductos = new System.Windows.Forms.GroupBox();
            this.pnlAccionesGrilla = new System.Windows.Forms.Panel();
            this.btnQuitarProducto = new System.Windows.Forms.Button();
            this.pnlInferior = new System.Windows.Forms.Panel();
            this.lblMontoTotal = new System.Windows.Forms.Label();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnGuardarVenta = new System.Windows.Forms.Button();
            this.lblTextoTotal = new System.Windows.Forms.Label();
            this.lblCantidadItems = new System.Windows.Forms.Label();
            this.dgvDetalle = new System.Windows.Forms.DataGridView();
            this.colIdProducto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCodigo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCantidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPrecio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSubtotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnlCargaRapida = new System.Windows.Forms.Panel();
            this.lblPrecio = new System.Windows.Forms.Label();
            this.lblCantidad = new System.Windows.Forms.Label();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.nudCantidad = new System.Windows.Forms.NumericUpDown();
            this.txtPrecio = new System.Windows.Forms.TextBox();
            this.lblStock = new System.Windows.Forms.Label();
            this.lblNombreProducto = new System.Windows.Forms.Label();
            this.btnBuscarProducto = new System.Windows.Forms.Button();
            this.lblCodigo = new System.Windows.Forms.Label();
            this.txtCodigo = new System.Windows.Forms.TextBox();
            this.pnlTitulo.SuspendLayout();
            this.gbDatosVenta.SuspendLayout();
            this.gbDetalleProductos.SuspendLayout();
            this.pnlAccionesGrilla.SuspendLayout();
            this.pnlInferior.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetalle)).BeginInit();
            this.pnlCargaRapida.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudCantidad)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlTitulo
            // 
            this.pnlTitulo.Controls.Add(this.lblTitulo);
            this.pnlTitulo.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTitulo.Location = new System.Drawing.Point(0, 0);
            this.pnlTitulo.Name = "pnlTitulo";
            this.pnlTitulo.Size = new System.Drawing.Size(834, 50);
            this.pnlTitulo.TabIndex = 1;
            // 
            // lblTitulo
            // 
            this.lblTitulo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitulo.Location = new System.Drawing.Point(328, 9);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(182, 31);
            this.lblTitulo.TabIndex = 2;
            this.lblTitulo.Text = "Nueva Venta";
            // 
            // gbDatosVenta
            // 
            this.gbDatosVenta.Controls.Add(this.txtDni);
            this.gbDatosVenta.Controls.Add(this.cmbMetodoPago);
            this.gbDatosVenta.Controls.Add(this.lblMetodoPago);
            this.gbDatosVenta.Controls.Add(this.dtpFecha);
            this.gbDatosVenta.Controls.Add(this.txtNroComprobante);
            this.gbDatosVenta.Controls.Add(this.lblComprobante);
            this.gbDatosVenta.Controls.Add(this.lblFecha);
            this.gbDatosVenta.Controls.Add(this.lblDni);
            this.gbDatosVenta.Controls.Add(this.btnNuevoCliente);
            this.gbDatosVenta.Controls.Add(this.btnBuscarCliente);
            this.gbDatosVenta.Controls.Add(this.txtCliente);
            this.gbDatosVenta.Controls.Add(this.lblCliente);
            this.gbDatosVenta.Dock = System.Windows.Forms.DockStyle.Top;
            this.gbDatosVenta.Location = new System.Drawing.Point(0, 50);
            this.gbDatosVenta.Name = "gbDatosVenta";
            this.gbDatosVenta.Size = new System.Drawing.Size(834, 115);
            this.gbDatosVenta.TabIndex = 2;
            this.gbDatosVenta.TabStop = false;
            this.gbDatosVenta.Text = "Datos de la venta";
            // 
            // txtDni
            // 
            this.txtDni.Location = new System.Drawing.Point(50, 22);
            this.txtDni.Name = "txtDni";
            this.txtDni.Size = new System.Drawing.Size(95, 22);
            this.txtDni.TabIndex = 0;
            // 
            // cmbMetodoPago
            // 
            this.cmbMetodoPago.DisplayMember = "nombre_metodo";
            this.cmbMetodoPago.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMetodoPago.FormattingEnabled = true;
            this.cmbMetodoPago.Location = new System.Drawing.Point(110, 62);
            this.cmbMetodoPago.Name = "cmbMetodoPago";
            this.cmbMetodoPago.Size = new System.Drawing.Size(200, 21);
            this.cmbMetodoPago.TabIndex = 10;
            this.cmbMetodoPago.ValueMember = "id_metodo_pago";
            // 
            // lblMetodoPago
            // 
            this.lblMetodoPago.AutoSize = true;
            this.lblMetodoPago.Location = new System.Drawing.Point(15, 65);
            this.lblMetodoPago.Name = "lblMetodoPago";
            this.lblMetodoPago.Size = new System.Drawing.Size(89, 13);
            this.lblMetodoPago.TabIndex = 99;
            this.lblMetodoPago.Text = "Medio de pago:";
            // 
            // dtpFecha
            // 
            this.dtpFecha.Enabled = false;
            this.dtpFecha.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFecha.Location = new System.Drawing.Point(600, 62);
            this.dtpFecha.Name = "dtpFecha";
            this.dtpFecha.Size = new System.Drawing.Size(130, 22);
            this.dtpFecha.TabIndex = 99;
            this.dtpFecha.TabStop = false;
            // 
            // txtNroComprobante
            // 
            this.txtNroComprobante.Location = new System.Drawing.Point(600, 22);
            this.txtNroComprobante.Name = "txtNroComprobante";
            this.txtNroComprobante.ReadOnly = true;
            this.txtNroComprobante.Size = new System.Drawing.Size(130, 22);
            this.txtNroComprobante.TabIndex = 99;
            this.txtNroComprobante.TabStop = false;
            this.txtNroComprobante.Text = "[Automático]";
            this.txtNroComprobante.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblComprobante
            // 
            this.lblComprobante.AutoSize = true;
            this.lblComprobante.Location = new System.Drawing.Point(505, 25);
            this.lblComprobante.Name = "lblComprobante";
            this.lblComprobante.Size = new System.Drawing.Size(81, 13);
            this.lblComprobante.TabIndex = 6;
            this.lblComprobante.Text = "Comprobante:";
            // 
            // lblFecha
            // 
            this.lblFecha.AutoSize = true;
            this.lblFecha.Location = new System.Drawing.Point(505, 65);
            this.lblFecha.Name = "lblFecha";
            this.lblFecha.Size = new System.Drawing.Size(40, 13);
            this.lblFecha.TabIndex = 5;
            this.lblFecha.Text = "Fecha:";
            // 
            // lblDni
            // 
            this.lblDni.AutoSize = true;
            this.lblDni.Location = new System.Drawing.Point(15, 25);
            this.lblDni.Name = "lblDni";
            this.lblDni.Size = new System.Drawing.Size(29, 13);
            this.lblDni.TabIndex = 4;
            this.lblDni.Text = "DNI:";
            // 
            // btnNuevoCliente
            // 
            this.btnNuevoCliente.Location = new System.Drawing.Point(440, 21);
            this.btnNuevoCliente.Name = "btnNuevoCliente";
            this.btnNuevoCliente.Size = new System.Drawing.Size(32, 25);
            this.btnNuevoCliente.TabIndex = 3;
            this.btnNuevoCliente.Text = "+";
            this.btnNuevoCliente.UseVisualStyleBackColor = true;
            this.btnNuevoCliente.Click += new System.EventHandler(this.btnNuevoCliente_Click);
            // 
            // btnBuscarCliente
            // 
            this.btnBuscarCliente.Location = new System.Drawing.Point(405, 21);
            this.btnBuscarCliente.Name = "btnBuscarCliente";
            this.btnBuscarCliente.Size = new System.Drawing.Size(32, 25);
            this.btnBuscarCliente.TabIndex = 2;
            this.btnBuscarCliente.Text = "...";
            this.btnBuscarCliente.UseVisualStyleBackColor = true;
            this.btnBuscarCliente.Click += new System.EventHandler(this.btnBuscarCliente_Click);
            // 
            // txtCliente
            // 
            this.txtCliente.Location = new System.Drawing.Point(210, 22);
            this.txtCliente.Name = "txtCliente";
            this.txtCliente.ReadOnly = true;
            this.txtCliente.Size = new System.Drawing.Size(190, 22);
            this.txtCliente.TabIndex = 99;
            this.txtCliente.TabStop = false;
            this.txtCliente.Text = "Consumidor Final";
            // 
            // lblCliente
            // 
            this.lblCliente.AutoSize = true;
            this.lblCliente.Location = new System.Drawing.Point(155, 25);
            this.lblCliente.Name = "lblCliente";
            this.lblCliente.Size = new System.Drawing.Size(46, 13);
            this.lblCliente.TabIndex = 0;
            this.lblCliente.Text = "Cliente:";
            // 
            // gbDetalleProductos
            // 
            this.gbDetalleProductos.Controls.Add(this.pnlAccionesGrilla);
            this.gbDetalleProductos.Controls.Add(this.pnlInferior);
            this.gbDetalleProductos.Controls.Add(this.dgvDetalle);
            this.gbDetalleProductos.Controls.Add(this.pnlCargaRapida);
            this.gbDetalleProductos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbDetalleProductos.Location = new System.Drawing.Point(0, 165);
            this.gbDetalleProductos.Name = "gbDetalleProductos";
            this.gbDetalleProductos.Size = new System.Drawing.Size(834, 446);
            this.gbDetalleProductos.TabIndex = 3;
            this.gbDetalleProductos.TabStop = false;
            this.gbDetalleProductos.Text = "Detalle de productos";
            // 
            // pnlAccionesGrilla
            // 
            this.pnlAccionesGrilla.Controls.Add(this.lblMontoTotal);
            this.pnlAccionesGrilla.Controls.Add(this.btnQuitarProducto);
            this.pnlAccionesGrilla.Controls.Add(this.lblTextoTotal);
            this.pnlAccionesGrilla.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlAccionesGrilla.Location = new System.Drawing.Point(3, 333);
            this.pnlAccionesGrilla.Name = "pnlAccionesGrilla";
            this.pnlAccionesGrilla.Size = new System.Drawing.Size(828, 35);
            this.pnlAccionesGrilla.TabIndex = 0;
            // 
            // btnQuitarProducto
            // 
            this.btnQuitarProducto.Location = new System.Drawing.Point(10, 5);
            this.btnQuitarProducto.Name = "btnQuitarProducto";
            this.btnQuitarProducto.Size = new System.Drawing.Size(140, 26);
            this.btnQuitarProducto.TabIndex = 0;
            this.btnQuitarProducto.Text = "Quitar Seleccionado";
            this.btnQuitarProducto.UseVisualStyleBackColor = true;
            this.btnQuitarProducto.Click += new System.EventHandler(this.btnQuitarProducto_Click);
            // 
            // pnlInferior
            // 
            this.pnlInferior.Controls.Add(this.btnCancelar);
            this.pnlInferior.Controls.Add(this.btnGuardarVenta);
            this.pnlInferior.Controls.Add(this.lblCantidadItems);
            this.pnlInferior.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlInferior.Location = new System.Drawing.Point(3, 368);
            this.pnlInferior.Name = "pnlInferior";
            this.pnlInferior.Size = new System.Drawing.Size(828, 75);
            this.pnlInferior.TabIndex = 5;
            // 
            // lblMontoTotal
            // 
            this.lblMontoTotal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblMontoTotal.AutoSize = true;
            this.lblMontoTotal.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMontoTotal.ForeColor = System.Drawing.Color.DarkGreen;
            this.lblMontoTotal.Location = new System.Drawing.Point(602, 5);
            this.lblMontoTotal.Name = "lblMontoTotal";
            this.lblMontoTotal.Size = new System.Drawing.Size(84, 32);
            this.lblMontoTotal.TabIndex = 19;
            this.lblMontoTotal.Text = "$ 0,00";
            this.lblMontoTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnCancelar
            // 
            this.btnCancelar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancelar.Location = new System.Drawing.Point(735, 18);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(85, 38);
            this.btnCancelar.TabIndex = 18;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnGuardarVenta
            // 
            this.btnGuardarVenta.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGuardarVenta.Location = new System.Drawing.Point(610, 18);
            this.btnGuardarVenta.Name = "btnGuardarVenta";
            this.btnGuardarVenta.Size = new System.Drawing.Size(115, 38);
            this.btnGuardarVenta.TabIndex = 17;
            this.btnGuardarVenta.Text = "Registrar Venta";
            this.btnGuardarVenta.UseVisualStyleBackColor = true;
            this.btnGuardarVenta.Click += new System.EventHandler(this.btnGuardarVenta_Click);
            // 
            // lblTextoTotal
            // 
            this.lblTextoTotal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTextoTotal.AutoSize = true;
            this.lblTextoTotal.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTextoTotal.ForeColor = System.Drawing.Color.DarkGreen;
            this.lblTextoTotal.Location = new System.Drawing.Point(512, 5);
            this.lblTextoTotal.Name = "lblTextoTotal";
            this.lblTextoTotal.Size = new System.Drawing.Size(92, 32);
            this.lblTextoTotal.TabIndex = 16;
            this.lblTextoTotal.Text = "TOTAL:";
            this.lblTextoTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblCantidadItems
            // 
            this.lblCantidadItems.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblCantidadItems.AutoSize = true;
            this.lblCantidadItems.Location = new System.Drawing.Point(15, 28);
            this.lblCantidadItems.Name = "lblCantidadItems";
            this.lblCantidadItems.Size = new System.Drawing.Size(104, 13);
            this.lblCantidadItems.TabIndex = 15;
            this.lblCantidadItems.Text = "Items agregados: 0";
            // 
            // dgvDetalle
            // 
            this.dgvDetalle.AllowUserToAddRows = false;
            this.dgvDetalle.AllowUserToDeleteRows = false;
            this.dgvDetalle.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvDetalle.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDetalle.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colIdProducto,
            this.colCodigo,
            this.colNombre,
            this.colCantidad,
            this.colPrecio,
            this.colSubtotal});
            this.dgvDetalle.Location = new System.Drawing.Point(3, 73);
            this.dgvDetalle.MultiSelect = false;
            this.dgvDetalle.Name = "dgvDetalle";
            this.dgvDetalle.ReadOnly = true;
            this.dgvDetalle.RowHeadersVisible = false;
            this.dgvDetalle.RowTemplate.Height = 32;
            this.dgvDetalle.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDetalle.Size = new System.Drawing.Size(828, 370);
            this.dgvDetalle.TabIndex = 4;
            // 
            // colIdProducto
            // 
            this.colIdProducto.DataPropertyName = "id_producto";
            this.colIdProducto.HeaderText = "idProducto";
            this.colIdProducto.Name = "colIdProducto";
            this.colIdProducto.ReadOnly = true;
            this.colIdProducto.Visible = false;
            // 
            // colCodigo
            // 
            this.colCodigo.DataPropertyName = "Código de artículo";
            dataGridViewCellStyle21.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.colCodigo.DefaultCellStyle = dataGridViewCellStyle21;
            this.colCodigo.HeaderText = "Código";
            this.colCodigo.Name = "colCodigo";
            this.colCodigo.ReadOnly = true;
            // 
            // colNombre
            // 
            this.colNombre.DataPropertyName = "Nombre del producto";
            this.colNombre.HeaderText = "Descripción";
            this.colNombre.Name = "colNombre";
            this.colNombre.ReadOnly = true;
            // 
            // colCantidad
            // 
            this.colCantidad.DataPropertyName = "Cantidad ingresada";
            dataGridViewCellStyle22.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.colCantidad.DefaultCellStyle = dataGridViewCellStyle22;
            this.colCantidad.HeaderText = "Cantidad";
            this.colCantidad.Name = "colCantidad";
            this.colCantidad.ReadOnly = true;
            this.colCantidad.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colCantidad.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // colPrecio
            // 
            this.colPrecio.DataPropertyName = "Precio unitario";
            dataGridViewCellStyle23.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.colPrecio.DefaultCellStyle = dataGridViewCellStyle23;
            this.colPrecio.HeaderText = "Precio Unit.";
            this.colPrecio.Name = "colPrecio";
            this.colPrecio.ReadOnly = true;
            this.colPrecio.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // colSubtotal
            // 
            this.colSubtotal.DataPropertyName = "Cantidad * Precio";
            dataGridViewCellStyle24.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.colSubtotal.DefaultCellStyle = dataGridViewCellStyle24;
            this.colSubtotal.HeaderText = "Subtotal";
            this.colSubtotal.Name = "colSubtotal";
            this.colSubtotal.ReadOnly = true;
            // 
            // pnlCargaRapida
            // 
            this.pnlCargaRapida.Controls.Add(this.lblPrecio);
            this.pnlCargaRapida.Controls.Add(this.lblCantidad);
            this.pnlCargaRapida.Controls.Add(this.btnAgregar);
            this.pnlCargaRapida.Controls.Add(this.nudCantidad);
            this.pnlCargaRapida.Controls.Add(this.txtPrecio);
            this.pnlCargaRapida.Controls.Add(this.lblStock);
            this.pnlCargaRapida.Controls.Add(this.lblNombreProducto);
            this.pnlCargaRapida.Controls.Add(this.btnBuscarProducto);
            this.pnlCargaRapida.Controls.Add(this.lblCodigo);
            this.pnlCargaRapida.Controls.Add(this.txtCodigo);
            this.pnlCargaRapida.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlCargaRapida.Location = new System.Drawing.Point(3, 18);
            this.pnlCargaRapida.Name = "pnlCargaRapida";
            this.pnlCargaRapida.Size = new System.Drawing.Size(828, 55);
            this.pnlCargaRapida.TabIndex = 0;
            // 
            // lblPrecio
            // 
            this.lblPrecio.AutoSize = true;
            this.lblPrecio.Location = new System.Drawing.Point(360, 18);
            this.lblPrecio.Name = "lblPrecio";
            this.lblPrecio.Size = new System.Drawing.Size(41, 13);
            this.lblPrecio.TabIndex = 16;
            this.lblPrecio.Text = "Precio:";
            // 
            // lblCantidad
            // 
            this.lblCantidad.AutoSize = true;
            this.lblCantidad.Location = new System.Drawing.Point(570, 18);
            this.lblCantidad.Name = "lblCantidad";
            this.lblCantidad.Size = new System.Drawing.Size(34, 13);
            this.lblCantidad.TabIndex = 15;
            this.lblCantidad.Text = "Cant:";
            // 
            // btnAgregar
            // 
            this.btnAgregar.BackColor = System.Drawing.Color.PaleGreen;
            this.btnAgregar.Location = new System.Drawing.Point(675, 12);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(95, 29);
            this.btnAgregar.TabIndex = 4;
            this.btnAgregar.Text = "+ Agregar";
            this.btnAgregar.UseVisualStyleBackColor = false;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // nudCantidad
            // 
            this.nudCantidad.Location = new System.Drawing.Point(610, 15);
            this.nudCantidad.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.nudCantidad.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudCantidad.Name = "nudCantidad";
            this.nudCantidad.Size = new System.Drawing.Size(50, 22);
            this.nudCantidad.TabIndex = 3;
            this.nudCantidad.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // txtPrecio
            // 
            this.txtPrecio.Location = new System.Drawing.Point(410, 15);
            this.txtPrecio.Name = "txtPrecio";
            this.txtPrecio.ReadOnly = true;
            this.txtPrecio.Size = new System.Drawing.Size(75, 22);
            this.txtPrecio.TabIndex = 99;
            this.txtPrecio.TabStop = false;
            this.txtPrecio.Text = "$ 0,00";
            this.txtPrecio.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblStock
            // 
            this.lblStock.AutoSize = true;
            this.lblStock.ForeColor = System.Drawing.Color.Blue;
            this.lblStock.Location = new System.Drawing.Point(495, 18);
            this.lblStock.Name = "lblStock";
            this.lblStock.Size = new System.Drawing.Size(45, 13);
            this.lblStock.TabIndex = 13;
            this.lblStock.Text = "Stock: -";
            // 
            // lblNombreProducto
            // 
            this.lblNombreProducto.AutoSize = true;
            this.lblNombreProducto.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNombreProducto.Location = new System.Drawing.Point(220, 18);
            this.lblNombreProducto.Name = "lblNombreProducto";
            this.lblNombreProducto.Size = new System.Drawing.Size(121, 13);
            this.lblNombreProducto.TabIndex = 12;
            this.lblNombreProducto.Text = "Seleccione producto...";
            // 
            // btnBuscarProducto
            // 
            this.btnBuscarProducto.Location = new System.Drawing.Point(180, 14);
            this.btnBuscarProducto.Name = "btnBuscarProducto";
            this.btnBuscarProducto.Size = new System.Drawing.Size(30, 25);
            this.btnBuscarProducto.TabIndex = 2;
            this.btnBuscarProducto.Text = "...";
            this.btnBuscarProducto.UseVisualStyleBackColor = true;
            this.btnBuscarProducto.Click += new System.EventHandler(this.btnBuscarProducto_Click);
            // 
            // lblCodigo
            // 
            this.lblCodigo.AutoSize = true;
            this.lblCodigo.Location = new System.Drawing.Point(10, 18);
            this.lblCodigo.Name = "lblCodigo";
            this.lblCodigo.Size = new System.Drawing.Size(48, 13);
            this.lblCodigo.TabIndex = 11;
            this.lblCodigo.Text = "Código:";
            // 
            // txtCodigo
            // 
            this.txtCodigo.Location = new System.Drawing.Point(65, 15);
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.Size = new System.Drawing.Size(110, 22);
            this.txtCodigo.TabIndex = 0;
            // 
            // FormNuevaVenta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(834, 611);
            this.Controls.Add(this.gbDetalleProductos);
            this.Controls.Add(this.gbDatosVenta);
            this.Controls.Add(this.pnlTitulo);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "FormNuevaVenta";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "HardAdmin - Nueva Venta";
            this.Load += new System.EventHandler(this.FormNuevaVenta_Load);
            this.pnlTitulo.ResumeLayout(false);
            this.pnlTitulo.PerformLayout();
            this.gbDatosVenta.ResumeLayout(false);
            this.gbDatosVenta.PerformLayout();
            this.gbDetalleProductos.ResumeLayout(false);
            this.pnlAccionesGrilla.ResumeLayout(false);
            this.pnlAccionesGrilla.PerformLayout();
            this.pnlInferior.ResumeLayout(false);
            this.pnlInferior.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetalle)).EndInit();
            this.pnlCargaRapida.ResumeLayout(false);
            this.pnlCargaRapida.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudCantidad)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlTitulo;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.GroupBox gbDatosVenta;
        private System.Windows.Forms.Label lblCliente;
        private System.Windows.Forms.TextBox txtCliente;
        private System.Windows.Forms.Button btnBuscarCliente;
        private System.Windows.Forms.Button btnNuevoCliente;
        private System.Windows.Forms.Label lblDni;
        private System.Windows.Forms.Label lblFecha;
        private System.Windows.Forms.Label lblComprobante;
        private System.Windows.Forms.DateTimePicker dtpFecha;
        private System.Windows.Forms.TextBox txtNroComprobante;
        private System.Windows.Forms.Label lblMetodoPago;
        private System.Windows.Forms.ComboBox cmbMetodoPago;
        private System.Windows.Forms.GroupBox gbDetalleProductos;
        private System.Windows.Forms.Panel pnlCargaRapida;
        private System.Windows.Forms.TextBox txtCodigo;
        private System.Windows.Forms.Button btnBuscarProducto;
        private System.Windows.Forms.Label lblCodigo;
        private System.Windows.Forms.Label lblNombreProducto;
        private System.Windows.Forms.Label lblStock;
        private System.Windows.Forms.NumericUpDown nudCantidad;
        private System.Windows.Forms.TextBox txtPrecio;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.DataGridView dgvDetalle;
        private System.Windows.Forms.DataGridViewTextBoxColumn colIdProducto;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCodigo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCantidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPrecio;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSubtotal;
        private System.Windows.Forms.Panel pnlInferior;
        private System.Windows.Forms.Label lblCantidadItems;
        private System.Windows.Forms.Label lblTextoTotal;
        private System.Windows.Forms.Button btnGuardarVenta;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Label lblCantidad;
        private System.Windows.Forms.Panel pnlAccionesGrilla;
        private System.Windows.Forms.Button btnQuitarProducto;
        private System.Windows.Forms.Label lblMontoTotal;
        private System.Windows.Forms.TextBox txtDni;
        private System.Windows.Forms.Label lblPrecio;
    }
}