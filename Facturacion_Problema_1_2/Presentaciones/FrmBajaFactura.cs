using Facturacion_Problema_1_2.Datos;
using Facturacion_Problema_1_2.Datos.Implementacion;
using Facturacion_Problema_1_2.Datos.Servicio;
using Facturacion_Problema_1_2.Entidades;
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
    public partial class FrmBajaFactura : Form
    {
        private IServicio servicio;

        public FrmBajaFactura(FabricarServicio fabrica)
        {
            InitializeComponent();
            servicio = fabrica.CrearServicio();
        }

        private void FrmBajaFactura_Load(object sender, EventArgs e)
        { 
            CargarComboBox(cboBoxCliente, "cod_cliente", "nombre_completo", "SP_CONSULTAR_TABLA_Clientes");
        }

        private void CargarComboBox(ComboBox combo, string valorID, string valorDisplay, string nombreSP)
        {
            DataTable tabla = AccesoDatosDAO.ObtenerInstancia().ProcedureReader(nombreSP);

            combo.DataSource = tabla;
            combo.ValueMember = valorID;
            combo.DisplayMember = valorDisplay;
            combo.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void lstFacturas_DoubleClick(object sender, EventArgs e)
        {
            if (lstFacturas.SelectedItem != null)
            {
                Facturas factura = (Facturas)lstFacturas.SelectedItem;
                if (MessageBox.Show($"Desea eliminar la factura {factura.NroFactura} ?", "ELIMINAR", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.OK)
                {
                    if (servicio.BajaFactura(factura))
                    {
                        lstFacturas.Items.Remove(lstFacturas.SelectedItem);
                        MessageBox.Show("Factura eliminada con exito.", "CONFIRMACION", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("La factura no se pudo eliminar.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private bool Validar()
        {
            if (cboBoxCliente.SelectedIndex == -1)
            {
                MessageBox.Show("No ingreso un cliente.", "VALIDACION", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return false;
            }
            if (dtpFecha.Value < Convert.ToDateTime("01/01/2023") || dtpFecha.Value > DateTime.Now)
            {
                MessageBox.Show($"No ingreso una fecha valida (01/01/2023 -> {DateTime.Today.ToString("dd/MM/yyyy")})", "VALIDACION", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return false;
            }
            return true;
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (Validar())
            {
                DataRowView c = (DataRowView)cboBoxCliente.SelectedItem;

                Clientes cliente = new Clientes();

                cliente.CodCliente = Convert.ToInt32(c.Row.ItemArray[0]);
                cliente.Apellido = c.Row.ItemArray[1].ToString();
                cliente.Nombre = c.Row.ItemArray[2].ToString();

                CargarLista(cliente, dtpFecha.Value);
            }
        }

        private void CargarLista(Clientes cliente, DateTime fecha)
        {
            lstFacturas.Items.Clear();
            servicio.ListarFacturas(cliente, fecha).ForEach((factura) => lstFacturas.Items.Add(factura) );
        }
    }
}
