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
using System.Data.SqlClient;
namespace SistemaFact
{
    public partial class FrmPresupuesto : FormBase 
    {
        cFunciones fun;
        DataTable tbDetalle;
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
            string Col = "CodPresupuesto;CodJoya;Nombre;Tipo;Cantidad;Precio";
            tbDetalle = fun.CrearTabla(Col);
            fun.EstiloBotones(btnGrabar);
            txtFecha.Text = DateTime.Now.ToShortDateString();
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
                        txtNombre.Text = trdo.Rows[0]["Nombre"].ToString();
                        txtApellido.Text = trdo.Rows[0]["Apellido"].ToString();
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
                        txtPrecio.Text = trdo.Rows[0]["PrecioVenta"].ToString();
                        if (trdo.Rows[0]["CodTipo"].ToString() != "")
                        {
                            cmbTipo.SelectedValue = trdo.Rows[0]["CodTipo"].ToString();
                        }
                        if (txtPrecio.Text !="")
                        {
                            txtPrecio.Text = fun.SepararDecimales(txtPrecio.Text);
                            txtPrecio.Text = fun.FormatoEnteroMiles(txtPrecio.Text);
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

        private void button2_Click(object sender, EventArgs e)
        {
            Agregar();
        }

        private void Agregar()
        {
            if (txtCodJoya.Text == "")
            {
                Mensaje("Debe ingresar una joya para continuar");
                return;
            }
            if (txtPrecio.Text == "")
            {
                Mensaje("Debe ingresar un precio para continuar");
                return;
            }
            //              string Col = "CodPresupuesto;CodJoya;Nombre;Tipo;Cantidad;Precio";
            string CodPresupuesto = "0";
            Int32 CodJoya = Convert.ToInt32(txtCodJoya.Text);
            string Nombre = txtNombreJoya.Text;
            string Precio = txtPrecio.Text;
            string Tipo = cmbTipo.Text;
            string Cantidad = "1";
            string val = CodPresupuesto + ";" + CodJoya + ";" + Nombre + ";" + Tipo;
            val = val + ";" + Cantidad + ";" + Precio;
            tbDetalle = fun.AgregarFilas(tbDetalle, val);
            Grilla.DataSource = tbDetalle;
            fun.AnchoColumnas(Grilla, "0;0;40;30;15;15");
            Double Total = fun.TotalizarColumna(tbDetalle, "Precio");
            txtTotal.Text = Total.ToString();
            txtCodigo.Text = "";
            txtCodJoya.Text = "";
            txtPrecio.Text = "";
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (Grilla.CurrentRow ==null)
            {
                Mensaje("Debe seleccionar un elelemnto");
                return;
            }
            string CodJoya = Grilla.CurrentRow.Cells[1].Value.ToString ();
            tbDetalle = fun.EliminarFila(tbDetalle, "CodJoya", CodJoya);
            Grilla.DataSource = tbDetalle;
            Double Total = fun.TotalizarColumna(tbDetalle, "Precio");
            txtTotal.Text = Total.ToString();
        }

        private void GrabarPresupuesto()
        {

            SqlTransaction Transaccion;
            SqlConnection con = new SqlConnection(cConexion.GetConexion());
            con.Open();
            Transaccion = con.BeginTransaction();
            DateTime Fecha = Convert.ToDateTime(txtFecha.Text);
            Int32? CodVendedor = null;
            string Nombre = "", Apellido = "";
            string NroDocumento = "", Telefono = "";
            string Direccion = "";
            Int32? CodCiudad = null;
            cVendedor vendedor = new cVendedor();

            Nombre = txtNombre.Text;
            Apellido = txtApellido.Text;
            Telefono = txtTelefono.Text;
            NroDocumento = txtNroDocumento.Text;
            Direccion = txtDireccion.Text;
            string Ciudad = "", Provincia = "";
            string DomicilioCompleto = "";
            if (cmbCiudad.SelectedIndex > 0)
            {
                CodCiudad = Convert.ToInt32(cmbCiudad.SelectedValue);
                Ciudad = cmbCiudad.Text;
            }
            if (cmbProvincia.SelectedIndex >0)
            {
                Provincia = cmbProvincia.Text; 
            }

            if (Direccion  != "")
                DomicilioCompleto = Direccion;
            if (Ciudad != "")
                DomicilioCompleto = DomicilioCompleto + " " + Ciudad;
            if (Provincia != "")
                DomicilioCompleto = DomicilioCompleto + " " + Provincia;

            Int32 CodPresupuesto = 0;
            Int32 CodJoya = 0;
            Double Precio = 0;
            Int32 Cantidad = 0;
           
            Double Total = 0;
            if (txtTotal.Text != "")
                Total = Convert.ToDouble(txtTotal.Text);
            
            // string Col = "CodArticulo;Nombre;Precio;Cantidad;Subtotal";
            cPresupuesto pre = new cPresupuesto();
            try
            {
               if (txtCodVendedor.Text =="")
                {
                    CodVendedor = (Int32)vendedor.InsertarVendedorTran(con, Transaccion, Apellido, Nombre, Telefono, NroDocumento, Direccion, CodCiudad, DomicilioCompleto);
                }
               else
                {
                    CodVendedor = Convert.ToInt32(txtCodVendedor.Text);
                    vendedor.ActualizarVendedor(con, Transaccion, Convert.ToInt32(CodVendedor), Apellido, Nombre, Telefono, NroDocumento, Direccion, CodCiudad, DomicilioCompleto);
                }
                
              
                CodPresupuesto = pre.InsertarPresupuesto(con, Transaccion, Total,
                    Fecha
                    , CodVendedor);

                Principal.CodigoSenia = CodPresupuesto.ToString();
                string NroPresupuesto =  GetNroPresupueto(CodPresupuesto.ToString());
                pre.ActualizarNroPresupuesto(con, Transaccion, CodPresupuesto, NroPresupuesto);
                for (int i = 0; i < tbDetalle.Rows.Count; i++)
                {
                    CodJoya = Convert.ToInt32(tbDetalle.Rows[i]["CodJoya"].ToString());
                    Precio = Convert.ToDouble(tbDetalle.Rows[i]["Precio"].ToString());
                    Cantidad = Convert.ToInt32(tbDetalle.Rows[i]["Cantidad"].ToString());
                    pre.InsertarDetalle(con, Transaccion, CodPresupuesto, Cantidad, Precio, CodJoya);

                }
                Transaccion.Commit();
                con.Close();
                Mensaje("Datos grabados correctamente");
                Principal.CodigoPrincipalAbm = CodPresupuesto.ToString();
                FrmVerReportePresupuesto frm = new FrmVerReportePresupuesto();
                frm.Show();
                Limpiar();
               // FrmReporte frm = new SistemaFact.FrmReporte();
               // frm.Show();
                // this.GetJugadorxCodigoTableAdapter.Fill(this.DataSet1.GetJugadorxCodigo, Codigo); 

            }
            catch (Exception exa)
            {
                MessageBox.Show(exa.Message.ToString());
                Transaccion.Rollback();
                con.Close();
                Mensaje("Hubo un error en el proceso de grabacion");
                Mensaje(exa.Message);

            }
        }

        public string GetNroPresupueto(string CodPresupuesto)
        {
            string Numero = "";
            int Can = CodPresupuesto.Length;
            switch (Can)
            {
                case 1:
                    Numero = "0000000" + CodPresupuesto.ToString();
                    break;
                case 2:
                    Numero = "000000" + CodPresupuesto.ToString();
                    break;
                case 3:
                    Numero = "00000" + CodPresupuesto.ToString();
                    break;
                case 4:
                    Numero = "0000" + CodPresupuesto.ToString();
                    break;
                case 5:
                    Numero = "000" + CodPresupuesto.ToString();
                    break;
                case 6:
                    Numero = "00" + CodPresupuesto.ToString();
                    break;
                case 7:
                    Numero = "0" + CodPresupuesto.ToString();
                    break;
            }
            return Numero;
        }

        private void Limpiar ()
        {
            txtCodVendedor.Text = "";
            txtApellido.Text = "";
            txtNombre.Text = "";
            cmbProvincia.SelectedIndex = 0;
            if (cmbCiudad.Items.Count > 0)
                cmbCiudad.SelectedIndex = 0;
            txtTelefono.Text = "";
            txtDireccion.Text = "";
            txtNroDocumento.Text = "";
            txtCodJoya.Text = "";
            tbDetalle.Clear();
            Grilla.DataSource = tbDetalle;
            txtTotal.Text = "";
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            if (txtNombre.Text =="")
            {
                Mensaje("Debe ingresar un nombre");
                return;
            }
             
            if (txtApellido.Text == "")
            {
                Mensaje("Debe ingresar un apellido");
                return;
            }
            if (tbDetalle.Rows.Count ==0)
            {
                Mensaje("Debe ingresar productos para continuar");
                return;
            }
            GrabarPresupuesto();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
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
        private void form_FormClosing(object sender, FormClosingEventArgs e)
        {
            cVendedor ven = new cVendedor();
            if (Principal.CodigoPrincipalAbm != null)
            {
                Int32 CodVendedor = Convert.ToInt32(Principal.CodigoPrincipalAbm);
                DataTable trdo = ven.GetVendedorxCodVendedor(CodVendedor);
                if (trdo.Rows.Count >0)
                {
                    if (trdo.Rows.Count > 0)
                    {
                        if (trdo.Rows[0]["CodVendedor"].ToString() != "")
                        {
                            txtNroDocumento.Text  = trdo.Rows[0]["NroDocumento"].ToString();
                            txtCodVendedor.Text = trdo.Rows[0]["CodVendedor"].ToString();
                            txtNombre.Text = trdo.Rows[0]["Nombre"].ToString();
                            txtApellido.Text = trdo.Rows[0]["Apellido"].ToString();
                            txtDireccion.Text = trdo.Rows[0]["Direccion"].ToString();
                            txtTelefono.Text = trdo.Rows[0]["Telefono"].ToString();

                            if (trdo.Rows[0]["CodProvincia"].ToString() != "")
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
            }

        }

        private void txtCodigo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                Agregar();
            }
        }

        private void btnBuscarArticulo_Click(object sender, EventArgs e)
        {
            Principal.CodigoPrincipalAbm = "6";
            FrmVerReportePresupuesto frm = new FrmVerReportePresupuesto();
            frm.Show();
        }
    }
}
