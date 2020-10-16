using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Office.Interop.Excel;
using System.IO;
using Excel = Microsoft.Office.Interop.Excel;
using SpreadsheetLight;
using SistemaFact.Clases;
namespace SistemaFact
{
    public partial class FrmImportarArticulo : FormBase
    {
        public FrmImportarArticulo()
        {
            InitializeComponent();
        }

        private void FrmImportarArticulo_Load(object sender, EventArgs e)
        {

        }

       

        public void ProcesarExcel()
        {
            string path = @"D:\AG\Archivo.xlsx";
            SLDocument doc = new SLDocument(path);
            int fila = 2;
            while (string.IsNullOrEmpty(doc.GetCellValueAsString(fila,1)))
            {
                string codigo = doc.GetCellValueAsString(fila, 1);
                string codigo2 = doc.GetCellValueAsString(fila, 2);
                fila++;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //
            OpenFileDialog file = new OpenFileDialog();
            if (file.ShowDialog() == DialogResult.OK)
            {
                string ruta = ""; //file.FileName;
                ruta = file.FileName;
                //Imagen.Image = System.Drawing.Image.FromFile(ruta);
                //string RutaGrabar = "e:\\ARCHIVO\\" + file.SafeFileName.ToString();
                // string RutaGrabar = cRuta.GetRuta() + "\\" + file.SafeFileName.ToString();
                txt_Ruta.Text = ruta;
                button1.Enabled = false;
                button1.Text = "Procesando";
                if (RadioJoyas.Checked == true)
                    Leer();
                if (radioVendedoras.Checked == true)
                    LeerVendedores();
                button1.Enabled = true;
                button1.Text = "Procesado";
            }
            else
            {
                txt_Ruta.Text = "";
            }
            //
           
           // LeerVariosArchivosExcel();
        }

        private void Leer()
        {
            Excel.Application xlApp;
            Excel.Workbook xlWorkBook;
            Excel.Worksheet xlWorkSheet;
            Excel.Range range;

            string str="";
            int rCnt=0;
            int cCnt=0;
            int rw = 0;
            int cl = 0;

            string Ruta = txt_Ruta.Text;
           // string Ruta = "C:\\SISTEMA\\LISTA.xlsx";
          //  string Ruta = "D:\\AG\\LISTA.xlsx";
            xlApp = new Excel.Application();
            xlWorkBook = xlApp.Workbooks.Open(Ruta , 0, true, 5, "", "", true, Microsoft.Office.Interop.Excel.XlPlatform.xlWindows, "\t", false, false, 0, true, 1, 0);
            xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);

            range = xlWorkSheet.UsedRange;
            rw = range.Rows.Count;
            cl = range.Columns.Count;
            string  Codigo = "";
            Int32? Id = 0;
            int Stock = 0;
            Double PrecioVenta = 0;
            string Nombre = "";
            string Tipo = "";
            Int32 CodTipo = 0;
            cTipo objTipo = new cTipo();
            cJoya joya = new Clases.cJoya();
            Double? Costo = null;
            cArticulo Articulo = new Clases.cArticulo();
            for (rCnt = 2; rCnt <= rw; rCnt++)
            {
                for (cCnt = 1; cCnt <= cl; cCnt++)
                {
                    txtProceso.Text = rCnt.ToString();
                    switch (cCnt)
                    {
                        case 1:
                            if ((range.Cells[rCnt, cCnt] as Excel.Range).Value2 != null)
                                Id = (Int32)(range.Cells[rCnt, cCnt] as Excel.Range).Value2;
                            break;
                        case 2:
                            if ((range.Cells[rCnt, cCnt] as Excel.Range).Value2 != null)
                                Nombre = (string)(range.Cells[rCnt, cCnt] as Excel.Range).Value2;
                            else
                                Nombre = null;
                            break;
                        case 3:
                            Tipo= (string)(range.Cells[rCnt, cCnt] as Excel.Range).Value2;
                           // string[] vec = tip.Split();
                           // Tipo = vec[0];  
                            break;
                        case 5:
                            if ((range.Cells[rCnt, cCnt] as Excel.Range).Value2 != null)
                            { //Codigo
                                 Codigo = (string)(range.Cells[rCnt, cCnt] as Excel.Range).Value2;
                               // string[] vec = Cod.Split(); ;
                                //Codigo = vec[0]; 
                            }
                                
                            break;
                        case 6:
                            if ((range.Cells[rCnt, cCnt] as Excel.Range).Value2 != null)
                                Stock = (Int32)(range.Cells[rCnt, cCnt] as Excel.Range).Value2;
                            else
                                Stock = 0;
                            break;
                        case 9:
                            if ((range.Cells[rCnt, cCnt] as Excel.Range).Value2 != null)
                                PrecioVenta = (Double)(range.Cells[rCnt, cCnt] as Excel.Range).Value2;
                            else
                                PrecioVenta = 0;
                            break;   
                    }                   
                }
                Nombre = Nombre.Replace("'", "");
                CodTipo = objTipo.GetCodxNombre(Tipo);
                if (CodTipo ==-1)
                {
                    if (Tipo !="")
                        CodTipo = objTipo.Insertar(Tipo);
                }
                if (joya.Existexid (Convert.ToInt32 (Id))==false)
                {
                    joya.Insertar(Nombre, CodTipo, Convert.ToInt32(Id), Stock, PrecioVenta,Codigo);
                }
                
            }
            string msj = "Filas recorridos " + rCnt.ToString();
            MessageBox.Show(msj);
            xlWorkBook.Close(true, null, null);
            xlApp.Quit();

           // Marshal.ReleaseComObject(xlWorkSheet);
           // Marshal.ReleaseComObject(xlWorkBook);
          //  Marshal.ReleaseComObject(xlApp);

        }

