
using System;
using System.Collections.Generic;
namespace EventosUCB.Models;
public class Evento
{
    public int IdEvento { get; set; }
    public string NombreEvento { get; set; }
    public DateTime Fecha { get; set; }
    public float Costo { get; set; }
    public int Capacidad { get; set; }
    public bool IsClosed { get; set; }
    public int IdUsuario { get; set; }
}
