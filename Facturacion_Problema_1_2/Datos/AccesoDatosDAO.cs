using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Facturacion_Problema_1_2.Datos
{
    public class AccesoDatosDAO
    {
        private static AccesoDatosDAO instancia;

        private SqlConnection cnn;

        private SqlCommand cmd;

        private DataTable tabla;

        private AccesoDatosDAO() 
        {
            cnn = new SqlConnection(Properties.Resources.ConexionStr);
        }

        public static AccesoDatosDAO ObtenerInstancia()
        {
            if (instancia == null)
            {
                instancia = new AccesoDatosDAO();
            }
            return instancia;
        }

        public SqlConnection ObtenerConexion()
        {
            return this.cnn;
        }

        #region Conectar y Desconectar
        private void Conectar()
        {
            cnn.Open();
            cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = cnn;
        }

        private void Desconectar()
        {
            cnn.Close();
        }
        #endregion

        #region Readers
        public DataTable ProcedureReader(string nombreSP)
        {
            tabla = new DataTable();
            Conectar();

            cmd.CommandText = nombreSP;

            tabla.Load(cmd.ExecuteReader());

            Desconectar();

            return tabla;
        }

        public DataTable ProcedureReader(string nombreSP, SqlParameter parameter)
        {
            tabla = new DataTable();
            Conectar();

            cmd.Parameters.Add(parameter);

            cmd.CommandText = nombreSP;

            tabla.Load(cmd.ExecuteReader());

            Desconectar();

            return tabla;
        }

        public DataTable ProcedureReader(string nombreSP, List<SqlParameter> listParam)
        {
            tabla = new DataTable();
            Conectar();

            listParam.ForEach((param) => { cmd.Parameters.Add(param); });

            cmd.CommandText = nombreSP;

            tabla.Load(cmd.ExecuteReader());

            Desconectar();

            return tabla;
        }
        #endregion

        #region Executer
        public void ProcedureExecuter(string nombreSP, List<SqlParameter> listParam)
        {

            SqlTransaction t = null;

            try
            {
                Conectar();

                t = cnn.BeginTransaction();
                cmd.Transaction = t;

                cmd.CommandText = nombreSP;

                listParam.ForEach((param) => cmd.Parameters.Add(param));

                cmd.ExecuteNonQuery();

                t.Commit();
            }
            catch (SqlException)
            {
                if (t != null)
                {
                    t.Rollback();
                }
            }
            finally
            {
                if (cnn.State == ConnectionState.Open)
                {
                    cnn.Close();
                }
            }
        }
        #endregion
    }
}
