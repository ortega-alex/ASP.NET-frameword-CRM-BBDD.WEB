using Proyecto.Logica.Models;
using System;
using System.Data;
using System.Data.SqlClient;

namespace Proyecto.Logica.BL
{

    public class UsuarioBl
    {

        SqlConnection _SqlConnection = null; //me permite establecer la comunicacion con BBDD
        SqlCommand _SqlCommand = null; //me permite ejecutar comandos SQL
        SqlDataAdapter _SqlDataAdapter = null; //me permite adaptar conjunto de datos SQL
        string stConexion = string.Empty;//cadena de conexion
        SqlParameter _SqlParameter = null;
        public UsuarioBl()
        {
            Connection obclsConexion = new Connection();
            stConexion = obclsConexion.getConexion();
        }

        /// <summary>
        /// Validad Usuario
        /// </summary>
        /// <param name="usuario">objet Usuario</param>
        /// <returns>confirmacion</returns>
        public bool getValidarUsuario(Usuario usuario)
        {
            try
            {
                DataSet dsConsulta = new DataSet();

                _SqlConnection = new SqlConnection(stConexion);
                _SqlConnection.Open();

                _SqlCommand = new SqlCommand("spConsultaUsuario", _SqlConnection);
                _SqlCommand.CommandType = CommandType.StoredProcedure;
                _SqlCommand.Parameters.Add(new SqlParameter("@USERNAME", usuario.Username));
                _SqlCommand.Parameters.Add(new SqlParameter("@PASSWORD", usuario.Password));
                _SqlCommand.ExecuteNonQuery();

                _SqlDataAdapter = new SqlDataAdapter(_SqlCommand);
                _SqlDataAdapter.Fill(dsConsulta);

                if (dsConsulta.Tables[0].Rows.Count > 0) return true;
                return false;

            } catch (Exception ex) { throw ex; }
            finally { _SqlConnection.Close(); }
        }

        /// <summary>
        /// crear cuenta
        /// </summary>
        /// <param name="usuario">objet usuairo</param>
        /// <returns>mensaje</returns>
        public string setCrearCuenta(Usuario usuario , int option)
        {
            try
            {
                _SqlConnection = new SqlConnection(stConexion);
                _SqlConnection.Open();

                //parametros de entrada
                _SqlCommand = new SqlCommand("spAdministrarUsuarios", _SqlConnection);
                _SqlCommand.CommandType = CommandType.StoredProcedure;
                _SqlCommand.Parameters.Add(new SqlParameter("@username", usuario.Username));
                _SqlCommand.Parameters.Add(new SqlParameter("@password", usuario.Password));
                _SqlCommand.Parameters.Add(new SqlParameter("@img", usuario.Img));
                _SqlCommand.Parameters.Add(new SqlParameter("@options", option));

                //parametros de salida
                _SqlParameter = new SqlParameter();
                _SqlParameter.ParameterName = "@mensaje";
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
