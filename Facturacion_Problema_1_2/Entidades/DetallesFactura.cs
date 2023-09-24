using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facturacion_Problema_1_2.Entidades
{
    public class DetallesFactura
    {
        private Articulos articulo;
        private int cantidad;

        public DetallesFactura(Articulos articulo, int cantidad)
        {
            this.articulo = articulo;
            this.cantidad = cantidad;
        }

        public DetallesFactura()
        {
            articulo = null;
            cantidad = 0;
        }

        public Articulos Articulo { get => articulo; set => articulo = value; }
        public int Cantidad { get => cantidad; set => cantidad = value; }

        public double CalcularPrecio()
        {
            return articulo.PrecioUnitario * cantidad;
        }
    }
}
