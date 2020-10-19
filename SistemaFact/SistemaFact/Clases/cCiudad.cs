using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
namespace SistemaFact.Clases
{
    public class cCiudad
    {
        public Int32 GetCodxNombre(string Nombre)
        {
            Int32 CodCiudad = -1;
            string sql = " select * from Ciudad";
            sql = sql + " where Nombre=" + "'" + Nombre + "'";
            DataTable trdo = cDb.GetDatatable(sql);
            if (trdo.Rows.Count > 0)
            {
                if (trdo.Rows[0]["CodCiudad"].ToString() != "")
                {
                    CodCiudad = Convert.ToInt32(trdo.Rows[0]["CodProvincia"].ToString());
                }
            }
            return CodCiudad;

        }

        public Int32 Insertar(string Nombre,int CodProvincia)
        {
            string sql = "insert into Ciudad(Nombre,CodProvincia)";
            sql = sql + " Values(" + "'" + Nombre + "'";
            sql = sql + "," + CodProvincia.ToString();
            sql = sql + ")";
            return cDb.EjecutarEscalar(sql);
        }

        public DataTable GetCiudadxProvincia(Int32 CodProvincia)
        {
            string sql = "select * from Ciudad ";
            sql = sql + " where CodProvincia=" + CodProvincia.ToString();
            sql = sql + " order by Nombre";
            return cDb.GetDatatable(sql);
        }
    }
}
