using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaFact
{
    static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {   
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            // Application.Run(new FrmIngreso());
             //  Application.Run(new FrmVentaJoya());
              //       Application.Run(new Prueba());
            // Application.Run(new Principal ());
              Application.Run(new FrmLogin());

        }
    }
}
