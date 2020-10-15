using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace SistemaFact.Clases
{
    public  class cJuguete
    {
        public DataTable GetArticulo(string Nombre, string CodigoBarra, string Codigo)
        {
            string sql = "select a.CodArticulo, a.Codigo,a.CodigoBarra,a.Nombre, a.stock ";
            sql = sql + ",Costo,PrecioEfectivo,PrecioTarjeta";
            sql = sql + " from juguete a";
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

            return cDb.GetDatatable(sql);
        }

        public DataTable GetDetalleArticulo(string Nombre, string CodigoBarra, string Codigo, Int32? CodMarca )
        {
            int b = 0;
            string sql = "select a.CodArticulo, a.Codigo,a.CodigoBarra,a.Nombre, a.stock ";
            sql = sql + ",Costo,PrecioTarjeta,";
            sql = sql + "(PrecioTarjeta - 0.10*PrecioTarjeta) as Descuento ";
            sql = sql + ",PrecioEfectivo";
            sql = sql + " from Juguete a ";
            if (Nombre != "")
            {
                b = 1;
                sql = sql + " where a.Nombre like " + "'%" + Nombre + "%'";
            }
            if (CodigoBarra != "")
            {
                b = 1;
                sql = sql + " where a.CodigoBarra =" + "'" + CodigoBarra + "'";
            }

            if (Codigo != "")
            {
                b = 1;
                sql = sql + " where a.Codigo =" + "'" + Codigo + "'";
            }

            if (CodMarca !=null)
            {
                if (b ==0)
                    sql = sql + " where CodMarca=" + CodMarca.ToString();
                else
                    sql = sql + " and CodMarca=" + CodMarca.ToString();
            }

            sql = sql + " order by a.Nombre";

            return cDb.GetDatatable(sql);
        }

        public DataTable GetTodosJuguetes()
        {
            string sql = "select a.CodArticulo,a.Nombre ";
            sql = sql + ",Costo,PrecioTarjeta";
            sql = sql + ",PrecioEfectivo";
            sql = sql + " from Juguete a";
            DataTable trdo = cDb.GetDatatable(sql);
            return trdo;
        }

        public void ActualizarStockResta(SqlConnection con, SqlTransaction Transaccion, Int32 CodArticulo, int Cantidad)
        {
            string sql = " update Juguete ";
            sql = sql + " set Stock = isnull(Stock,0) - " + Cantidad.ToString();
            sql = sql + " where CodArticulo=" + CodArticulo.ToString();
            cDb.EjecutarNonQueryTransaccion(con, Transaccion, sql);
        }

        public DataTable GetArticuloxCodArt(Int32 CodArt)
        {
            string sql = "select * from Juguete where CodArticulo=" + CodArt.ToString();
            DataTable trdo = cDb.GetDatatable(sql);
            return trdo;
        }
    }
}
