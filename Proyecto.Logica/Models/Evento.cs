using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto.Logica.Models
{
    public class Evento
    {
        public int Id { get; set; }
        public Relacionado Relacionado { get; set; }
        public string Nombre { get; set; }
        public string Ubicacion { get; set; }

        public string TodoDia { get; set; }
        public string Fecha { get; set; }
        public string Descripcion { get; set; }
    }
}
