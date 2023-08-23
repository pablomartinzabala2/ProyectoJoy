namespace SistemaFact
{
    partial class FrmIngreso
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.ImagenCodigo = new System.Windows.Forms.PictureBox();
            this.btnGenerarCodigoBarra = new System.Windows.Forms.Button();
            this.btnAgregarOrigen = new System.Windows.Forms.Button();
            this.btnNuevaTipoPrenda = new System.Windows.Forms.Button();
            this.txtRuta = new System.Windows.Forms.TextBox();
            this.btnGrabar = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.txtCodigoBarra = new System.Windows.Forms.TextBox();
            this.btnAbrirImagen = new System.Windows.Forms.Button();
            this.Imagen = new System.Windows.Forms.PictureBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtStock = new System.Windows.Forms.TextBox();
            this.txtPrecioVenta = new System.Windows.Forms.TextBox();
            this.txtDescripcion = new System.Windows.Forms.TextBox();
            this.cmbColor = new System.Windows.Forms.ComboBox();
            this.cmbOrigen = new System.Windows.Forms.ComboBox();
            this.CmbTipoPrenda = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ImagenCodigo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Imagen)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.ImagenCodigo);
            this.groupBox1.Controls.Add(this.btnGenerarCodigoBarra);
            this.groupBox1.Controls.Add(this.btnAgregarOrigen);
            this.groupBox1.Controls.Add(this.btnNuevaTipoPrenda);
            this.groupBox1.Controls.Add(this.txtRuta);
            this.groupBox1.Controls.Add(this.btnGrabar);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.txtCodigoBarra);
            this.groupBox1.Controls.Add(this.btnAbrirImagen);
            this.groupBox1.Controls.Add(this.Imagen);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.txtStock);
            this.groupBox1.Controls.Add(this.txtPrecioVenta);
            this.groupBox1.Controls.Add(this.txtDescripcion);
            this.groupBox1.Controls.Add(this.cmbColor);
            this.groupBox1.Controls.Add(this.cmbOrigen);
            this.groupBox1.Controls.Add(this.CmbTipoPrenda);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(646, 465);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Información del artículo";
            // 
            // ImagenCodigo
            // 
            this.ImagenCodigo.Location = new System.Drawing.Point(158, 218);
            this.ImagenCodigo.Name = "ImagenCodigo";
            this.ImagenCodigo.Size = new System.Drawing.Size(240, 50);
            this.ImagenCodigo.TabIndex = 22;
            this.ImagenCodigo.TabStop = false;
            // 
            // btnGenerarCodigoBarra
            // 
            this.btnGenerarCodigoBarra.Image = global::SistemaFact.Properties.Resources.CodigoBarra;
            this.btnGenerarCodigoBarra.Location = new System.Drawing.Point(398, 218);
            this.btnGenerarCodigoBarra.Name = "btnGenerarCodigoBarra";
            this.btnGenerarCodigoBarra.Size = new System.Drawing.Size(26, 26);
            this.btnGenerarCodigoBarra.TabIndex = 21;
            this.btnGenerarCodigoBarra.UseVisualStyleBackColor = true;
            this.btnGenerarCodigoBarra.Click += new System.EventHandler(this.btnGenerarCodigoBarra_Click);
            // 
            // btnAgregarOrigen
            // 
            this.btnAgregarOrigen.Image = global::SistemaFact.Properties.Resources.add;
            this.btnAgregarOrigen.Location = new System.Drawing.Point(512, 69);
            this.btnAgregarOrigen.Name = "btnAgregarOrigen";
            this.btnAgregarOrigen.Size = new System.Drawing.Size(26, 26);
            this.btnAgregarOrigen.TabIndex = 20;
            this.btnAgregarOrigen.UseVisualStyleBackColor = true;
            this.btnAgregarOrigen.Click += new System.EventHandler(this.btnAgregarOrigen_Click);
            // 
            // btnNuevaTipoPrenda
            // 
            this.btnNuevaTipoPrenda.Image = global::SistemaFact.Properties.Resources.add;
            this.btnNuevaTipoPrenda.Location = new System.Drawing.Point(512, 37);
            this.btnNuevaTipoPrenda.Name = "btnNuevaTipoPrenda";
            this.btnNuevaTipoPrenda.Size = new System.Drawing.Size(26, 26);
            this.btnNuevaTipoPrenda.TabIndex = 19;
            this.btnNuevaTipoPrenda.UseVisualStyleBackColor = true;
            this.btnNuevaTipoPrenda.Click += new System.EventHandler(this.btnNuevaTipoPrenda_Click);
            // 
            // txtRuta
            // 
            this.txtRuta.Location = new System.Drawing.Point(296, 189);
            this.txtRuta.Name = "txtRuta";
            this.txtRuta.Size = new System.Drawing.Size(132, 23);
            this.txtRuta.TabIndex = 18;
            this.txtRuta.Visible = false;
            this.txtRuta.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // btnGrabar
            // 
            this.btnGrabar.Location = new System.Drawing.Point(158, 398);
            this.btnGrabar.Name = "btnGrabar";
            this.btnGrabar.Size = new System.Drawing.Size(75, 34);
            this.btnGrabar.TabIndex = 17;
            this.btnGrabar.Text = "Grabar";
            this.btnGrabar.UseVisualStyleBackColor = true;
            this.btnGrabar.Click += new System.EventHandler(this.btnGrabar_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(36, 218);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(91, 17);
            this.label8.TabIndex = 16;
            this.label8.Text = "Código Barra";
            // 
            // txtCodigoBarra
            // 
            this.txtCodigoBarra.Location = new System.Drawing.Point(430, 218);
            this.txtCodigoBarra.Name = "txtCodigoBarra";
            this.txtCodigoBarra.Size = new System.Drawing.Size(132, 23);
            this.txtCodigoBarra.TabIndex = 15;
            this.txtCodigoBarra.TextChanged += new System.EventHandler(this.txtCodigoBarra_TextChanged);
            // 
            // btnAbrirImagen
            // 
            this.btnAbrirImagen.Location = new System.Drawing.Point(296, 275);
            this.btnAbrirImagen.Name = "btnAbrirImagen";
            this.btnAbrirImagen.Size = new System.Drawing.Size(75, 34);
            this.btnAbrirImagen.TabIndex = 14;
            this.btnAbrirImagen.Text = "button1";
            this.btnAbrirImagen.UseVisualStyleBackColor = true;
            this.btnAbrirImagen.Click += new System.EventHandler(this.btnAbrirImagen_Click);
            // 
            // Imagen
            // 
            this.Imagen.Location = new System.Drawing.Point(158, 275);
            this.Imagen.Name = "Imagen";
            this.Imagen.Size = new System.Drawing.Size(132, 117);
            this.Imagen.TabIndex = 13;
            this.Imagen.TabStop = false;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(36, 264);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(54, 17);
            this.label7.TabIndex = 12;
            this.label7.Text = "Imagen";
            // 
            // txtStock
            // 
            this.txtStock.Location = new System.Drawing.Point(158, 189);
            this.txtStock.Name = "txtStock";
            this.txtStock.Size = new System.Drawing.Size(132, 23);
            this.txtStock.TabIndex = 11;
            // 
            // txtPrecioVenta
            // 
            this.txtPrecioVenta.Location = new System.Drawing.Point(158, 158);
            this.txtPrecioVenta.Name = "txtPrecioVenta";
            this.txtPrecioVenta.Size = new System.Drawing.Size(132, 23);
            this.txtPrecioVenta.TabIndex = 10;
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.Location = new System.Drawing.Point(158, 129);
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.Size = new System.Drawing.Size(348, 23);
            this.txtDescripcion.TabIndex = 9;
            // 
            // cmbColor
            // 
            this.cmbColor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbColor.FormattingEnabled = true;
            this.cmbColor.Location = new System.Drawing.Point(158, 99);
            this.cmbColor.Name = "cmbColor";
            this.cmbColor.Size = new System.Drawing.Size(348, 24);
            this.cmbColor.TabIndex = 8;
            // 
            // cmbOrigen
            // 
            this.cmbOrigen.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbOrigen.FormattingEnabled = true;
            this.cmbOrigen.Location = new System.Drawing.Point(158, 69);
            this.cmbOrigen.Name = "cmbOrigen";
            this.cmbOrigen.Size = new System.Drawing.Size(348, 24);
            this.cmbOrigen.TabIndex = 7;
            // 
            // CmbTipoPrenda
            // 
            this.CmbTipoPrenda.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbTipoPrenda.FormattingEnabled = true;
            this.CmbTipoPrenda.Location = new System.Drawing.Point(158, 39);
            this.CmbTipoPrenda.Name = "CmbTipoPrenda";
            this.CmbTipoPrenda.Size = new System.Drawing.Size(348, 24);
            this.CmbTipoPrenda.TabIndex = 6;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(36, 189);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(82, 17);
            this.label6.TabIndex = 5;
            this.label6.Text = "Stock Inicial";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(36, 158);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(109, 17);
            this.label5.TabIndex = 4;
            this.label5.Text = "Precio de Venta";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(36, 129);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(82, 17);
            this.label4.TabIndex = 3;
            this.label4.Text = "Descripción";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(36, 98);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(110, 17);
            this.label3.TabIndex = 2;
            this.label3.Text = "Color de prenda";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(36, 67);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(120, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "Origen de prenda";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(36, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(105, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Tipo de prenda";
            // 
            // FrmIngreso
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(670, 489);
            this.Controls.Add(this.groupBox1);
            this.Name = "FrmIngreso";
            this.Load += new System.EventHandler(this.FrmIngreso_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ImagenCodigo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Imagen)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnAbrirImagen;
        private System.Windows.Forms.PictureBox Imagen;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtStock;
        private System.Windows.Forms.TextBox txtPrecioVenta;
        private System.Windows.Forms.TextBox txtDescripcion;
        private System.Windows.Forms.ComboBox cmbColor;
        private System.Windows.Forms.ComboBox cmbOrigen;
        private System.Windows.Forms.ComboBox CmbTipoPrenda;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtCodigoBarra;
        private System.Windows.Forms.Button btnGrabar;
        private System.Windows.Forms.TextBox txtRuta;
        private System.Windows.Forms.Button btnNuevaTipoPrenda;
        private System.Windows.Forms.Button btnAgregarOrigen;
        private System.Windows.Forms.Button btnGenerarCodigoBarra;
        private System.Windows.Forms.PictureBox ImagenCodigo;
    }
}