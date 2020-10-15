namespace SistemaFact
{
    partial class FrmVentaJuguetes
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmVentaJuguetes));
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtTotal = new System.Windows.Forms.TextBox();
            this.btnGrabar = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label7 = new System.Windows.Forms.Label();
            this.CmbTipoOperacion = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.txtFecha = new System.Windows.Forms.MaskedTextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radioJugueteria = new System.Windows.Forms.RadioButton();
            this.radioLibreria = new System.Windows.Forms.RadioButton();
            this.btnLimpiarArticulo = new System.Windows.Forms.Button();
            this.txt_Nombre = new System.Windows.Forms.ComboBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.chkDescuento = new System.Windows.Forms.CheckBox();
            this.txtDescuento = new System.Windows.Forms.TextBox();
            this.btnBuscarArticulo = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.Grilla = new System.Windows.Forms.DataGridView();
            this.txtPrecio = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtCantidad = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.txt_Codigo = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtCodigo = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txt_CodigoBarra = new System.Windows.Forms.TextBox();
            this.txt_Stock = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.txtTotalDescuento = new System.Windows.Forms.TextBox();
            this.CmbTarjeta = new System.Windows.Forms.ComboBox();
            this.txtTotalConDescuento = new System.Windows.Forms.TextBox();
            this.lblTarjeta = new System.Windows.Forms.Label();
            this.lblCupon = new System.Windows.Forms.Label();
            this.txtCupon = new System.Windows.Forms.TextBox();
            this.txtPordescuento = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Grilla)).BeginInit();
            this.SuspendLayout();
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(442, 481);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(86, 13);
            this.label5.TabIndex = 97;
            this.label5.Text = "Total Descuento";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(639, 484);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(31, 13);
            this.label3.TabIndex = 96;
            this.label3.Text = "Total";
            // 
            // txtTotal
            // 
            this.txtTotal.Location = new System.Drawing.Point(700, 451);
            this.txtTotal.Name = "txtTotal";
            this.txtTotal.Size = new System.Drawing.Size(69, 20);
            this.txtTotal.TabIndex = 95;
            // 
            // btnGrabar
            // 
            this.btnGrabar.Location = new System.Drawing.Point(700, 510);
            this.btnGrabar.Name = "btnGrabar";
            this.btnGrabar.Size = new System.Drawing.Size(75, 23);
            this.btnGrabar.TabIndex = 94;
            this.btnGrabar.Text = "Grabar";
            this.btnGrabar.UseVisualStyleBackColor = true;
            this.btnGrabar.Click += new System.EventHandler(this.btnGrabar_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.CmbTipoOperacion);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Controls.Add(this.txtFecha);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(37, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(701, 48);
            this.groupBox2.TabIndex = 22;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Tipo de Operación";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 22);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(191, 17);
            this.label7.TabIndex = 84;
            this.label7.Text = "Seleccione tipo de operación";
            // 
            // CmbTipoOperacion
            // 
            this.CmbTipoOperacion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbTipoOperacion.FormattingEnabled = true;
            this.CmbTipoOperacion.Location = new System.Drawing.Point(203, 19);
            this.CmbTipoOperacion.Name = "CmbTipoOperacion";
            this.CmbTipoOperacion.Size = new System.Drawing.Size(199, 24);
            this.CmbTipoOperacion.TabIndex = 83;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(567, 22);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(47, 17);
            this.label12.TabIndex = 81;
            this.label12.Text = "Fecha";
            // 
            // txtFecha
            // 
            this.txtFecha.Location = new System.Drawing.Point(619, 19);
            this.txtFecha.Mask = "00/00/0000";
            this.txtFecha.Name = "txtFecha";
            this.txtFecha.Size = new System.Drawing.Size(73, 23);
            this.txtFecha.TabIndex = 80;
            this.txtFecha.ValidatingType = typeof(System.DateTime);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radioJugueteria);
            this.groupBox1.Controls.Add(this.radioLibreria);
            this.groupBox1.Controls.Add(this.btnLimpiarArticulo);
            this.groupBox1.Controls.Add(this.txt_Nombre);
            this.groupBox1.Controls.Add(this.label14);
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Controls.Add(this.chkDescuento);
            this.groupBox1.Controls.Add(this.txtDescuento);
            this.groupBox1.Controls.Add(this.btnBuscarArticulo);
            this.groupBox1.Controls.Add(this.btnEliminar);
            this.groupBox1.Controls.Add(this.Grilla);
            this.groupBox1.Controls.Add(this.txtPrecio);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtCantidad);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.button2);
            this.groupBox1.Controls.Add(this.txt_Codigo);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.txtCodigo);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.txt_CodigoBarra);
            this.groupBox1.Controls.Add(this.txt_Stock);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(28, 65);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(751, 359);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Información del Producto";
            // 
            // radioJugueteria
            // 
            this.radioJugueteria.AutoSize = true;
            this.radioJugueteria.Location = new System.Drawing.Point(98, 120);
            this.radioJugueteria.Name = "radioJugueteria";
            this.radioJugueteria.Size = new System.Drawing.Size(93, 21);
            this.radioJugueteria.TabIndex = 99;
            this.radioJugueteria.Text = "Jugueteria";
            this.radioJugueteria.UseVisualStyleBackColor = true;
            // 
            // radioLibreria
            // 
            this.radioLibreria.AutoSize = true;
            this.radioLibreria.Checked = true;
            this.radioLibreria.Location = new System.Drawing.Point(18, 120);
            this.radioLibreria.Name = "radioLibreria";
            this.radioLibreria.Size = new System.Drawing.Size(74, 21);
            this.radioLibreria.TabIndex = 98;
            this.radioLibreria.TabStop = true;
            this.radioLibreria.Text = "Libreria";
            this.radioLibreria.UseVisualStyleBackColor = true;
            // 
            // btnLimpiarArticulo
            // 
            this.btnLimpiarArticulo.Image = global::SistemaFact.Properties.Resources.cancel;
            this.btnLimpiarArticulo.Location = new System.Drawing.Point(541, 25);
            this.btnLimpiarArticulo.Name = "btnLimpiarArticulo";
            this.btnLimpiarArticulo.Size = new System.Drawing.Size(40, 28);
            this.btnLimpiarArticulo.TabIndex = 97;
            this.btnLimpiarArticulo.UseVisualStyleBackColor = true;
            // 
            // txt_Nombre
            // 
            this.txt_Nombre.FormattingEnabled = true;
            this.txt_Nombre.Location = new System.Drawing.Point(93, 62);
            this.txt_Nombre.Name = "txt_Nombre";
            this.txt_Nombre.Size = new System.Drawing.Size(502, 24);
            this.txt_Nombre.TabIndex = 96;
            this.txt_Nombre.SelectedIndexChanged += new System.EventHandler(this.txt_Nombre_SelectedIndexChanged);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(617, 393);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(40, 17);
            this.label14.TabIndex = 95;
            this.label14.Text = "Total";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(450, 393);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(76, 17);
            this.label13.TabIndex = 92;
            this.label13.Text = "Descuento";
            // 
            // chkDescuento
            // 
            this.chkDescuento.AutoSize = true;
            this.chkDescuento.Location = new System.Drawing.Point(463, 94);
            this.chkDescuento.Name = "chkDescuento";
            this.chkDescuento.Size = new System.Drawing.Size(59, 21);
            this.chkDescuento.TabIndex = 89;
            this.chkDescuento.Text = "Desc";
            this.chkDescuento.UseVisualStyleBackColor = true;
            // 
            // txtDescuento
            // 
            this.txtDescuento.Location = new System.Drawing.Point(519, 94);
            this.txtDescuento.Name = "txtDescuento";
            this.txtDescuento.Size = new System.Drawing.Size(79, 23);
            this.txtDescuento.TabIndex = 88;
            // 
            // btnBuscarArticulo
            // 
            this.btnBuscarArticulo.Image = ((System.Drawing.Image)(resources.GetObject("btnBuscarArticulo.Image")));
            this.btnBuscarArticulo.Location = new System.Drawing.Point(495, 27);
            this.btnBuscarArticulo.Name = "btnBuscarArticulo";
            this.btnBuscarArticulo.Size = new System.Drawing.Size(40, 28);
            this.btnBuscarArticulo.TabIndex = 63;
            this.btnBuscarArticulo.UseVisualStyleBackColor = true;
            this.btnBuscarArticulo.Click += new System.EventHandler(this.btnBuscarArticulo_Click);
            // 
            // btnEliminar
            // 
            this.btnEliminar.Image = global::SistemaFact.Properties.Resources.cancel;
            this.btnEliminar.Location = new System.Drawing.Point(661, 94);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(40, 28);
            this.btnEliminar.TabIndex = 57;
            this.btnEliminar.UseVisualStyleBackColor = true;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // Grilla
            // 
            this.Grilla.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Grilla.Location = new System.Drawing.Point(9, 158);
            this.Grilla.Name = "Grilla";
            this.Grilla.ReadOnly = true;
            this.Grilla.RowTemplate.DefaultCellStyle.BackColor = System.Drawing.Color.White;
            this.Grilla.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            this.Grilla.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.Grilla.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.White;
            this.Grilla.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.Grilla.Size = new System.Drawing.Size(732, 163);
            this.Grilla.TabIndex = 56;
            // 
            // txtPrecio
            // 
            this.txtPrecio.Location = new System.Drawing.Point(378, 94);
            this.txtPrecio.Name = "txtPrecio";
            this.txtPrecio.Size = new System.Drawing.Size(79, 23);
            this.txtPrecio.TabIndex = 55;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(324, 94);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 17);
            this.label2.TabIndex = 54;
            this.label2.Text = "Precio";
            // 
            // txtCantidad
            // 
            this.txtCantidad.Location = new System.Drawing.Point(237, 91);
            this.txtCantidad.Name = "txtCantidad";
            this.txtCantidad.Size = new System.Drawing.Size(80, 23);
            this.txtCantidad.TabIndex = 53;
            this.txtCantidad.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCantidad_KeyPress);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(173, 91);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(64, 17);
            this.label4.TabIndex = 52;
            this.label4.Text = "Cantidad";
            // 
            // button2
            // 
            this.button2.Image = global::SistemaFact.Properties.Resources.add;
            this.button2.Location = new System.Drawing.Point(613, 94);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(40, 28);
            this.button2.TabIndex = 51;
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // txt_Codigo
            // 
            this.txt_Codigo.Location = new System.Drawing.Point(93, 33);
            this.txt_Codigo.Name = "txt_Codigo";
            this.txt_Codigo.Size = new System.Drawing.Size(132, 23);
            this.txt_Codigo.TabIndex = 25;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(10, 33);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(52, 17);
            this.label6.TabIndex = 24;
            this.label6.Text = "Código";
            // 
            // txtCodigo
            // 
            this.txtCodigo.Location = new System.Drawing.Point(669, 30);
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.Size = new System.Drawing.Size(41, 23);
            this.txtCodigo.TabIndex = 23;
            this.txtCodigo.Visible = false;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(260, 33);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(91, 17);
            this.label8.TabIndex = 16;
            this.label8.Text = "Código Barra";
            // 
            // txt_CodigoBarra
            // 
            this.txt_CodigoBarra.Location = new System.Drawing.Point(357, 33);
            this.txt_CodigoBarra.Name = "txt_CodigoBarra";
            this.txt_CodigoBarra.Size = new System.Drawing.Size(132, 23);
            this.txt_CodigoBarra.TabIndex = 1;
            this.txt_CodigoBarra.TextChanged += new System.EventHandler(this.txt_CodigoBarra_TextChanged);
            // 
            // txt_Stock
            // 
            this.txt_Stock.Location = new System.Drawing.Point(93, 91);
            this.txt_Stock.Name = "txt_Stock";
            this.txt_Stock.Size = new System.Drawing.Size(74, 23);
            this.txt_Stock.TabIndex = 11;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(15, 95);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(47, 17);
            this.label9.TabIndex = 5;
            this.label9.Text = "Stock ";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(10, 62);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(82, 17);
            this.label10.TabIndex = 3;
            this.label10.Text = "Descripción";
            // 
            // txtTotalDescuento
            // 
            this.txtTotalDescuento.Location = new System.Drawing.Point(540, 484);
            this.txtTotalDescuento.Name = "txtTotalDescuento";
            this.txtTotalDescuento.Size = new System.Drawing.Size(69, 20);
            this.txtTotalDescuento.TabIndex = 90;
            // 
            // CmbTarjeta
            // 
            this.CmbTarjeta.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbTarjeta.FormattingEnabled = true;
            this.CmbTarjeta.Location = new System.Drawing.Point(97, 451);
            this.CmbTarjeta.Name = "CmbTarjeta";
            this.CmbTarjeta.Size = new System.Drawing.Size(178, 21);
            this.CmbTarjeta.TabIndex = 83;
            // 
            // txtTotalConDescuento
            // 
            this.txtTotalConDescuento.Location = new System.Drawing.Point(700, 484);
            this.txtTotalConDescuento.Name = "txtTotalConDescuento";
            this.txtTotalConDescuento.Size = new System.Drawing.Size(69, 20);
            this.txtTotalConDescuento.TabIndex = 94;
            // 
            // lblTarjeta
            // 
            this.lblTarjeta.AutoSize = true;
            this.lblTarjeta.Location = new System.Drawing.Point(38, 451);
            this.lblTarjeta.Name = "lblTarjeta";
            this.lblTarjeta.Size = new System.Drawing.Size(40, 13);
            this.lblTarjeta.TabIndex = 84;
            this.lblTarjeta.Text = "Tarjeta";
            // 
            // lblCupon
            // 
            this.lblCupon.AutoSize = true;
            this.lblCupon.Location = new System.Drawing.Point(288, 451);
            this.lblCupon.Name = "lblCupon";
            this.lblCupon.Size = new System.Drawing.Size(38, 13);
            this.lblCupon.TabIndex = 85;
            this.lblCupon.Text = "Cupon";
            // 
            // txtCupon
            // 
            this.txtCupon.Location = new System.Drawing.Point(332, 448);
            this.txtCupon.Name = "txtCupon";
            this.txtCupon.Size = new System.Drawing.Size(120, 20);
            this.txtCupon.TabIndex = 86;
            // 
            // txtPordescuento
            // 
            this.txtPordescuento.Location = new System.Drawing.Point(540, 451);
            this.txtPordescuento.Name = "txtPordescuento";
            this.txtPordescuento.Size = new System.Drawing.Size(69, 20);
            this.txtPordescuento.TabIndex = 93;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(458, 451);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(70, 13);
            this.label11.TabIndex = 91;
            this.label11.Text = "% Descuento";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(638, 451);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 13);
            this.label1.TabIndex = 58;
            this.label1.Text = "Subtotal";
            // 
            // FrmVentaJuguetes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(803, 594);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtTotal);
            this.Controls.Add(this.btnGrabar);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.txtTotalDescuento);
            this.Controls.Add(this.CmbTarjeta);
            this.Controls.Add(this.txtTotalConDescuento);
            this.Controls.Add(this.lblTarjeta);
            this.Controls.Add(this.lblCupon);
            this.Controls.Add(this.txtCupon);
            this.Controls.Add(this.txtPordescuento);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label1);
            this.Name = "FrmVentaJuguetes";
            this.Text = "FrmVentaJuguetes";
            this.Load += new System.EventHandler(this.FrmVentaJuguetes_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Grilla)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnLimpiarArticulo;
        private System.Windows.Forms.ComboBox txt_Nombre;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox txtTotalConDescuento;
        private System.Windows.Forms.TextBox txtPordescuento;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtTotalDescuento;
        private System.Windows.Forms.CheckBox chkDescuento;
        private System.Windows.Forms.TextBox txtDescuento;
        private System.Windows.Forms.TextBox txtCupon;
        private System.Windows.Forms.Label lblCupon;
        private System.Windows.Forms.Label lblTarjeta;
        private System.Windows.Forms.ComboBox CmbTarjeta;
        private System.Windows.Forms.Button btnBuscarArticulo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.DataGridView Grilla;
        private System.Windows.Forms.TextBox txtPrecio;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtCantidad;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox txt_Codigo;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtCodigo;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txt_CodigoBarra;
        private System.Windows.Forms.TextBox txt_Stock;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox CmbTipoOperacion;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.MaskedTextBox txtFecha;
        private System.Windows.Forms.RadioButton radioJugueteria;
        private System.Windows.Forms.RadioButton radioLibreria;
        private System.Windows.Forms.Button btnGrabar;
        private System.Windows.Forms.TextBox txtTotal;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
    }
}