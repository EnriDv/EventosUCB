using System;
using System.Collections.Generic;

namespace EventApp.Domain.Entities
{
    public class Inscripcion
    {
        public int IdInscripcion { get; set; }
        public int IdEvento { get; set; }
        public string UsuarioCi { get; set; }
        public DateTime FechaInscripcion { get; set; }
        public string Estado { get; set; } = "PENDIENTE_PAGO";
    }
}