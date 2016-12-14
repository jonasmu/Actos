using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Actos.AccesoDatos
{
    public abstract class AccesoDatosBase
    {
        #region Atributos
        private const string SQLServer = "SQLServer";
        private SqlConnection conexion = new SqlConnection(ConfigurationManager.ConnectionStrings[SQLServer].ConnectionString);
        #endregion

        #region Metodos
        private SqlCommand PrepararConexion(string procedimientoAlmacenado, params SqlParameter[] parametros)
        {
            SqlCommand comando = new SqlCommand(procedimientoAlmacenado, conexion);
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddRange(parametros);
            return comando;
        }

        protected DataTable DevolverTabla(string procedimientoAlmacenado, params SqlParameter[] parametros)
        {
            try
            {
                SqlCommand comando = PrepararConexion(procedimientoAlmacenado, parametros);
                SqlDataAdapter dataAdapter = new SqlDataAdapter(comando);
                DataTable dataTable = new DataTable();
                dataAdapter.Fill(dataTable);
                return dataTable;
            }
            finally
            {
                if (conexion.State == ConnectionState.Open)
                {
                    conexion.Close();
                }
            }
        }

        protected DataSet DevolverConjunto(string procedimientoAlmacenado, params SqlParameter[] parametros)
        {
            try
            {
                SqlCommand comando = PrepararConexion(procedimientoAlmacenado, parametros);
                SqlDataAdapter dataAdapter = new SqlDataAdapter(comando);
                DataSet dataSet = new DataSet();
                dataAdapter.Fill(dataSet);
                return dataSet;
            }
            finally
            {
                if (conexion.State == ConnectionState.Open)
                {
                    conexion.Close();
                }
            }
        }

        protected Object DevolverEscalar(string procedimientoAlmacenado, params SqlParameter[] parametros)
        {
            try
            {
                SqlCommand comando = PrepararConexion(procedimientoAlmacenado, parametros);
                comando.Connection.Open();
                return comando.ExecuteScalar();
            }
            finally
            {
                if (conexion.State == ConnectionState.Open)
                {
                    conexion.Close();
                }
            }
        }

        protected void EjecutarConsulta(string procedimientoAlmacenado, params SqlParameter[] parametros)
        {
            try
            {
                SqlCommand comando = PrepararConexion(procedimientoAlmacenado, parametros);
                comando.Connection.Open();
                comando.ExecuteNonQuery();
            }
            finally
            {
                if (conexion.State == ConnectionState.Open)
                {
                    conexion.Close();
                }
            }
        }
        #endregion
    }
}
