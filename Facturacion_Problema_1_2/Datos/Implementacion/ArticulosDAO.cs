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
    public class ArticulosDAO : IArticulosDAO
    {
        public List<Articulos> ListarArticulos()
        {
            List<Articulos> listArticulos = new List<Articulos>();

            DataTable tabla = AccesoDatosDAO.ObtenerInstancia().ProcedureReader("SP_CONSULTAR_TABLA_Articulos");

            foreach (DataRow row in tabla.Rows) 
            {
                Articulos a = new Articulos();

                a.IdArticulo = Convert.ToInt32(row[0].ToString());
                a.Descripcion = row[1].ToString();
                a.PrecioUnitario = Convert.ToDouble(row[2].ToString());

                listArticulos.Add(a);
            }
            return listArticulos;
        }

        public bool AgregarArticulo(Articulos articulo)
        {
            List<SqlParameter> listParam = new List<SqlParameter>();

            listParam.Add(new SqlParameter("@descripcion", articulo.Descripcion));
            listParam.Add(new SqlParameter("@pre_unitario", articulo.PrecioUnitario));

            return AccesoDatosDAO.ObtenerInstancia().ProcedureExecuter("SP_INSERTAR_ARTICULO", listParam);
        }
    }
}
