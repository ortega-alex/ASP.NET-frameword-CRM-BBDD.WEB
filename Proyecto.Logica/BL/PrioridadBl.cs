using System;

using System.Data;
using System.Data.SqlClient;

namespace Proyecto.Logica.BL
{
    public class PrioridadBl
    {
        SqlConnection _SqlConnection = null; //me permite establecer la comunicacion con BBDD
        SqlCommand _SqlCommand = null; //me permite ejecutar comandos SQL
        SqlDataAdapter _SqlDataAdapter = null; //me permite adaptar conjunto de datos SQL
        string stConexion = string.Empty;//cadena de conexion
        
        public PrioridadBl()
        {
            Connection obclsConexion = new Connection();
            stConexion = obclsConexion.getConexion();
        }

        /// <summary>
        /// consulta prioridades tarea
        /// </summary>
        /// <returns>registros prioridades tarea</returns>
        public DataSet getPrioridadesTareas()
        {
            try
            {
                DataSet dsConsulta = new DataSet();

                _SqlConnection = new SqlConnection(stConexion);
                _SqlConnection.Open();

                _SqlCommand = new SqlCommand("spConsultaPrioridad", _SqlConnection);
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
