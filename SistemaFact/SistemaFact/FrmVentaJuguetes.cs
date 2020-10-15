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
    public partial class FrmVentaJuguetes : FormBase
    {
        Boolean PuedeAgregar = false;
        Boolean Cargando = true;
        int Indice = 0;
        DataTable tbVenta;
        cFunciones fun;
        public FrmVentaJuguetes()
        {
            InitializeComponent();
        }

        private void txt_CodigoBarra_TextChanged(object sender, EventArgs e)
        {
            int b = 0;
            int Operacion = 0;
            if (CmbTipoOperacion.SelectedIndex > 0)
                Operacion = Convert.ToInt32(CmbTipoOperacion.SelectedValue);
            if (txt_CodigoBarra.Text.Length < 5)
            {
                return;
            }
            string Codigo = txt_CodigoBarra.Text;
            cArticulo art = new cArticulo();
            cJuguete jug = new cJuguete();
            if (radioJugueteria.Checked ==true)
            {
                DataTable trdo = jug.GetArticulo("", Codigo, "");
                if (trdo.Rows.Count > 0)
                {
                    b = 1;
                    txtCodigo.Text = trdo.Rows[0]["CodArticulo"].ToString();
                    txt_Nombre.SelectedValue = trdo.Rows[0]["CodArticulo"].ToString();
                    txt_CodigoBarra.Text = trdo.Rows[0]["CodigoBarra"].ToString();
                    txt_Nombre.Text = trdo.Rows[0]["Nombre"].ToString();
                    txt_Stock.Text = trdo.Rows[0]["Stock"].ToString();


                    if (Operacion == 1)
                        txtPrecio.Text = trdo.Rows[0]["PrecioEfectivo"].ToString();
                    if (Operacion == 2)
                    {
                        txtPrecio.Text = trdo.Rows[0]["PrecioTarjeta"].ToString();
                        Double Precio = Convert.ToDouble(trdo.Rows[0]["PrecioTarjeta"].ToString());
                        Precio = Precio - 0.10 * Precio;
                        txtDescuento.Text = Precio.ToString();
                    }

                    if (Operacion == 3)
                        txtPrecio.Text = trdo.Rows[0]["PrecioEfectivo"].ToString();

                    if (txtPrecio.Text != "")
                    {
                        Double Precio = Convert.ToDouble(txtPrecio.Text);
                        Precio = Math.Round(Precio, 0);
                        txtPrecio.Text = Precio.ToString();
                    }

                    if (txtDescuento.Text != "")
                    {
                        Double Precio = Convert.ToDouble(txtDescuento.Text);
                        Precio = Math.Round(Precio, 0);
                        txtDescuento.Text = Precio.ToString();
                    }

                    if (b == 1)
                    {
                        PuedeAgregar = false;
                        txtCantidad.Focus();
                    }

                }
            }
               
            if (radioLibreria.Checked == true)
            {  
                DataTable trdo = art.GetArticulo("", Codigo, "");
                if (trdo.Rows.Count > 0)
                {
                    b = 1;
                    txtCodigo.Text = trdo.Rows[0]["CodArticulo"].ToString();
                    txt_Nombre.SelectedValue = trdo.Rows[0]["CodArticulo"].ToString();
                    txt_CodigoBarra.Text = trdo.Rows[0]["CodigoBarra"].ToString();
                    txt_Nombre.Text = trdo.Rows[0]["Nombre"].ToString();
                    txt_Stock.Text = trdo.Rows[0]["Stock"].ToString();


                    if (Operacion == 1)
                        txtPrecio.Text = trdo.Rows[0]["PrecioEfectivo"].ToString();
                    if (Operacion == 2)
                    {
                        txtPrecio.Text = trdo.Rows[0]["PrecioTarjeta"].ToString();
                        Double Precio = Convert.ToDouble(trdo.Rows[0]["PrecioTarjeta"].ToString());
                        Precio = Precio - 0.10 * Precio;
                        txtDescuento.Text = Precio.ToString();
                    }

                    if (Operacion == 3)
                        txtPrecio.Text = trdo.Rows[0]["PrecioEfectivo"].ToString();

                    if (txtPrecio.Text != "")
                    {
                        Double Precio = Convert.ToDouble(txtPrecio.Text);
                        Precio = Math.Round(Precio, 0);
                        txtPrecio.Text = Precio.ToString();
                    }

                    if (txtDescuento.Text != "")
                    {
                        Double Precio = Convert.ToDouble(txtDescuento.Text);
                        Precio = Math.Round(Precio, 0);
                        txtDescuento.Text = Precio.ToString();
                    }

                    if (b == 1)
                    {
                        PuedeAgregar = false;
                        txtCantidad.Focus();
                    }

                }
            }

        }

        private void CargarTipoOperacion()
        {
            cTipoOperacion tipo = new cTipoOperacion();
            DataTable tb = tipo.GetTipos();
            fun.LlenarComboDatatable(CmbTipoOperacion, tb, "Nombre", "Codigo");
            CmbTipoOperacion.SelectedIndex = 1;
        }

        private void FrmVentaJuguetes_Load(object sender, EventArgs e)
        {
            Inicializar();
        }

        private void Inicializar()
        {
            DateTime Fecha = DateTime.Now;
            txtFecha.Text = Fecha.ToShortDateString();
            fun = new Clases.cFunciones();
            CargarTipoOperacion();
            string Col = "CodArticulo;Nombre;Precio;Cantidad;Subtotal;Indice;Libreria";
            tbVenta = fun.CrearTabla(Col);
            LlenarComboArticulo();
            Cargando = false;
        }

        private void txtCantidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (PuedeAgregar == false)
            {
                if (txtCodigo.Text != "")
                {
                    txt_Nombre.SelectedValue = txtCodigo.Text;
                }
                PuedeAgregar = true;
                return;
            }

         

            if (txtCodigo.Text == "")
            {
                Mensaje("Debe ingresar un articulo");
                return;
            }

            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                if (txtCodigo.Text == "")
                {
                    Mensaje("Debe ingresar un articulo");
                    return;
                }
                if (txtCantidad.Text == "")
                {
                    txtCantidad.Text = "1";
                }
                Agregar();
            }
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
            Boolean Des = false;
            if (chkDescuento.Visible == true)
                if (chkDescuento.Checked == true)
                    Des = true;
            //string Col = "CodArticulo;Nombre;Precio;Cantidad;Subtotal";
            Int32 CodArticulo = Convert.ToInt32(txtCodigo.Text);
            int Cantidad = Convert.ToInt32(txtCantidad.Text);
            Double Precio = 0;
            if (Des == false)
                Precio = Convert.ToDouble(txtPrecio.Text);
            if (Des == true)
                Precio = Convert.ToDouble(txtDescuento.Text);
            Double Subtotal = Precio * Cantidad;
            string Nombre = txt_Nombre.Text;

            if (fun.Buscar(tbVenta, "CodArticulo", CodArticulo.ToString()) == true)
            {
                Mensaje("Ya se ha ingresado el articulo");
                return;
            }
            int Libreria = 1;
            if (radioJugueteria.Checked == true)
                Libreria = 0;

            string Val = CodArticulo + ";" + Nombre;
            Val = Val + ";" + Precio.ToString();
            Val = Val + ";" + Cantidad.ToString();
            Val = Val + ";" + Subtotal.ToString();
            Val = Val + ";" + Indice.ToString();
            Val = Val + ";" + Libreria;

            tbVenta = fun.AgregarFilas(tbVenta, Val);
            Indice = Indice + 1;
            //Grilla.Sort(Grilla.Columns[3]), ListSortDirection.Ascending)
            if (tbVenta.Rows.Count > 1)
                Grilla.Sort(Grilla.Columns[5], ListSortDirection.Descending);
            Grilla.DataSource = tbVenta;
            Grilla.Columns[0].Visible = false;
            Grilla.Columns[5].Visible = false;
            Grilla.Columns[1].Width = 370;
            Double Total = fun.TotalizarColumna(tbVenta, "Subtotal");
            txtTotal.Text = Total.ToString();
            txtTotalConDescuento.Text = Total.ToString();
            txtCodigo.Text = "";
            txt_Codigo.Text = "";
            txt_CodigoBarra.Text = "";
            txt_Stock.Text = "";
            txtPrecio.Text = "";
            txtCantidad.Text = "";
            txt_Nombre.Text = "";
           // Valida = false;
            txt_CodigoBarra.Focus();
            Grilla.Refresh();
            if (tbVenta.Rows.Count > 0)
            {
                for (int i = 0; i < Grilla.Rows.Count - 1; i++)
                {
                    if (i == 0)
                        Grilla.Rows[0].Selected = true;
                    else
                        Grilla.Rows[i].Selected = false;
                }
            }
            //    
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (Grilla.CurrentRow == null)
            {
                Mensaje("Debe seleccionar una fila");
                return;
            }
            string Codigo = Grilla.CurrentRow.Cells[0].Value.ToString();
            tbVenta = fun.EliminarFila(tbVenta, "CodArticulo", Codigo);
            Grilla.DataSource = tbVenta;
            Double Total = fun.TotalizarColumna(tbVenta, "Subtotal");
            txtTotal.Text = Total.ToString();
            txtTotalConDescuento.Text = Total.ToString();
        }

        private void LlenarComboArticulo()
        {
            cFunciones fun = new cFunciones();
            cArticulo art = new cArticulo();
           // DataTable trdo = art.GetTodosArticulos();
            DataTable trdo = art.GetTodosArticulosJuguetes();
            txt_Nombre.DataSource = trdo;
            txt_Nombre.ValueMember = "CodArticulo";
            txt_Nombre.DisplayMember = "Nombre";
            AutoCompleteStringCollection coleccion = new AutoCompleteStringCollection();
            foreach (DataRow r in trdo.Rows)
            {
                coleccion.Add(r["Nombre"].ToString());
            }
            /*
            cJuguete jug = new cJuguete();
            DataTable tbJuguete = jug.GetTodosJuguetes();
            foreach (DataRow r in tbJuguete.Rows)
            {
                coleccion.Add(r["Nombre"].ToString());
            }
            */
            txt_Nombre.AutoCompleteCustomSource = coleccion;
            txt_Nombre.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            txt_Nombre.AutoCompleteSource = AutoCompleteSource.CustomSource;
            txt_Nombre.SelectedIndex = -1;

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void Grabar()
        {
            int TipoOp = Convert.ToInt32(CmbTipoOperacion.SelectedValue);
            SqlTransaction Transaccion;
            SqlConnection con = new SqlConnection(cConexion.GetConexion());
            con.Open();  
            Transaccion = con.BeginTransaction();
            DateTime Fecha = Convert.ToDateTime(txtFecha.Text);
            Int32? CodCliente = null;
            Double ImporteEfectivo = 0;
            Double ImporteTarjeta = 0;
            cCliente cli = new cCliente();
            Int32 CodVenta = 0;
            Int32? CodTarjeta = null;
            if (TipoOp == 2)
            {
                ImporteTarjeta = Convert.ToDouble(txtTotal.Text);
                CodTarjeta = Convert.ToInt32(CmbTarjeta.SelectedValue);
            }

            if (TipoOp == 1)
                ImporteEfectivo = Convert.ToDouble(txtTotal.Text);
            if (TipoOp == 3)
                ImporteEfectivo = Convert.ToDouble(txtTotal.Text);

            Int32 CodArticulo = 0;
            Double Precio = 0;
            Int32 Cantidad = 0;
            Double Subtotal = 0;
            Double Descuento = 0;
            Double PorDescuento = 0;
            Double TotalConDescuento = 0;
            int Libreria = 0;

            if (txtPordescuento.Text != "")
                PorDescuento = Convert.ToDouble(txtPordescuento.Text);

            if (txtTotalDescuento.Text != "")
                Descuento = Convert.ToDouble(txtTotalDescuento.Text);

            if (txtTotalConDescuento.Text != "")
                TotalConDescuento = Convert.ToDouble(txtTotalConDescuento.Text);

            cArticulo objArt = new Clases.cArticulo();
            string Cupon = txtCupon.Text;
            // string Col = "CodArticulo;Nombre;Precio;Cantidad;Subtotal";
            cVenta venta = new cVenta();
            cJuguete jug = new Clases.cJuguete();
            try
            {
               
                CodVenta = venta.InsertarVenta(con, Transaccion, ImporteEfectivo,
                    Fecha, ImporteEfectivo, ImporteTarjeta
                    , CodTarjeta, CodCliente, Cupon, Descuento, PorDescuento, TotalConDescuento);
                for (int i = 0; i < tbVenta.Rows.Count; i++)
                {
                    CodArticulo = Convert.ToInt32(tbVenta.Rows[i]["CodArticulo"].ToString());
                    Precio = Convert.ToDouble(tbVenta.Rows[i]["Precio"].ToString());
                    Cantidad = Convert.ToInt32(tbVenta.Rows[i]["Cantidad"].ToString());
                    Subtotal = Convert.ToDouble(tbVenta.Rows[i]["Subtotal"].ToString());
                    Libreria = Convert.ToInt32(tbVenta.Rows[i]["Libreria"].ToString());
                    if (Libreria ==1)
                    {
                        venta.InsertarDetalleVenta(con, Transaccion, CodVenta, Cantidad, Precio, CodArticulo, Subtotal);
                        objArt.ActualizarStockResta(con, Transaccion, CodArticulo, Cantidad);
                    }
                    else
                    {
                        venta.InsertarDetalleVentaJuguete (con, Transaccion, CodVenta, Cantidad, Precio, CodArticulo, Subtotal);
                        jug.ActualizarStockResta(con, Transaccion, CodArticulo, Cantidad);
                    }
                    
                }
                Transaccion.Commit();
                con.Close();
                Mensaje("Datos grabados correctamente");
                Limpiar();
            }
            catch (Exception exa)
            {
                Transaccion.Rollback();
                con.Close();
                Mensaje("Hubo un error en el proceso de grabacion");
                Mensaje(exa.Message);

            }
        }

        private void Limpiar()
        {
            tbVenta.Clear();
            Grilla.DataSource = tbVenta;
            txtTotal.Text = "";
            txtCupon.Text = "";
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            if (tbVenta.Rows.Count <1)
            {
                Mensaje("Debe ingresar articulos para continuar");
                return;
            }
            Grabar();
        }

        private void txt_Nombre_SelectedIndexChanged(object sender, EventArgs e)
        {
            Boolean EsJuguete = false;
            if (radioJugueteria.Checked == true)
                EsJuguete = true;
            int b = 0;
            int Operacion = 0;
            if (CmbTipoOperacion.SelectedIndex > 0)
                Operacion = Convert.ToInt32(CmbTipoOperacion.SelectedValue);
            if (Cargando == false)
            {
                if (EsJuguete ==false)
                {
                    if (txt_Nombre.SelectedIndex > 0)
                    {
                        Int32 CodArt = Convert.ToInt32(txt_Nombre.SelectedValue);
                        cArticulo art = new Clases.cArticulo();
                        DataTable trdo = art.GetArticuloxCodArt(CodArt);
                        if (trdo.Rows.Count > 0)
                        {
                            b = 1;
                            radioLibreria.Checked = true;
                            radioJugueteria.Checked = false;
                            txtCodigo.Text = trdo.Rows[0]["CodArticulo"].ToString();
                            //txt_Nombre.Text = trdo.Rows[0]["Nombre"].ToString();
                            txt_CodigoBarra.Text = trdo.Rows[0]["CodigoBarra"].ToString();
                            // txt_Codigo.Text = trdo.Rows[0]["Codigo"].ToString();
                            txt_Stock.Text = trdo.Rows[0]["Stock"].ToString();
                            if (Operacion == 1)
                                txtPrecio.Text = trdo.Rows[0]["PrecioEfectivo"].ToString();
                            if (Operacion == 2)
                            {
                                txtPrecio.Text = trdo.Rows[0]["PrecioTarjeta"].ToString();
                                Double Precio = Convert.ToDouble(trdo.Rows[0]["PrecioTarjeta"].ToString());
                                Precio = Precio - 0.10 * Precio;
                                txtDescuento.Text = Precio.ToString();
                            }

                            if (Operacion == 3)
                                txtPrecio.Text = trdo.Rows[0]["PrecioEfectivo"].ToString();

                            if (txtPrecio.Text != "")
                            {
                                Double Precio = Convert.ToDouble(txtPrecio.Text);
                                Precio = Math.Round(Precio, 0);
                                txtPrecio.Text = Precio.ToString();
                            }

                            if (txtDescuento.Text != "")
                            {
                                Double Precio = Convert.ToDouble(txtDescuento.Text);
                                Precio = Math.Round(Precio, 0);
                                txtDescuento.Text = Precio.ToString();
                            }
                            PuedeAgregar = true;
                            txtCantidad.Focus();
                        }
                    }
                }
                
                if (EsJuguete==true)
                {
                    //busco juguete
                    radioLibreria.Checked = false;
                    radioJugueteria.Checked = true;
                    Int32 CodArt = Convert.ToInt32(txt_Nombre.SelectedValue);
                    cJuguete jug = new cJuguete();
                    DataTable trdo = jug.GetArticuloxCodArt(CodArt);
                    if (trdo.Rows.Count > 0)
                    {
                        txtCodigo.Text = trdo.Rows[0]["CodArticulo"].ToString();
                        //txt_Nombre.Text = trdo.Rows[0]["Nombre"].ToString();
                        txt_CodigoBarra.Text = trdo.Rows[0]["CodigoBarra"].ToString();
                        // txt_Codigo.Text = trdo.Rows[0]["Codigo"].ToString();
                        txt_Stock.Text = trdo.Rows[0]["Stock"].ToString();
                        if (Operacion == 1)
                            txtPrecio.Text = trdo.Rows[0]["PrecioEfectivo"].ToString();
                        if (Operacion == 2)
                        {
                            txtPrecio.Text = trdo.Rows[0]["PrecioTarjeta"].ToString();
                            Double Precio = Convert.ToDouble(trdo.Rows[0]["PrecioTarjeta"].ToString());
                            Precio = Precio - 0.10 * Precio;
                            txtDescuento.Text = Precio.ToString();
                        }

                        if (Operacion == 3)
                            txtPrecio.Text = trdo.Rows[0]["PrecioEfectivo"].ToString();

                        if (txtPrecio.Text != "")
                        {
                            Double Precio = Convert.ToDouble(txtPrecio.Text);
                            Precio = Math.Round(Precio, 0);
                            txtPrecio.Text = Precio.ToString();
                        }

                        if (txtDescuento.Text != "")
                        {
                            Double Precio = Convert.ToDouble(txtDescuento.Text);
                            Precio = Math.Round(Precio, 0);
                            txtDescuento.Text = Precio.ToString();
                        }
                        PuedeAgregar = true;
                        txtCantidad.Focus();
                    }
                }
            }
        }

        private void btnBuscarArticulo_Click(object sender, EventArgs e)
        {
            if (txt_Nombre.SelectedIndex >0)
            {
                string xx = txt_Nombre.SelectedValue.ToString();
            }
                
        }
    }
}
