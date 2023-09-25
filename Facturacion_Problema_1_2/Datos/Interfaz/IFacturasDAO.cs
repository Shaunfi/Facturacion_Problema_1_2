using Facturacion_Problema_1_2.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facturacion_Problema_1_2.Datos.Interfaz
{
    interface IFacturasDAO
    {
        bool CrearFactura(Facturas factura);

        bool BajaFactura(Facturas factura);

        List<Facturas> ListarFacturas(Clientes cliente, DateTime fecha);
    }
}
