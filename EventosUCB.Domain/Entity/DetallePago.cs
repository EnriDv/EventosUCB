using System;
using System.Collections.Generic;
namespace EventosUCB.Models;

public class DetallePago
{
    public int IdDetallePago { get; set; }
    public float Monto { get; set; }
    public DateTime Fecha { get; set; }
    public int IdEvento { get; set; }
    public int IdUsuario { get; set; }
}