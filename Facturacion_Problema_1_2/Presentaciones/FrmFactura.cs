using Facturacion_Problema_1_2.Entidade;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Facturacion_Problema_1_2.Presentaciones
{
    public partial class FrmFactura : Form
    {
        private AccesoDatos sql;
        
        public FrmFactura()
        {
            InitializeComponent();
            sql = new AccesoDatos(@"Data Source=DESKTOP-BGJJ9MM\SQLEXPRESS;Initial Catalog=FACTURACIONES_1_2;Integrated Security=True");
        }

        private void FrmFactura_Load(object sender, EventArgs e)
        {
            CargarComboBox(cboBoxCliente, "cod_cliente", "nom_cliente", "SP_CONSULTAR_TABLA_Clientes");
            CargarComboBox(cboBoxArticulo, "id_articulo", "descripcion", "SP_CONSULTAR_TABLA_Articulos");
        }

        private void CargarComboBox(ComboBox combo, string valorID, string valorDisplay, string nombreSP)
        {
            DataTable tabla = sql.ProcedureReader(nombreSP);

            combo.DataSource = tabla;
            combo.ValueMember = valorID;
            combo.DisplayMember = valorDisplay;
            combo.DropDownStyle = ComboBoxStyle.DropDownList;
        }
    }
}
