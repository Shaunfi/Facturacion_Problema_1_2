using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facturacion_Problema_1_2.Entidades
{
    internal class Articulos
    {
        private int idArticulo;
        private string descripcion;
        private double precioUnitario;

        public Articulos(int idArticulo, string descripcion, double precioUnitario)
        {
            this.idArticulo = idArticulo;
            this.descripcion = descripcion;
            this.precioUnitario = precioUnitario;
        }

        public Articulos()
        {
            idArticulo = 0;
            descripcion = String.Empty;
            precioUnitario = 0;
        }

        public int IdArticulo { get => idArticulo; set => idArticulo = value; }
        public string Descripcion { get => descripcion; set => descripcion = value; }
    }
}
