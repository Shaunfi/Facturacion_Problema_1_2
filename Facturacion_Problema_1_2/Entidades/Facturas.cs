using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facturacion_Problema_1_2.Entidades
{
    public class Facturas
    {
        private int nroFactura;
        private int formaPago;
        private DateTime fecha;
        private Clientes cliente;
        private List<DetallesFactura> lDetalle;

        public Facturas(int formaPago, Clientes cliente, int nroFactura)
        {
            this.FormaPago = formaPago;
            this.Fecha = DateTime.Now;
            this.Cliente = cliente;
            this.LDetalle = new List<DetallesFactura>();
            this.nroFactura = nroFactura;
        }

        public Facturas()
        {
            this.nroFactura = 0;
            this.FormaPago = 0;
            this.Fecha = DateTime.Now;
            this.Cliente = null;
            this.LDetalle = new List<DetallesFactura>();
        }

        public int FormaPago { get => formaPago; set => formaPago = value; }
        public DateTime Fecha { get => fecha; set => fecha = value; }
        public Clientes Cliente { get => cliente; set => cliente = value; }
        public List<DetallesFactura> LDetalle { get => lDetalle; set => lDetalle = value; }
        public int NroFactura { get => nroFactura; set => nroFactura = value; }

        public void QuitarDetalle(int posicion)
        {
            LDetalle.RemoveAt(posicion);
        }

        public override string ToString()
        {
            return $"Nro. Factura: {nroFactura} | Fecha: {fecha.ToString("dd / MM / yyyy")}";
        }
    }
}
