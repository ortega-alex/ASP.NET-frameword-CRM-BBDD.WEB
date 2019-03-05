using Proyecto.Logica.Models;
using System;
using System.Data;
using System.Data.SqlClient;

namespace Proyecto.Logica.BL
{
    public class PosibleClietneBl
    {
        SqlConnection _SqlConnection = null; //me permite establecer la comunicacion con BBDD
        SqlCommand _SqlCommand = null; //me permite ejecutar comandos SQL
        SqlDataAdapter _SqlDataAdapter = null; //me permite adaptar conjunto de datos SQL
        string stConexion = string.Empty;//cadena de conexion

        SqlParameter _SqlParameter = null;

        public PosibleClietneBl()
        {
            Connection obclsConexion = new Connection();
            stConexion = obclsConexion.getConexion();
        }

        /// <summary>
        /// consulta de posibles clientes
        /// </summary>
        /// <returns>registros de posibles clientes</returns>
        public DataSet getPosiblesClientes()
        {
            try
            {
                DataSet dsConsulta = new DataSet();

                _SqlConnection = new SqlConnection(stConexion);
                _SqlConnection.Open();

                _SqlCommand = new SqlCommand("spConsultarPosiblesClientes", _SqlConnection);
                _SqlCommand.CommandType = CommandType.StoredProcedure;
                _SqlCommand.ExecuteNonQuery();

                _SqlDataAdapter = new SqlDataAdapter(_SqlCommand);
                _SqlDataAdapter.Fill(dsConsulta);

                return dsConsulta;

            }
            catch (Exception ex) { throw ex; }
            finally { _SqlConnection.Close(); }
        }

        /// <summary>
        /// administrador de clientes
        /// </summary>
        /// <param name="posibleCliente">objeto</param>
        /// <param name="nOptions">opcion de ejecucion</param>
        /// <returns>mensaje de proceso</returns>
        public string getAdministrarPosiblesClientes(PosibleCliente posibleCliente , int nOptions)
        {
            try
            {
                _SqlConnection = new SqlConnection(stConexion);
                _SqlConnection.Open();

                _SqlCommand = new SqlCommand("spAdministrarPosiblesClientes", _SqlConnection);
                _SqlCommand.CommandType = CommandType.StoredProcedure;
                _SqlCommand.Parameters.Add(new SqlParameter("@id", posibleCliente.Id));
                _SqlCommand.Parameters.Add(new SqlParameter("@nombres", posibleCliente.Nombres));
                _SqlCommand.Parameters.Add(new SqlParameter("@apellidos", posibleCliente.Apellidos));
                _SqlCommand.Parameters.Add(new SqlParameter("@correo", posibleCliente.Correo));
                _SqlCommand.Parameters.Add(new SqlParameter("@telefono", posibleCliente.Telefono));
                _SqlCommand.Parameters.Add(new SqlParameter("@direccion", posibleCliente.Direccion));
                _SqlCommand.Parameters.Add(new SqlParameter("@noptions", nOptions));
               

                _SqlParameter = new SqlParameter();
                _SqlParameter.ParameterName = "@mesaje";
                _SqlParameter.Direction = ParameterDirection.Output;
                _SqlParameter.SqlDbType = SqlDbType.NVarChar;
                _SqlParameter.Size = 50;

                _SqlCommand.Parameters.Add(_SqlParameter);
                _SqlCommand.ExecuteNonQuery();

                return _SqlParameter.Value.ToString();
            }
            catch (Exception ex) { throw ex; }
            finally { _SqlConnection.Close(); }
        }
    }
}
