[ApiController]
[Route("[controller]")]
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