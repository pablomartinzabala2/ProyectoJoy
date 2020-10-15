using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
namespace SistemaFact.Clases
{
    public class cTipo
    {
        public Int32 GetCodxNombre(string Nombre)
        {
            Int32 CodTipo = -1;
            string sql = " select * from Tipo";
            sql = sql + " where Nombre=" + "'" + Nombre + "'";
            DataTable trdo = cDb.GetDatatable(sql);
            if (trdo.Rows.Count >0)
            {
                if (trdo.Rows[0]["CodTipo"].ToString ()!="")
                {
                    CodTipo = Convert.ToInt32(trdo.Rows[0]["CodTipo"].ToString());
                }
            }
            return CodTipo;

        }

        public Int32  Insertar (string Nombre)
        {
            string sql = "insert into Tipo(Nombre)";
            sql = sql + " Values(" + "'" + Nombre + "'";
            sql = sql + ")";
           return cDb.EjecutarEscalar(sql);
        }
    }
}
