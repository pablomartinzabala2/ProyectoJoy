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
    public partial class FrmVentaJoya : FormBase 
    {
        cFunciones fun;
        DataTable tbVenta;
        
        public FrmVentaJoya()
        {
            InitializeComponent();
        }

        private void btnBuscarPresupuesto_Click(object sender, EventArgs e)
        {
            FrmBuscadorPresupuesto frm = new FrmBuscadorPresupuesto();
            frm.Show();
            frm.FormClosing += new FormClosingEventHandler(form_FormClosing);
        }

        private void form_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (Principal.CodigoPrincipalAbm != null)
            {
                Int32 CodPresupuesto = Convert.ToInt32(Principal.CodigoPrincipalAbm);
                GetPresupuesto(CodPresupuesto);
            }

        }

        private void GetPresupuesto(Int32 CodPresupuesto)
        {
            cDetallePresupuesto det = new Clases.cDetallePresupuesto();
            DataTable trdo = det.getJoyasxPresupuesto(CodPresupuesto);
            GrillaPresupuesto.DataSource = trdo;
            string Col = "0;0;15;55;15;15";
            fun.AnchoColumnas(GrillaPresupuesto, Col);
            GetVendedor(CodPresupuesto);
            txtCodPresupuesto.Text = CodPresupuesto.ToString();
        }

        private void FrmVentaJoya_Load(object sender, EventArgs e)
        {
            fun = new Clases.cFunciones();
            string Col = "CodRegistro;CodJoya;Codigo;Nombre;Cantidad;Precio;Comision";
            tbVenta = fun.CrearTabla(Col);
            DateTime Fecha = DateTime.Now;
            txtFecha.Text = Fecha.ToShortDateString();
            fun.EstiloBotones(btnGrabar);  
            fun.EstiloBotones(btnCancelar);
            if (Principal.CodVenta !=null)
            {
                BuscarVenta(Convert.ToInt32(Principal.CodVenta));
            }
            
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (GrillaPresupuesto.CurrentRow ==null)
            {
                Mensaje("Debe seleccionar un registro");
                return;
            }

            if (txtPorcentajeAplicado.Text == "")
            {
                Mensaje("Debe ingresar un porcentaje a a aplicar");
                return;
            }
            string Val = "";
            string CodRegistro = GrillaPresupuesto.CurrentRow.Cells[0].Value.ToString();
            string CodJoya = GrillaPresupuesto.CurrentRow.Cells[1].Value.ToString();
            string Codigo = GrillaPresupuesto.CurrentRow.Cells[2].Value.ToString();
            string Nombre = GrillaPresupuesto.CurrentRow.Cells[3].Value.ToString();
            string Cantidad = GrillaPresupuesto.CurrentRow.Cells[4].Value.ToString();
            if (fun.Buscar (tbVenta ,"CodRegistro",CodRegistro)==true)
            {
                Mensaje("Ya se ha ingresado el registro");
                return;
            }
            Double Precio =Convert.ToDouble (GrillaPresupuesto.CurrentRow.Cells[5].Value.ToString());
            Double Por = fun.ToDouble(txtPorcentajeAplicado.Text);
            Double Comision = 0;
            Comision = Precio * Por  / 100;
            Val = CodRegistro + ";" + CodJoya + ";" + Codigo;
            Val = Val + ";" + Nombre + ";" + Cantidad.ToString() + ";" + Precio.ToString() + ";" + Comision.ToString();
            tbVenta = fun.AgregarFilas(tbVenta, Val);
            GrillaVentas.DataSource = tbVenta;
            string Col = "0;0;15;40;15;15;15";
            fun.AnchoColumnas(GrillaVentas, Col);
        }

        private void btnQuitar_Click(object sender, EventArgs e)
        {  
            if (GrillaVentas.CurrentRow == null)
            {
                Mensaje("Debe seleccionar un registro");
                return;
            }
            string CodRegistro = GrillaVentas.CurrentRow.Cells[0].Value.ToString();
            tbVenta = fun.EliminarFila(tbVenta, "Codregistro", CodRegistro); 
        }

        private void GetVendedor(Int32 CodPresupuesto)
        {
            cVendedor ven = new Clases.cVendedor();
            DataTable trdo = ven.GetVendedorxCodPresupuesto(CodPresupuesto);
            if (trdo.Rows.Count >0)
            {
                txtApellido.Text = trdo.Rows[0]["Apellido"].ToString();
                txtNombre.Text = trdo.Rows[0]["Nombre"].ToString();
                txtCodVendedor.Text = trdo.Rows[0]["CodVendedor"].ToString();
            }
        }

        private void GrabarVenta()
        {
            DateTime Fecha = Convert.ToDateTime(txtFecha.Text);
            Int32? CodVendedor = null;
            Int32 CodVenta = 0;
            cVentaJoya venta = new cVentaJoya();
            cPresupuesto prep = new cPresupuesto();
            cJoya joya = new cJoya();
            int Cantidad = 0;
            Int32 CodJoya = 0;
            Double Precio = 0;
            Double Comision = 0;
            Int32 CodRegistro = 0;
            Int32 CodPresupuesto = 0;
            if (txtCodVendedor.Text !="")
            {
                CodVendedor = Convert.ToInt32(txtCodVendedor.Text);
            }
            if (txtCodPresupuesto.Text !="")
            {
                CodPresupuesto = Convert.ToInt32(txtCodPresupuesto.Text);
            }
            SqlTransaction Transaccion;
            SqlConnection con = new SqlConnection(cConexion.GetConexion());
            con.Open();
            Transaccion = con.BeginTransaction();
           
            try
            {
                CodVenta = venta.InsertarVenta (con, Transaccion, CodVendedor, Fecha,CodPresupuesto);
                prep.ActualizarProcesado(con, Transaccion, CodPresupuesto);
                for (int i = 0; i < tbVenta.Rows.Count ; i++)
                {
                    CodRegistro = Convert.ToInt32(tbVenta.Rows[i]["CodRegistro"]);
                    CodJoya = Convert.ToInt32(tbVenta.Rows[i]["CodJoya"]);
                    Cantidad = Convert.ToInt32(tbVenta.Rows[i]["Cantidad"]);
                    Precio = fun.ToDouble(tbVenta.Rows[i]["Precio"].ToString ());
                    Comision = fun.ToDouble(tbVenta.Rows[i]["Comision"].ToString());
                    venta.InsertarDetalleVenta(con, Transaccion, CodVenta, CodJoya, Cantidad, Precio, CodRegistro, Comision);
                    joya.ActualizarStock(con, Transaccion, CodJoya, Cantidad);
                }
                Transaccion.Commit();
                con.Close();
                Mensaje("Datos grabados correctamente");
                Limpiar();
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

        private void Limpiar()
        {
            tbVenta.Clear();
            GrillaVentas.DataSource = tbVenta;
            cDetallePresupuesto det = new Clases.cDetallePresupuesto();
            DataTable trdo = det.getJoyasxPresupuesto(-1);
            GrillaPresupuesto.DataSource = trdo;
            txtCodVendedor.Text = "";
            txtApellido.Text = "";
            txtNombre.Text = "";
            txtCodPresupuesto.Text = "";
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            if (GrillaPresupuesto.Rows.Count <1)
            {
                Mensaje("Debe ingresar registros para continuar");
                return;
            }
          
            int b = 0;
            cPresupuesto prep = new cPresupuesto();
            Int32 CodPresupuesto = 0;
            if (txtCodPresupuesto.Text !="")
            {
                CodPresupuesto = Convert.ToInt32(txtCodPresupuesto.Text);
                DataTable trdo = prep.GetPresupuestoxCodigo(CodPresupuesto);
                if (trdo.Rows.Count >0)
                {
                    if (trdo.Rows[0]["Procesado"].ToString() != "1")
                        b = 1;
                }
            }
            if (b==0)
            {
                Mensaje("Ya se proceso el presupuesto");
                return;
            }
            GrabarVenta();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void txtPorcentajeAplicado_KeyPress(object sender, KeyPressEventArgs e)
        {
            fun.SoloEnteroConPunto(sender, e);
        }

        private void BuscarVenta(Int32 CodVenta)
        {  //GetPresupuesto
            cVentaJoya Venta = new Clases.cVentaJoya();
            DataTable trdo = Venta.GetVentaxCodVenta(CodVenta);
            if (trdo.Rows.Count >0)
            {
                Int32 CodPresupuesto = Convert.ToInt32(trdo.Rows[0]["CodPresupuesto"].ToString());
                GetPresupuesto(CodPresupuesto);
                txtCodVendedor.Text = trdo.Rows[0]["CodVendedor"].ToString();
                txtNombre.Text = trdo.Rows[0]["Nombre"].ToString();
                string Val = "";
                txtApellido.Text = trdo.Rows[0]["Apellido"].ToString();
                for (int i = 0; i < trdo.Rows.Count ; i++)
                {
                    string CodRegistro = trdo.Rows[i]["CodRegistro"].ToString();
                    string CodJoya = trdo.Rows[i]["CodJoya"].ToString();
                    string Codigo = trdo.Rows[i]["Codigo"].ToString();
                    string Nombre = trdo.Rows[i]["Nombre1"].ToString();
                    string Precio = trdo.Rows[i]["Precio"].ToString();
                    string Cantidad = trdo.Rows[i]["Cantidad"].ToString();
                    string Comision = trdo.Rows[i]["Comision"].ToString();
                    Val = CodRegistro + ";" + CodJoya + ";" + Codigo;
                    Val = Val + ";" + Nombre + ";" + Cantidad + ";" + Precio + ";" + Comision;
                    tbVenta = fun.AgregarFilas(tbVenta, Val);
                    GrillaVentas.DataSource = tbVenta;
                   
                }
                string Col = "0;0;15;40;15;15;15";
                fun.AnchoColumnas(GrillaVentas, Col);
            }
        }
    }
}
