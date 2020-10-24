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
            this.btnBuscar = new System.Windows.Forms.Button();
            this.txtCodigo = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtDescripcion = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.Grilla = new System.Windows.Forms.DataGridView();
            this.Grupo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Grilla)).BeginInit();
            this.SuspendLayout();
            // 
            // Grupo
            // 
            this.Grupo.Controls.Add(this.Grilla);
            this.Grupo.Controls.Add(this.btnBuscar);
            this.Grupo.Controls.Add(this.txtCodigo);
            this.Grupo.Controls.Add(this.label4);
            this.Grupo.Controls.Add(this.label3);
            this.Grupo.Controls.Add(this.txtDescripcion);
            this.Grupo.Controls.Add(this.label1);
            this.Grupo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Grupo.Location = new System.Drawing.Point(12, 12);
            this.Grupo.Name = "Grupo";
            this.Grupo.Size = new System.Drawing.Size(1083, 514);
            this.Grupo.TabIndex = 20;
            this.Grupo.TabStop = false;
            this.Grupo.Enter += new System.EventHandler(this.Grupo_Enter);
            // 
            // btnBuscar
            // 
            this.btnBuscar.Image = ((System.Drawing.Image)(resources.GetObject("btnBuscar.Image")));
            this.btnBuscar.Location = new System.Drawing.Point(455, 12);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(31, 26);
            this.btnBuscar.TabIndex = 80;
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // txtCodigo
            // 
            this.txtCodigo.Location = new System.Drawing.Point(319, 15);
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.Size = new System.Drawing.Size(130, 23);
            this.txtCodigo.TabIndex = 61;
            this.txtCodigo.TextChanged += new System.EventHandler(this.txtCodigo_TextChanged);
            this.txtCodigo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCodigo_KeyDown);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(261, 19);
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
            this.label3.Text = "Listado de Joyas";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
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
            this.Grilla.Location = new System.Drawing.Point(0, 69);
            this.Grilla.Name = "Grilla";
            this.Grilla.ReadOnly = true;
            this.Grilla.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.Grilla.Size = new System.Drawing.Size(1071, 439);
            this.Grilla.TabIndex = 106;
            // 
            // FrmListadoArticulo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1107, 538);
            this.Controls.Add(this.Grupo);
            this.Name = "FrmListadoArticulo";
            this.Text = "Listado de Joyas";
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
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtDescripcion;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtCodigo;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.DataGridView Grilla;
    }
}