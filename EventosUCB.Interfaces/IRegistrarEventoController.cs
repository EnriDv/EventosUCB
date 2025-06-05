using EventosUCB.Models;
namespace EventosUCB.Interface;
public interface IRegistrarEventoController
{
    public bool validarUsuarioRepetido(int IdUsuario);
    public bool validarFechaEvento(string date, bool isClosed);
}