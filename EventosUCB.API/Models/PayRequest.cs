using System.ComponentModel.DataAnnotations;
namespace EventApp.Api.Models
{
    public class PayRequest
    {
        public int InscripcionId { get; set; }
        [Range(0.01, double.MaxValue)] public decimal MontoPagado { get; set; }
    }
}