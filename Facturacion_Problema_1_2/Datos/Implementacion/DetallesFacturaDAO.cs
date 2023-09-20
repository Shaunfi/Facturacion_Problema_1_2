using Facturacion_Problema_1_2.Datos.Interfaz;
using Facturacion_Problema_1_2.Entidades;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facturacion_Problema_1_2.Datos.Implementacion
{
    public class DetallesFacturaDAO : IDetallesFactura
    {
        public void CrearDetalle(DetallesFactura detalle, int nroFactura)
        {
            List<SqlParameter> listParam = new List<SqlParameter>();

            listParam.Add(new SqlParameter("@nro_factura", nroFactura));
            listParam.Add(new SqlParameter("@id_articulo", detalle.Articulo.IdArticulo));
            listParam.Add(new SqlParameter("@cantidad", detalle.Cantidad));
            listParam.Add(new SqlParameter("@pre_unitario", detalle.Precio));

            AccesoDatosDAO.ObtenerInstancia().ProcedureExecuters("SP_INSERTAR_Detalle", listParam);
        }
    }
}
