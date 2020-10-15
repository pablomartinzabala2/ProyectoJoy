namespace SistemaFact
{
    partial class FrmCompra
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
            this.Grupo = new System.Windows.Forms.GroupBox();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.txtDescuento = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.btnGrabar = new System.Windows.Forms.Button();
            this.txtTotal = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.Grilla = new System.Windows.Forms.DataGridView();
            this.txtPrecio = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtCantidad = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.txt_Codigo = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtCodigo = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txt_CodigoBarra = new System.Windows.Forms.TextBox();
            this.txt_Stock = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txt_Nombre = new System.Windows.Forms.ComboBox();
            this.Grupo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Grilla)).BeginInit();
            this.SuspendLayout();
            // 
            // Grupo
            // 
            this.Grupo.Controls.Add(this.txt_Nombre);
            this.Grupo.Controls.Add(this.btnCancelar);
            this.Grupo.Controls.Add(this.txtDescuento);
            this.Grupo.Controls.Add(this.label7);
            this.Grupo.Controls.Add(this.btnGrabar);
            this.Grupo.Controls.Add(this.txtTotal);
            this.Grupo.Controls.Add(this.label5);
            this.Grupo.Controls.Add(this.btnEliminar);
            this.Grupo.Controls.Add(this.Grilla);
            this.Grupo.Controls.Add(this.txtPrecio);
            this.Grupo.Controls.Add(this.label3);
            this.Grupo.Controls.Add(this.txtCantidad);
            this.Grupo.Controls.Add(this.label2);
            this.Grupo.Controls.Add(this.button1);
            this.Grupo.Controls.Add(this.btnBuscar);
            this.Grupo.Controls.Add(this.txt_Codigo);
            this.Grupo.Controls.Add(this.label1);
            this.Grupo.Controls.Add(this.txtCodigo);
            this.Grupo.Controls.Add(this.label8);
            this.Grupo.Controls.Add(this.txt_CodigoBarra);
            this.Grupo.Controls.Add(this.txt_Stock);
            this.Grupo.Controls.Add(this.label6);
            this.Grupo.Controls.Add(this.label4);
            this.Grupo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Grupo.Location = new System.Drawing.Point(12, 12);
            this.Grupo.Name = "Grupo";
            this.Grupo.Size = new System.Drawing.Size(810, 486);
            this.Grupo.TabIndex = 19;
            this.Grupo.TabStop = false;
            this.Grupo.Text = "Información del artículo";
            this.Grupo.Enter += new System.EventHandler(this.Grupo_Enter);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(648, 457);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 62;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // txtDescuento
            // 
            this.txtDescuento.Location = new System.Drawing.Point(541, 91);
            this.txtDescuento.Name = "txtDescuento";
            this.txtDescuento.Size = new System.Drawing.Size(82, 23);
            this.txtDescuento.TabIndex = 61;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(459, 94);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(76, 17);
            this.label7.TabIndex = 60;
            this.label7.Text = "Descuento";
            // 
            // btnGrabar
            // 
            this.btnGrabar.Location = new System.Drawing.Point(729, 457);
            this.btnGrabar.Name = "btnGrabar";
            this.btnGrabar.Size = new System.Drawing.Size(75, 23);
            this.btnGrabar.TabIndex = 59;
            this.btnGrabar.Text = "Grabar";
            this.btnGrabar.UseVisualStyleBackColor = true;
            this.btnGrabar.Click += new System.EventHandler(this.btnGrabar_Click);
            // 
            // txtTotal
            // 
            this.txtTotal.Location = new System.Drawing.Point(735, 417);
            this.txtTotal.Name = "txtTotal";
            this.txtTotal.Size = new System.Drawing.Size(69, 23);
            this.txtTotal.TabIndex = 56;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(689, 423);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(40, 17);
            this.label5.TabIndex = 58;
            this.label5.Text = "Total";
            // 
            // btnEliminar
            // 
            this.btnEliminar.Image = global::SistemaFact.Properties.Resources.cancel;
            this.btnEliminar.Location = new System.Drawing.Point(675, 86);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(40, 28);
            this.btnEliminar.TabIndex = 57;
            this.btnEliminar.UseVisualStyleBackColor = true;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // Grilla
            // 
            this.Grilla.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Grilla.Location = new System.Drawing.Point(10, 120);
            this.Grilla.Name = "Grilla";
            this.Grilla.RowTemplate.DefaultCellStyle.BackColor = System.Drawing.Color.White;
            this.Grilla.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            this.Grilla.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.Grilla.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.White;
            this.Grilla.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.Grilla.Size = new System.Drawing.Size(794, 291);
            this.Grilla.TabIndex = 56;
            // 
            // txtPrecio
            // 
            this.txtPrecio.Location = new System.Drawing.Point(383, 91);
            this.txtPrecio.Name = "txtPrecio";
            this.txtPrecio.Size = new System.Drawing.Size(79, 23);
            this.txtPrecio.TabIndex = 55;
            this.txtPrecio.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPrecio_KeyPress);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(335, 94);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 17);
            this.label3.TabIndex = 54;
            this.label3.Text = "Precio";
            // 
            // txtCantidad
            // 
            this.txtCantidad.Location = new System.Drawing.Point(249, 91);
            this.txtCantidad.Name = "txtCantidad";
            this.txtCantidad.Size = new System.Drawing.Size(80, 23);
            this.txtCantidad.TabIndex = 53;
            this.txtCantidad.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCantidad_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(188, 94);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 17);
            this.label2.TabIndex = 52;
            this.label2.Text = "Cantidad";
            // 
            // button1
            // 
            this.button1.Image = global::SistemaFact.Properties.Resources.add;
            this.button1.Location = new System.Drawing.Point(629, 86);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(40, 28);
            this.button1.TabIndex = 51;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnBuscar
            // 
            this.btnBuscar.Location = new System.Drawing.Point(541, 22);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(40, 28);
            this.btnBuscar.TabIndex = 50;
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Visible = false;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // txt_Codigo
            // 
            this.txt_Codigo.Location = new System.Drawing.Point(108, 33);
            this.txt_Codigo.Name = "txt_Codigo";
            this.txt_Codigo.Size = new System.Drawing.Size(132, 23);
            this.txt_Codigo.TabIndex = 25;
            this.txt_Codigo.TextChanged += new System.EventHandler(this.txt_Codigo_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 17);
            this.label1.TabIndex = 24;
            this.label1.Text = "Código";
            // 
            // txtCodigo
            // 
            this.txtCodigo.Location = new System.Drawing.Point(495, 30);
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
            this.txt_CodigoBarra.TabIndex = 15;
            this.txt_CodigoBarra.TextChanged += new System.EventHandler(this.txt_CodigoBarra_TextChanged);
            // 
            // txt_Stock
            // 
            this.txt_Stock.Location = new System.Drawing.Point(108, 91);
            this.txt_Stock.Name = "txt_Stock";
            this.txt_Stock.Size = new System.Drawing.Size(74, 23);
            this.txt_Stock.TabIndex = 11;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(24, 94);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(82, 17);
            this.label6.TabIndex = 5;
            this.label6.Text = "Stock Inicial";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(20, 62);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(82, 17);
            this.label4.TabIndex = 3;
            this.label4.Text = "Descripción";
            // 
            // txt_Nombre
            // 
            this.txt_Nombre.FormattingEnabled = true;
            this.txt_Nombre.Location = new System.Drawing.Point(108, 62);
            this.txt_Nombre.Name = "txt_Nombre";
            this.txt_Nombre.Size = new System.Drawing.Size(381, 24);
            this.txt_Nombre.TabIndex = 63;
            this.txt_Nombre.SelectedValueChanged += new System.EventHandler(this.txt_Nombre_SelectedValueChanged);
            this.txt_Nombre.RightToLeftChanged += new System.EventHandler(this.txt_Nombre_RightToLeftChanged);
            // 
            // FrmCompra
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(834, 510);
            this.Controls.Add(this.Grupo);
            this.Name = "FrmCompra";
            this.Text = "Compra de artículos";
            this.Load += new System.EventHandler(this.FrmCompra_Load);
            this.Grupo.ResumeLayout(false);
            this.Grupo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Grilla)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox Grupo;
        private System.Windows.Forms.TextBox txt_Codigo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtCodigo;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txt_CodigoBarra;
        private System.Windows.Forms.TextBox txt_Stock;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtPrecio;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtCantidad;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.DataGridView Grilla;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtTotal;
        private System.Windows.Forms.Button btnGrabar;
        private System.Windows.Forms.TextBox txtDescuento;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.ComboBox txt_Nombre;
    }
}