[ApiController]
[Route("[controller]")]
public class IPagoEventoController
{
    public string generarQr(int IdEvento);
    public DetallePago pagar(int IdUsuario);
}

