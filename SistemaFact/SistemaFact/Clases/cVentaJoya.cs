using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
namespace SistemaFact.Clases
{
    public  class cVentaJoya
    {
        public Int32 InsertarVenta(SqlConnection con, SqlTransaction Transaccion,Int32? CodVendedor, DateTime Fecha)
        {
            cFunciones fun = new cFunciones();
            string sql = "insert into Venta(CodVendedor,Fecha)";
            if (CodVendedor != null)
                sql = sql + " values(" + CodVendedor.ToString();
            else
                sql = sql + " Values(null";
            sql = sql + "," + "'" + fun.FormatoFechaDMA(Fecha) + "'";
            sql = sql + ")";
            return cDb.EjecutarEscalarTransaccion(con, Transaccion, sql);
        }

        public void InsertarDetalleVenta(SqlConnection con, SqlTransaction Transaccion, Int32 CodVenta,Int32 CodJoya, double Cantidad, Double Precio)
        {
            string sql = " insert into DetalleVenta(CodVenta,CodJoya,Cantidad,Precio)";
            sql = sql + " values (" + CodVenta.ToString();
            sql = sql + "," + CodJoya.ToString();
            sql = sql + "," + Cantidad.ToString().Replace(",", ".");
            sql = sql + "," + Precio.ToString().Replace(",", ".");
            sql = sql + ")";
            cDb.EjecutarNonQueryTransaccion(con, Transaccion, sql);
        }

    }
}
