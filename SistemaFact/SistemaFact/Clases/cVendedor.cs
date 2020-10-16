using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
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
    }
}
