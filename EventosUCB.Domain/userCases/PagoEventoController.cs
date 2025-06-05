
using Microsoft.AspNetCore.Mvc;
using EventosUCB.Interface;
using EventosUCB.Models;

namespace EventosUCB.Controllers;
public class PagoEventoController : IPagoEventoController
{
    public string generarQr(int IdEvento)
    {
        return "Qr generado";
    }
    public DetallePago pagar(int IdUsuario)
    {
        return new DetallePago();
    }
}