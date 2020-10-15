using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
namespace SistemaFact.Clases
{
    public class cArticulo
    {
        public void Insertar(string Nombre,Double? Costo,Double? Precio,
            int? CodColor,string Ruta, int? CodTipoPrenda,string CodigoBarra)
        {
            string sql = "insert into Articulo(";
            sql = sql + "Nombre,Costo,Precio,CodColor,Ruta,CodTipoPrenda,CodigoBarra)";
            sql = sql + " Values(";
            sql = sql + "'" + Nombre + "'";
            if (Costo != null)
                sql = sql + "," + Costo.ToString().Replace(",",".");
            else
                sql = sql + ",null";
            if (Precio != null)
                sql = sql + "," + Precio.ToString().Replace(",",".");
            else
                sql = sql + ",null";
            if (CodColor != null)
                sql = sql + "," + CodColor.ToString();
            else
                sql = sql + ",null";
            sql = sql + "," + "'" + Ruta + "'";
            if (CodTipoPrenda  != null)
                sql = sql + "," + CodTipoPrenda.ToString();
            else
                sql = sql + ",null";
            if (CodigoBarra != null)
                sql = sql + "," + "'" + CodigoBarra + "'";
            else
                sql = sql + ",null";
            sql = sql + ")";
            cDb.Grabar(sql);
        }

        public DataTable GetArticulo(string Nombre,string CodigoBarra,string Codigo)
        {
            string sql = "select a.CodArticulo, a.Codigo,a.CodigoBarra,a.Nombre, a.stock ";
            sql = sql + ",Costo,PrecioEfectivo,PrecioTarjeta";
            sql = sql + " from articulo a";
            if (Nombre !="")
            {
                sql = sql + " where a.Nombre like " + "'%" + Nombre + "%'";
            }
            if (CodigoBarra !="")
            {
                sql = sql + " where a.CodigoBarra =" + "'" + CodigoBarra +"'";
            }

            if (Codigo != "")
            {
                sql = sql + " where a.Codigo =" + "'" + Codigo + "'";
            }

            return cDb.GetDatatable(sql);
        }

        public void InsertarArticulo(string Codigo,string CodigoBarra,string Nombre,Double? Costo)
        {  
            Double? PrecioEfectivo = null;
            Double? PrecioTarjeta = null;
            if (Costo !=null)
            {
                PrecioEfectivo = Costo + Costo * 0.7;
                PrecioTarjeta = Costo + Costo * 1.0;
            }
            string sql = "insert into Articulo(Nombre,Codigo,CodigoBarra,Costo,PrecioEfectivo,PrecioTarjeta)";
            sql = sql + " Values(" + "'" + Nombre + "'";
            if (Codigo != null)
                sql = sql + "," + "'" + Codigo + "'";
            else
                sql = sql + ",null";

            if (CodigoBarra  != null)
                sql = sql + "," + "'" + CodigoBarra  + "'";
            else
                sql = sql + ",null";

            if (Costo != null)
                sql = sql + "," + Costo.ToString().Replace(",", ".");
            else
                sql = sql + ",null";

            if (PrecioEfectivo  != null)
                sql = sql + "," + PrecioEfectivo.ToString().Replace(",", ".");
            else
                sql = sql + ",null";
             
            if (PrecioTarjeta != null)
                sql = sql + "," + PrecioTarjeta.ToString().Replace(",", ".");
            else
                sql = sql + ",null";

            sql = sql + ")";
            //verifico si existe
            Int32 CodArticulo = Existe(Codigo, CodigoBarra);
            if (CodArticulo == 0)
                cDb.Grabar(sql);
            else
                ModificarArticulo(CodArticulo, Costo, PrecioEfectivo, PrecioTarjeta);
        }

        public Int32  Existe(string Codigo,string CodigoBarra)
        {
            int b = 0;
            Int32 CodArticulo = 0;
            string sql = "select CodArticulo";
            sql = sql + " from Articulo";
            if (Codigo !="")
            {
                sql = sql + " where Codigo=" + "'" + Codigo + "'";
                b = 1;
            }

            if (CodigoBarra !="")
            {
                if (b==0)
                    sql = sql + " where CodigoBarra=" + "'" + CodigoBarra + "'";
            }
           
            DataTable trdo = cDb.GetDatatable(sql);
            if (trdo.Rows.Count > 0)
                if (trdo.Rows[0]["CodArticulo"].ToString() != "")
                    CodArticulo = Convert.ToInt32(trdo.Rows[0]["CodArticulo"].ToString());
            return CodArticulo;
        }

