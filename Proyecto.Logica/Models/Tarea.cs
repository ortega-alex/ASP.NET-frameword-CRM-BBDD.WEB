namespace Proyecto.Logica.Models
{
    public class Tarea
    {
        public int id { get; set; }
        public Estado estado { get; set; }
        public Prioridad prioridad { get; set; }
        public string titular { get; set; }
        public string asunto { get; set; }
        public string fechaVencimiento { get; set; }
        public string contacto { get; set; }
        public char enviaMensaje { get; set; }
        public char tareaDescripcion { get; set; }
    }
}
