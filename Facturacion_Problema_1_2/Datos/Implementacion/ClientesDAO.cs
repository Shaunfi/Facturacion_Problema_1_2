using Facturacion_Problema_1_2.Datos.Interfaz;
using Facturacion_Problema_1_2.Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facturacion_Problema_1_2.Datos.Implementacion
{
    public class ClientesDAO : IClientesDAO
    {
        public List<Clientes> ListarClientes()
        {
            List<Clientes> listClientes = new List<Clientes>();

            DataTable tabla = AccesoDatosDAO.ObtenerInstancia().ProcedureReader("SP_CONSULTAR_TABLA_Clientes");

            foreach (DataRow row in tabla.Rows) 
            {
                Clientes cliente = new Clientes();

                cliente.CodCliente = Convert.ToInt32(row[0].ToString());
                cliente.Apellido = row[1].ToString();
                cliente.Nombre = row[2].ToString();

                listClientes.Add(cliente);
            }

            return listClientes;
        }

        public bool AgregarCliente(Clientes cliente)
        {
            List<SqlParameter> listParam = new List<SqlParameter>();

            listParam.Add(new SqlParameter("@apellido", cliente.Apellido));
            listParam.Add(new SqlParameter("@nombre", cliente.Nombre));

            return AccesoDatosDAO.ObtenerInstancia().ProcedureExecuter("SP_INSERTAR_CLIENTE", listParam);
        }

    }
}
