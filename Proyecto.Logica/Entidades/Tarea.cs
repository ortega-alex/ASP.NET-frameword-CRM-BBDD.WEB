//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Proyecto.Logica.Entidades
{
    using System;
    using System.Collections.Generic;
    
    public partial class Tarea
    {
        public int id { get; set; }
        public int estado { get; set; }
        public int prioridad { get; set; }
        public string titular { get; set; }
        public string asunto { get; set; }
        public string fechaVencimiento { get; set; }
        public string contacto { get; set; }
        public string enviarMensaje { get; set; }
        public string tareaDescripcion { get; set; }
        public string repetir { get; set; }
        public string cuenta { get; set; }
    
        public virtual EstadoTarea EstadoTarea { get; set; }
        public virtual Prioridad Prioridad1 { get; set; }
    }
}
