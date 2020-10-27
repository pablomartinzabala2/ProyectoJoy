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
        int Indice = 0;
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
                cDetallePresupuesto det = new Clases.cDetallePresupuesto();
                DataTable trdo = det.getJoyasxPresupuesto(CodPresupuesto);
                GrillaPresupuesto.DataSource = trdo;
                string Col = "0;0;15;55;15;15";
                fun.AnchoColumnas(GrillaPresupuesto, Col);
                GetVendedor(CodPresupuesto);
            }

        }

        private void FrmVentaJoya_Load(object sender, EventArgs e)
        {
            fun = new Clases.cFunciones();
            string Col = "CodRegistro;CodJoya;Codigo;Nombre;Precio;Cantidad";
            tbVenta = fun.CrearTabla(Col);
            DateTime Fecha = DateTime.Now;
            txtFecha.Text = Fecha.ToShortDateString();
            fun.EstiloBotones(btnGrabar);  
            fun.EstiloBotones(btnCancelar);
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (GrillaPresupuesto.CurrentRow ==null)
            {
                Mensaje("Debe seleccionar un registro");
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
            Val = CodRegistro + ";" + CodJoya + ";" + Codigo;
            Val = Val + ";" + Nombre + ";" + Precio.ToString() + ";" + Cantidad.ToString();
            tbVenta = fun.AgregarFilas(tbVenta, Val);
            GrillaVentas.DataSource = tbVenta;
            string Col = "0;0;15;55;15;15";
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
            int Cantidad = 0;
            Int32 CodJoya = 0;
            Double Precio = 0;
            if (txtCodVendedor.Text !="")
            {
                CodVendedor = Convert.ToInt32(txtCodVendedor.Text);
            }
            SqlTransaction Transaccion;
            SqlConnection con = new SqlConnection(cConexion.GetConexion());
            Transaccion = con.BeginTransaction();
            con.Open();
            try
            {
                CodVenta = venta.InsertarVenta (con, Transaccion, CodVendedor, Fecha);
                for (int i = 0; i < tbVenta.Rows.Count ; i++)
                {
                    CodJoya = Convert.ToInt32(tbVenta.Rows[i]["CodJoya"]);
                    Cantidad = Convert.ToInt32(tbVenta.Rows[i]["Cantidad"]);
                    Precio = fun.ToDouble(tbVenta.Rows[i]["Cantidad"].ToString ());
                    venta.InsertarDetalleVenta(con, Transaccion, CodVenta, CodJoya, Cantidad, Precio);
                }
                Transaccion.Commit();
                con.Close();
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

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            if (GrillaPresupuesto.Rows.Count <1)
            {
                Mensaje("Debe ingresar registros para continuar");
                return;
            }
            GrabarVenta();
        }
    }
}
