using Facturacion_Problema_1_2.Datos.Interfaz;
using Facturacion_Problema_1_2.Entidades;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Windows.Forms;

namespace Facturacion_Problema_1_2.Datos.Implementacion
{
    public class FacturasDAO : IFacturasDAO
    {
        private DetallesFacturaDAO daoDetalles;


        public bool CrearFactura(Facturas factura)
        {
            daoDetalles = new DetallesFacturaDAO();
            SqlConnection cnn = AccesoDatosDAO.ObtenerInstancia().ObtenerConexion();
            bool resultado = true;
            SqlTransaction t = null;
            try
            {
                cnn.Open();

                t = cnn.BeginTransaction();

                List<SqlParameter> listParam = new List<SqlParameter>();

                listParam.Add(new SqlParameter("@cod_cliente", factura.Cliente.CodCliente));
                listParam.Add(new SqlParameter("@id_forma_pago", factura.FormaPago));
                SqlParameter paramOutput = new SqlParameter("@nro_factura", SqlDbType.Int);
                paramOutput.Direction = ParameterDirection.Output;
                listParam.Add(paramOutput);

                AccesoDatosDAO.ObtenerInstancia().ProcedureExecuterSinT("SP_INSERTAR_Facturas", listParam, t);

                factura.NroFactura = Convert.ToInt32(listParam[2].Value.ToString());

                daoDetalles.CrearDetalle(factura, t);
                t.Commit();
            }
            catch (SqlException)
            {
                if (t != null)
                {
                    t.Rollback();
                    resultado = false;
                    throw;
                }
            }
            finally
            {
                if (cnn.State == ConnectionState.Open)
                {
                    cnn.Close();
                }
            }
            return true;
        }
        public bool BajaFactura(Facturas factura)
        {
            SqlParameter param = new SqlParameter("@nro_factura", factura.NroFactura);

            return AccesoDatosDAO.ObtenerInstancia().ProcedureExecuter("SP_BAJAR_FACTURA", param); ;
        }

        public List<Facturas> ListarFacturas(Clientes cliente, DateTime fecha)
        {
            List<Facturas> listFacturas = new List<Facturas>();

            List<SqlParameter> listParam = new List<SqlParameter>();

            listParam.Add(new SqlParameter("@cod_cliente", cliente.CodCliente));
            listParam.Add(new SqlParameter("@fecha", fecha.ToString("yyyy/MM/dd")));


            DataTable tabla = AccesoDatosDAO.ObtenerInstancia().ProcedureReader("SP_CONSULTAR_TABLA_Facturas", listParam);

            foreach (DataRow row in tabla.Rows )
            {
                Facturas f = new Facturas();

                f.NroFactura = Convert.ToInt32(row[0].ToString());
                f.Fecha = Convert.ToDateTime(row[2].ToString());

                listFacturas.Add(f);
            }

            return listFacturas;
        }
    }
}
