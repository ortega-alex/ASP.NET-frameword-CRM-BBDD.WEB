using Proyecto.Logica.Entidades;
using Proyecto.Logica.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto.Logica.BL
{
    public class TareaBl
    {
        /// <summary>
        /// adiciona una tarea
        /// </summary>
        /// <param name="tarea">modelo de tarea</param>
        /// <returns>mensaje</returns>
        public string addTarea(Models.Tarea tarea)
        {
            try
            {
                using (dbGeneralEntities db = new dbGeneralEntities())
                {
                    Entidades.Tarea dbTarea = new Entidades.Tarea
                    {
                        id = tarea.id,
                        titular = tarea.titular,
                        asunto = tarea.asunto,
                        fechaVencimiento = tarea.fechaVencimiento,
                        contacto = tarea.contacto,
                        estado = tarea.estado.id,
                        prioridad = tarea.prioridad.id,
                        enviarMensaje = tarea.enviaMensaje.ToString(),
                        tareaDescripcion = tarea.tareaDescripcion,
                        repetir = tarea.repetir.ToString(),
                        cuenta = tarea.cuenta
                    };

                    db.Tarea.Add(dbTarea);
                    db.SaveChanges();

                    return "Se adiciono on exito";
                }

            } catch (Exception ex) { throw ex;  }
        }

        /// <summary>
        /// modifica una tarea
        /// </summary>
        /// <param name="tarea">modelo de tarea</param>
        /// <returns>mensaje</returns>
        public string updateTare(Models.Tarea tarea)
        {
            try
            {
                using (dbGeneralEntities db = new dbGeneralEntities())
                {
                    Entidades.Tarea dbTarea = (from q in db.Tarea
                                               where q.id == tarea.id
                                               select q).FirstOrDefault();
                    dbTarea.titular = tarea.titular;
                    dbTarea.asunto = tarea.asunto;
                    dbTarea.fechaVencimiento = tarea.fechaVencimiento;
                    dbTarea.contacto = tarea.contacto;
                    dbTarea.cuenta = tarea.cuenta;
                    dbTarea.estado = tarea.estado.id;
                    dbTarea.prioridad = tarea.prioridad.id;
                    dbTarea.enviarMensaje = tarea.enviaMensaje.ToString();
                    dbTarea.repetir = tarea.repetir.ToString();
                    dbTarea.tareaDescripcion = tarea.tareaDescripcion;


                    db.SaveChanges();

                    return "Se modifico con exito";
                }

            }
            catch (Exception ex) { throw ex; }
        }

        /// <summary>
        /// elimina una tarea 
        /// </summary>
        /// <param name="tarea">modelo de tarea</param>
        /// <returns>mensaje</returns>
        public string deleteTare(Models.Tarea tarea)
        {
            try
            {
                using (dbGeneralEntities db = new dbGeneralEntities())
                {
                    Entidades.Tarea dbTarea = (from q in db.Tarea
                                               where q.id == tarea.id
                                               select q).FirstOrDefault();
                    db.Tarea.Remove(dbTarea);
                    db.SaveChanges();

                    return "Se elimino con exito";
                }

            }
            catch (Exception ex) { throw ex; }
        }

        /// <summary>
        /// todas las tareas
        /// </summary>
        /// <returns>lista de tareas</returns>
        public List<Models.Tarea> getTare()
        {
            try
            {
                using (dbGeneralEntities db = new dbGeneralEntities())
                {

                    return (from q in db.Tarea
                            join dbEt in db.EstadoTarea on q.estado equals dbEt.id
                            join dbPr in db.Prioridad on q.prioridad equals dbPr.id
                            select new Models.Tarea
                            {
                                id = q.id ,
                                titular = q.titular,
                                asunto = q.asunto,
                                fechaVencimiento = q.fechaVencimiento,
                                contacto = q.contacto,
                                cuenta = q.cuenta,
                                estado = new Models.Estado
                                {
                                    id = q.estado,
                                    description = dbEt.description
                                },
                                prioridad = new Models.Prioridad {
                                   id = q.prioridad,
                                    description = dbPr.description
                                },
                                enviaMensaje = q.enviarMensaje,
                                repetir = q.repetir,
                                tareaDescripcion = q.tareaDescripcion
                            }).ToList();
                }

            }
            catch (Exception ex) { throw ex; }
        }

        /// <summary>
        /// una tarea
        /// </summary>
        /// <param name="tarea">modelo de tarea</param>
        /// <returns>lista de tarea</returns>
        public List<Models.Tarea> getTare(Models.Tarea tarea)
        {
            try
            {
                using (dbGeneralEntities db = new dbGeneralEntities())
                {

                    return (from q in db.Tarea
                            join dbEt in db.EstadoTarea on q.estado equals dbEt.id
                            join dbPr in db.Prioridad on q.prioridad equals dbPr.id
                            where q.id == tarea.id
                            select new Models.Tarea
                            {
                                id = q.id,
                                titular = q.titular,
                                asunto = q.asunto,
                                fechaVencimiento = q.fechaVencimiento,
                                contacto = q.contacto,
                                cuenta = q.cuenta,
                                estado = new Models.Estado
                                {
                                    id = Convert.ToInt32(q.estado),
                                    description = dbEt.description
                                },
                                prioridad = new Models.Prioridad
                                {
                                    id = Convert.ToInt32(q.prioridad),
                                    description = dbPr.description
                                },
                                enviaMensaje = q.enviarMensaje,
                                repetir = q.repetir,
                                tareaDescripcion = q.tareaDescripcion
                            }).ToList();
                }

            }
            catch (Exception ex) { throw ex; }
        }

    }
}
