using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
namespace SistemaFact.Clases
{
   public  class cCompra
    {
        public Int32 GrabarCompra(SqlConnection con, SqlTransaction Transaccion,DateTime Fecha,Double Total)
        {
            string sql = "insert into Compra(Fecha,Total";
            sql = sql + ")";
            sql = sql + " values(" + "'" + Fecha.ToShortDateString() + "'";
            sql = sql + "," + Total.ToString().Replace(",", ".");
            sql = sql + ")";
            return cDb.EjecutarEscalarTransaccion(con, Transaccion, sql);
        }

        public DataTable GetComprasxFecha(DateTime FechaDesde,DateTime FechaHasta)
        {
            string sql = "select c.CodCompra,c.Fecha,c.Total ";
            sql = sql + " from Compra c ";
            sql = sql + " where c.Fecha>=" + "'" + FechaDesde.ToShortDateString() + "'";
            sql = sql + " and c.Fecha<=" + "'" + FechaHasta.ToShortDateString() + "'";
            return cDb.GetDatatable(sql); 
        }
    }
}
