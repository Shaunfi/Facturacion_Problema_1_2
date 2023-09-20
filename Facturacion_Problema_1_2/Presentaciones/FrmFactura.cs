using Facturacion_Problema_1_2.Entidade;
using Facturacion_Problema_1_2.Entidades;
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

        private Clientes cliente;

        private Facturas factura;
        
        public FrmFactura()
        {
            InitializeComponent();
            factura = new Facturas();
            sql = new AccesoDatos(@"Data Source=DESKTOP-BGJJ9MM\SQLEXPRESS;Initial Catalog=FACTURACIONES_1_2;Integrated Security=True");
        }

        private void FrmFactura_Load(object sender, EventArgs e)
        {
            CargarComboBox(cboBoxCliente, "cod_cliente", "nom_cliente", "SP_CONSULTAR_TABLA_Clientes");
            CargarComboBox(cboBoxArticulo, "id_articulo", "descripcion", "SP_CONSULTAR_TABLA_Articulos");
            CargarComboBox(cboBoxFormasPago, "id_forma_pago", "forma_pago", "SP_CONSULTAR_TABLA_FormasPago");
            Limpiar();
        }

        private void CargarComboBox(ComboBox combo, string valorID, string valorDisplay, string nombreSP)
        {
            DataTable tabla = sql.ProcedureReader(nombreSP);

            combo.DataSource = tabla;
            combo.ValueMember = valorID;
            combo.DisplayMember = valorDisplay;
            combo.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void Limpiar()
        {
            cboBoxCliente.SelectedIndex = -1;
            cboBoxArticulo.SelectedIndex = -1;
            cboBoxFormasPago.SelectedIndex = -1;
            numCantidad.Value = 1;
        }
        
        private void CalcularTotal()
        {
            double total = 0;

            foreach (DetallesFactura df in factura.LDetalle)
            {
                total += df.Precio;
            }
            labelTotal.Text = total.ToString();
        }

        private bool Validar()
        {
            if (Convert.ToInt32(cboBoxCliente.SelectedValue) < 0)
                return false;

            if (Convert.ToInt32(cboBoxArticulo.SelectedValue) < 0)
                return false;

            if (Convert.ToInt32(cboBoxFormasPago.SelectedValue) < 0)
                return false;

            return true;
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            DataRowView c = (DataRowView)cboBoxCliente.SelectedItem;

            if (Validar())
            {
                if (cliente == null)
                {
                    if (MessageBox.Show($"Seguro quiere seleccionar el cliente {c.Row.ItemArray[1]} {c.Row.ItemArray[2]} ?", "Confirmar Cliente", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Cancel)
                    {
                        return;
                    }

                    cboBoxCliente.Enabled = false;
                    cliente = new Clientes();

                    cliente.CodCliente = Convert.ToInt32(c.Row.ItemArray[0]);
                    cliente.Apellido = c.Row.ItemArray[1].ToString();
                    cliente.Nombre = c.Row.ItemArray[2].ToString();
                }

                DataRowView a = (DataRowView)cboBoxArticulo.SelectedItem;

                foreach (DataGridViewRow row in dgvDetalles.Rows)
                {
                    if (row.Cells["cIdDescripcion"].Value == a.Row.ItemArray[1])
                    {
                        MessageBox.Show("Ya esta repetido autista.", "AUTISTA", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                        return;
                    }
                }

                foreach (DetallesFactura df in factura.LDetalle)
                {
                    if (df.Articulo.IdArticulo == Convert.ToInt32(a.Row.ItemArray[0]))
                    {
                        MessageBox.Show("Ya esta repetido autista.", "AUTISTA", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                        return;
                    }
                }

                Articulos articulos = new Articulos();

                articulos.IdArticulo = Convert.ToInt32(a.Row.ItemArray[0]);
                articulos.Descripcion = a.Row.ItemArray[1].ToString();
                articulos.PrecioUnitario = Convert.ToDouble(a.Row.ItemArray[2]); ;


                DetallesFactura detalle = new DetallesFactura();

                detalle.Articulo = articulos;
                detalle.Cantidad = Convert.ToInt32(numCantidad.Value);
                detalle.Precio = Convert.ToDouble(articulos.PrecioUnitario * detalle.Cantidad);

                factura.LDetalle.Add(detalle);

                dgvDetalles.Rows.Add(new object[] { detalle.Articulo.Descripcion, detalle.Cantidad, detalle.Precio, "Quitar" });

                CalcularTotal();
            }
        }

        private void dgvDetalles_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvDetalles.CurrentCell.ColumnIndex == 3)
            {
                factura.QuitarDetalle(dgvDetalles.CurrentRow.Index);
                dgvDetalles.Rows.RemoveAt(dgvDetalles.CurrentRow.Index);
                CalcularTotal();
            }
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {

        }
    }
}
