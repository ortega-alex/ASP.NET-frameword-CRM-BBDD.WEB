using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;

namespace Proyecto.Test
{
    [TestClass]
    public class Evento
    {
        [TestMethod]
        public void CreateEventoTest()
        {
            //arrange 
            wsServicios.Servicios servicio = new wsServicios.Servicios();

            //act
            Logica.Models.Evento evento = new Logica.Models.Evento
            {
                Descripcion = "Primer semestre",
                Fecha = "2019-09-02",
                Nombre = "Induccion",
                Relacionado = new Logica.Models.Relacionado
                {
                    Id = 1
                },
                TodoDia = "S",
                Ubicacion = "UTAP"
            };
           
            //ASSERT
            servicio.CreateEvento(JsonConvert.SerializeObject(evento));
        }
    }
}
