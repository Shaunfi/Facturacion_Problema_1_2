using Facturacion_Problema_1_2.Datos.Interfaz;
using Facturacion_Problema_1_2.Entidades;
using Facturacion_Problema_1_2.Presentaciones;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace Facturacion_Problema_1_2.Datos.Implementacion
{
    public class DetallesFacturaDAO : IDetallesFacturaDAO
    {
        public void CrearDetalle(Facturas factura, SqlTransaction t)
        {
            List<SqlParameter> listParam = new List<SqlParameter>();
            foreach (DetallesFactura df in factura.LDetalle)
            {
                listParam.Clear();
                listParam.Add(new SqlParameter("@nro_factura", factura.NroFactura));
                listParam.Add(new SqlParameter("@id_articulo", df.Articulo.IdArticulo));
                listParam.Add(new SqlParameter("@cantidad", df.Cantidad));
                listParam.Add(new SqlParameter("@pre_unitario", df.CalcularPrecio()));

                AccesoDatosDAO.ObtenerInstancia().ProcedureExecuterSinT("SP_INSERTAR_Detalle", listParam, t);
            }
        }
    }
}
