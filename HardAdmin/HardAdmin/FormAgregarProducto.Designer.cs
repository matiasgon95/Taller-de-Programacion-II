namespace HardAdmin
{
    partial class FormAgregarProducto
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
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnSubir = new System.Windows.Forms.Button();
            this.nupStockActual = new System.Windows.Forms.NumericUpDown();
            this.nupStockMinimo = new System.Windows.Forms.NumericUpDown();
            this.nupPrecio = new System.Windows.Forms.NumericUpDown();
            this.cmbCategoria = new System.Windows.Forms.ComboBox();
            this.tbDescripcion = new System.Windows.Forms.TextBox();
            this.tbCodigo = new System.Windows.Forms.TextBox();
            this.tbNombre = new System.Windows.Forms.TextBox();
            this.LB_imagen = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.LB_Categoria = new System.Windows.Forms.Label();
            this.LB_ = new System.Windows.Forms.Label();
            this.LB_Codigo = new System.Windows.Forms.Label();
            this.LB_Nombre = new System.Windows.Forms.Label();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.lb_encabezado = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nupStockActual)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nupStockMinimo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nupPrecio)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Comic Sans MS", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(140, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(253, 40);
            this.label1.TabIndex = 0;
            this.label1.Text = "Agregar Producto";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.btnSubir);
            this.panel1.Controls.Add(this.nupStockActual);
            this.panel1.Controls.Add(this.nupStockMinimo);
            this.panel1.Controls.Add(this.nupPrecio);
            this.panel1.Controls.Add(this.cmbCategoria);
            this.panel1.Controls.Add(this.tbDescripcion);
            this.panel1.Controls.Add(this.tbCodigo);
            this.panel1.Controls.Add(this.tbNombre);
            this.panel1.Controls.Add(this.LB_imagen);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.LB_Categoria);
            this.panel1.Controls.Add(this.LB_);
            this.panel1.Controls.Add(this.LB_Codigo);
            this.panel1.Controls.Add(this.LB_Nombre);
            this.panel1.Location = new System.Drawing.Point(59, 52);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(427, 344);
            this.panel1.TabIndex = 1;
            // 
            // btnSubir
            // 
            this.btnSubir.Location = new System.Drawing.Point(249, 302);
            this.btnSubir.Name = "btnSubir";
            this.btnSubir.Size = new System.Drawing.Size(84, 26);
            this.btnSubir.TabIndex = 15;
            this.btnSubir.Text = "Subir Imagen..";
            this.btnSubir.UseVisualStyleBackColor = true;
            // 
            // nupStockActual
            // 
            this.nupStockActual.Location = new System.Drawing.Point(196, 268);
            this.nupStockActual.Name = "nupStockActual";
            this.nupStockActual.Size = new System.Drawing.Size(195, 20);
            this.nupStockActual.TabIndex = 14;
            // 
            // nupStockMinimo
            // 
            this.nupStockMinimo.Location = new System.Drawing.Point(196, 240);
            this.nupStockMinimo.Name = "nupStockMinimo";
            this.nupStockMinimo.Size = new System.Drawing.Size(195, 20);
            this.nupStockMinimo.TabIndex = 13;
            // 
            // nupPrecio
            // 
            this.nupPrecio.Location = new System.Drawing.Point(196, 207);
            this.nupPrecio.Name = "nupPrecio";
            this.nupPrecio.Size = new System.Drawing.Size(195, 20);
            this.nupPrecio.TabIndex = 12;
            // 
            // cmbCategoria
            // 
            this.cmbCategoria.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCategoria.FormattingEnabled = true;
            this.cmbCategoria.Items.AddRange(new object[] {
            "Tarjeta Grafica",
            "Pantalla",
            "Raton",
            "RAM"});
            this.cmbCategoria.Location = new System.Drawing.Point(196, 174);
            this.cmbCategoria.Name = "cmbCategoria";
            this.cmbCategoria.Size = new System.Drawing.Size(195, 21);
            this.cmbCategoria.TabIndex = 11;
            // 
            // tbDescripcion
            // 
            this.tbDescripcion.Location = new System.Drawing.Point(196, 93);
            this.tbDescripcion.Multiline = true;
            this.tbDescripcion.Name = "tbDescripcion";
            this.tbDescripcion.Size = new System.Drawing.Size(195, 60);
            this.tbDescripcion.TabIndex = 10;
            // 
            // tbCodigo
            // 
            this.tbCodigo.Location = new System.Drawing.Point(196, 60);
            this.tbCodigo.Name = "tbCodigo";
            this.tbCodigo.Size = new System.Drawing.Size(195, 20);
            this.tbCodigo.TabIndex = 9;
            // 
            // tbNombre
            // 
            this.tbNombre.Location = new System.Drawing.Point(196, 23);
            this.tbNombre.Name = "tbNombre";
            this.tbNombre.Size = new System.Drawing.Size(195, 20);
            this.tbNombre.TabIndex = 8;
            // 
            // LB_imagen
            // 
            this.LB_imagen.AutoSize = true;
            this.LB_imagen.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.LB_imagen.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.LB_imagen.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LB_imagen.Location = new System.Drawing.Point(18, 302);
            this.LB_imagen.Name = "LB_imagen";
            this.LB_imagen.Size = new System.Drawing.Size(57, 18);
            this.LB_imagen.TabIndex = 7;
            this.LB_imagen.Text = "Imagen:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(18, 272);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(86, 18);
            this.label4.TabIndex = 6;
            this.label4.Text = "Stock Actual:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(18, 240);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(92, 18);
            this.label3.TabIndex = 5;
            this.label3.Text = "Stock Minimo:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(18, 207);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(106, 18);
            this.label2.TabIndex = 4;
            this.label2.Text = "Precio de venta:";
            // 
            // LB_Categoria
            // 
            this.LB_Categoria.AutoSize = true;
            this.LB_Categoria.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.LB_Categoria.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.LB_Categoria.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LB_Categoria.Location = new System.Drawing.Point(18, 175);
            this.LB_Categoria.Name = "LB_Categoria";
            this.LB_Categoria.Size = new System.Drawing.Size(71, 18);
            this.LB_Categoria.TabIndex = 3;
            this.LB_Categoria.Text = "Categoria:";
            // 
            // LB_
            // 
            this.LB_.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.LB_.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.LB_.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LB_.Location = new System.Drawing.Point(18, 93);
            this.LB_.Name = "LB_";
            this.LB_.Size = new System.Drawing.Size(113, 34);
            this.LB_.TabIndex = 2;
            this.LB_.Text = "Descripcion (max 300 caracteres):";
            // 
            // LB_Codigo
            // 
            this.LB_Codigo.AutoSize = true;
            this.LB_Codigo.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.LB_Codigo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.LB_Codigo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LB_Codigo.Location = new System.Drawing.Point(18, 61);
            this.LB_Codigo.Name = "LB_Codigo";
            this.LB_Codigo.Size = new System.Drawing.Size(56, 18);
            this.LB_Codigo.TabIndex = 1;
            this.LB_Codigo.Text = "Codigo:";
            this.LB_Codigo.Click += new System.EventHandler(this.LB_Codigo_Click);
            // 
            // LB_Nombre
            // 
            this.LB_Nombre.AutoSize = true;
            this.LB_Nombre.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.LB_Nombre.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.LB_Nombre.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LB_Nombre.Location = new System.Drawing.Point(18, 23);
            this.LB_Nombre.Name = "LB_Nombre";
            this.LB_Nombre.Size = new System.Drawing.Size(61, 18);
            this.LB_Nombre.TabIndex = 0;
            this.LB_Nombre.Text = "Nombre:";
            // 
            // btnGuardar
            // 
            this.btnGuardar.Location = new System.Drawing.Point(309, 402);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(84, 36);
            this.btnGuardar.TabIndex = 2;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = true;
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(401, 402);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(85, 36);
            this.btnCancelar.TabIndex = 3;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            // 
            // lb_encabezado
            // 
            this.lb_encabezado.AutoSize = true;
            this.lb_encabezado.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lb_encabezado.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_encabezado.Location = new System.Drawing.Point(78, 49);
            this.lb_encabezado.Name = "lb_encabezado";
            this.lb_encabezado.Size = new System.Drawing.Size(124, 18);
            this.lb_encabezado.TabIndex = 4;
            this.lb_encabezado.Text = "Datos del Producto";
            // 
            // FormAgregarProducto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(532, 450);
            this.Controls.Add(this.lb_encabezado);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label1);
            this.Name = "FormAgregarProducto";
            this.Text = "HardAdmin - Agregar Producto";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nupStockActual)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nupStockMinimo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nupPrecio)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label LB_;
        private System.Windows.Forms.Label LB_Codigo;
        private System.Windows.Forms.Label LB_Nombre;
        private System.Windows.Forms.Label LB_imagen;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label LB_Categoria;
        private System.Windows.Forms.TextBox tbDescripcion;
        private System.Windows.Forms.TextBox tbCodigo;
        private System.Windows.Forms.TextBox tbNombre;
        private System.Windows.Forms.ComboBox cmbCategoria;
        private System.Windows.Forms.NumericUpDown nupStockActual;
        private System.Windows.Forms.NumericUpDown nupStockMinimo;
        private System.Windows.Forms.NumericUpDown nupPrecio;
        private System.Windows.Forms.Button btnSubir;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Label lb_encabezado;
    }
}