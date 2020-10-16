using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
namespace SistemaFact.Clases
{
    public  class cProvincia
    {
        public Int32 GetCodxNombre(string Nombre)
        {
            Int32 CodProvincia = -1;
            string sql = " select * from Provincia";
            sql = sql + " where Nombre=" + "'" + Nombre + "'";
            DataTable trdo = cDb.GetDatatable(sql);
            if (trdo.Rows.Count > 0)
            {
                if (trdo.Rows[0]["CodProvincia"].ToString() != "")
                {
                    CodProvincia = Convert.ToInt32(trdo.Rows[0]["CodProvincia"].ToString());
                }
            }
            return CodProvincia;

        }

        public Int32 Insertar(string Nombre)
        {
            string sql = "insert into Provincia(Nombre)";
            sql = sql + " Values(" + "'" + Nombre + "'";
            sql = sql + ")";
            return cDb.EjecutarEscalar(sql);
        }
    }
}
