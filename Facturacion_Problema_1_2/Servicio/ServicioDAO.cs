using Facturacion_Problema_1_2.Datos.Interfaz;
using Facturacion_Problema_1_2.Datos.Implementacion;
using Facturacion_Problema_1_2.Entidades;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facturacion_Problema_1_2.Datos.Servicio
{
    public class ServicioDAO : IServicio
    {
        private IFacturasDAO daoFacturas;
        private IDetallesFacturaDAO daoDetalles;
        private IClientesDAO daoClientes;
        private IArticulosDAO daoArticulos;

        public ServicioDAO()
        {
            daoFacturas = new FacturasDAO();
            daoDetalles = new DetallesFacturaDAO();
            daoClientes = new ClientesDAO();
            daoArticulos = new ArticulosDAO();
        }

        public bool AgregarArticulo(Articulos articulo)
        {
            return daoArticulos.AgregarArticulo(articulo);
        }

        public bool AgregarCliente(Clientes cliente)
        {
            return daoClientes.AgregarCliente(cliente);
        }

        public bool BajaFactura(Facturas factura)
        {
            return daoFacturas.BajaFactura(factura);
        }

        public bool CrearFactura(Facturas factura)
        {
            return daoFacturas.CrearFactura(factura);
        }

        public List<Articulos> ListarArticulos()
        {
            return daoArticulos.ListarArticulos();
        }

        public List<Clientes> ListarClientes()
        {
            return daoClientes.ListarClientes();
        }

        public List<Facturas> ListarFacturas(Clientes cliente, DateTime fecha)
        {
            return daoFacturas.ListarFacturas(cliente, fecha);
        }
    }
}
