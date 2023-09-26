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
    public partial class FrmNuevoArticulo : Form
    {
        private IServicio servicio;

        public FrmNuevoArticulo(FabricarServicio fabrica)
        {
            InitializeComponent();
            servicio = fabrica.CrearServicio();
        }

        private void FrmNuevoArticulo_Load(object sender, EventArgs e)
        {
            CargarLista();
            Limpiar();
        }

        private void CargarLista()
        {
            lstArticulos.Items.Clear();

            servicio.ListarArticulos().ForEach((articulo) => lstArticulos.Items.Add(articulo));
        }

        private void Limpiar()
        {
            numPrecio.Value = 1;
            numUnidades.Value = 1;
            txtBoxDescripcion.Text = String.Empty;
        }

        private bool Validar()
        {
            if (numPrecio.Value < 0)
            {
                MessageBox.Show("Precio Vacio", "Validaciones", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (numUnidades.Value < 0)
            {
                MessageBox.Show("Unidades Vacias", "Validaciones", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (txtBoxDescripcion.Text == String.Empty)
            {
                MessageBox.Show("Descripcion Vacia", "Validaciones", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (Validar())
            {
                Articulos articulo = new Articulos();

                articulo.Descripcion = $"{txtBoxDescripcion.Text} x {numUnidades.Value}U";
                articulo.PrecioUnitario = Convert.ToDouble(numPrecio.Value);

                if (servicio.AgregarArticulo(articulo))
                {
                    MessageBox.Show("El articulo ha si agregado con exito.", "CONFIRMACION", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("El articulo no se ha agregado.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                Limpiar();
                CargarLista();
            }
        }
    }
}
