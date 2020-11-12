using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
namespace SistemaFact.Clases
{
    public class cVenta
    {
        public Int32 InsertarVenta(SqlConnection con, SqlTransaction Transaccion, double Total, DateTime Fecha,
            double ImporteEfectivo, double ImporteTarjeta, Int32? CodTarjeta,Int32? CodCliente,
            string cupon,Double Descuento,Double PorDescuento, Double TotalConDescuento)
        {
            string sql = " insert into Venta(Total,Fecha,ImporteEfectivo,ImporteTarjeta,CodTarjeta,CodCliente,cupon";
            sql = sql + ",Descuento,PorDescuento,TotalConDescuento)";
            sql = sql + " values (" + Total.ToString().Replace(",", ".");
            sql = sql + "," + "'" + Fecha.ToShortDateString() + "'";
            sql = sql + "," + ImporteEfectivo.ToString().Replace(",", ".");
            sql = sql + "," + ImporteTarjeta.ToString().Replace(",", ".");
            if (CodTarjeta != null)
                sql = sql + "," + CodTarjeta.ToString();
            else
                sql = sql + ",null";
             
            if (CodCliente != null)
                sql = sql + "," + CodCliente.ToString();
            else
                sql = sql + ",null";
            sql = sql + "," + "'" + cupon + "'";    
            sql = sql + "," + Descuento.ToString().Replace(",", ".");
            sql = sql + "," + PorDescuento.ToString().Replace(",", ".");
            sql = sql + "," + TotalConDescuento.ToString().Replace(",", ".");
            sql = sql + ")";
            return cDb.EjecutarEscalarTransaccion(con, Transaccion, sql);
        }

        public void InsertarDetalleVenta(SqlConnection con, SqlTransaction Transaccion, Int32 CodVenta, double Cantidad, Double Precio,
            Int32 CodArticulo, double Subtotal)
        {
            string sql = " insert into DetalleVenta(CodVenta,CodArticulo,Cantidad,Precio,Subtotal)";
            sql = sql + " values (" + CodVenta.ToString();
            sql = sql + "," + CodArticulo.ToString();
            sql = sql + "," + Cantidad.ToString().Replace(",", ".");
            sql = sql + "," + Precio.ToString().Replace(",", ".");
            sql = sql + "," + Subtotal.ToString().Replace(",", ".");
            sql = sql + ")";
            cDb.EjecutarNonQueryTransaccion(con, Transaccion, sql);
        }

        public DataTable GetVentasxFecha(DateTime FechaDesde, DateTime FechaHasta)
        {
            string sql = "select v.CodVenta,v.Fecha,v.ImporteEfectivo,v.ImporteTarjeta";
            sql = sql + ",(select t.Nombre from Tarjeta t where t.CodTarjeta = v.CodTarjeta) as Tarjeta";
            sql = sql + ", v.Total";
            sql = sql + " from Venta v ";
            sql = sql + " where Fecha>=" + "'" + FechaDesde.ToShortDateString() + "'";
            sql = sql + " and Fecha <=" + "'" + FechaHasta.ToShortDateString() + "'";
            sql = sql + " order by v.CodVenta desc";
            return cDb.GetDatatable(sql);
        }

        public DataTable GetVentaxCodigo(Int32 CodVenta)
        {
            string sql = " select *";
            sql = sql + " from Venta v,DetalleVenta d,Articulo a";
            sql = sql + " where v.CodVenta = d.CodVenta";
            sql = sql + " and d.CodArticulo=a.CodArticulo";
            sql = sql + " and v.CodVenta =" + CodVenta.ToString();
            return cDb.GetDatatable(sql);
        }

        public void BorrarVenta(SqlConnection con, SqlTransaction Transaccion, Int32 CodVenta)
        {

            string sql = "delete from venta where CodVenta=" + CodVenta.ToString();
            cDb.EjecutarNonQueryTransaccion(con, Transaccion, sql);
            sql = "delete from DetalleVenta where CodVenta=" + CodVenta.ToString();
            cDb.EjecutarNonQueryTransaccion(con, Transaccion, sql);
            sql = "delete from movimiento where CodVenta=" + CodVenta.ToString();
            cDb.EjecutarNonQueryTransaccion(con, Transaccion, sql);
        }

        public void InsertarDetalleVentaJuguete(SqlConnection con, SqlTransaction Transaccion, Int32 CodVenta, double Cantidad, Double Precio,
         Int32 CodArticulo, double Subtotal)
        {
            string sql = " insert into DetalleVenta(CodVenta,CodArticulo,Cantidad,Precio,Subtotal)";
            sql = sql + " values (" + CodVenta.ToString();
            sql = sql + "," + CodArticulo.ToString();
            sql = sql + "," + Cantidad.ToString().Replace(",", ".");
            sql = sql + "," + Precio.ToString().Replace(",", ".");
            sql = sql + "," + Subtotal.ToString().Replace(",", ".");
            sql = sql + ")";
            cDb.EjecutarNonQueryTransaccion(con, Transaccion, sql);
        }
        
        public DataTable GetResumenVentas(DateTime FechaDesde, DateTime FechaHasta)
        {
            cFunciones fun = new cFunciones();
            string sql = " SELECT MONTH(FECHA) as Mes, YEAR(FECHA) as Anio,SUM(TOTAL) as Total, ";
            sql = sql + " sum(totalcomision) as TotalComision, sum(TotalVentaComision) as TotalRendido";
            sql = sql + " FROM VENTA ";
            sql = sql +  " where fecha>=" + "'" + fun.FormatoFechaDMA(FechaDesde) + "'";
            sql = sql + " and fecha<=" + "'" + fun.FormatoFechaDMA(FechaHasta) + "'";
            sql = sql + " GROUP BY MONTH(FECHA), YEAR(FECHA)";
            return cDb.GetDatatable(sql);
        }
    
        
    }
}
