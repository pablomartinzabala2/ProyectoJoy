namespace SistemaFact
{
    partial class FrmAbmArticulocs
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmAbmArticulocs));
            this.Grupo = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_PrecioVenta = new System.Windows.Forms.TextBox();
            this.txt_Codigo = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtCodigo = new System.Windows.Forms.TextBox();
            this.txt_Stock = new System.Windows.Forms.TextBox();
            this.txt_Nombre = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.BarraBotones = new System.Windows.Forms.ToolStrip();
            this.button1 = new System.Windows.Forms.Button();
            this.btnNuevo = new System.Windows.Forms.ToolStripButton();
            this.btnEditar = new System.Windows.Forms.ToolStripButton();
            this.btnEliminar = new System.Windows.Forms.ToolStripButton();
            this.btnAceptar = new System.Windows.Forms.ToolStripButton();
            this.btnCancelar = new System.Windows.Forms.ToolStripButton();
            this.btnAbrir = new System.Windows.Forms.ToolStripButton();
            this.btnIGregarColor = new System.Windows.Forms.ToolStripButton();
            this.btnSalir = new System.Windows.Forms.ToolStripButton();
            this.cmb_CodTipo = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.Grupo.SuspendLayout();
            this.BarraBotones.SuspendLayout();
            this.SuspendLayout();
            // 
            // Grupo
            // 
            this.Grupo.AccessibleRole = System.Windows.Forms.AccessibleRole.IpAddress;
            this.Grupo.Controls.Add(this.label3);
            this.Grupo.Controls.Add(this.cmb_CodTipo);
            this.Grupo.Controls.Add(this.button1);
            this.Grupo.Controls.Add(this.label2);
            this.Grupo.Controls.Add(this.txt_PrecioVenta);
            this.Grupo.Controls.Add(this.txt_Codigo);
            this.Grupo.Controls.Add(this.label1);
            this.Grupo.Controls.Add(this.txtCodigo);
            this.Grupo.Controls.Add(this.txt_Stock);
            this.Grupo.Controls.Add(this.txt_Nombre);
            this.Grupo.Controls.Add(this.label6);
            this.Grupo.Controls.Add(this.label4);
            this.Grupo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Grupo.Location = new System.Drawing.Point(5, 42);
            this.Grupo.Name = "Grupo";
            this.Grupo.Size = new System.Drawing.Size(619, 323);
            this.Grupo.TabIndex = 18;
            this.Grupo.TabStop = false;
            this.Grupo.Text = "Información del artículo";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(17, 118);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 17);
            this.label2.TabIndex = 27;
            this.label2.Text = "Precio Venta";
            // 
            // txt_PrecioVenta
            // 
            this.txt_PrecioVenta.Location = new System.Drawing.Point(120, 118);
            this.txt_PrecioVenta.Name = "txt_PrecioVenta";
            this.txt_PrecioVenta.Size = new System.Drawing.Size(132, 23);
            this.txt_PrecioVenta.TabIndex = 26;
            // 
            // txt_Codigo
            // 
            this.txt_Codigo.Location = new System.Drawing.Point(120, 89);
            this.txt_Codigo.Name = "txt_Codigo";
            this.txt_Codigo.Size = new System.Drawing.Size(132, 23);
            this.txt_Codigo.TabIndex = 25;
            this.txt_Codigo.TextChanged += new System.EventHandler(this.txt_Codigo_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 89);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 17);
            this.label1.TabIndex = 24;
            this.label1.Text = "Código";
            // 
            // txtCodigo
            // 
            this.txtCodigo.Location = new System.Drawing.Point(448, 78);
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.Size = new System.Drawing.Size(41, 23);
            this.txtCodigo.TabIndex = 23;
            this.txtCodigo.Visible = false;
            // 
            // txt_Stock
            // 
            this.txt_Stock.Location = new System.Drawing.Point(120, 60);
            this.txt_Stock.Name = "txt_Stock";
            this.txt_Stock.Size = new System.Drawing.Size(132, 23);
            this.txt_Stock.TabIndex = 11;
            this.txt_Stock.TextChanged += new System.EventHandler(this.txt_Stock_TextChanged);
            // 
            // txt_Nombre
            // 
            this.txt_Nombre.Location = new System.Drawing.Point(120, 31);
            this.txt_Nombre.Name = "txt_Nombre";
            this.txt_Nombre.Size = new System.Drawing.Size(482, 23);
            this.txt_Nombre.TabIndex = 9;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(17, 63);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(82, 17);
            this.label6.TabIndex = 5;
            this.label6.Text = "Stock Inicial";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(17, 31);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(82, 17);
            this.label4.TabIndex = 3;
            this.label4.Text = "Descripción";
            // 
            // BarraBotones
            // 
            this.BarraBotones.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.BarraBotones.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnNuevo,
            this.btnEditar,
            this.btnEliminar,
            this.btnAceptar,
            this.btnCancelar,
            this.btnAbrir,
            this.btnIGregarColor,
            this.btnSalir});
            this.BarraBotones.Location = new System.Drawing.Point(0, 0);
            this.BarraBotones.Name = "BarraBotones";
            this.BarraBotones.Size = new System.Drawing.Size(636, 39);
            this.BarraBotones.TabIndex = 17;
            this.BarraBotones.Text = "toolStrip1";
            this.BarraBotones.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.BarraBotones_ItemClicked);
            // 
            // button1
            // 
            this.button1.Image = global::SistemaFact.Properties.Resources.page_add1;
            this.button1.Location = new System.Drawing.Point(368, 150);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(40, 28);
            this.button1.TabIndex = 28;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnNuevo
            // 
            this.btnNuevo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnNuevo.Image = ((System.Drawing.Image)(resources.GetObject("btnNuevo.Image")));
            this.btnNuevo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Size = new System.Drawing.Size(36, 36);
            this.btnNuevo.Text = "nuevo";
            this.btnNuevo.ToolTipText = "Nuevo";
            this.btnNuevo.Click += new System.EventHandler(this.btnNuevo_Click);
            // 
            // btnEditar
            // 
            this.btnEditar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnEditar.Image = ((System.Drawing.Image)(resources.GetObject("btnEditar.Image")));
            this.btnEditar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(36, 36);
            this.btnEditar.Text = "toolStripButton2";
            this.btnEditar.ToolTipText = "Modificar";
            this.btnEditar.Click += new System.EventHandler(this.btnEditar_Click);
            // 
            // btnEliminar
            // 
            this.btnEliminar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnEliminar.Image = ((System.Drawing.Image)(resources.GetObject("btnEliminar.Image")));
            this.btnEliminar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(36, 36);
            this.btnEliminar.Text = "toolStripButton3";
            this.btnEliminar.ToolTipText = "Eliminar";
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // btnAceptar
            // 
            this.btnAceptar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnAceptar.Image = ((System.Drawing.Image)(resources.GetObject("btnAceptar.Image")));
            this.btnAceptar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(36, 36);
            this.btnAceptar.Text = "Grabar";
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnCancelar.Image = ((System.Drawing.Image)(resources.GetObject("btnCancelar.Image")));
            this.btnCancelar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(36, 36);
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnAbrir
            // 
            this.btnAbrir.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnAbrir.Image = ((System.Drawing.Image)(resources.GetObject("btnAbrir.Image")));
            this.btnAbrir.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAbrir.Name = "btnAbrir";
            this.btnAbrir.Size = new System.Drawing.Size(36, 36);
            this.btnAbrir.Text = "Abrir";
            this.btnAbrir.Click += new System.EventHandler(this.btnAbrir_Click);
            // 
            // btnIGregarColor
            // 
            this.btnIGregarColor.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnIGregarColor.Image = ((System.Drawing.Image)(resources.GetObject("btnIGregarColor.Image")));
            this.btnIGregarColor.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnIGregarColor.Name = "btnIGregarColor";
            this.btnIGregarColor.Size = new System.Drawing.Size(36, 36);
            this.btnIGregarColor.Text = "toolStripButton1";
            this.btnIGregarColor.ToolTipText = "Imprimir";
            this.btnIGregarColor.Click += new System.EventHandler(this.btnIGregarColor_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnSalir.Image = ((System.Drawing.Image)(resources.GetObject("btnSalir.Image")));
            this.btnSalir.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(36, 36);
            this.btnSalir.Text = "Salir";
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // cmb_CodTipo
            // 
            this.cmb_CodTipo.FormattingEnabled = true;
            this.cmb_CodTipo.Location = new System.Drawing.Point(120, 150);
            this.cmb_CodTipo.Name = "cmb_CodTipo";
            this.cmb_CodTipo.Size = new System.Drawing.Size(230, 24);
            this.cmb_CodTipo.TabIndex = 29;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(17, 150);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 17);
            this.label3.TabIndex = 30;
            this.label3.Text = "Categoria";
            // 
            // FrmAbmArticulocs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(636, 376);
            this.Controls.Add(this.Grupo);
            this.Controls.Add(this.BarraBotones);
            this.Name = "FrmAbmArticulocs";
            this.Text = "Formulario de Joyas";
            this.Load += new System.EventHandler(this.FrmAbmArticulocs_Load);
            this.Grupo.ResumeLayout(false);
            this.Grupo.PerformLayout();
            this.BarraBotones.ResumeLayout(false);
            this.BarraBotones.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip BarraBotones;
        private System.Windows.Forms.ToolStripButton btnNuevo;
        private System.Windows.Forms.ToolStripButton btnEditar;
        private System.Windows.Forms.ToolStripButton btnEliminar;
        private System.Windows.Forms.ToolStripButton btnAceptar;
        private System.Windows.Forms.ToolStripButton btnCancelar;
        private System.Windows.Forms.ToolStripButton btnAbrir;
        private System.Windows.Forms.ToolStripButton btnIGregarColor;
        private System.Windows.Forms.ToolStripButton btnSalir;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txt_Nombre;
        private System.Windows.Forms.TextBox txt_Stock;
        private System.Windows.Forms.TextBox txtCodigo;
        private System.Windows.Forms.GroupBox Grupo;
        private System.Windows.Forms.TextBox txt_Codigo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_PrecioVenta;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmb_CodTipo;
    }
}