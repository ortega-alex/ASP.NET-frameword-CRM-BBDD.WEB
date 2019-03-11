using System;

using System.Data;
using System.Data.SqlClient;

namespace Proyecto.Logica.BL
{
    public class EstadoBl
    {
        SqlConnection _SqlConnection = null; //me permite establecer la comunicacion con BBDD
        SqlCommand _SqlCommand = null; //me permite ejecutar comandos SQL
        SqlDataAdapter _SqlDataAdapter = null; //me permite adaptar conjunto de datos SQL
        string stConexion = string.Empty;//cadena de conexion
        
        public EstadoBl()
        {
            Connection obclsConexion = new Connection();
            stConexion = obclsConexion.getConexion();
        }

        /// <summary>
        /// consulta estados tarea
        /// </summary>
        /// <returns>registros estado tarea</returns>
        public DataSet getEstadosTareas()
        {
            try
            {
                DataSet dsConsulta = new DataSet();

                _SqlConnection = new SqlConnection(stConexion);
                _SqlConnection.Open();

                _SqlCommand = new SqlCommand("spConsultaEstadoTareas", _SqlConnection);
                _SqlCommand.CommandType = CommandType.StoredProcedure;
                _SqlCommand.ExecuteNonQuery();

                _SqlDataAdapter = new SqlDataAdapter(_SqlCommand);
                _SqlDataAdapter.Fill(dsConsulta);

                return dsConsulta;

            }
            catch (Exception ex) { throw ex; }
            finally { _SqlConnection.Close(); }
        }
    }
}
