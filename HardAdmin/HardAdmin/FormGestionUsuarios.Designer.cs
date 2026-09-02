namespace HardAdmin
{
    partial class FormGestionUsuarios
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label1 = new System.Windows.Forms.Label();
            this.btnAgregarUsuario = new System.Windows.Forms.Button();
            this.dgvUsuarios = new System.Windows.Forms.DataGridView();
            this.colUsuario = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEmail = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colRol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colActivo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAccion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnModificarFila = new System.Windows.Forms.Button();
            this.pnlMenuLateral = new System.Windows.Forms.Panel();
            this.btnSalir = new System.Windows.Forms.Button();
            this.btnConfiguración = new System.Windows.Forms.Button();
            this.btnReportes = new System.Windows.Forms.Button();
            this.btnVentas = new System.Windows.Forms.Button();
            this.btnProductos = new System.Windows.Forms.Button();
            this.btnUsuarios = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsuarios)).BeginInit();
            this.pnlMenuLateral.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(305, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(273, 31);
            this.label1.TabIndex = 1;
            this.label1.Text = "Listado de Usuarios";
            // 
            // btnAgregarUsuario
            // 
            this.btnAgregarUsuario.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnAgregarUsuario.Location = new System.Drawing.Point(141, 419);
            this.btnAgregarUsuario.Name = "btnAgregarUsuario";
            this.btnAgregarUsuario.Size = new System.Drawing.Size(99, 38);
            this.btnAgregarUsuario.TabIndex = 2;
            this.btnAgregarUsuario.Text = "Agregar Usuario";
            this.btnAgregarUsuario.UseVisualStyleBackColor = true;
            // 
            // dgvUsuarios
            // 
            this.dgvUsuarios.AllowUserToAddRows = false;
            this.dgvUsuarios.AllowUserToDeleteRows = false;
            this.dgvUsuarios.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvUsuarios.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvUsuarios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvUsuarios.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colUsuario,
            this.colEmail,
            this.colRol,
            this.colActivo,
            this.colAccion});
            this.dgvUsuarios.Location = new System.Drawing.Point(141, 68);
            this.dgvUsuarios.MultiSelect = false;
            this.dgvUsuarios.Name = "dgvUsuarios";
            this.dgvUsuarios.ReadOnly = true;
            this.dgvUsuarios.RowHeadersVisible = false;
            this.dgvUsuarios.RowTemplate.Height = 32;
            this.dgvUsuarios.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvUsuarios.Size = new System.Drawing.Size(627, 320);
            this.dgvUsuarios.TabIndex = 3;
            this.dgvUsuarios.Scroll += new System.Windows.Forms.ScrollEventHandler(this.dgvUsuarios_Scroll);
            this.dgvUsuarios.SelectionChanged += new System.EventHandler(this.dgvUsuarios_SelectionChanged);
            // 
            // colUsuario
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.colUsuario.DefaultCellStyle = dataGridViewCellStyle1;
            this.colUsuario.HeaderText = "Usuario";
            this.colUsuario.Name = "colUsuario";
            this.colUsuario.ReadOnly = true;
            // 
            // colEmail
            // 
            this.colEmail.HeaderText = "Email";
            this.colEmail.Name = "colEmail";
            this.colEmail.ReadOnly = true;
            // 
            // colRol
            // 
            this.colRol.HeaderText = "Rol";
            this.colRol.Name = "colRol";
            this.colRol.ReadOnly = true;
            // 
            // colActivo
            // 
            this.colActivo.HeaderText = "Activo";
            this.colActivo.Name = "colActivo";
            this.colActivo.ReadOnly = true;
            this.colActivo.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colActivo.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // colAccion
            // 
            this.colAccion.HeaderText = "Acción";
            this.colAccion.Name = "colAccion";
            this.colAccion.ReadOnly = true;
            this.colAccion.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // btnModificarFila
            // 
            this.btnModificarFila.Location = new System.Drawing.Point(669, 103);
            this.btnModificarFila.Name = "btnModificarFila";
            this.btnModificarFila.Size = new System.Drawing.Size(75, 23);
            this.btnModificarFila.TabIndex = 4;
            this.btnModificarFila.Text = "Modificar";
            this.btnModificarFila.UseVisualStyleBackColor = true;
            this.btnModificarFila.Visible = false;
            // 
            // pnlMenuLateral
            // 
            this.pnlMenuLateral.Controls.Add(this.btnSalir);
            this.pnlMenuLateral.Controls.Add(this.btnConfiguración);
            this.pnlMenuLateral.Controls.Add(this.btnReportes);
            this.pnlMenuLateral.Controls.Add(this.btnVentas);
            this.pnlMenuLateral.Controls.Add(this.btnProductos);
            this.pnlMenuLateral.Controls.Add(this.btnUsuarios);
            this.pnlMenuLateral.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlMenuLateral.Location = new System.Drawing.Point(0, 0);
            this.pnlMenuLateral.Name = "pnlMenuLateral";
            this.pnlMenuLateral.Size = new System.Drawing.Size(100, 469);
            this.pnlMenuLateral.TabIndex = 5;
            // 
            // btnSalir
            // 
            this.btnSalir.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnSalir.FlatAppearance.BorderSize = 0;
            this.btnSalir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSalir.Image = global::HardAdmin.Properties.Resources.salir;
            this.btnSalir.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnSalir.Location = new System.Drawing.Point(0, 389);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(100, 80);
            this.btnSalir.TabIndex = 11;
            this.btnSalir.Text = "Salir";
            this.btnSalir.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // btnConfiguración
            // 
            this.btnConfiguración.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnConfiguración.FlatAppearance.BorderSize = 0;
            this.btnConfiguración.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConfiguración.Image = global::HardAdmin.Properties.Resources.configuracion;
            this.btnConfiguración.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnConfiguración.Location = new System.Drawing.Point(0, 320);
            this.btnConfiguración.Name = "btnConfiguración";
            this.btnConfiguración.Size = new System.Drawing.Size(100, 80);
            this.btnConfiguración.TabIndex = 10;
            this.btnConfiguración.Text = "Configuración";
            this.btnConfiguración.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnConfiguración.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnConfiguración.UseVisualStyleBackColor = true;
            // 
            // btnReportes
            // 
            this.btnReportes.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnReportes.FlatAppearance.BorderSize = 0;
            this.btnReportes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReportes.Image = global::HardAdmin.Properties.Resources.reportes;
            this.btnReportes.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnReportes.Location = new System.Drawing.Point(0, 240);
            this.btnReportes.Name = "btnReportes";
            this.btnReportes.Size = new System.Drawing.Size(100, 80);
            this.btnReportes.TabIndex = 9;
            this.btnReportes.Text = "Reportes";
            this.btnReportes.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnReportes.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnReportes.UseVisualStyleBackColor = true;
            // 
            // btnVentas
            // 
            this.btnVentas.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnVentas.FlatAppearance.BorderSize = 0;
            this.btnVentas.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVentas.Image = global::HardAdmin.Properties.Resources.ventas;
            this.btnVentas.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnVentas.Location = new System.Drawing.Point(0, 160);
            this.btnVentas.Name = "btnVentas";
            this.btnVentas.Size = new System.Drawing.Size(100, 80);
            this.btnVentas.TabIndex = 8;
            this.btnVentas.Text = "Ventas";
            this.btnVentas.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnVentas.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnVentas.UseVisualStyleBackColor = true;
            // 
            // btnProductos
            // 
            this.btnProductos.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnProductos.FlatAppearance.BorderSize = 0;
            this.btnProductos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnProductos.Image = global::HardAdmin.Properties.Resources.productos;
            this.btnProductos.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnProductos.Location = new System.Drawing.Point(0, 80);
            this.btnProductos.Name = "btnProductos";
            this.btnProductos.Size = new System.Drawing.Size(100, 80);
            this.btnProductos.TabIndex = 7;
            this.btnProductos.Text = "Productos";
            this.btnProductos.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnProductos.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnProductos.UseVisualStyleBackColor = true;
            // 
            // btnUsuarios
            // 
            this.btnUsuarios.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnUsuarios.FlatAppearance.BorderSize = 0;
            this.btnUsuarios.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUsuarios.Image = global::HardAdmin.Properties.Resources.usuarios;
            this.btnUsuarios.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnUsuarios.Location = new System.Drawing.Point(0, 0);
            this.btnUsuarios.Name = "btnUsuarios";
            this.btnUsuarios.Size = new System.Drawing.Size(100, 80);
            this.btnUsuarios.TabIndex = 6;
            this.btnUsuarios.Text = "Usuarios";
            this.btnUsuarios.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnUsuarios.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnUsuarios.UseVisualStyleBackColor = true;
            // 
            // FormGestionUsuarios
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 469);
            this.Controls.Add(this.pnlMenuLateral);
            this.Controls.Add(this.btnModificarFila);
            this.Controls.Add(this.dgvUsuarios);
            this.Controls.Add(this.btnAgregarUsuario);
            this.Controls.Add(this.label1);
            this.Name = "FormGestionUsuarios";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "HardAdmin - Gestión de Usuarios";
            this.Load += new System.EventHandler(this.FormGestionUsuarios_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsuarios)).EndInit();
            this.pnlMenuLateral.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnAgregarUsuario;
        private System.Windows.Forms.DataGridView dgvUsuarios;
        private System.Windows.Forms.Button btnModificarFila;
        private System.Windows.Forms.DataGridViewTextBoxColumn colUsuario;
        private System.Windows.Forms.DataGridViewTextBoxColumn colEmail;
        private System.Windows.Forms.DataGridViewTextBoxColumn colRol;
        private System.Windows.Forms.DataGridViewTextBoxColumn colActivo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAccion;
        private System.Windows.Forms.Panel pnlMenuLateral;
        private System.Windows.Forms.Button btnUsuarios;
        private System.Windows.Forms.Button btnReportes;
        private System.Windows.Forms.Button btnVentas;
        private System.Windows.Forms.Button btnProductos;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.Button btnConfiguración;
    }
}