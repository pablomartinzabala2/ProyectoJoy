using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
namespace SistemaFact.Clases
{
    public  class cDetalleCompra
    {
        public void Insertar(SqlConnection con, SqlTransaction Transaccion,Int32 CodCompra,Int32 CodArticulo,
            int Cantidad,Double Costo, Double Descuento, Double Subtotal)
        {
            string sql = "insert into DetalleCompra(";
            sql = sql + "CodCompra,CodArticulo,Cantidad,Costo,";
            sql = sql + "Descuento,Subtotal";
            sql = sql + ")";
            sql = sql + " Values(" + CodCompra.ToString();
            sql = sql + "," + CodArticulo.ToString();
            sql = sql + "," + Cantidad.ToString();
            sql = sql + "," + Costo.ToString().Replace(",", ".");
            sql = sql + "," + Descuento.ToString().Replace(",", ".");
            sql = sql + "," + Subtotal.ToString().Replace(",", ".");
            sql = sql + ")";
            cDb.EjecutarNonQueryTransaccion(con, Transaccion, sql);
        }

        public DataTable GetDetallexId(Int32 CodCompra)
        {
            string sql = "select d.*,a.Nombre ";
            sql = sql + " from DetalleCompra d,Articulo a";
            sql = sql + " where d.CodArticulo = a.CodArticulo";
            sql = sql + " and CodCompra=" + CodCompra.ToString();
            return cDb.GetDatatable(sql);
        }
        
    }
}