        void LeerVariosArchivosExcel()
        {
            //******NOTA TODOS LOS DOCUMENTOS EN LA RUTA DEBEN DE SER ARCHIVOS DE EXCEL****
            string ruta = @"D:\AG";
            Excel.Application exlApp = new Excel.Application();
            Workbook libroExcel;
            Worksheet hojaExcel;
            Range miRango;
            try
            {
                DirectoryInfo di = new DirectoryInfo(ruta);

                //LEER CADA ARCHIVO EN LA RUTA ESPECIFICADA
                foreach (var fi in di.GetFiles())
                {
                    libroExcel = exlApp.Workbooks.Open(ruta + @"\" + fi);

                    //Definimos la hoja a utilizar
                    hojaExcel = (Worksheet)libroExcel.Worksheets.get_Item("Hoja1");
                    try
                    {
                       // int fila = 3;
                       // int columna = 5;
                        int fila = 1;
                        int columna = 1;
                        string val1 = "";
                        miRango = hojaExcel.UsedRange;
                       //       str = (string)(range.Cells[rCnt, cCnt] as Excel.Range).Value;
                        string DATO = (string)(miRango.Cells[fila, columna] as Range).Value2;

                        if (DATO != null)
                        {
                            val1 = "El contenido de la celda es " + DATO;
                        }
                        else
                        {
                            val1 = "LA CELDA ESTA VACIA";
                        }
                        System.Windows.Forms.MessageBox.Show(val1.ToString());
                    }
                    catch (Exception e)
                    {
                        System.Windows.Forms.MessageBox.Show("Error" + e.Message);
                    }
                    finally
                    {
                        // cerrar
                        libroExcel.Close(false);
                        exlApp.Quit();
                    }
                }
            }
            catch (Exception e)
            {
                System.Windows.Forms.MessageBox.Show("Error " + e.Message);
            }
        }

        private void txtProceso_TextChanged(object sender, EventArgs e)
        {

        }

        private void txt_Ruta_TextChanged(object sender, EventArgs e)
        {

        }

        private void LeerVendedores()
        {
            Excel.Application xlApp;
            Excel.Workbook xlWorkBook;
            Excel.Worksheet xlWorkSheet;
            Excel.Range range;

            string str = "";
            int rCnt = 0;
            int cCnt = 0;
            int rw = 0;
            int cl = 0;

            string Ruta = txt_Ruta.Text;
            // string Ruta = "C:\\SISTEMA\\LISTA.xlsx";
            //  string Ruta = "D:\\AG\\LISTA.xlsx";
            xlApp = new Excel.Application();
            xlWorkBook = xlApp.Workbooks.Open(Ruta, 0, true, 5, "", "", true, Microsoft.Office.Interop.Excel.XlPlatform.xlWindows, "\t", false, false, 0, true, 1, 0);
            xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);

            range = xlWorkSheet.UsedRange;
            rw = range.Rows.Count;
            cl = range.Columns.Count;
            string NroDocumento = "";
            string Nombre = "";
            string Apellido = "";
            Double Telefono = 0;
            string Direccion = "";
            string Ciudad = "";
            string Provincia = "";
            Int32 CodProvincia = 0;
            Int32 CodCiudad = 0;
            cProvincia objProvincia = new cProvincia();
            cCiudad objCiudad = new cCiudad();
            cVendedor vend = new cVendedor();

            string Codigo = "";
            Int32? Id = 0;
          
         
            cArticulo Articulo = new Clases.cArticulo();
            for (rCnt = 2; rCnt <= rw; rCnt++)
            {
                for (cCnt = 1; cCnt <= cl; cCnt++)
                {
                    txtProceso.Text = rCnt.ToString();
                    switch (cCnt)
                    {
                        case 1:
                            if ((range.Cells[rCnt, cCnt] as Excel.Range).Value2 != null)
                                Id = (Int32)(range.Cells[rCnt, cCnt] as Excel.Range).Value2;
                            break;
                        case 2:
                            if ((range.Cells[rCnt, cCnt] as Excel.Range).Value2 != null )
                            {
                                 NroDocumento = (string)(range.Cells[rCnt, cCnt] as Excel.Range).Value2;
                                // NroDocumento = NroDocumento.Replace (".","");
                            }

                            else
                                NroDocumento = "";
                            break;
                        case 3:
                            if ((range.Cells[rCnt, cCnt] as Excel.Range).Value2 != null)
                                Nombre = (string)(range.Cells[rCnt, cCnt] as Excel.Range).Value2;
                            else
                                Nombre = "";
                            // string[] vec = tip.Split();
                            // Tipo = vec[0];  
                            break;
                        case 4:
                            if ((range.Cells[rCnt, cCnt] as Excel.Range).Value2 != null)
                            { //Codigo
                                Apellido = (string)(range.Cells[rCnt, cCnt] as Excel.Range).Value2;
                                // string[] vec = Cod.Split(); ;
                                //Codigo = vec[0]; 
                            }
                            else
                                Apellido = "";

                            break;
                      
                        case 8:
                            if ((range.Cells[rCnt, cCnt] as Excel.Range).Value2 != null)
                                Direccion = (string)(range.Cells[rCnt, cCnt] as Excel.Range).Value2;
                            else
                                Direccion = "";
                            break;
                        case 9:
                            if ((range.Cells[rCnt, cCnt] as Excel.Range).Value2 != null)
                                Ciudad = (string)(range.Cells[rCnt, cCnt] as Excel.Range).Value2;
                            else
                                Ciudad = "";
                            break;
                        case 10:
                            if ((range.Cells[rCnt, cCnt] as Excel.Range).Value2 != null)
                                Provincia  = (string)(range.Cells[rCnt, cCnt] as Excel.Range).Value2;
                            else
                                Provincia  = "";
                            break;
                        case 22:
                            if ((range.Cells[rCnt, cCnt] as Excel.Range).Value2 != null)
                                Telefono = (Double)(range.Cells[rCnt, cCnt] as Excel.Range).Value2;
                            else
                                Telefono = 0;
                            break;

                    }
                }
                Nombre = Nombre.Replace("'", "");
                CodProvincia = objProvincia.GetCodxNombre(Provincia);
                if (CodProvincia == -1)
                {
                    if (Provincia != "")
                        CodProvincia = objProvincia.Insertar(Provincia);
                }
                CodCiudad = objCiudad.GetCodxNombre(Ciudad);
                if (CodCiudad == -1)
                {
                    if (Ciudad.Trim () != "")
                        CodCiudad = objCiudad.Insertar(Ciudad, CodProvincia);
                }
                cVendedor ven = new cVendedor();
                if (ven.Existe (NroDocumento) == false)
                {
                    ven.Insertar(NroDocumento, Apellido, Nombre, Telefono.ToString (), CodCiudad, Direccion);
                }
                
            }
            string msj = "Filas recorridos " + rCnt.ToString();
            MessageBox.Show(msj);
            xlWorkBook.Close(true, null, null);
            xlApp.Quit();

            // Marshal.ReleaseComObject(xlWorkSheet);
            // Marshal.ReleaseComObject(xlWorkBook);
            //  Marshal.ReleaseComObject(xlApp);

        }
    }
}
