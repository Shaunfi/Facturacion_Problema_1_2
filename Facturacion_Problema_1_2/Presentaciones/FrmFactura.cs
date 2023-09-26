using Facturacion_Problema_1_2.Datos;
using Facturacion_Problema_1_2.Datos.Implementacion;
using Facturacion_Problema_1_2.Datos.Servicio;
using Facturacion_Problema_1_2.Entidades;
using Facturacion_Problema_1_2.Factory;
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
using System.Xml.Linq;

namespace Facturacion_Problema_1_2.Presentaciones
{
    public partial class FrmFactura : Form
    {
        private Facturas factura;

        private IServicio servicio;
        
        public FrmFactura(FabricarServicio fabrica)
        {
            InitializeComponent();
            factura = new Facturas();
            servicio = fabrica.CrearServicio();
        }

        private void FrmFactura_Load(object sender, EventArgs e)
        {
            btnConfirmar.Enabled = false;
            btnCancelar.Enabled = false;
            CargarComboBox(cboBoxCliente, "codCliente", "nombre", servicio.ListarClientes().ToArray());
            CargarComboBox(cboBoxArticulo, "idArticulo", "descripcion", servicio.ListarArticulos().ToArray());
            CargarCombo(cboBoxFormasPago, "id_forma_pago", "forma_pago", "SP_CONSULTAR_TABLA_FormasPago");
            Limpiar();
        }

        private void CargarComboBox(ComboBox combo, string valorID, string valorDisplay, object[] objects)
        {
            combo.DataSource = objects;
            combo.ValueMember = valorID;
            combo.DisplayMember = valorDisplay;
            combo.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void CargarCombo(ComboBox combo, string valorID, string valorDisplay, string nombreSP) // Se supone que esto estaria mal pero no voy hacer una clase para FormasPago
        {
            DataTable tabla = AccesoDatosDAO.ObtenerInstancia().ProcedureReader(nombreSP);

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
                total += df.CalcularPrecio();
            }
            labelTotal.Text = total.ToString();
        }

        private bool Validar()
        {
            if (Convert.ToInt32(cboBoxCliente.SelectedIndex) < 0)
            {
                MessageBox.Show("No se ha cargado un cliente.", "VALIDACION", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }

            if (Convert.ToInt32(cboBoxArticulo.SelectedIndex) < 0)
            {
                MessageBox.Show("No se ha cargado un articulo.", "VALIDACION", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }

            if (Convert.ToInt32(cboBoxFormasPago.SelectedIndex) < 0)
            {
                MessageBox.Show("No se ha cargado una forma de pago.", "VALIDACION", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;   
            }

            return true;
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            Clientes cliente = (Clientes)cboBoxCliente.SelectedItem;

            if (Validar())
            {
                if (factura.Cliente == null)
                {
                    if (MessageBox.Show($"Seguro quiere seleccionar el cliente {cliente.Apellido} {cliente.Nombre} ?", "Confirmar Cliente", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Cancel)
                    {
                        cboBoxCliente.SelectedIndex = -1;
                        return;
                    }

                    cboBoxCliente.Enabled = false;

                    factura.Cliente = cliente;
                }

                Articulos articulo = (Articulos)cboBoxArticulo.SelectedItem;

                foreach (DataGridViewRow row in dgvDetalles.Rows)
                {
                    if (Convert.ToInt32(row.Cells["cIdIdArticulo"].Value) == articulo.IdArticulo) 
                    {
                        if (Convert.ToInt32(row.Cells["cIdCantidad"].Value) + Convert.ToInt32(numCantidad.Value) < 20)
                        {
                            if (MessageBox.Show($"Ya esta en la lista ese articulo. Desea agregar {numCantidad.Value} unidades al articulo {articulo.Descripcion} ?", "Error", MessageBoxButtons.OKCancel, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1) == DialogResult.OK)
                            {

                                foreach (DetallesFactura df in factura.LDetalle)
                                {
                                    if (Convert.ToInt32(row.Cells[0].Value) == df.Articulo.IdArticulo)
                                    {
                                        df.Cantidad += Convert.ToInt32(numCantidad.Value);
                                        row.Cells["cIdCantidad"].Value = df.Cantidad;
                                        row.Cells["cIdPrecio"].Value = $"$ {df.CalcularPrecio()}";
                                        CalcularTotal();
                                        return;
                                    }
                                }
                            }
                            else
                            {
                                return;
                            }
                        }
                        else
                        {
                            MessageBox.Show("No se pueden cargar mas de 20 unidades por un articulo.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                            return;
                        }
                    }
                }

                DetallesFactura detalle = new DetallesFactura();

                detalle.Articulo = articulo;
                detalle.Cantidad = Convert.ToInt32(numCantidad.Value);

                factura.LDetalle.Add(detalle);

                dgvDetalles.Rows.Add(new object[] { detalle.Articulo.IdArticulo ,detalle.Articulo.Descripcion, detalle.Cantidad, $"$ {detalle.CalcularPrecio()}", "Quitar" });

                CalcularTotal();
            }
        }

        private void dgvDetalles_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvDetalles.CurrentCell.ColumnIndex == 4)
            {
                factura.QuitarDetalle(dgvDetalles.CurrentRow.Index);
                dgvDetalles.Rows.RemoveAt(dgvDetalles.CurrentRow.Index);
                CalcularTotal();
            }
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            if (factura.LDetalle.Count > 0) 
            {
                if (MessageBox.Show($"Quiere dar la factura por finalizada ?", "Confirmar Factura", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.OK)
                {
                    factura.FormaPago = Convert.ToInt32(cboBoxFormasPago.SelectedValue);
                    if (servicio.CrearFactura(factura))
                    {
                        MessageBox.Show("La factura ha sido agregado con exito.", "CONFIRMACION", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        
                    }
                    else
                    {
                        MessageBox.Show("La factura ha fallado al agregarse.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    if (MessageBox.Show($"Desea salir ?", "Salir", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.OK)
                    {
                        this.Close();
                    }
                }
            }
            else
            {
                MessageBox.Show("No puede confirmar la factura sin detalles", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Seguro quiere cancelar la factura ?", "FACTURA", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.OK)
            {
                this.Close();
            }
        }

        private void dgvDetalles_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            if (dgvDetalles.Rows.Count == 1)
            {
                btnConfirmar.Enabled = true;
                btnCancelar.Enabled = true;
            }
        }

        private void dgvDetalles_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            if (dgvDetalles.Rows.Count == 0)
            {
                btnConfirmar.Enabled = false;
                btnCancelar.Enabled = false;
            }
        }
    }
}
