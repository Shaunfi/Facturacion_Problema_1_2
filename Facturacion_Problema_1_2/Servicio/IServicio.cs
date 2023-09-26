using Facturacion_Problema_1_2.Entidades;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facturacion_Problema_1_2.Datos.Servicio
{
    public interface IServicio
    {
        bool CrearFactura(Facturas factura);

        bool BajaFactura(Facturas factura);

        List<Facturas> ListarFacturas(Clientes cliente, DateTime fecha);

        List<Articulos> ListarArticulos();

        List<Clientes> ListarClientes();

        bool AgregarArticulo(Articulos articulo);

        bool AgregarCliente(Clientes cliente);
    }
}
