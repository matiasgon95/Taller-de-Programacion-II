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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.LB_titulo = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.CL_Codigo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CL_Nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CL_Categoria = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CL_Stock = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CL_Stock_Minimo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CL_Precio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CL_Activo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CL_Modificar = new System.Windows.Forms.DataGridViewButtonColumn();
            this.CL_Eliminar = new System.Windows.Forms.DataGridViewButtonColumn();
            this.btnAgregarProducto = new System.Windows.Forms.Button();
            this.btnMovimientos = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // LB_titulo
            // 
            this.LB_titulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LB_titulo.Location = new System.Drawing.Point(231, 9);
            this.LB_titulo.Name = "LB_titulo";
            this.LB_titulo.Size = new System.Drawing.Size(305, 31);
            this.LB_titulo.TabIndex = 1;
            this.LB_titulo.Text = "Listado de Productos";
            this.LB_titulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CL_Codigo,
            this.CL_Nombre,
            this.CL_Categoria,
            this.CL_Stock,
            this.CL_Stock_Minimo,
            this.CL_Precio,
            this.CL_Activo,
            this.CL_Modificar,
            this.CL_Eliminar});
            this.dataGridView1.Location = new System.Drawing.Point(28, 56);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(744, 316);
            this.dataGridView1.TabIndex = 2;
            // 
            // CL_Codigo
            // 
            this.CL_Codigo.HeaderText = "Codigo";
            this.CL_Codigo.Name = "CL_Codigo";
            // 
            // CL_Nombre
            // 
            this.CL_Nombre.HeaderText = "Nombre";
            this.CL_Nombre.Name = "CL_Nombre";
            // 
            // CL_Categoria
            // 
            this.CL_Categoria.HeaderText = "Categoria";
            this.CL_Categoria.Name = "CL_Categoria";
            // 
            // CL_Stock
            // 
            this.CL_Stock.HeaderText = "Stock";
            this.CL_Stock.Name = "CL_Stock";
            // 
            // CL_Stock_Minimo
            // 
            this.CL_Stock_Minimo.HeaderText = "Stock Minimo";
            this.CL_Stock_Minimo.Name = "CL_Stock_Minimo";
            // 
            // CL_Precio
            // 
            this.CL_Precio.HeaderText = "Precio";
            this.CL_Precio.Name = "CL_Precio";
            // 
            // CL_Activo
            // 
            this.CL_Activo.HeaderText = "Activo";
            this.CL_Activo.Name = "CL_Activo";
            // 
            // CL_Modificar
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Silver;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            this.CL_Modificar.DefaultCellStyle = dataGridViewCellStyle1;
            this.CL_Modificar.HeaderText = "Modificar Producto";
            this.CL_Modificar.Name = "CL_Modificar";
            this.CL_Modificar.Text = "Modificar";
            this.CL_Modificar.UseColumnTextForButtonValue = true;
            this.CL_Modificar.Width = 92;
            // 
            // CL_Eliminar
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.Gray;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            this.CL_Eliminar.DefaultCellStyle = dataGridViewCellStyle2;
            this.CL_Eliminar.HeaderText = "Eliminar Producto";
            this.CL_Eliminar.Name = "CL_Eliminar";
            this.CL_Eliminar.Text = "Eliminar";
            this.CL_Eliminar.UseColumnTextForButtonValue = true;
            // 
            // btnAgregarProducto
            // 
            this.btnAgregarProducto.Location = new System.Drawing.Point(28, 389);
            this.btnAgregarProducto.Name = "btnAgregarProducto";
            this.btnAgregarProducto.Size = new System.Drawing.Size(119, 49);
            this.btnAgregarProducto.TabIndex = 3;
            this.btnAgregarProducto.Text = "Agregar Producto";
            this.btnAgregarProducto.UseVisualStyleBackColor = true;
            this.btnAgregarProducto.Click += new System.EventHandler(this.btnAgregarProducto_Click);
            // 
            // btnMovimientos
            // 
            this.btnMovimientos.Location = new System.Drawing.Point(643, 389);
            this.btnMovimientos.Name = "btnMovimientos";
            this.btnMovimientos.Size = new System.Drawing.Size(129, 49);
            this.btnMovimientos.TabIndex = 4;
            this.btnMovimientos.Text = "Movimientos de Stock";
            this.btnMovimientos.UseVisualStyleBackColor = true;
            // 
            // FormGestionProductos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnMovimientos);
            this.Controls.Add(this.btnAgregarProducto);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.LB_titulo);
            this.Name = "FormGestionProductos";
            this.Text = "HardAdmin -Gestion de Productos";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label LB_titulo;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnAgregarProducto;
        private System.Windows.Forms.Button btnMovimientos;
        private System.Windows.Forms.DataGridViewTextBoxColumn CL_Codigo;
        private System.Windows.Forms.DataGridViewTextBoxColumn CL_Nombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn CL_Categoria;
        private System.Windows.Forms.DataGridViewTextBoxColumn CL_Stock;
        private System.Windows.Forms.DataGridViewTextBoxColumn CL_Stock_Minimo;
        private System.Windows.Forms.DataGridViewTextBoxColumn CL_Precio;
        private System.Windows.Forms.DataGridViewTextBoxColumn CL_Activo;
        private System.Windows.Forms.DataGridViewButtonColumn CL_Modificar;
        private System.Windows.Forms.DataGridViewButtonColumn CL_Eliminar;
    }
}