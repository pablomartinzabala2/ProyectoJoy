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
          //  string cadena = "Data Source=NTBK\\SQLEXPRESS;Initial Catalog=LIBRERIA;Integrated Security=True";
            return cadena;
        }
    }
}
