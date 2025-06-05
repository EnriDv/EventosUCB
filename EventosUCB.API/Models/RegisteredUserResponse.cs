namespace EventApp.Api.Models
{
    public class RegisteredUserResponse
    {
        public string UsuarioCi { get; set; }
        public string NombreUsuario { get; set; }
        public string CiUsuario { get; set; }
        public string EstadoInscripcion { get; set; }
        public string EstadoPago { get; set; }
    }
}