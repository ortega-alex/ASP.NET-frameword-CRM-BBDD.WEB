using System.Configuration;

namespace Proyecto.Logica.BL
{
    public class Connection
    {

        /// <summary>
        /// Obtiene la conexion de base de datos
        /// </summary>
        /// <returns>Cadena de conexion</returns>
        public string getConexion()
        {
            return ConfigurationManager.ConnectionStrings["Cnx"].ToString();
        }
    }
}
