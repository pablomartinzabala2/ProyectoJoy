using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data;
namespace SistemaFact.Clases
{
    public class cUsuario
    {
        public DataTable GetUsuario(string USUARIO, string CLAVE)
        {
            string sql = "select *";
            sql = sql + " from Usuario";
            sql = sql + " Where Nombre=" + "'" + USUARIO.ToString() + "'";
            sql = sql + " AND Clave=" + "'" + CLAVE + "'";
            return cDb.GetDatatable(sql);
        }

        public string GetNombreUsuarioxCodUsuario(Int32 CodUsuario)
        {
            string user ="";
            string sql = "select * from Usuario";
            sql = sql + " where CodUsuario=" +CodUsuario.ToString ();
            DataTable trdo = cDb.GetDatatable(sql);
            if (trdo.Rows.Count > 0)
                user = trdo.Rows[0]["Nombre"].ToString();
            return user;
        }
    }
}
