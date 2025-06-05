using System;
using System.Collections.Generic;

namespace EventApp.Domain.Entities
{
    public class Evento
    {
        public int IdEvento { get; set; }
        public string Nombre { get; set; }
        public DateTime Fecha { get; set; }
        public decimal Costo { get; set; }
        public int Capacidad { get; set; }
        public List<string> InscripcionesUsuarioCis { get; set; } = new List<string>();

        public bool EsVigente() => Fecha >= DateTime.UtcNow;
        public bool TieneCupo() => InscripcionesUsuarioCis.Count < Capacidad;
    }
}