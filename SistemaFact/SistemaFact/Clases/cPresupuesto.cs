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
           , Int32? CodVendedor,DateTime? FechaRendicion)
        {
            cFunciones fun = new cFunciones();
            string sql = " insert into Presupuesto(Total,Fecha,CodVendedor";
            sql = sql + ",FechaRendicion,FechaRendicionTexto)";
            sql = sql + " values (" + Total.ToString().Replace(",", ".");
            sql = sql + "," + "'" + Fecha.ToShortDateString() + "'";
            

            if (CodVendedor  != null)
                sql = sql + "," + CodVendedor.ToString();
            else
                sql = sql + ",null";
           if (FechaRendicion !=null)
           {
                sql = sql + "," + "'" + fun.FormatoFechaDMA(Convert.ToDateTime(FechaRendicion)) + "'";
                sql = sql + "," + "'" + fun.FormatoFechaDMA(Convert.ToDateTime(FechaRendicion)) + "'";
            }
           else
            {
                sql = sql + ",null,null";
            }
                
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
           Int32 CodJoya,Double SubTotal,int Orden)
        {
            string sql = " insert into DetallePresupuesto(CodPresupuesto,CodJoya,Cantidad,Precio,SubTotal,Orden)";
            sql = sql + " values (" + CodPresupuesto.ToString();
            sql = sql + "," + CodJoya.ToString();
            sql = sql + "," + Cantidad.ToString().Replace(",", ".");
            sql = sql + "," + Precio.ToString().Replace(",", ".");
            sql = sql + "," + SubTotal.ToString().Replace(",", ".");
            sql = sql + "," + Orden.ToString();
            sql = sql + ")";
            cDb.EjecutarNonQueryTransaccion(con, Transaccion, sql);
        }

        public DataTable GetPresupuestoxFecha(DateTime FechaDesde,DateTime FechaHasta,string Apellido)
        {
            cFunciones fun = new cFunciones();
            string sql = "select p.CodPresupuesto,p.Fecha,v.Apellido,v.Nombre,p.Total";
            sql = sql + " from Presupuesto p, Vendedor v";
            sql = sql + " where p.CodVendedor=v.CodVendedor";
            sql = sql + " and p.Fecha>=" + "'" + fun.FormatoFechaDMA(FechaDesde) + "'";
            sql = sql + " and p.Fecha<=" + "'" + fun.FormatoFechaDMA(FechaHasta) + "'";
            if (Apellido != "")
                sql = sql + " and v.Apellido like " + "'%" + Apellido  +"%'";
            sql = sql + " order by p.CodPresupuesto desc";
            return cDb.GetDatatable(sql);
        }

        public void ActualizarProcesado(SqlConnection con, SqlTransaction Transaccion, Int32 CodPresupuesto)
        {
            string sql = "Update Presupuesto set Procesado = 1 ";
            sql = sql + " where CodPresupuesto=" + CodPresupuesto.ToString();
            cDb.EjecutarNonQueryTransaccion(con, Transaccion, sql);
        }

        public DataTable GetPresupuestoxCodigo(Int32 CodPresupuesto)
        {
            string sql = "select * from Presupuesto ";
            sql = sql + " where CodPresupuesto=" + CodPresupuesto.ToString();
            return cDb.GetDatatable(sql);
        }
    }
}
