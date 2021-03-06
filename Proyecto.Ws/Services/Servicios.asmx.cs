﻿using Newtonsoft.Json;
using Proyecto.Logica.BL;
using Proyecto.Logica.Models;
using System.Collections.Generic;
using System.Web.Services;

namespace Proyecto.Ws.Services
{
    /// <summary>
    /// Descripción breve de Servicios
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    // [System.Web.Script.Services.ScriptService]
    public class Servicios : System.Web.Services.WebService
    {

        [WebMethod]
        public string GetEventos()
        {
            EventoBl eventoBl = new EventoBl();           
            return JsonConvert.SerializeObject(eventoBl.GetEventos());
        }

        [WebMethod]
        public List<Evento> GetEventos_xml()
        {
            EventoBl eventoBl = new EventoBl();
            return eventoBl.GetEventos();
        }

        [WebMethod]
        //public void CreateEvento(Evento evento)
        public void CreateEvento(string objEvento)
        {
            EventoBl eventoBl = new EventoBl();
            Evento evento = JsonConvert.DeserializeObject<Evento>(objEvento);
            eventoBl.CreateEvento(evento);
        }
    }
}
