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
    public partial class FrmCompra : FormBase
    {
        cFunciones fun;
        DataTable tbCompra;
        Boolean PuedeAgregar;
        public FrmCompra()
        {
            InitializeComponent();
        }

        private void FrmCompra_Load(object sender, EventArgs e)
        {
            fun = new Clases.cFunciones();
            string Col = "CodArticulo;Nombre;Cantidad;Precio;Descuento;Subtotal";
            tbCompra = fun.CrearTabla(Col);
            LlenarComboArticulo();
            // (2x +4)/10 =4 
            

        }

        private void txt_Codigo_TextChanged(object sender, EventArgs e)
        {
            if (txt_Codigo.Text.Length <3)
            {
                txt_Nombre.Text = "";
                txt_CodigoBarra.Text = "";
               // txt_Codigo.Text = "";
                txt_Stock.Text = "";
                return;
            }
            string Codigo = txt_Codigo.Text;
            cArticulo art = new cArticulo();
            DataTable trdo = art.GetArticulo("", "", Codigo);
            if (trdo.Rows.Count > 0)
            {
                if (trdo.Rows[0]["CodArticulo"].ToString() != "")
                {
                    txtCodigo.Text = trdo.Rows[0]["CodArticulo"].ToString();
                    txt_Nombre.Text = trdo.Rows[0]["Nombre"].ToString();
                    txt_CodigoBarra.Text = trdo.Rows[0]["CodigoBarra"].ToString();
                    // txt_Codigo.Text = trdo.Rows[0]["Codigo"].ToString();
                    txt_Stock.Text = trdo.Rows[0]["Stock"].ToString();
                }
                else
                {
                    txt_Nombre.Text = "";
                    txt_CodigoBarra.Text = "";
                    txt_Stock.Text = "";
                }
            }
            else
            {
                txt_Nombre.Text = "";
                txt_CodigoBarra.Text = "";
                txt_Stock.Text = "";
            }

        }

        private void txt_CodigoBarra_TextChanged(object sender, EventArgs e)
        {
            int b = 0;
            if (txt_CodigoBarra.Text.Length >7)
            {
                string CodigoBarra = txt_CodigoBarra.Text;
                cArticulo art = new cArticulo();
                DataTable trdo = art.GetArticulo("", CodigoBarra, "");
                if (trdo.Rows.Count > 0)
                    if (trdo.Rows[0]["CodArticulo"].ToString() != "")
                    {
                        b = 1;
                        txtCodigo.Text = trdo.Rows[0]["CodArticulo"].ToString();
                        txt_Nombre.SelectedValue = txtCodigo.Text;
                        txt_CodigoBarra.Text = trdo.Rows[0]["CodigoBarra"].ToString();
                        txt_Codigo.Text = trdo.Rows[0]["Codigo"].ToString();
                        txt_Stock.Text = trdo.Rows[0]["Stock"].ToString();
                    }
                if (b==1)
                {
                    PuedeAgregar = false;
                    txtCantidad.Text = "1";
                    txtCantidad.Focus();
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Agregar();
        }

        private void Agregar()
        {
            if (txtCodigo.Text == "")
            {
                Mensaje("Debe ingresar un articulo");
                return;
            }
            if (txtCantidad.Text == "")
            {
                Mensaje("Debe ingresar una cantidad");
                return;
            }

            if (txtPrecio.Text == "")
            {
                Mensaje("Debe ingresar un precio");
                return;
            }

            string Codigo = txtCodigo.Text;
            if (fun.Buscar(tbCompra, "CodArticulo", Codigo) == true)
            {
                Mensaje("Ya se ha ingresado el articulo");
                return;
            }
            string Nombre = txt_Nombre.Text;
            Int32 Cantidad = Convert.ToInt32(txtCantidad.Text);
            Double Precio = fun.ToDouble(txtPrecio.Text);
            Double Descuento = 0;
            if (txtDescuento.Text != "")
                Descuento = fun.ToDouble(txtDescuento.Text);
            Double SubTotal = Cantidad * Precio - Descuento;
            string Val = Codigo + ";" + Nombre;
            Val = Val + ";" + Cantidad.ToString();
            Val = Val + ";" + Precio.ToString();
            Val = Val + ";" + Descuento.ToString();
            Val = Val + ";" + SubTotal;
            tbCompra = fun.AgregarFilas(tbCompra, Val);
            Grilla.DataSource = tbCompra;
            CalcularTotal();
            LimpiarArticulo();
            fun.AnchoColumnas(Grilla, "0;40;15;15;15;15");
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (Grilla.CurrentRow ==null)
            {
                Mensaje("Debe seleccionar una fila");
                return;
            }
            string Codigo = Grilla.CurrentRow.Cells[0].Value.ToString();
            tbCompra = fun.EliminarFila(tbCompra , "CodArticulo", Codigo);
            Grilla.DataSource = tbCompra;
            CalcularTotal();
        }

        private void Grupo_Enter(object sender, EventArgs e)
        {

        }

        private void CalcularTotal()
        {
           double Total = fun.TotalizarColumna(tbCompra, "Subtotal");
            txtTotal.Text = Total.ToString();
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            SqlTransaction Transaccion;
            SqlConnection con = new SqlConnection(cConexion.GetConexion());
            con.Open();
            Transaccion = con.BeginTransaction();
            try
            {
                Int32 CodCompra = GrabarCompra(con, Transaccion);
                GrabarDetalleCompra(con, Transaccion, CodCompra);
                Transaccion.Commit();
                con.Close();
                Mensaje("Datos grabados Correctamente");
                LimpiarGrilla();
                
            }
            catch (Exception exa)
            {
                Transaccion.Rollback();
                con.Close();
                Mensaje("Hubo un error en el proceso de grabacion");
                Mensaje(exa.Message);
                
            }
        }

        public Int32 GrabarCompra(SqlConnection con, SqlTransaction Transaccion)
        {
            DateTime Fecha = DateTime.Now;
            cCompra compra = new Clases.cCompra();
            Double Total = fun.ToDouble(txtTotal.Text);
            return compra.GrabarCompra(con, Transaccion, Fecha,Total);
        }

        public void GrabarDetalleCompra(SqlConnection con, SqlTransaction Transaccion,Int32 CodCompra)
        {
            Int32 CodArticulo = 0;
            int Cantidad = 0;
            Double Costo = 0;
            Double Descueneto = 0;
            Double Subtotal = 0;
            cArticulo objArt = new cArticulo();
            cDetalleCompra detalle = new cDetalleCompra();
            cArticulo art = new cArticulo();
            //string Col = "CodArticulo;Nombre;Cantidad;Precio;Descuento;Subtotal";
            for (int i=0;i< tbCompra.Rows.Count;i++)
            {
                CodArticulo = Convert.ToInt32(tbCompra.Rows[i]["CodArticulo"].ToString());
                Cantidad = Convert.ToInt32(tbCompra.Rows[i]["Cantidad"].ToString());
                art.ActualizarStock(con, Transaccion, CodArticulo, Cantidad);
                Costo = fun.ToDouble(tbCompra.Rows[i]["Precio"].ToString());
                Descueneto = fun.ToDouble(tbCompra.Rows[i]["Descuento"].ToString());
                Subtotal = fun.ToDouble (tbCompra.Rows[i]["Subtotal"].ToString());
                detalle.Insertar(con, Transaccion, CodCompra, CodArticulo, Cantidad, Costo, Descueneto, Subtotal);
               
            }
        }

        private void LimpiarArticulo()
        {
            txtCodigo.Text = "";
            txt_Codigo.Text = "";
            txt_CodigoBarra.Text = "";
            txt_Nombre.SelectedIndex = -1;
            txtCantidad.Text = "";
            txt_Stock.Text = "";
            txtPrecio.Text = "";
            
        }

        private void LimpiarGrilla()
        {
            tbCompra.Clear();
            Grilla.DataSource = tbCompra;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            LimpiarArticulo();
            LimpiarGrilla();
        }

        private void BuscarCompra(Int32 CodCompra)
        {
            cDetalleCompra det = new cDetalleCompra();
            DataTable trdo = det.GetDetallexId(CodCompra);
            string Val = "";
            // string Col = "CodArticulo;Nombre;Cantidad;Precio;Descuento;Subtotal";
           if (trdo.Rows.Count >0)
            {      

                string CodArt = trdo.Rows[0]["CodArticulo"].ToString();
                string Nombre = trdo.Rows[0]["Nombre"].ToString();
                string Cantidad = trdo.Rows[0]["Cantidad"].ToString();
                string Precio = trdo.Rows[0]["Costo"].ToString();
                string Descuento = trdo.Rows[0]["Descuento"].ToString();
                string Subtotal = trdo.Rows[0]["Subtotal"].ToString();

                Val = CodArt + ";" + Nombre;
                Val = Val + ";" + Cantidad.ToString();
                Val = Val + ";" + Precio.ToString();
                Val = Val + ";" + Descuento.ToString();
                Val = Val + ";" + Subtotal.ToString();
                tbCompra = fun.AgregarFilas(tbCompra, Val);
                Grilla.DataSource = tbCompra;
                CalcularTotal();
            }
        }

        private void txtCantidad_KeyPress(object sender, KeyPressEventArgs e)
        {  
            if (PuedeAgregar == false)
            {
                PuedeAgregar = true;
                return;
            }
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                Agregar();
            }
                
        }

        private void LlenarComboArticulo()
        {
            cFunciones fun = new cFunciones();
            cArticulo art = new cArticulo();
            DataTable trdo = art.GetTodosArticulos();
            txt_Nombre.DataSource = trdo;
            txt_Nombre.ValueMember = "CodArticulo";
            txt_Nombre.DisplayMember = "Nombre";
            AutoCompleteStringCollection coleccion = new AutoCompleteStringCollection();
            foreach (DataRow r in trdo.Rows)
            {
                coleccion.Add(r["Nombre"].ToString());
            }
            txt_Nombre.AutoCompleteCustomSource = coleccion;
            txt_Nombre.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            txt_Nombre.AutoCompleteSource = AutoCompleteSource.CustomSource;
            txt_Nombre.SelectedIndex = -1;

        }

        private void txtPrecio_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                Agregar();
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {

        }

        private void txt_Nombre_RightToLeftChanged(object sender, EventArgs e)
        {
           
        }

        private void txt_Nombre_SelectedValueChanged(object sender, EventArgs e)
        {
            int b = 0;
            if (txt_Nombre.SelectedIndex > 0)
            {
                Int32 CodArt = Convert.ToInt32(txt_Nombre.SelectedValue);
                cArticulo art = new Clases.cArticulo();
                DataTable trdo = art.GetArticuloxCodArt(CodArt);
                if (trdo.Rows.Count > 0)
                    if (trdo.Rows[0]["CodArticulo"].ToString() != "")
                    {
                        b = 1;
                        txtCodigo.Text = trdo.Rows[0]["CodArticulo"].ToString();
                        txt_Nombre.SelectedValue = txtCodigo.Text;
                        txt_CodigoBarra.Text = trdo.Rows[0]["CodigoBarra"].ToString();
                        txt_Codigo.Text = trdo.Rows[0]["Codigo"].ToString();
                        txt_Stock.Text = trdo.Rows[0]["Stock"].ToString();
                    }
                if (b == 1)
                {
                    PuedeAgregar = false;
                    txtCantidad.Text = "1";
                    txtCantidad.Focus();
                }
            }
        }
    }
}
