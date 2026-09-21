namespace HardAdmin
{
    partial class FormReportes
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
            this.gbVentas = new System.Windows.Forms.GroupBox();
            this.btnVentas = new System.Windows.Forms.Button();
            this.lbVentasInfo = new System.Windows.Forms.Label();
            this.gbProductos = new System.Windows.Forms.GroupBox();
            this.btnProductos = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.gbFinanzas = new System.Windows.Forms.GroupBox();
            this.btnFinanzas = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.lbTitulo = new System.Windows.Forms.Label();
            this.gbVentas.SuspendLayout();
            this.gbProductos.SuspendLayout();
            this.gbFinanzas.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbVentas
            // 
            this.gbVentas.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbVentas.Controls.Add(this.btnVentas);
            this.gbVentas.Controls.Add(this.lbVentasInfo);
            this.gbVentas.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbVentas.Location = new System.Drawing.Point(74, 47);
            this.gbVentas.Name = "gbVentas";
            this.gbVentas.Size = new System.Drawing.Size(633, 104);
            this.gbVentas.TabIndex = 0;
            this.gbVentas.TabStop = false;
            this.gbVentas.Text = "Reportes de Ventas";
            // 
            // btnVentas
            // 
            this.btnVentas.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnVentas.Location = new System.Drawing.Point(469, 30);
            this.btnVentas.Name = "btnVentas";
            this.btnVentas.Size = new System.Drawing.Size(143, 50);
            this.btnVentas.TabIndex = 1;
            this.btnVentas.Text = "Ver reportes";
            this.btnVentas.UseVisualStyleBackColor = true;
            this.btnVentas.Click += new System.EventHandler(this.btnVentas_Click);
            // 
            // lbVentasInfo
            // 
            this.lbVentasInfo.AutoSize = true;
            this.lbVentasInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbVentasInfo.Location = new System.Drawing.Point(33, 48);
            this.lbVentasInfo.Name = "lbVentasInfo";
            this.lbVentasInfo.Size = new System.Drawing.Size(274, 16);
            this.lbVentasInfo.TabIndex = 0;
            this.lbVentasInfo.Text = "Reportes asociados a las ventas realizadas.";
            // 
            // gbProductos
            // 
            this.gbProductos.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbProductos.Controls.Add(this.btnProductos);
            this.gbProductos.Controls.Add(this.label1);
            this.gbProductos.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbProductos.Location = new System.Drawing.Point(74, 182);
            this.gbProductos.Name = "gbProductos";
            this.gbProductos.Size = new System.Drawing.Size(633, 111);
            this.gbProductos.TabIndex = 1;
            this.gbProductos.TabStop = false;
            this.gbProductos.Text = "Reportes de Productos";
            // 
            // btnProductos
            // 
            this.btnProductos.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnProductos.Location = new System.Drawing.Point(469, 36);
            this.btnProductos.Name = "btnProductos";
            this.btnProductos.Size = new System.Drawing.Size(143, 50);
            this.btnProductos.TabIndex = 1;
            this.btnProductos.Text = "Ver reportes";
            this.btnProductos.UseVisualStyleBackColor = true;
            this.btnProductos.Click += new System.EventHandler(this.btnProductos_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(33, 54);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(287, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Reportes asociados a los productos vendidos.";
            // 
            // gbFinanzas
            // 
            this.gbFinanzas.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbFinanzas.Controls.Add(this.btnFinanzas);
            this.gbFinanzas.Controls.Add(this.label2);
            this.gbFinanzas.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbFinanzas.Location = new System.Drawing.Point(74, 319);
            this.gbFinanzas.Name = "gbFinanzas";
            this.gbFinanzas.Size = new System.Drawing.Size(633, 106);
            this.gbFinanzas.TabIndex = 2;
            this.gbFinanzas.TabStop = false;
            this.gbFinanzas.Text = "Reportes de Finanzas";
            // 
            // btnFinanzas
            // 
            this.btnFinanzas.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFinanzas.Location = new System.Drawing.Point(469, 32);
            this.btnFinanzas.Name = "btnFinanzas";
            this.btnFinanzas.Size = new System.Drawing.Size(143, 50);
            this.btnFinanzas.TabIndex = 1;
            this.btnFinanzas.Text = "Ver reportes";
            this.btnFinanzas.UseVisualStyleBackColor = true;
            this.btnFinanzas.Click += new System.EventHandler(this.btnFinanzas_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(33, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(283, 16);
            this.label2.TabIndex = 0;
            this.label2.Text = "Reportes asociados a las finanzas completas.";
            // 
            // lbTitulo
            // 
            this.lbTitulo.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lbTitulo.AutoSize = true;
            this.lbTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTitulo.Location = new System.Drawing.Point(332, 9);
            this.lbTitulo.Name = "lbTitulo";
            this.lbTitulo.Size = new System.Drawing.Size(125, 31);
            this.lbTitulo.TabIndex = 3;
            this.lbTitulo.Text = "Reportes";
            // 
            // FormReportes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lbTitulo);
            this.Controls.Add(this.gbFinanzas);
            this.Controls.Add(this.gbProductos);
            this.Controls.Add(this.gbVentas);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormReportes";
            this.Text = "HardAmin - Reportes Estadisticos";
            this.gbVentas.ResumeLayout(false);
            this.gbVentas.PerformLayout();
            this.gbProductos.ResumeLayout(false);
            this.gbProductos.PerformLayout();
            this.gbFinanzas.ResumeLayout(false);
            this.gbFinanzas.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox gbVentas;
        private System.Windows.Forms.GroupBox gbProductos;
        private System.Windows.Forms.GroupBox gbFinanzas;
        private System.Windows.Forms.Label lbVentasInfo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnVentas;
        private System.Windows.Forms.Button btnProductos;
        private System.Windows.Forms.Button btnFinanzas;
        private System.Windows.Forms.Label lbTitulo;
    }
}