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
        private double precio;

        public DetallesFactura(Articulos articulo, int cantidad, double precio)
        {
            this.articulo = articulo;
            this.cantidad = cantidad;
            this.precio = precio;
        }

        public DetallesFactura()
        {
            articulo = null;
            cantidad = 0;
            precio = 0;
        }

        public Articulos Articulo { get => articulo; set => articulo = value; }
        public int Cantidad { get => cantidad; set => cantidad = value; }
        public double Precio { get => precio; set => precio = value; }
    }
}
