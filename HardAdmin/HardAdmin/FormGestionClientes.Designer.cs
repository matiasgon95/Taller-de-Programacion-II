namespace HardAdmin
{
    partial class FormGestionClientes
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
            this.dgvClientes = new System.Windows.Forms.DataGridView();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.btnNuevoCliente = new System.Windows.Forms.Button();
            this.btnModificarFila = new System.Windows.Forms.Button();
            this.colNroCliente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCliente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDNI = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTelefono = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEmail = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDireccion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colActivo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAccion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvClientes)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvClientes
            // 
            this.dgvClientes.AllowUserToAddRows = false;
            this.dgvClientes.AllowUserToDeleteRows = false;
            this.dgvClientes.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvClientes.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvClientes.ColumnHeadersHeight = 34;
            this.dgvClientes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvClientes.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colNroCliente,
            this.colCliente,
            this.colDNI,
            this.colTelefono,
            this.colEmail,
            this.colDireccion,
            this.colActivo,
            this.colAccion});
            this.dgvClientes.Location = new System.Drawing.Point(28, 56);
            this.dgvClientes.MultiSelect = false;
            this.dgvClientes.Name = "dgvClientes";
            this.dgvClientes.ReadOnly = true;
            this.dgvClientes.RowHeadersVisible = false;
            this.dgvClientes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvClientes.Size = new System.Drawing.Size(743, 316);
            this.dgvClientes.TabIndex = 2;
            // 
            // lblTitulo
            // 
            this.lblTitulo.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitulo.Location = new System.Drawing.Point(266, 9);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(264, 31);
            this.lblTitulo.TabIndex = 1;
            this.lblTitulo.Text = "Listado de Clientes";
            // 
            // btnNuevoCliente
            // 
            this.btnNuevoCliente.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnNuevoCliente.Location = new System.Drawing.Point(31, 392);
            this.btnNuevoCliente.Name = "btnNuevoCliente";
            this.btnNuevoCliente.Size = new System.Drawing.Size(119, 49);
            this.btnNuevoCliente.TabIndex = 2;
            this.btnNuevoCliente.Text = "Nuevo Cliente";
            this.btnNuevoCliente.UseVisualStyleBackColor = true;
            this.btnNuevoCliente.Click += new System.EventHandler(this.btnNuevoCliente_Click);
            // 
            // btnModificarFila
            // 
            this.btnModificarFila.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnModificarFila.Location = new System.Drawing.Point(684, 96);
            this.btnModificarFila.Name = "btnModificarFila";
            this.btnModificarFila.Size = new System.Drawing.Size(75, 23);
            this.btnModificarFila.TabIndex = 3;
            this.btnModificarFila.Text = "Modifcar";
            this.btnModificarFila.UseVisualStyleBackColor = true;
            this.btnModificarFila.Visible = false;
            // 
            // colNroCliente
            // 
            this.colNroCliente.HeaderText = "Nro Cliente";
            this.colNroCliente.Name = "colNroCliente";
            this.colNroCliente.ReadOnly = true;
            // 
            // colCliente
            // 
            this.colCliente.HeaderText = "Cliente";
            this.colCliente.Name = "colCliente";
            this.colCliente.ReadOnly = true;
            // 
            // colDNI
            // 
            this.colDNI.HeaderText = "DNI/CUIT";
            this.colDNI.Name = "colDNI";
            this.colDNI.ReadOnly = true;
            // 
            // colTelefono
            // 
            this.colTelefono.HeaderText = "Tel/Cel";
            this.colTelefono.Name = "colTelefono";
            this.colTelefono.ReadOnly = true;
            // 
            // colEmail
            // 
            this.colEmail.HeaderText = "Email";
            this.colEmail.Name = "colEmail";
            this.colEmail.ReadOnly = true;
            // 
            // colDireccion
            // 
            this.colDireccion.HeaderText = "Direccion";
            this.colDireccion.Name = "colDireccion";
            this.colDireccion.ReadOnly = true;
            // 
            // colActivo
            // 
            this.colActivo.HeaderText = "Activo";
            this.colActivo.Name = "colActivo";
            this.colActivo.ReadOnly = true;
            // 
            // colAccion
            // 
            this.colAccion.HeaderText = "Accion";
            this.colAccion.Name = "colAccion";
            this.colAccion.ReadOnly = true;
            // 
            // FormGestionClientes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnModificarFila);
            this.Controls.Add(this.btnNuevoCliente);
            this.Controls.Add(this.lblTitulo);
            this.Controls.Add(this.dgvClientes);
            this.Name = "FormGestionClientes";
            this.Text = "HardAdmin - Clientes";
            ((System.ComponentModel.ISupportInitialize)(this.dgvClientes)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvClientes;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Button btnNuevoCliente;
        private System.Windows.Forms.Button btnModificarFila;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNroCliente;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCliente;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDNI;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTelefono;
        private System.Windows.Forms.DataGridViewTextBoxColumn colEmail;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDireccion;
        private System.Windows.Forms.DataGridViewTextBoxColumn colActivo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAccion;
    }
}