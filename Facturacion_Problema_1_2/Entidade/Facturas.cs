﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facturacion_Problema_1_2.Entidades
{
    internal class Facturas
    {
        private int formaPago;
        private DateTime fecha;
        private Clientes cliente;
        private List<DetallesFactura> lDetalle;

        public Facturas(int formaPago, Clientes cliente)
        {
            this.FormaPago = formaPago;
            this.Fecha = DateTime.Now;
            this.Cliente = cliente;
        }

        public Facturas()
        {
            this.FormaPago = 0;
            this.Fecha = DateTime.Now;
            this.Cliente = null;
        }

        public int FormaPago { get => formaPago; set => formaPago = value; }
        public DateTime Fecha { get => fecha; set => fecha = value; }
        public Clientes Cliente { get => cliente; set => cliente = value; }
        public List<DetallesFactura> LDetalle { get => lDetalle; set => lDetalle = value; }
    }
}
