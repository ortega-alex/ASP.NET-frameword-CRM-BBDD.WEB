﻿using Proyecto.Logica.Entidades;
using System;
using System.Linq;
using System.Collections.Generic;

namespace Proyecto.Logica.BL
{
    public class EventoBl
    {
        public List<Models.Evento> GetEventos()
        {
            try
            {
                using (dbGeneralEntities db = new dbGeneralEntities())
                {
                    List<Models.Evento> eventos = (from q in db.Evento
                                                   join r in db.Relacionado on q.Relacionado equals r.Id
                                                   select new Models.Evento
                                                   {
                                                       Id = q.Id,
                                                       Descripcion = q.Descripcion,
                                                       Fecha = q.Fecha,
                                                       Nombre = q.Nombre,
                                                       Relacionado = new Models.Relacionado
                                                       {
                                                           Id = r.Id,
                                                           Descripcion = r.Descripcion
                                                       },
                                                       TodoDia = q.TodoDia,
                                                       Ubicacion = q.Ubicacion
                                                   }).ToList();
                    return eventos;
                }
            }
            catch (Exception ex) { throw ex; }
        }

        public void CreateEvento(Models.Evento evento)
        {
            try
            {
                using (dbGeneralEntities db = new dbGeneralEntities())
                {
                    db.Evento.Add(new Evento
                    {
                        Nombre = evento.Nombre,
                        Fecha = evento.Fecha,
                        TodoDia = evento.TodoDia,
                        Ubicacion = evento.Ubicacion,
                        Relacionado = evento.Relacionado.Id,
                        Descripcion = evento.Descripcion
                    });
                    db.SaveChanges();
                }
            }
            catch (Exception ex) { throw ex; }
        }

    }

}
