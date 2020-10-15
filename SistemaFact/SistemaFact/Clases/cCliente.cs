using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
namespace SistemaFact.Clases
{
    public class cCliente
    {
        public DataTable GetClientexCodigo(Int32 CodCliente)
        {
            string sql = "select * from cliente where CodCliente =" + CodCliente.ToString();
            return cDb.GetDatatable(sql);
        }

        public Int32 InsertarClienteTran(SqlConnection con, SqlTransaction Transaccion, string Apellido, string Nombre, string Telefono, int? CodTipoDoc, string NroDocumento,string Cuit,string Direccion)
        {
            string sql = "Insert into Cliente";
            sql = sql + "(Nombre,Apellido,Telefono,CodTipoDoc,NroDocumento,Cuit,Direccion)";
            sql = sql + " values (";
            sql = sql + "'" + Nombre + "'";
            sql = sql + "," + "'" + Apellido + "'";
            sql = sql + "," + "'" + Telefono + "'";
            
            if (CodTipoDoc != null)
                sql = sql + "," + CodTipoDoc.ToString();
            else
                sql = sql + ",null";
            sql = sql + "," + "'" + NroDocumento + "'";
            sql = sql + "," + "'" + Cuit + "'";
            sql = sql + "," + "'" + Direccion + "'";
            sql = sql + ")";
            return cDb.EjecutarEscalarTransaccion(con, Transaccion, sql);
        }

        public void ModificarClienteTran(SqlConnection con, SqlTransaction Transaccion, Int32 CodCliente, string Apellido, string Nombre,  string Telefono, int? CodTipoDoc, string NroDocumento,string Cuit,string Direccion)
        {
            string sql = "Update Cliente ";
            sql = sql + "set Nombre =" + "'" + Nombre + "'";
            sql = sql + " ,Apellido =" + "'" + Apellido + "'";
            sql = sql + ", Telefono =" + "'" + Telefono + "'";
            
            if (CodTipoDoc != null)
                sql = sql + ",CodTipoDoc=" + CodTipoDoc.ToString();
            else
                sql = sql + ",CodTipoDoc =null";
            sql = sql + ",NroDocumento=" + "'" + NroDocumento + "'";
            sql = sql + ",Cuit=" + "'" + Cuit + "'";
            sql = sql + ",Direccion=" + "'" + Direccion + "'";  
            sql = sql + " where CodCliente =" + CodCliente.ToString();


            cDb.EjecutarNonQueryTransaccion(con, Transaccion, sql);

        }

       

        public DataTable GetClientesxNroDocumento(string NroDocumento)
        {
            string sql = "select * from cliente where NroDocumento =" + "'" + NroDocumento + "'";
            return cDb.GetDatatable(sql);
        }

        public DataTable GetClientesxCuit(string Cuit)
        {
            string sql = "select * from cliente where Cuit  =" + "'" + Cuit + "'";
            return cDb.GetDatatable(sql);
        }

        public DataTable GetClientexNomApe(string Nombre, String Apellido)
        {
            string sql = "select * from cliente";
            sql = sql + " where Nombre like " + "'%" + Nombre + "%'";
            sql = sql + " and apellido like " + "'%" + Apellido + "%'";
            return cDb.GetDatatable(sql);
        }

        public void BorrarCliente(Int32 CodCliente)
        {
            string sql = "Delete from cliente where CodCliente=" + CodCliente.ToString();
            cDb.Grabar(sql);
        }

        public Int32 GetCodClienteNulo()
        {
            Int32 CodigoCliente = -1;
            int ban = 0;
            string sql = "select CodCliente";
            sql = sql + " from Cliente ";
            sql = sql + " where ClienteNulo = 1";
            DataTable trdo = cDb.GetDatatable(sql);
            if (trdo.Rows.Count > 0)
            {
                if (trdo.Rows[0]["CodCliente"].ToString() != "")
                {
                    CodigoCliente = Convert.ToInt32(trdo.Rows[0]["CodCliente"].ToString());
                    ban = 1;
                }
            }
            if (ban == 0)
            {
                sql = "Insert into Cliente(ClienteNulo)";
                sql = sql + "values(1)";
                CodigoCliente = cDb.EjecutarEscalar(sql);
            }
            return CodigoCliente;
        }
    }
}
