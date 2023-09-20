using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Sql;
using System.Data;
using System.Data.SqlClient;

namespace Facturacion_Problema_1_2.Entidade
{
    internal class AccesoDatos
    {
        private SqlConnection cnn;

        private SqlCommand cmd;

        private SqlTransaction t;

        private DataTable tabla;

        public AccesoDatos(string conexion)
        {
            cnn = new SqlConnection(conexion);
        }

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

            listParam.ForEach((param)  => { cmd.Parameters.Add(param); });

            cmd.CommandText = nombreSP;

            tabla.Load(cmd.ExecuteReader());

            Desconectar();

            return tabla;
        }
    }
}