        public void ModificarArticulo(Int32 CodArticulo, Double? Costo, Double? PrecioEfectivo, Double? PrecioTarjeta)
        {
            string sql = "Update Articulo ";
            if (Costo != null)
                sql = sql + " set Costo=" + Costo.ToString().Replace(",", ".");
            else
                sql = sql + " set Costo=null";

            if (PrecioEfectivo != null)
                sql = sql + " , PrecioEfectivo=" + PrecioEfectivo.ToString().Replace(",", ".");
            else
                sql = sql + " , PrecioEfectivo=null";

            if (PrecioTarjeta != null)
                sql = sql + " , PrecioTarjeta=" + PrecioTarjeta.ToString().Replace(",", ".");
            else
                sql = sql + " , PrecioTarjeta=null";

            sql = sql + " where CodArticulo=" + CodArticulo.ToString();
            cDb.Grabar(sql);
        }

        public Int32 GetStock(Int32 CodArticulo)
        {
            Int32 Stock = 0;
            string sql = "select stock from Articulo where";
            sql = sql + " CodArticulo=" + CodArticulo.ToString();
            DataTable trdo = cDb.GetDatatable(sql);
            if (trdo.Rows.Count > 0)
                if (trdo.Rows[0]["Stock"].ToString() != "")
                    Stock = Convert.ToInt32(trdo.Rows[0]["Stock"].ToString());
            return Stock;
        }

        public void ActualizarStock (SqlConnection con, SqlTransaction Transaccion,
            Int32 CodArticulo,Int32 Cantidad)
        {
            string sql = "Update Articulo set Stock = isnull(stock,0) + " + Cantidad.ToString();
            sql = sql + " where CodArticulo =" + CodArticulo.ToString ();
            cDb.EjecutarNonQueryTransaccion(con, Transaccion, sql);
        }

        public DataTable GetArticuloxCodArt(Int32 CodArt)
        {
            string sql = "select * from Articulo where CodArticulo=" + CodArt.ToString();
            DataTable trdo = cDb.GetDatatable(sql);
            return trdo;
        }

        public DataTable GetDetalleArticulo(string Nombre, string CodigoBarra, string Codigo, string Tabla)
        {
            string sql = "select a.CodArticulo, a.Codigo,a.CodigoBarra,a.Nombre, a.stock ";
            sql = sql + ",Costo,PrecioTarjeta,";
            sql = sql + "(PrecioTarjeta - 0.10*PrecioTarjeta) as Descuento ";
            sql = sql + ",PrecioEfectivo";
            sql = sql + " from " + Tabla  + " a ";
            if (Nombre != "")
            {
                sql = sql + " where a.Nombre like " + "'%" + Nombre + "%'";
            }
            if (CodigoBarra != "")
            {
                sql = sql + " where a.CodigoBarra =" + "'" + CodigoBarra + "'";
            }

            if (Codigo != "")
            {
                sql = sql + " where a.Codigo =" + "'" + Codigo + "'";
            }

            sql = sql + " order by a.Nombre";

            return cDb.GetDatatable(sql);
        }

        public void ActualizarStockResta(SqlConnection con, SqlTransaction Transaccion,Int32 CodArticulo,int Cantidad)
        {
            string sql = " update articulo ";
            sql = sql + " set Stock = isnull(Stock,0) - " + Cantidad.ToString();
            sql = sql + " where CodArticulo=" + CodArticulo.ToString ();
            cDb.EjecutarNonQueryTransaccion(con, Transaccion, sql);
        }

        public DataTable GetTodosArticulos()
        {
            string sql = "select a.CodArticulo,a.Nombre ";
            sql = sql + ",Costo,PrecioTarjeta,";
            sql = sql + "(PrecioTarjeta - 0.10*PrecioTarjeta) as Descuento ";
            sql = sql + ",PrecioEfectivo";
            sql = sql + " from articulo a";
            DataTable trdo = cDb.GetDatatable(sql);
            return trdo;
        }

        public DataTable GetTodosArticulosJuguetes()
        {
            string sql = "select a.CodArticulo,a.Nombre ";
            sql = sql + ",Costo,PrecioTarjeta,";
            sql = sql + "(PrecioTarjeta - 0.10*PrecioTarjeta) as Descuento ";
            sql = sql + ",PrecioEfectivo";
            sql = sql + " from articulo a";
            sql = sql + " Union ";
            sql = "select j.CodArticulo,j.Nombre ";
            sql = sql + ",Costo,PrecioTarjeta,";
            sql = sql + "(PrecioTarjeta - 0.10*PrecioTarjeta) as Descuento ";
            sql = sql + ",PrecioEfectivo";
            sql = sql + " from Juguete j";
            DataTable trdo = cDb.GetDatatable(sql);
            return trdo;
        }
    }
}
