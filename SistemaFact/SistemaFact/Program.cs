﻿using System;
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
            //   Application.Run(new FrmActualizarPrecioJuguete());
            //         Application.Run(new FrmCompra());
            Application.Run(new Principal ());
            //  Application.Run(new FrmVerReporte());

        }
    }
}
