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
    public partial class FrmPresupuesto : FormBase 
    {
        cFunciones fun;
        public FrmPresupuesto()
        {
            InitializeComponent();
        }

        private void FrmPresupuesto_Load(object sender, EventArgs e)
        {
            Inicializar();
        }

        private void Inicializar()
        {
            fun = new Clases.cFunciones();
            fun.LlenarCombo(cmbProvincia, "Provincia","Nombre","CodProvincia");
            fun.LlenarCombo(cmbTipo ,"Tipo","Nombre","CodTipo");
        }

        private void cmbProvincia_RightToLeftChanged(object sender, EventArgs e)
        {

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
            fun.LlenarComboDatatable(cmbCiudad, trdo, "Nombre", "CodCiudad");
        }

        private void txtNroDocumento_TextChanged(object sender, EventArgs e)
        {
            string NroDocumento = txtNroDocumento.Text;
            int b = 0;
            if (NroDocumento.Length >5)
            {
                cVendedor ven = new Clases.cVendedor();
                DataTable trdo = ven.GetVendedorxDni(NroDocumento);
                if (trdo.Rows.Count >0)
                {
                    if (trdo.Rows[0]["CodVendedor"].ToString ()!="")
                    {
                        b = 1;
                        txtCodVendedor.Text = trdo.Rows[0]["CodVendedor"].ToString();
                        txtNombre.Text = trdo.Rows[0]["CodVendedor"].ToString();
                        txtApellido.Text = trdo.Rows[0]["CodVendedor"].ToString();
                        txtDireccion.Text = trdo.Rows[0]["Direccion"].ToString();
                        txtTelefono.Text = trdo.Rows[0]["Telefono"].ToString();

                        if (trdo.Rows[0]["CodProvincia"].ToString()!="")
                        {
                            Int32 CodProv = Convert.ToInt32(trdo.Rows[0]["CodProvincia"].ToString());
                            CargarCiudadxProv(CodProv);
                            cmbProvincia.SelectedValue = CodProv.ToString();
                        }

                        if (trdo.Rows[0]["CodCiudad"].ToString() != "")
                        {
                            Int32 CodCiudad = Convert.ToInt32(trdo.Rows[0]["CodCiudad"].ToString());
                            cmbCiudad.SelectedValue = CodCiudad.ToString();

                        }



                    }
                }
            }
            if (b==0)
            {
                txtCodVendedor.Text = "";
                txtApellido.Text = "";
                txtNombre.Text = "";
                cmbProvincia.SelectedIndex = 0;
                if (cmbCiudad.Items.Count > 0)
                    cmbCiudad.SelectedIndex = 0;
                txtTelefono.Text = "";
                txtDireccion.Text = "";
            }
        }

        private void txt_Codigo_TabStopChanged(object sender, EventArgs e)
        {   
          
        }

        private void txtCodigo_TextChanged(object sender, EventArgs e)
        {
            string Codigo = txtCodigo.Text;
            int b = 0;
            if (Codigo.Length > 3)
            {
                cJoya joya = new cJoya();
                DataTable trdo = joya.GetJoyaxCodigo(Codigo);
                if (trdo.Rows.Count > 0)
                {
                    if (trdo.Rows[0]["CodJoya"].ToString() != "")
                    {
                        b = 1;  
                        txtCodJoya.Text = trdo.Rows[0]["CodJoya"].ToString();
                        txtNombreJoya.Text = trdo.Rows[0]["Nombre"].ToString();
                        txtStock.Text = trdo.Rows[0]["Stock"].ToString();

                        if (trdo.Rows[0]["CodTipo"].ToString() != "")
                        {
                            cmbTipo.SelectedValue = trdo.Rows[0]["CodTipo"].ToString();
                        }

                    }
                }
            }
            if (b == 0)
            {
                txtCodJoya.Text = "";
                txtNombreJoya.Text = "";
                txtStock.Text = "";
                if (cmbTipo.Items.Count >0)
                    cmbTipo.SelectedIndex = 0;
            }
        }
    }
}
