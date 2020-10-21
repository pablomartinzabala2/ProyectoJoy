using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaFact.Clases
{
    public static class cConexion
    {
        public static string GetConexion()
        {
            //casa
              string cadena = "Data Source=DESKTOP-QKECIIE;Initial Catalog=joy;Integrated Security=True";
            //NTBK\SQLEXPRESS
            //  string cadena = "Data Source=DESKTOP-I0OF5F9\\SQLEXPRESS;Initial Catalog=JOY;Integrated Security=True";
            return cadena;
        }
    }
}
