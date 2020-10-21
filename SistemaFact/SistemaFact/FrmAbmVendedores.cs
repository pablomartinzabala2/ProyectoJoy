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
    public partial class FrmAbmVendedores : FormBase 
    {
        cFunciones fun;
        public FrmAbmVendedores()
        {
            InitializeComponent();
        }

        private void FrmAbmVendedores_Load(object sender, EventArgs e)
        {
            fun = new Clases.cFunciones();
            Botonera(1);
            Grupo.Enabled = false;
            cProvincia prov = new Clases.cProvincia();
            DataTable trdo = prov.GetProvincias();
            fun.LlenarComboDatatable(cmbProvincia, trdo, "Nombre", "CodProvincia");
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
                case 4:
                    btnNuevo.Enabled = true;
                    btnEditar.Enabled = false;
                    btnEliminar.Enabled = false;
                    btnAceptar.Enabled = false;
                    btnCancelar.Enabled = false;
                    break;
            }


        }

        private void cmbProvincia_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbProvincia.SelectedIndex >0)
            {
                Int32 CodProvincia = Convert.ToInt32(cmbProvincia.SelectedValue);
                CargarCiudadxProv(CodProvincia);
            }       
        }
        private void CargarCiudadxProv(Int32 CodProv)
        {   
            cCiudad ciudad = new cCiudad();
            DataTable trdo = ciudad.GetCiudadxProvincia(CodProv);
            fun.LlenarComboDatatable(cmb_CodCiudad, trdo, "Nombre", "CodCiudad");
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
            if (txtCodigo.Text == "")
                fun.GuardarNuevoGenerico(this, "Vendedor");
            else
            {
                fun.ModificarGenerico(this, "Vendedor", "CodVendedor", txtCodigo.Text);

            }

            Mensaje("Datos grabados correctamente");
            Botonera(1);
            fun.LimpiarGenerico(this);
        }

        private void form_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (Principal.CodigoPrincipalAbm != null)
            {
                Botonera(3);
                txtCodigo.Text = Principal.CodigoPrincipalAbm.ToString(); 
                fun.CargarControles(this, "Vendedor", "CodVendedor", txtCodigo.Text);
                CargarCiudadProvincia(Convert.ToInt32(txtCodigo.Text));
            }

        }

        private void btnAbrir_Click(object sender, EventArgs e)
        {
            Principal.OpcionesdeBusqueda = "NroDocumento;Apellido";
            Principal.TablaPrincipal = "Vendedor";
            Principal.OpcionesColumnasGrilla = "CodVendedor;NroDocumento;Nombre;Apellido";
            Principal.ColumnasVisibles = "0;1;1;1";
            Principal.ColumnasAncho = "0;80;250;250";
            FrmBuscadorGenerico form = new FrmBuscadorGenerico();
            form.FormClosing += new FormClosingEventHandler(form_FormClosing);
            form.ShowDialog();
        }

        private void CargarCiudadProvincia(Int32 CodVendedor)
        {
            cVendedor ven = new cVendedor();
            DataTable trdo = ven.GetVendedorxCodVendedor(CodVendedor);
            if (trdo.Rows.Count > 0)
            {
                if (trdo.Rows[0]["CodVendedor"].ToString() != "")
                {
                    if (trdo.Rows[0]["CodProvincia"].ToString() != "")
                    {
                        Int32 CodProv = Convert.ToInt32(trdo.Rows[0]["CodProvincia"].ToString());
                        CargarCiudadxProv(CodProv);
                        cmbProvincia.SelectedValue = CodProv.ToString();
                    }

                    if (trdo.Rows[0]["CodCiudad"].ToString() != "")
                    {  
                        Int32 CodCiudad = Convert.ToInt32(trdo.Rows[0]["CodCiudad"].ToString());
                        cmb_CodCiudad.SelectedValue = CodCiudad.ToString();

                    }
                }
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            Botonera(2);
            Grupo.Enabled = true;
        }
    }
}
