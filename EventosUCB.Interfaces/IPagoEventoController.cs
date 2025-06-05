using EventosUCB.Models;
namespace EventosUCB.Interface;
public interface IPagoEventoController
{
    public string generarQr(int IdEvento);
    public DetallePago pagar(int IdUsuario);
}

