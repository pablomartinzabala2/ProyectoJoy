using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
namespace SistemaFact.Clases
{
    public  class cJoya
    {
        public void Insertar (string Nombre,Int32?CodTipo,Int32? Id,int Stock,Double PrecioVenta,string Codigo)
        {
            string sql = "insert into Joya(Nombre,CodTipo,Id,Stock,PrecioVenta,Codigo)";
            sql = sql + " values(" + "'" + Nombre +"'";
            if (CodTipo !=null)
            {
                sql = sql + "," + CodTipo.ToString();
            }
            else
            {
                sql = sql + ",null";
            }

            if (Id != null)
            {
                sql = sql + "," + Id.ToString();
            }
            else
            {
                sql = sql + ",null";
            }
            sql = sql + "," + Stock.ToString();
            sql = sql + "," + PrecioVenta.ToString().Replace(",", ".");
            sql = sql + "," + "'" + Codigo + "'";
            sql = sql + ")";
            cDb.Grabar(sql);
        }

        public Boolean Existexid(Int32 Id)
        {
            Boolean Op = false;
            string sql = "select * from Joya where Id=" + Id.ToString();
            DataTable trdo = cDb.GetDatatable(sql);
            if (trdo.Rows.Count >0)
            {
                if (trdo.Rows[0]["Id"].ToString ()!="") 
                {
                    Op = true;
                }
            }
            return Op;
        }

        public DataTable GetJoyas()
        {
            string sql = "select j.CodJoya,j.Codigo,j.Nombre";
            sql = sql + ",(select t.Nombre from Tipo t where t.CodTipo = j.CodTipo) as Tipo";
            sql = sql + ",j.Stock,j.PrecioVenta";
            sql = sql + " from Joya j";
            sql = sql + " order by j.Nombre";
            return cDb.GetDatatable(sql);
        }

        public DataTable GetJoyaxCodigo(string Codigo)
        {
            string sql = "select j.*";
            sql = sql + ",(select t.Nombre from Tipo t where t.CodTipo = j.CodTipo) as Tipo ";
            sql = sql + " from Joya j";
            sql = sql + " where Codigo=" + "'" + Codigo + "'";
            return cDb.GetDatatable(sql);
        }

        public DataTable GetJoyaxCodJoya(Int32 CodJoya)
        {
            string sql = "select j.*";
            sql = sql + ",(select t.Nombre from Tipo t where t.CodTipo = j.CodTipo) as Tipo ";
            sql = sql + " from Joya j";
            sql = sql + " where CodJoya=" + CodJoya.ToString();
            return cDb.GetDatatable(sql);
        }

        public void ActualizarStock(SqlConnection con, SqlTransaction Transaccion,Int32 CodJoya,int Cantidad)
        {
            string sql = "Update Joya set Stock=Stock - " + Cantidad.ToString();
            sql = sql + " where CodJoya=" + CodJoya.ToString();
            cDb.EjecutarNonQueryTransaccion(con, Transaccion, sql);
        }

        public DataTable GetJoyaxCodigoBarra(string CodigoBarra)
        {
            string sql = "select j.*";
            sql = sql + ",(select t.Nombre from Tipo t where t.CodTipo = j.CodTipo) as Tipo ";
            sql = sql + " from Joya j";
            sql = sql + " where CodigoBarra=" + "'" + CodigoBarra + "'";
            return cDb.GetDatatable(sql);
        }


    }
}
