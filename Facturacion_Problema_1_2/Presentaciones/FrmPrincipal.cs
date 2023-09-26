using Facturacion_Problema_1_2.Factory;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Facturacion_Problema_1_2.Presentaciones
{
    public partial class FrmPrincipal : Form
    {
        private FabricarServicio fabrica;

        public FrmPrincipal(FabricarServicio fabrica)
        {
            InitializeComponent();
            this.fabrica = fabrica;
        }

        private void FrmPrincipal_Load(object sender, EventArgs e)
        {

        }

        private void nuevaFacturaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new FrmFactura(fabrica).ShowDialog();
        }

        private void nuevoArticuloToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new FrmNuevoArticulo(fabrica).ShowDialog();
        }

        private void nuevoClienteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new FrmNuevoCliente(fabrica).ShowDialog();
        }

        private void bajaFacturaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new FrmBajaFactura(fabrica).ShowDialog();
        }
    }
}
