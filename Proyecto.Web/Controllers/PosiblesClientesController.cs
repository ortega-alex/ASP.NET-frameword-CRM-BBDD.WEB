using Proyecto.Logica.BL;
using Proyecto.Logica.Models;
using System;
using System.Data;

namespace Proyecto.Web.Controllers
{
    public class PosiblesClientesController
    {
        /// <summary>
        /// obtiene registros posibles clientes
        /// </summary>
        /// <returns>data posibles clientes</returns>
        public DataSet getPosiblesClientes()
        {
            try
            {
                PosibleClietneBl posibleClietneBl = new PosibleClietneBl();
                return posibleClietneBl.getPosiblesClientes();
            } catch (Exception ex) { throw ex; }
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
                PosibleClietneBl posibleClietneBl = new PosibleClietneBl();
                return posibleClietneBl.getAdministrarPosiblesClientes(posibleCliente, nOptions);
            }
            catch (Exception)  { throw; }
        }
    }
}