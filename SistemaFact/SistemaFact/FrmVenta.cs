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
    public partial class FrmVenta : FormBase
    {  //AREA PASAR EL EXCEL DE ENERO CON LA COLUMNA J
        //PARA ACTUALIZAR EL COSTO
        cFunciones fun;
        DataTable tbVenta;
        Boolean Valida = false;
        Boolean Cargando = true;
        Boolean PuedeAgregar = false;
        int Indice = 0;
        public FrmVenta()
        {
            InitializeComponent();
        }

        private void FrmVenta_Load(object sender, EventArgs e)
        {
           // insert into cliente(apellido, nombre, clientenulo)
          //values('', '', 1)
            Principal.CodigoSenia = "1";
            fun = new Clases.cFunciones();
            Inicializar();
            LlenarComboArticulo();
            if (Principal.CodigoPrincipalAbm != null)
                if (Principal.CodigoPrincipalAbm !="")
                {
                    Int32 CodVenta = Convert.ToInt32(Principal.CodigoPrincipalAbm);
                    BuscarVenta(CodVenta);
                }
            Cargando = false;
        }

        public void Inicializar()
        {
            txtFechaAltaOrden.Text = DateTime.Now.ToShortDateString();
            fun.LlenarCombo(cmbTipoDoc, "TipoDocumento", "Nombre", "CodTipoDoc");
            fun.LlenarCombo(CmbTarjeta , "Tarjeta", "Nombre", "CodTarjeta");
            if (cmbTipoDoc.Items.Count > 0)
                cmbTipoDoc.SelectedIndex = 1;
            string Col = "CodArticulo;Nombre;Precio;Cantidad;Subtotal;Indice";
            tbVenta = fun.CrearTabla(Col);
            CargarTipoOperacion();
            lblTarjeta.Visible = false;
            lblCupon.Visible = false;
            CmbTarjeta.Visible = false;
            txtCupon.Visible = false;
            txt_CodigoBarra.Focus();
            txtDescuento.Visible = false;
            chkDescuento.Visible = false;
        }

        private void CargarTipoOperacion()
        {
            /*
            string Col = "Codigo;Nombre";
            DataTable tb = new DataTable();
            tb = fun.CrearTabla(Col);
            string Val = "";
            Val = "1;Contado Efectivo";
            tb = fun.AgregarFilas(tb, Val);
            Val = "2;Tarjeta Credito";
            tb = fun.AgregarFilas(tb, Val);
            Val = "3;Tarjeta Débito";
            tb = fun.AgregarFilas(tb, Val);
            fun.LlenarComboDatatable(CmbTipoOperacion, tb, "Nombre", "Codigo");
            */
            cTipoOperacion tipo = new cTipoOperacion();
            DataTable tb = tipo.GetTipos();
            fun.LlenarComboDatatable(CmbTipoOperacion, tb, "Nombre", "Codigo");
            CmbTipoOperacion.SelectedIndex = 1;
        }

        private void txtNroDocumento_TextChanged(object sender, EventArgs e)
        {
            int b = 0;
            string NroDoc = txtNroDocumento.Text;
            if (NroDoc.Length < 3)
                return;
            cCliente cli = new cCliente();
            DataTable trdo = cli.GetClientesxNroDocumento(NroDoc);
            if (trdo.Rows.Count > 0)
                if (trdo.Rows[0]["CodCliente"].ToString() != "")
                {
                    Int32 CodCliente = Convert.ToInt32(trdo.Rows[0]["CodCliente"].ToString());
                    GetClientexCodigo(CodCliente);
                    b = 1;
                }
            if (b == 0)
            {
                txtCodCliente.Text = "";
                txtApellido.Text = "";
                txtNombre.Text = "";
            }
        }

        private void GetClientexCodigo(Int32 CodCliente)
        {
            cCliente cli = new cCliente();
            DataTable trdo = cli.GetClientexCodigo(CodCliente);
            if (trdo.Rows.Count > 0)
            {
                txtCodCliente.Text = trdo.Rows[0]["CodCliente"].ToString();
                txtNroDocumento.Text = trdo.Rows[0]["NroDocumento"].ToString();
                txtNombre.Text = trdo.Rows[0]["Nombre"].ToString();
                txtApellido.Text = trdo.Rows[0]["Apellido"].ToString();
                txtTelefono.Text = trdo.Rows[0]["Telefono"].ToString();
                txtCuit.Text = trdo.Rows[0]["Cuit"].ToString();
                txtDireccion.Text = trdo.Rows[0]["Direccion"].ToString();


            }
        }

        private void txt_Codigo_TextChanged(object sender, EventArgs e)
        {
            int Operacion = 0;
            if (txt_Codigo.Text.Length < 3)
            {
                return;
            }
            Operacion = Convert.ToInt32(CmbTipoOperacion.SelectedValue);
            string Codigo = txt_Codigo.Text;
            cArticulo art = new cArticulo();
            DataTable trdo = art.GetArticulo("", "", Codigo);
            if (trdo.Rows.Count > 0)
            {
                txtCodigo.Text = trdo.Rows[0]["CodArticulo"].ToString();
                txt_Nombre.Text = trdo.Rows[0]["Nombre"].ToString();
                txt_CodigoBarra.Text = trdo.Rows[0]["CodigoBarra"].ToString();
                // txt_Codigo.Text = trdo.Rows[0]["Codigo"].ToString();
                txt_Stock.Text = trdo.Rows[0]["Stock"].ToString();
                if (Operacion == 1)
                    txtPrecio.Text = trdo.Rows[0]["PrecioEfectivo"].ToString();
                if (Operacion == 2)
                    txtPrecio.Text = trdo.Rows[0]["PrecioTarjeta"].ToString();
                if (Operacion == 3)
                    txtPrecio.Text = trdo.Rows[0]["PrecioEfectivo"].ToString();
            }
            if (txtPrecio.Text !="")
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
        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void btnBuscarArticulo_Click(object sender, EventArgs e)
        {
            if (CmbTipoOperacion.SelectedIndex <1)
            {
                Mensaje("Debe seleccionar un tipo de operación");
                return;
            }
            Principal.OpcionesdeBusqueda = "Codigo;Nombre;CodigoBarra";
            Principal.TablaPrincipal = "Articulo";
            Principal.OpcionesColumnasGrilla = "CodArticulo;Nombre;PrecioEfectivo;PrecioTarjeta";
            Principal.ColumnasVisibles = "0;1;1;1";
            Principal.ColumnasAncho = "0;390;95;95";
            Principal.NombreTablaSecundario = "Articulo";
            Principal.CampoIdSecundarioGenerado = "";
            FrmBuscadorGenerico form = new FrmBuscadorGenerico();
            form.FormClosing += new FormClosingEventHandler(form_FormClosing);
            form.ShowDialog();
            txtCantidad.Focus();
        }

        private void form_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (Principal.CodigoPrincipalAbm != "")
            {
                Clases.cFunciones fun = new Clases.cFunciones();
                switch (Principal.NombreTablaSecundario)
                {
                    case "Articulo":
                        BuscarArticuloxCodigo(Convert.ToInt32(Principal.CodigoPrincipalAbm));
                        break;
                    case "Cantidad":
                        txtCantidad.Text = Principal.CantidadArticulo.ToString();
                        txtCantidad.Focus();
                        break;
                }
            }
        }

        private void BuscarArticuloxCodigo(Int32 CodArt)
        {
            int Operacion = Convert.ToInt32(CmbTipoOperacion.SelectedValue);
            cArticulo art = new cArticulo();
            DataTable trdo = art.GetArticuloxCodArt(CodArt);
            if (trdo.Rows.Count > 0)
            {  
                txtCodigo.Text = trdo.Rows[0]["CodArticulo"].ToString();
                txt_Codigo.Text = trdo.Rows[0]["Codigo"].ToString();
                txt_Nombre.Text = trdo.Rows[0]["Nombre"].ToString();
               // txt_CodigoBarra.Text = trdo.Rows[0]["CodigoBarra"].ToString();
                txt_Stock.Text = trdo.Rows[0]["Stock"].ToString();
                txtPrecio.Text = trdo.Rows[0]["PrecioEfectivo"].ToString();
                txtCantidad.Text = "1";
                //  if (txtPrecio.Text != "")
                //      txtPrecio.Text = txtPrecio.Text.Replace(",", ".");
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
                txtCantidad.Focus();
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
            if (Des ==false)
                Precio = Convert.ToDouble(txtPrecio.Text);
            if (Des ==true)
                Precio = Convert.ToDouble(txtDescuento.Text);
            Double Subtotal = Precio * Cantidad;
            string Nombre = txt_Nombre.Text;

            if (fun.Buscar(tbVenta, "CodArticulo", CodArticulo.ToString()) == true)
            {
                Mensaje("Ya se ha ingresado el articulo");
                return;
            }

            string Val = CodArticulo + ";" + Nombre;
            Val = Val + ";" + Precio.ToString();
            Val = Val + ";" + Cantidad.ToString();
            Val = Val + ";" + Subtotal.ToString();
            Val = Val + ";" + Indice.ToString();
            tbVenta = fun.AgregarFilas(tbVenta, Val);
            Indice = Indice + 1;
            //Grilla.Sort(Grilla.Columns[3]), ListSortDirection.Ascending)
            if (tbVenta.Rows.Count >1)
              Grilla.Sort(Grilla.Columns[5], ListSortDirection.Descending );
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
            Valida = false;
            txt_CodigoBarra.Focus();
            Grilla.Refresh();
            if (tbVenta.Rows.Count > 0)
            {
                for (int i=0;i<Grilla.Rows.Count -1;i++)
                {
                    if (i==0)
                        Grilla.Rows[0].Selected = true;
                    else
                        Grilla.Rows[i].Selected = false;
                }
            }
              //    
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Agregar();
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

        private void button2_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void txtCantidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            
            if (PuedeAgregar ==false )
            {
                if (txtCodigo.Text !="")
                {
                    txt_Nombre.SelectedValue = txtCodigo.Text;
                }
                PuedeAgregar = true;
                return;
            }

            if (txtCodigo.Text  == "")
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

        private void txtApellido_TextChanged(object sender, EventArgs e)
        {

        }

        private void Grabar()
        {
            int TipoOp = Convert.ToInt32(CmbTipoOperacion.SelectedValue);
            SqlTransaction Transaccion;
            SqlConnection con = new SqlConnection(cConexion.GetConexion());
            con.Open();
            Transaccion = con.BeginTransaction();
            DateTime Fecha = Convert.ToDateTime(txtFechaAltaOrden.Text);
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
            try
            { 
                if (txtNroDocumento.Text !="" && txtApellido.Text !="")
                {
                if (txtCodCliente.Text == "")
                    CodCliente = GrabarCliente(con, Transaccion);
                else
                    {
                        ModificarCliente(con, Transaccion);
                        CodCliente = Convert.ToInt32(txtCodCliente.Text);
                    }
                    
                }
                CodVenta = venta.InsertarVenta(con, Transaccion, ImporteEfectivo,
                    Fecha, ImporteEfectivo, ImporteTarjeta
                    , CodTarjeta, CodCliente, Cupon, Descuento, PorDescuento,TotalConDescuento );
                for (int i = 0; i < tbVenta.Rows.Count ; i++)
                {
                    CodArticulo = Convert.ToInt32(tbVenta.Rows[i]["CodArticulo"].ToString());
                    Precio = Convert.ToDouble(tbVenta.Rows[i]["Precio"].ToString());
                    Cantidad = Convert.ToInt32(tbVenta.Rows[i]["Cantidad"].ToString());
                    Subtotal = Convert.ToDouble(tbVenta.Rows[i]["Subtotal"].ToString());
                    venta.InsertarDetalleVenta(con, Transaccion, CodVenta, Cantidad, Precio, CodArticulo, Subtotal);
                    objArt.ActualizarStockResta(con, Transaccion, CodArticulo, Cantidad);
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

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            if (Validar() ==true)
            Grabar();
        }

        public bool Validar()
        {
            int TipoOperacion = 0;
            if (CmbTipoOperacion.SelectedIndex ==0)
            {
                Mensaje("Seleccione un tipo de operacion");
                return false;
            }
            if (Grilla.Rows.Count <1)
            {
                Mensaje("Debe ingresar artíclos para continuar");
                return false;
            }
            TipoOperacion = Convert.ToInt32(CmbTipoOperacion.SelectedValue);
            if (TipoOperacion ==2)
            {
                if (CmbTarjeta.SelectedIndex  <1)
                {
                    Mensaje("Debe seleccionar una tarjeta de crédito para continuar");
                    return false;
                }
            }
            return true;
        }

        private void Limpiar()
        {
            txtCodigo.Text = "";
            txt_Codigo.Text = "";
            txt_CodigoBarra.Text = "";
            txtNombre.Text = "";
            txt_Stock.Text = "";
            txtPrecio.Text = "";
            txtCantidad.Text = "";
            txt_Nombre.Text = "";
            txtTotal.Text = "";
            tbVenta.Rows.Clear();
            Grilla.DataSource = tbVenta;
            txtTotal.Text = "";
            txtNombre.Text = "";
            txtApellido.Text = "";
            txtNroDocumento.Text = "";
            txtTelefono.Text = "";
            txtDireccion.Text = "";
            txtCupon.Text = "";
            txtCodCliente.Text = "";
            txtDescuento.Text = "";
            chkDescuento.Checked = false;
            txtTotalConDescuento.Text = "";
            txtPordescuento.Text = "";
            txtTotalDescuento.Text = "";
            txtCuit.Text = "";
            txtObservacion.Text = "";
        }

        private void CmbTipoOperacion_Resize(object sender, EventArgs e)
        {

        }

        private void CmbTipoOperacion_SelectedIndexChanged(object sender, EventArgs e)
        {
            chkDescuento.Visible = false ;
            txtDescuento.Visible = false ;
            if (CmbTipoOperacion.SelectedIndex >0)
            {
                int Indice = Convert.ToInt32(CmbTipoOperacion.SelectedValue);
                switch (Indice)
                {
                    case 1:
                        lblCupon.Visible = false;
                        lblTarjeta.Visible = false;
                        CmbTarjeta.Visible = false;
                        txtCupon.Visible = false;
                        txt_CodigoBarra.Focus();
                        break;
                    case 2:
                        lblCupon.Visible = true;
                        lblTarjeta.Visible = true;
                        CmbTarjeta.Visible = true;
                        txtCupon.Visible = true;
                        chkDescuento.Visible = true;
                        txtDescuento.Visible = true;
                        break;
                }
            }
        }

        private void lblCupon_Click(object sender, EventArgs e)
        {

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
            DataTable trdo = art.GetArticulo("", Codigo , "");
            if (trdo.Rows.Count > 0)
            {
                b = 1;
                txtCodigo.Text = trdo.Rows[0]["CodArticulo"].ToString();
                txt_Nombre.SelectedValue  = trdo.Rows[0]["CodArticulo"].ToString();
                txt_CodigoBarra.Text = trdo.Rows[0]["CodigoBarra"].ToString();
                txt_Nombre.Text = trdo.Rows[0]["Nombre"].ToString();
                txt_Stock.Text = trdo.Rows[0]["Stock"].ToString();
                
                
                if (Operacion ==1)
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
                    //txtCantidad.Text = "1";
                    /*
                    Principal.NombreTablaSecundario = "Cantidad";
                    FrmCantidad form = new FrmCantidad();
                    form.FormClosing += new FormClosingEventHandler(form_FormClosing);
                    form.ShowDialog();
                    */
                }
                    
            }
           
        }

        public Int32 GrabarCliente(SqlConnection con, SqlTransaction Transaccion)
        {
            string Ape = txtApellido.Text;
            string Nom = txtNombre.Text;
            string NroDoc = txtNroDocumento.Text;
            Int32 CodTipoDoc = 1;
            string Cuit = txtCuit.Text;
            if (cmbTipoDoc.SelectedIndex > 0)
                CodTipoDoc = Convert.ToInt32(cmbTipoDoc.SelectedValue); 
            string Telefono = txtTelefono.Text;
            string Direccion = txtDireccion.Text;
            cCliente cli = new Clases.cCliente();
           Int32 CodCli= cli.InsertarClienteTran(con, Transaccion, Ape, Nom, Telefono, CodTipoDoc , NroDoc,Cuit,Direccion);
            return CodCli;
        }

        public void ModificarCliente(SqlConnection con, SqlTransaction Transaccion)
        {
            string Ape = txtApellido.Text;
            string Nom = txtNombre.Text;
            string NroDoc = txtNroDocumento.Text;
            Int32 CodCli = Convert.ToInt32(txtCodCliente.Text);
            Int32 CodTipoDoc = 1;
            if (cmbTipoDoc.SelectedIndex > 0)
                CodTipoDoc = Convert.ToInt32(cmbTipoDoc.SelectedValue);
            string Telefono = txtTelefono.Text;
            string Cuit = txtCuit.Text;
            string Direccion = txtDireccion.Text;
            cCliente cli = new Clases.cCliente();
            cli.ModificarClienteTran(con, Transaccion, CodCli, Ape,
                Nom , Telefono, CodTipoDoc, NroDoc,Cuit,Direccion);
        }

        private void BuscarVenta(Int32 CodVenta)
        {   //string Col = "CodArticulo;Nombre;Precio;Cantidad;Subtotal";
            cVenta ven = new cVenta();
            DataTable trdo = ven.GetVentaxCodigo(CodVenta);
            string CodArticulo = "";
            string Nombre = "";
            string Precio = "";
            string Cantidad = "";
            string Subtotal = "";
            string Val = "";
            if (trdo.Rows.Count >0)
            {
                if (trdo.Rows[0]["CodTarjeta"].ToString ()!="")
                {
                    CmbTarjeta.SelectedValue = trdo.Rows[0]["CodTarjeta"].ToString();
                    txtCupon.Text = trdo.Rows[0]["Cupon"].ToString();
                    CmbTarjeta.Visible = true;
                    txtCupon.Visible = true;
                }
                if (trdo.Rows[0]["CodCliente"].ToString() != "")
                {
                    Int32 CodCli = Convert.ToInt32(trdo.Rows[0]["CodCliente"].ToString());
                    BuscarCliente(CodCli);
                }
                    for (int i = 0; i < trdo.Rows.Count ; i++)
                {
                    CodArticulo = trdo.Rows[i]["CodArticulo"].ToString();
                    Nombre = trdo.Rows[i]["Nombre"].ToString();
                    Precio = trdo.Rows[i]["Precio"].ToString();
                    Cantidad = trdo.Rows[i]["Cantidad"].ToString();
                    Subtotal = trdo.Rows[i]["Subtotal"].ToString();
                    Val = CodArticulo + ";" + Nombre;
                    Val = Val + ";" + Precio + ";" + Cantidad;
                    Val = Val + ";" + Subtotal;
                    tbVenta = fun.AgregarFilas(tbVenta, Val);
                }
                Grilla.DataSource = tbVenta;
                Grilla.Columns[0].Visible = false;
                Grilla.Columns[1].Width = 330;
                Double Total = fun.TotalizarColumna(tbVenta, "Subtotal");
                txtTotal.Text = Total.ToString();
                btnGrabar.Enabled = false;
                btnCancelar.Enabled = false;
            }
        }
        
        private void BuscarCliente(Int32 CodCliente)
        {
            cCliente cli = new Clases.cCliente();
            DataTable trdo = cli.GetClientexCodigo(CodCliente);
            if (trdo.Rows.Count >0)
            {
                txtNombre.Text = trdo.Rows[0]["Nombre"].ToString();
                txtApellido.Text = trdo.Rows[0]["Apellido"].ToString();
                txtNroDocumento.Text = trdo.Rows[0]["NroDocumento"].ToString();
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void btnPresupuesto_Click(object sender, EventArgs e)
        {
            if (txtNombre.Text  == "")
            {

                if (chkSinCliente.Checked == false)
                {
                    Mensaje("Debe tildar la opcion sin registrar cliente para continuar");
                    return;
                }
            }
            if (tbVenta.Rows.Count <1)
            {
                Mensaje("Debe ingresar artículos para continaur");
                return;
            }
            GrabarPresupuesto();
        }

        private void GrabarPresupuesto()
        {
            
            SqlTransaction Transaccion;
            SqlConnection con = new SqlConnection(cConexion.GetConexion());
            con.Open();
            Transaccion = con.BeginTransaction();
            DateTime Fecha = Convert.ToDateTime(txtFechaAltaOrden.Text);
            Int32? CodCliente = null;
           
            cCliente cli = new cCliente();
            Int32 CodPresupuesto = 0;
            Int32 CodArticulo = 0;
            Double Precio = 0;
            Int32 Cantidad = 0;
            Double Subtotal = 0;
            Double Total = 0;
            if (txtTotal.Text != "")
                Total = Convert.ToDouble(txtTotal.Text);
            cArticulo objArt = new Clases.cArticulo();
            string Cupon = txtCupon.Text;
            Double Descuento = 0;
            Double PorDescuento = 0;
            Double TotalConDescuento = 0;
            string FormaPago = "";

            if (txtPordescuento.Text != "")
                PorDescuento = Convert.ToDouble(txtPordescuento.Text);

            if (txtTotalDescuento.Text != "")
                Descuento = Convert.ToDouble(txtTotalDescuento.Text);

            if (txtTotalConDescuento.Text != "")
                TotalConDescuento = Convert.ToDouble(txtTotalConDescuento.Text);
            if (chkSinCliente.Checked == true)
            {
                //cCliente cli = new Clases.cCliente();
                CodCliente = cli.GetCodClienteNulo();
            }
            // string Col = "CodArticulo;Nombre;Precio;Cantidad;Subtotal";
            cPresupuesto pre = new cPresupuesto();
            try
            {
                if(chkSinCliente.Checked==false)
                {
                    if (txtNroDocumento.Text != "" && txtApellido.Text != "")
                    {
                        if (txtCodCliente.Text == "")
                            CodCliente = GrabarCliente(con, Transaccion);
                        else
                        {
                            ModificarCliente(con, Transaccion);
                            CodCliente = Convert.ToInt32(txtCodCliente.Text);
                        }

                    }
                    else
                    {
                        if (chkSinCliente.Checked == false)
                        {
                            Mensaje("Debe tildar la opcion sin registrar cliente para continuar");
                            return;
                        }
                    }
                }

                FormaPago = GetFormaPago();
                CodPresupuesto = pre.InsertarPresupuesto(con, Transaccion, Total,
                    Fecha
                    , CodCliente, Descuento, PorDescuento, TotalConDescuento,FormaPago);
                Principal.CodigoSenia = CodPresupuesto.ToString();
                string NroPresupuesto ="0001-"+ GetNroPresupueto(CodPresupuesto.ToString());
                pre.ActualizarNroPresupuesto(con, Transaccion, CodPresupuesto, NroPresupuesto);
                for (int i = 0; i < tbVenta.Rows.Count; i++)
                {
                    CodArticulo = Convert.ToInt32(tbVenta.Rows[i]["CodArticulo"].ToString());
                    Precio = Convert.ToDouble(tbVenta.Rows[i]["Precio"].ToString());
                    Cantidad = Convert.ToInt32(tbVenta.Rows[i]["Cantidad"].ToString());
                    Subtotal = Convert.ToDouble(tbVenta.Rows[i]["Subtotal"].ToString());
                    pre.InsertarDetalle(con, Transaccion, CodPresupuesto, Cantidad, Precio, CodArticulo, Subtotal);
                    
                }
                Transaccion.Commit();
                con.Close();
                Mensaje("Datos grabados correctamente");
                Limpiar();
                FrmReporte frm = new SistemaFact.FrmReporte();
                frm.Show();
                // this.GetJugadorxCodigoTableAdapter.Fill(this.DataSet1.GetJugadorxCodigo, Codigo); 
                
            }
            catch (Exception exa)
            {
                Transaccion.Rollback();
                con.Close();
                Mensaje("Hubo un error en el proceso de grabacion");
                Mensaje(exa.Message);

            }
        }

        public string GetFormaPago()
        {
            string tipo = "";
            if (CmbTipoOperacion.SelectedIndex >0)
            {
                tipo = CmbTipoOperacion.Text;
            }
            if (CmbTarjeta.Visible ==true)
            {
                if (CmbTarjeta.SelectedIndex >0)
                {
                    tipo = tipo + ", Tarjeta " + CmbTarjeta.Text; 
                }
            }
            return tipo;
        }

        public string GetNroPresupueto(string CodPresupuesto)
        {
            string Numero = "";
            int Can = CodPresupuesto.Length;
            switch (Can)
            {
                case 1:
                    Numero = "000" + CodPresupuesto.ToString();
                    break;
                case 2:
                    Numero = "00" + CodPresupuesto.ToString();
                    break;
                case 3:
                    Numero = "0" + CodPresupuesto.ToString();
                    break;
            }
            return Numero;
        }

        private void txtPordescuento_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                if (tbVenta.Rows.Count <1)
                {
                    Mensaje("Debe ingresar artículos");
                    return;
                }
                if (txtPordescuento.Text =="")
                {
                    Mensaje("Debe ingresar un porcentaje de descueneto para continuar");
                    return;
                }
                Double Total = Convert.ToDouble(txtTotal.Text);
                Double Por = Convert.ToDouble(txtPordescuento.Text);
                Double Des = Total * Por / 100;
                Des = Math.Round(Des, 0);
                txtTotalDescuento.Text = Des.ToString();
                Double TotalConDescuento = Total - Des;
                txtTotalConDescuento.Text = TotalConDescuento.ToString();
            }
        }

        private void txtTotalDescuento_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                if (tbVenta.Rows.Count < 1)
                {
                    Mensaje("Debe ingresar artículos");
                    return;
                }
                if (txtTotalDescuento.Text == "")
                {
                    Mensaje("Debe ingresar descueneto para continuar");
                    return;
                }
                Double Total = Convert.ToDouble(txtTotal.Text);
                Double Por = 0;
                Double Des = Convert.ToDouble(txtTotalDescuento.Text);
                Des = Math.Round(Des, 0);
                Por = Des * 100 / Total;
                Por = Math.Round(Por, 0);
                txtPordescuento.Text = Por.ToString(); 
                Double TotalConDescuento = Total - Des;
                txtTotalConDescuento.Text = TotalConDescuento.ToString();
            }
        }

        private void txtCuit_Enter(object sender, EventArgs e)
        {
            
        }

        private void txtNombre_Enter(object sender, EventArgs e)
        {
            
        }

        private void txtCuit_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                txtNombre.Focus();
            }
        }

        private void txtNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                txtApellido.Focus();
            }
        }

        private void txtCuit_TextChanged(object sender, EventArgs e)
        {
            int b = 0;
            string NroDoc = txtCuit.Text;
            if (NroDoc.Length < 3)
                return;
            cCliente cli = new cCliente();
            DataTable trdo = cli.GetClientesxCuit(NroDoc);
            if (trdo.Rows.Count > 0)
                if (trdo.Rows[0]["CodCliente"].ToString() != "")
                {
                    Int32 CodCliente = Convert.ToInt32(trdo.Rows[0]["CodCliente"].ToString());
                    GetClientexCodigo(CodCliente);
                    b = 1;
                }
            if (b == 0)
            {
                txtCodCliente.Text = "";
                txtApellido.Text = "";
                txtNombre.Text = "";
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtTelefono_TextChanged(object sender, EventArgs e)
        {

        }

        private void chkSinCliente_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void txtFechaAltaOrden_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void txtCantidad_TextChanged(object sender, EventArgs e)
        {

        }

        private void Grilla_KeyPress(object sender, KeyPressEventArgs e)
        {
            string xx = e.KeyChar.ToString();
        }

        private void FrmVenta_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void txt_Nombre_TextChanged(object sender, EventArgs e)
        {
           
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

        private void txt_Nombre_SelectedIndexChanged(object sender, EventArgs e)
        {
            int Operacion = 0;
            if (CmbTipoOperacion.SelectedIndex > 0)
                Operacion = Convert.ToInt32(CmbTipoOperacion.SelectedValue);
            if (Cargando ==false )
            {
                if(txt_Nombre.SelectedIndex >0)
                {
                    Int32 CodArt = Convert.ToInt32(txt_Nombre.SelectedValue);
                    cArticulo art = new Clases.cArticulo();
                    DataTable trdo = art.GetArticuloxCodArt(CodArt);
                    if (trdo.Rows.Count >0)
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

        private void txtCantidad_Enter(object sender, EventArgs e)
        {
           
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            txtCantidad.Focus();
        }

        private void txt_CodigoBarra_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void btnLimpiarArticulo_Click(object sender, EventArgs e)
        {
            txt_CodigoBarra.Text = "";
            txt_Nombre.Text = "";
            txtCantidad.Text = "";
            txtPrecio.Text = "";
            txt_Stock.Text = "";
            txt_CodigoBarra.Focus();
        }

        private void txt_Nombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            int Operacion = 0;
            if (CmbTipoOperacion.SelectedIndex > 0)
                Operacion = Convert.ToInt32(CmbTipoOperacion.SelectedValue);
           
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                PuedeAgregar = true;
                if (txt_Nombre.SelectedIndex >0)
                {
                    Int32 CodArt = Convert.ToInt32(txt_Nombre.SelectedValue);
                    cArticulo art = new Clases.cArticulo();
                    DataTable trdo = art.GetArticuloxCodArt(CodArt);
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
                        txtCantidad.Focus();
                    }
                }
            }
        }
    }
}
