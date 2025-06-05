
namespace EventApp.Application.Dtos
{
    public class InscripcionDto
    {
        public int Id { get; set; }
        public int EventoId { get; set; }
        public string UsuarioCi { get; set; }
        public DateTime FechaInscripcion { get; set; }
        public string EstadoInscripcion { get; set; }
        public string EventoNombre { get; set; }
        public string UsuarioNombre { get; set; }
        public decimal CostoEvento { get; set; }
        public string EstadoPago { get; set; }
    }
}