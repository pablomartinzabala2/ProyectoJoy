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
    public partial class FrmAbmTarjeta : FormBase 
    {
        public FrmAbmTarjeta()
        {
            InitializeComponent();
        }

        private void FrmAbmTarjeta_Load(object sender, EventArgs e)
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

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            Botonera(2);
            Grupo.Enabled = true;
            Clases.cFunciones fun = new Clases.cFunciones();
            fun.LimpiarGenerico(this);
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            Clases.cFunciones fun = new Clases.cFunciones();
            if (txt_Nombre.Text =="")
            {
                Mensaje("Debe ingresar una tarjeta");
                return;
            }
            if (txtCodigo.Text == "")
                fun.GuardarNuevoGenerico(this, "Tarjeta");
            else
            {
                // if (txt_Ruta.Text != "")
                //   txt_Ruta.Text = txt_Ruta.Text.Replace("\\", "\\\\");
                fun.ModificarGenerico(this, "Tarjeta", "CodTarjeta", txtCodigo.Text);

            }
            Mensaje("Datos grabados correctamente");
            Botonera(1);
            fun.LimpiarGenerico(this);
            txtCodigo.Text = "";
            Grupo.Enabled = false;
        }

        private void btnAbrir_Click(object sender, EventArgs e)
        {
            Principal.OpcionesdeBusqueda = "Nombre";
            Principal.TablaPrincipal = "Tarjeta";
            Principal.OpcionesColumnasGrilla = "CodTarjeta;Nombre";
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
                fun.CargarControles(this, "Tarjeta", "CodTarjeta", txtCodigo.Text);
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
