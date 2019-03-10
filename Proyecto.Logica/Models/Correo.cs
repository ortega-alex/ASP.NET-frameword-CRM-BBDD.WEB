namespace Proyecto.Logica.Models
{
    public class Correo
    {
        public string Servidor { get; set; }
        public string Usuairo { get; set; }
        public string Password { get; set; }
        public bool ConexionSegura { get; set; }
        public bool Autenticacion { get; set; }
        public string From { get; set; }
        public string To { get; set; }
        public string Asunto { get; set; }
        public string Mensaje { get; set; }
        public int Tipo {get; set; }
        public int Prioridad { get; set; }
        public string  Puerto { get; set; }
        public string Image { get; set; }
        public string IdImage { get; set; }
    }
}
