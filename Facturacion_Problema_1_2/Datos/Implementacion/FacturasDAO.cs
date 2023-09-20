using Facturacion_Problema_1_2.Datos.Interfaz;
using Facturacion_Problema_1_2.Entidades;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace Facturacion_Problema_1_2.Datos.Implementacion
{
    public class FacturasDAO : IFacturasDAO
    {
        public bool CrearFactura(Facturas factura)
        {
            SqlConnection cnn = AccesoDatosDAO.ObtenerInstancia().ObtenerConexion();
            bool resultado = true;
            SqlTransaction t = null;
            try
            {
                List<SqlParameter> listParam = new List<SqlParameter>();

                listParam.Add(new SqlParameter("@cod_cliente", factura.Cliente.CodCliente));
                listParam.Add(new SqlParameter("@id_forma_pago", factura.FormaPago));
                SqlParameter paramOutput = new SqlParameter("@nro_factura", SqlDbType.Int);
                paramOutput.Direction = ParameterDirection.Output;
                listParam.Add(paramOutput);

                AccesoDatosDAO.ObtenerInstancia().ProcedureExecuter("SP_INSERTAR_Facturas", listParam);

                foreach (DetallesFactura df in factura.LDetalle)
                {
                    
                }
                t.Commit();
            }
            catch (SqlException)
            {
                if (t != null)
                {
                    t.Rollback();
                    resultado = false;
                }
            }
            finally
            {
                
            }

            

        }
    }
}
