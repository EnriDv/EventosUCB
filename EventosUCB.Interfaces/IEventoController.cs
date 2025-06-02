[ApiController]
[Route("[controller]")]
public class IEventoController
{
    public List<Evento> listarEventos();
    public List<Evento> listarEventosInscritos(int IdUsuario);
}