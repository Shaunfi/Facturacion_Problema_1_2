using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facturacion_Problema_1_2.Entidades
{
    internal class DetallesFactura
    {
        private Articulos articulos;
        private int cantidad;
        private double precio;

        public DetallesFactura(Articulos articulos, int cantidad, double precio)
        {
            this.articulos = articulos;
            this.cantidad = cantidad;
            this.precio = precio;
        }

        public DetallesFactura()
        {
            articulos = null;
            cantidad = 0;
            precio = 0;
        }

        public Articulos IdArticulo { get => articulos; set => articulos = value; }
        public int Cantidad { get => cantidad; set => cantidad = value; }
        public double Precio { get => precio; set => precio = value; }
    }
}
