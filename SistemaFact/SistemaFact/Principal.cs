using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaFact
{
    public partial class Principal : Form
    {
        public static int CantidadArticulo;
        private int childFormNumber = 0;
        //nombre del campo id
        public static string CampoIdSecundario;
        //nombre del campo descripcion
        public static string CampoNombreSecundario;
        //nombre de la tabla donde se realiza el grabado
        public static string NombreTablaSecundario;
        public static string NombreLabelSecundario;
        //valor del id que genera al insertar
        public static string CampoIdSecundarioGenerado;
        public static Int32 CodUsuarioLogueado;
        public static string NombreUsuarioLogueado;
        public static string CodigoPrincipalAbm;
        public static string CodigoSenia;
        
        public static string OpcionesdeBusqueda;
        public static string TablaPrincipal;
        public static string OpcionesColumnasGrilla;
        public static string ColumnasVisibles;
        public static string ColumnasAncho;
        public static string Comodin;
        public Principal()
        {
            InitializeComponent();
        }

        private void ShowNewForm(object sender, EventArgs e)
        {
            FrmAbmArticulocs childForm = new FrmAbmArticulocs();
            childForm.MdiParent = this;
            childForm.Text = "Window " + childFormNumber++;
            childForm.Show();
        }

        private void OpenFile(object sender, EventArgs e)
        {
            FrmImportarArticulo  childForm = new FrmImportarArticulo();
            childForm.MdiParent = this;
            //childForm.Text = "Window " + childFormNumber++;
            childForm.Show();
        }

        private void SaveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            saveFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            if (saveFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = saveFileDialog.FileName;
            }
        }

        private void ExitToolsStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmConfigurarImpresora childForm = new FrmConfigurarImpresora();
            childForm.MdiParent = this;
            //childForm.Text = "Window " + childFormNumber++;
            childForm.Show();
        }

        private void CutToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void CopyToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void PasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void ToolBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void StatusBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void CascadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.Cascade);
        }

        private void TileVerticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileVertical);
        }

        private void TileHorizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void ArrangeIconsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.ArrangeIcons);
        }

        private void CloseAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form childForm in MdiChildren)
            {
                childForm.Close();
            }
        }

        private void Principal_Load(object sender, EventArgs e)
        {

        }

        private void printSetupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmColor  childForm = new FrmColor();
            childForm.MdiParent = this;
            //childForm.Text = "Window " + childFormNumber++;
            childForm.Show();
        }

        private void openToolStripButton_Click(object sender, EventArgs e)
        {
            FrmListadoArticulo frm = new FrmListadoArticulo();
            frm.MdiParent = this;
            frm.Show();
        }

        private void registrarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmCompra frm = new FrmCompra();
            frm.MdiParent = this;
            frm.Show();
        }

        private void listadoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmListadoCompra frm = new FrmListadoCompra();
            frm.Show();
        }

        private void registrarToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Principal.CodigoPrincipalAbm = null;
            FrmVenta frm = new SistemaFact.FrmVenta();
            frm.MdiParent = this;
            frm.Show();
        }

        private void consultarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmListadoVentas frm = new FrmListadoVentas();
            frm.Show();
        }

        private void helpToolStripButton_Click(object sender, EventArgs e)
        {

        }

        private void saveToolStripButton_Click(object sender, EventArgs e)
        {
            FrmBackUp frm = new SistemaFact.FrmBackUp();
            frm.Show();
        }

        private void tarjetasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmAbmTarjeta frm = new SistemaFact.FrmAbmTarjeta();
            frm.Show();
        }

        private void jugueteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmAbmJuguete form = new SistemaFact.FrmAbmJuguete();
            form.Show();
        }

        private void registrarToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            FrmVentaJuguetes frm = new FrmVentaJuguetes();
            frm.Show();
        }

        private void ventaRapidaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmVentaJuguetes frm = new FrmVentaJuguetes();
            frm.Show();        }

        private void printPreviewToolStripButton_Click(object sender, EventArgs e)
        {

        }

        private void marcasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmAbmMarca form = new SistemaFact.FrmAbmMarca();
            form.Show();
        }

        private void categoriaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmAnmTipoJoya frm = new FrmAnmTipoJoya();
            frm.Show();
        }

        private void crearToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmPresupuesto frm = new SistemaFact.FrmPresupuesto();
            frm.Show();
        }
    }
}
