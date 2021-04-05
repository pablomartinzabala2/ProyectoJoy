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
        public Int32 InsertarVenta(SqlConnection con, SqlTransaction Transaccion,Int32? CodVendedor, DateTime Fecha, 
            Int32 CodPresupuesto,Double Total,Double TotalComision,Double TotalVentaComision)
        {
            cFunciones fun = new cFunciones();
            string sql = "insert into Venta(CodVendedor,Fecha,CodPresupuesto,Total,TotalComision,TotalVentaComision)";
            if (CodVendedor != null)
                sql = sql + " values(" + CodVendedor.ToString();
            else
                sql = sql + " Values(null";
            sql = sql + "," + "'" + fun.FormatoFechaDMA(Fecha) + "'";
            sql = sql + "," + CodPresupuesto.ToString();
            sql = sql + "," + Total.ToString().Replace(",", ".");
            sql = sql + "," + TotalComision.ToString().Replace(",", ".");
            sql = sql + "," + TotalVentaComision.ToString().Replace(",", ".");
            sql = sql + ")";
            return cDb.EjecutarEscalarTransaccion(con, Transaccion, sql);
        }

        public void InsertarDetalleVenta(SqlConnection con, SqlTransaction Transaccion, Int32 CodVenta,Int32 CodJoya, double Cantidad, Double Precio,Int32 CodRegistro,Double Comision)
        {
            Double SubTotal = Precio * Cantidad;
            string sql = " insert into DetalleVenta(CodVenta,CodJoya,Cantidad,Precio,CodRegistro,Comision,SubTotal)";
            sql = sql + " values (" + CodVenta.ToString();
            sql = sql + "," + CodJoya.ToString();
            sql = sql + "," + Cantidad.ToString().Replace(",", ".");
            sql = sql + "," + Precio.ToString().Replace(",", ".");
            sql = sql + "," + CodRegistro.ToString();
            sql = sql + "," + Comision.ToString().Replace(",", ".");
            sql = sql + "," + SubTotal.ToString().Replace(",", ".");
            sql = sql + ")";
            cDb.EjecutarNonQueryTransaccion(con, Transaccion, sql);
        }

        public DataTable GetVentasxFecha(DateTime FechaDesde, DateTime FechaHasta)
        {
            string sql = "select v.CodVenta,v.Fecha";
            sql = sql + ",(select ve.Apellido from Vendedor ve where ve.CodVendedor = v.CodVendedor) as Apellido";
            sql = sql + ",(select ve.Nombre from Vendedor ve where ve.CodVendedor = v.CodVendedor) as Nombre";
            sql = sql + " from Venta v ";
            sql = sql + " where Fecha>=" + "'" + FechaDesde.ToShortDateString() + "'";
            sql = sql + " and Fecha <=" + "'" + FechaHasta.ToShortDateString() + "'";
            sql = sql + " order by v.CodVenta desc";
            return cDb.GetDatatable(sql);
        }

        public DataTable GetVentaxCodVenta(Int32 CodVenta)
        {
            string sql = " select *";
            sql = sql + " from Venta v,Vendedor ve, DetalleVenta dv,Joya j";
            sql = sql + " where v.CodVendedor=ve.CodVendedor";
            sql = sql + " and v.Codventa= dv.CodVenta";
            sql = sql + " and dv.CodJoya=j.CodJoya";
            sql = sql + " and v.CodVenta=" + CodVenta.ToString();
            return cDb.GetDatatable(sql);
        }

        public DataTable GetResumenVentasxFecha(DateTime FechaDesde, DateTime FechaHasta, Int32? CodTipo)
        {
            string sql = " select t.nombre,count(v.Total) as Cantidad,sum(dv.Precio) as Total";
            sql = sql + " from Venta v,Tipo t,DetalleVenta dv, Joya j";
            sql = sql + " where v.CodVenta=dv.CodVenta";
            sql = sql + " and dv.CodJoya=j.CodJoya";
            sql = sql + " and j.CodTipo=t.CodTipo";
            sql = sql + " and Fecha>=" + "'" + FechaDesde.ToShortDateString() + "'";
            sql = sql + " and Fecha <=" + "'" + FechaHasta.ToShortDateString() + "'";
            if (CodTipo != null)
                sql = sql + " and t.CodTipo=" + CodTipo.ToString();
            sql = sql + " group by t.nombre";
            sql = sql + " order by t.nombre";
            return cDb.GetDatatable(sql);
        }

    }
}
