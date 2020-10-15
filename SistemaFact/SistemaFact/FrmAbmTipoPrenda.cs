using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SistemaFact.Clases;

namespace SistemaFact
{
    public partial class FrmAbmTipoPrenda : FormBase
    {
        public FrmAbmTipoPrenda()
        {
            InitializeComponent();
        }

        private void FrmAbmTipoPrenda_Load(object sender, EventArgs e)
        {
            Botonera(1);
            Grupo.Enabled = false;
        }

        private void Botonera(int Jugada)
        {
            switch (Jugada)
            {
                //estado inicial
                case 1:
                    btnNuevo.Enabled = true;
                    btnEditar.Enabled = false;
                    btnEliminar.Enabled = false;
                    btnAceptar.Enabled = false;
                    btnCancelar.Enabled = false;
                    break;
                case 2:
                    btnNuevo.Enabled = false;
                    btnEditar.Enabled = false;
                    btnEliminar.Enabled = true;
                    btnAceptar.Enabled = true;
                    btnCancelar.Enabled = true;
                    break;
                case 3:
                    //viene del buscador
                    btnNuevo.Enabled = true;
                    btnEditar.Enabled = true;
                    btnEliminar.Enabled = true;
                    btnAceptar.Enabled = false;
                    btnCancelar.Enabled = false;
                    break;
            }


        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            Botonera(2);
            Grupo.Enabled = true;
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (txt_Nombre.Text =="")
            {
                Mensaje("Debe ingresar una descripción");
                return;
            }
            Clases.cFunciones fun = new Clases.cFunciones();
            if (txtCodigo.Text == "")
                fun.GuardarNuevoGenerico(this, "TipoPrenda");
            else
                fun.ModificarGenerico(this, "TipoPrenda", "CodTipoPrenda", txtCodigo.Text);
            Mensaje("Datos grabados correctamente");
            txtCodigo.Text = "";
            txt_Nombre.Text = "";
        }

        private void btnAbrir_Click(object sender, EventArgs e)
        {
            Principal.OpcionesdeBusqueda = "Nombre";
            Principal.TablaPrincipal = "TipoPrenda";
            Principal.OpcionesColumnasGrilla = "CodTipoPrenda;Nombre";
            Principal.ColumnasVisibles = "0;1";
            Principal.ColumnasAncho = "0;580";
            FrmBuscadorGenerico form = new FrmBuscadorGenerico();
            form.FormClosing += new FormClosingEventHandler(form_FormClosing);
            form.ShowDialog();
        }

        private void form_FormClosing(object sender, FormClosingEventArgs e)
        {            
            if (Principal.CodigoPrincipalAbm != null)
            {
                Botonera(3);
                txtCodigo.Text = Principal.CodigoPrincipalAbm.ToString();
                cFunciones fun = new Clases.cFunciones();
                fun.CargarControles(this, "TipoPrenda", "CodTipoPrenda", txtCodigo.Text);                
            }

        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            Botonera(2);
            Grupo.Enabled = true;
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            cFunciones fun = new Clases.cFunciones();
            txtCodigo.Text = "";
            txt_Nombre.Text = "";
            Botonera(1);
            Grupo.Enabled = false;
            fun.LimpiarGenerico(this);
        }
    }
}
