using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
namespace SistemaFact.Clases
{
    public class cVendedor
    {
        public void Insertar (string NroDocumento,string Apellido,string Nombre, 
            string Telefono, Int32 CodCiudad,string Direccion)
        {
            string sql = "insert into Vendedor(NroDocumento,Apellido,Nombre,Telefono,CodCiudad,Direccion)";
            sql = sql + " values(" + Texto(NroDocumento.Replace(".",""));
            sql = sql + "," + Texto(Apellido);
            sql = sql + "," + Texto(Nombre);
            sql = sql + "," + Texto(Telefono);
            if (CodCiudad > 0)
                sql = sql + "," + CodCiudad.ToString();
            else
                sql = sql + ",null";
            sql = sql + "," + Texto(Direccion);
            sql = sql + ")";
            cDb.Grabar(sql);
        }

        private string Texto(string t)
        {
            String t2 = "'" + t + "'";
            return t2;
        }

        public Boolean Existe(string NroDocumento)
        {
            Boolean op = false;
            string sql = "select * from vendedor ";
            sql = sql + " where NroDocumento=" + Texto(NroDocumento);
            DataTable trdo = cDb.GetDatatable(sql);
            if (trdo.Rows.Count >0)
            {
                if (trdo.Rows[0]["NroDocumento"].ToString() != "")
                {
                    op = true;
                }
            }

            return op;

        }

        public DataTable GetVendedorxDni(string NroDocumento)
        {
            string sql = "select * ";
            sql = sql + ",(select c.CodProvincia from Ciudad c where c.CodCiudad=v.CodCiudad) as CodProvincia";
            sql = sql + " from vendedor v";
            sql = sql + " where NroDocumento=" + Texto(NroDocumento);
            DataTable trdo = cDb.GetDatatable(sql);
            return trdo;
        }

        public Int32 InsertarVendedorTran(SqlConnection con, SqlTransaction Transaccion, string Apellido, string Nombre, 
            string Telefono, string NroDocumento, string Direccion, Int32? CodCiudad , string DomicilioCompleto)
        {
            
            string sql = "Insert into Vendedor";
            sql = sql + "(Nombre,Apellido,Telefono,NroDocumento,Direccion,CodCiudad,DomicilioCompleto)";
            sql = sql + " values (";
            sql = sql + "'" + Nombre + "'";
            sql = sql + "," + "'" + Apellido + "'";
            sql = sql + "," + "'" + Telefono + "'";
            sql = sql + "," + "'" + NroDocumento + "'";
            sql = sql + "," + "'" + Direccion + "'";
            if (CodCiudad != null)
                sql = sql + "," + CodCiudad.ToString();
            else
                sql = sql + ",null";
            sql = sql + "," + Texto(DomicilioCompleto);
            sql = sql + ")";
            return cDb.EjecutarEscalarTransaccion(con, Transaccion, sql);
        }

        public void ActualizarVendedor(SqlConnection con, SqlTransaction Transaccion,Int32 CodVendedor, string Apellido, string Nombre,
            string Telefono, string NroDocumento, string Direccion, Int32? CodCiudad,string  DomicilioCompleto)
        {
            string sql = "Update Vendedor ";
            sql = sql + " set Apellido=" + Texto(Apellido);
            sql = sql + ",Nombre=" + Texto(Nombre);
            sql = sql + ",NroDocumento=" + Texto(NroDocumento);
            sql = sql + ",Direccion=" + Texto(Direccion);
            sql = sql + ",Telefono=" + Texto(Telefono);
            if (CodCiudad != null)
                sql = sql + ",CodCiudad=" + CodCiudad.ToString();
            else
                sql = sql + ",CodCiudad=null";
            sql = sql + ",DomicilioCompleto=" + Texto(DomicilioCompleto);
            sql = sql + " where CodVendedor=" + CodVendedor.ToString();
            cDb.EjecutarNonQueryTransaccion(con, Transaccion, sql);
        }


        public void ActDomicilio()
        {
            string sql = "select v.*,c.nombre as Ciudad,p.Nombre as Provincia ";
            sql = sql + " from vendedor v,ciudad c,provincia p";
            sql = sql +" where c.CodProvincia=p.CodProvincia";
            DataTable trdo = cDb.GetDatatable(sql);
            string Calle = "";
            string Provincia = "";
            string Ciudad = "";
            Int32 CodVendedor = 0;
            string sql2 = "";
            string DomicilioCompleto = "";
            for (int i=0;i<trdo.Rows.Count;i++)
            {
                Calle = trdo.Rows[i]["Direccion"].ToString();
                Provincia = trdo.Rows[i]["Provincia"].ToString();
                Ciudad = trdo.Rows[i]["Ciudad"].ToString();
                CodVendedor = Convert.ToInt32(trdo.Rows[i]["CodVendedor"]);
                if (Calle != "")
                    DomicilioCompleto = Calle;
                if (Ciudad != "")
                    DomicilioCompleto = DomicilioCompleto +" " + Ciudad;
                if (Provincia != "")
                    DomicilioCompleto = DomicilioCompleto + " " + Provincia;
                sql2 = "Update Vendedor set DomicilioCompleto=" + Texto(DomicilioCompleto);
                sql2 = sql2 + " where CodVendedor=" + CodVendedor.ToString();
                cDb.Grabar(sql2);   
             }
        }

        public DataTable GetVendedorxCodVendedor(Int32 CodVendedor)
        {
            string sql = "select * ";
            sql = sql + ",(select c.CodProvincia from Ciudad c where c.CodCiudad=v.CodCiudad) as CodProvincia";
            sql = sql + " from vendedor v";
            sql = sql + " where CodVendedor=" + CodVendedor.ToString();
            DataTable trdo = cDb.GetDatatable(sql);
            return trdo;
        }

        public DataTable GetVendedorxCodPresupuesto(Int32 CodPresupuesto)
        {
            string sql = " select v.*";
            sql = sql + " from Vendedor v,Presupuesto p";
            sql = sql + " where v.CodVendedor=p.CodVendedor";
            sql = sql + " and p.CodPresupuesto=" + CodPresupuesto.ToString();
            return cDb.GetDatatable(sql);
        }
    }
}
