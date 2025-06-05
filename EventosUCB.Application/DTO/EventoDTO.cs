
namespace EventApp.Application.Dtos
{
    public class EventoDto
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public DateTime Fecha { get; set; }
        public decimal Costo { get; set; }
        public int Capacidad { get; set; }
        public int Inscritos { get; set; }
    }
}
