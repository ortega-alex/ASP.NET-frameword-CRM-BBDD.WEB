using Proyecto.Logica.BL;
using Proyecto.Logica.Models;
using System;
using System.Collections.Generic;
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

        /// <summary>
        /// adiciona una tarea
        /// </summary>
        /// <param name="tarea">objeto tarea</param>
        /// <returns>mensage</returns>
        public string addTarea(Tarea tarea)
        {
            try
            {
                TareaBl tareaBl = new TareaBl();
                return tareaBl.addTarea(tarea);
            } catch (Exception ex) { throw ex; }
        }

        /// <summary>
        /// modifica una tarea
        /// </summary>
        /// <param name="tarea">objeto tarea</param>
        /// <returns>mensage</returns>
        public string updateTare(Tarea tarea)
        {
            try
            {
                TareaBl tareaBl = new TareaBl();
                return tareaBl.updateTare(tarea);
            }
            catch (Exception ex) { throw ex; }
        }

        /// <summary>
        /// elimina una tarea
        /// </summary>
        /// <param name="tarea">objeto tarea</param>
        /// <returns>mensage</returns>
        public string deleteTare(Tarea tarea)
        {
            try
            {
                TareaBl tareaBl = new TareaBl();
                return tareaBl.deleteTare(tarea);
            }
            catch (Exception ex) { throw ex; }
        }

        /// <summary>
        /// obtiene todas las tarea
        /// </summary>
        /// <returns>list tarea</returns>
        public List<Tarea> getTare()
        {
            try
            {
                TareaBl tareaBl = new TareaBl();
                return tareaBl.getTare();
            }
            catch (Exception ex) { throw ex; }
        }

        /// <summary>
        /// obtiene una tarea
        /// </summary>
        /// <param name="tarea">objeto tarea</param>
        /// <returns>lista de tarea</returns>
        public List<Tarea> getTare(Tarea tarea)
        {
            try
            {
                TareaBl tareaBl = new TareaBl();
                return tareaBl.getTare(tarea);
            }
            catch (Exception ex) { throw ex; }
        }
    }
}