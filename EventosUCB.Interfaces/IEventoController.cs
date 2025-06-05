using EventosUCB.Models;
namespace EventosUCB.Interface;
public interface IEventoController
{
    public List<Evento> listarEventos();
    public List<Evento> listarEventosInscritos(int IdUsuario);
}