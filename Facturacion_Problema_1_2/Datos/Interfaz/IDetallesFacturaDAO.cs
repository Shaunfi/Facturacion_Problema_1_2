using Facturacion_Problema_1_2.Entidades;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facturacion_Problema_1_2.Datos.Interfaz
{
    interface IDetallesFacturaDAO
    {
        void CrearDetalle(Facturas factura, SqlTransaction t);
    }
}
