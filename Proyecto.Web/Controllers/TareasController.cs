using Proyecto.Logica.BL;
using System;
using System.Data;

namespace Proyecto.Web.Controllers
{
    public class TareasController
    {
        /// <summary>
        /// obtiene registros Estado tarea
        /// </summary>
        /// <returns>data estados tareas</returns>
        public DataSet getEstadosTareas()
        {
            try
            {
                EstadoBl estadoBl = new EstadoBl();
                return estadoBl.getEstadosTareas();
            }
            catch (Exception ex) { throw ex; }
        }

        /// <summary>
        /// obtiene registros prioridad tarea
        /// </summary>
        /// <returns>data prioridad tareas</returns>
        public DataSet getPrioridadesTareas()
        {
            try
            {
                PrioridadBl prioridadBl = new PrioridadBl();
                return prioridadBl.getPrioridadesTareas();
            }
            catch (Exception ex) { throw ex; }
        }
    }
}