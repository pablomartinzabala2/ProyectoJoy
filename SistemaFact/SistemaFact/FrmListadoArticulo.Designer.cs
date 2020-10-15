namespace SistemaFact
{
    partial class FrmListadoArticulo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmListadoArticulo));
            this.Grupo = new System.Windows.Forms.GroupBox();
            this.chkLibreria = new System.Windows.Forms.CheckBox();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.txtCodigo = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtCodigoBarra = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtDescripcion = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.Grilla = new System.Windows.Forms.DataGridView();
            this.label5 = new System.Windows.Forms.Label();
            this.cmbMarca = new System.Windows.Forms.ComboBox();
            this.Grupo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Grilla)).BeginInit();
            this.SuspendLayout();
            // 
            // Grupo
            // 
            this.Grupo.Controls.Add(this.cmbMarca);
            this.Grupo.Controls.Add(this.label5);
            this.Grupo.Controls.Add(this.chkLibreria);
            this.Grupo.Controls.Add(this.btnBuscar);
            this.Grupo.Controls.Add(this.txtCodigo);
            this.Grupo.Controls.Add(this.label4);
            this.Grupo.Controls.Add(this.label3);
            this.Grupo.Controls.Add(this.txtCodigoBarra);
            this.Grupo.Controls.Add(this.label2);
            this.Grupo.Controls.Add(this.txtDescripcion);
            this.Grupo.Controls.Add(this.label1);
            this.Grupo.Controls.Add(this.Grilla);
            this.Grupo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Grupo.Location = new System.Drawing.Point(12, 12);
            this.Grupo.Name = "Grupo";
            this.Grupo.Size = new System.Drawing.Size(1083, 514);
            this.Grupo.TabIndex = 20;
            this.Grupo.TabStop = false;
            this.Grupo.Enter += new System.EventHandler(this.Grupo_Enter);
            // 
            // chkLibreria
            // 
            this.chkLibreria.AutoSize = true;
            this.chkLibreria.Checked = true;
            this.chkLibreria.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkLibreria.Location = new System.Drawing.Point(961, 10);
            this.chkLibreria.Name = "chkLibreria";
            this.chkLibreria.Size = new System.Drawing.Size(75, 21);
            this.chkLibreria.TabIndex = 81;
            this.chkLibreria.Text = "Libreria";
            this.chkLibreria.UseVisualStyleBackColor = true;
            // 
            // btnBuscar
            // 
            this.btnBuscar.Image = ((System.Drawing.Image)(resources.GetObject("btnBuscar.Image")));
            this.btnBuscar.Location = new System.Drawing.Point(924, 10);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(31, 26);
            this.btnBuscar.TabIndex = 80;
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // txtCodigo
            // 
            this.txtCodigo.Location = new System.Drawing.Point(597, 12);
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.Size = new System.Drawing.Size(130, 23);
            this.txtCodigo.TabIndex = 61;
            this.txtCodigo.TextChanged += new System.EventHandler(this.txtCodigo_TextChanged);
            this.txtCodigo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCodigo_KeyDown);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(539, 18);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(52, 17);
            this.label4.TabIndex = 60;
            this.label4.Text = "Código";
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.MediumPurple;
            this.label3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(0, 41);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(1071, 25);
            this.label3.TabIndex = 59;
            this.label3.Text = "Listado de Artículos";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtCodigoBarra
            // 
            this.txtCodigoBarra.Location = new System.Drawing.Point(358, 15);
            this.txtCodigoBarra.Name = "txtCodigoBarra";
            this.txtCodigoBarra.Size = new System.Drawing.Size(175, 23);
            this.txtCodigoBarra.TabIndex = 4;
            this.txtCodigoBarra.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            this.txtCodigoBarra.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCodigoBarra_KeyDown);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(261, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(91, 17);
            this.label2.TabIndex = 3;
            this.label2.Text = "Codigo Barra";
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.CausesValidation = false;
            this.txtDescripcion.Location = new System.Drawing.Point(80, 15);
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.Size = new System.Drawing.Size(175, 23);
            this.txtDescripcion.TabIndex = 2;
            this.txtDescripcion.TextChanged += new System.EventHandler(this.txtDescripcion_TextChanged);
            this.txtDescripcion.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtDescripcion_KeyDown);
            this.txtDescripcion.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDescripcion_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(0, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Descripción";
            // 
            // Grilla
            // 
            this.Grilla.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Grilla.Location = new System.Drawing.Point(0, 70);
            this.Grilla.Name = "Grilla";
            this.Grilla.RowTemplate.DefaultCellStyle.BackColor = System.Drawing.Color.White;
            this.Grilla.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            this.Grilla.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.Grilla.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.White;
            this.Grilla.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.Grilla.Size = new System.Drawing.Size(1077, 438);
            this.Grilla.TabIndex = 0;
            this.Grilla.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.Grilla_CellContentClick);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(733, 15);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(47, 17);
            this.label5.TabIndex = 82;
            this.label5.Text = "Marca";
            // 
            // cmbMarca
            // 
            this.cmbMarca.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMarca.FormattingEnabled = true;
            this.cmbMarca.Location = new System.Drawing.Point(795, 10);
            this.cmbMarca.Name = "cmbMarca";
            this.cmbMarca.Size = new System.Drawing.Size(121, 24);
            this.cmbMarca.TabIndex = 83;
            // 
            // FrmListadoArticulo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1107, 538);
            this.Controls.Add(this.Grupo);
            this.Name = "FrmListadoArticulo";
            this.Text = "Listado de artículos";
            this.Load += new System.EventHandler(this.FrmListadoArticulo_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmListadoArticulo_KeyDown);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.FrmListadoArticulo_KeyPress);
            this.Grupo.ResumeLayout(false);
            this.Grupo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Grilla)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox Grupo;
        private System.Windows.Forms.DataGridView Grilla;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtCodigoBarra;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtDescripcion;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtCodigo;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.CheckBox chkLibreria;
        private System.Windows.Forms.ComboBox cmbMarca;
        private System.Windows.Forms.Label label5;
    }
}