using Newtonsoft.Json;
using Proyecto.Logica.Models;
using Proyecto.Web.wsServicios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Evento = Proyecto.Logica.Models.Evento;

namespace Proyecto.Web.Controllers
{
    public class EventoController
    {
        public List<Evento> GetEventos()
        {
            try
            {
                Servicios servicio = new Servicios();
                List<Evento> eventos = JsonConvert.DeserializeObject<List<Evento>>(servicio.GetEventos());
                return eventos;
            } catch (Exception ex) { throw ex;  }
        }

    }

    public class EventoControllerXml
    {
        public object GetEventos_xml()
        {
            try
            {
                Servicios servicio = new Servicios();
                var eventos = servicio.GetEventos_xml();
                return eventos;
            }
            catch (Exception ex) { throw ex; }
        }

    }
}