using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
namespace SistemaFact.Clases
{
    public class cPresupuesto
    {
        public Int32 InsertarPresupuesto(SqlConnection con, SqlTransaction Transaccion, double Total, DateTime Fecha
           , Int32? CodCliente, Double Descuento, Double PorDescuento, Double TotalConDescuento,string FormaPago)
        {
            string sql = " insert into Presupuesto(Total,Fecha,CodCliente";
            sql = sql + ", Descuento,  PorDescuento,TotalConDescuento,FormaPago)";
            sql = sql + " values (" + Total.ToString().Replace(",", ".");
            sql = sql + "," + "'" + Fecha.ToShortDateString() + "'";
            

            if (CodCliente != null)
                sql = sql + "," + CodCliente.ToString();
            else
                sql = sql + ",null";
            sql = sql + "," + Descuento.ToString().Replace(",", ".");
            sql = sql + "," + PorDescuento.ToString().Replace(",", ".");
            sql = sql + "," + TotalConDescuento.ToString().Replace(",", ".");
            sql = sql + "," + "'" + FormaPago + "'";
            sql = sql + ")";
            
            return cDb.EjecutarEscalarTransaccion(con, Transaccion, sql);
        }

        public void ActualizarNroPresupuesto(SqlConnection con, SqlTransaction Transaccion,Int32 CodPresupuesto,string NroPresupuesto)
        {
            string sql = "update Presupuesto ";
            sql = sql + " set NroPresupuesto=" + "'" + NroPresupuesto + "'";
            sql = sql + " where CodPresupuesto=" + CodPresupuesto.ToString();
            cDb.EjecutarNonQueryTransaccion(con, Transaccion, sql);
        }
        public void InsertarDetalle(SqlConnection con, SqlTransaction Transaccion, Int32 CodPresupuesto, double Cantidad, Double Precio,
           Int32 CodArticulo, double Subtotal)
        {
            string sql = " insert into DetallePresupuesto(CodPresupuesto,CodArticulo,Cantidad,Precio,Subtotal)";
            sql = sql + " values (" + CodPresupuesto.ToString();
            sql = sql + "," + CodArticulo.ToString();
            sql = sql + "," + Cantidad.ToString().Replace(",", ".");
            sql = sql + "," + Precio.ToString().Replace(",", ".");
            sql = sql + "," + Subtotal.ToString().Replace(",", ".");
            sql = sql + ")";
            cDb.EjecutarNonQueryTransaccion(con, Transaccion, sql);
        }
    }
}
