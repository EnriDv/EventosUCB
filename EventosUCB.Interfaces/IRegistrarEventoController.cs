[ApiController]
[Route("[controller]")]
public class IRegistrarEventoController
{
    public bool validarUsuarioRepetido(int IdUsuario);
    public bool validarFechaEvento(string date, bool isClosed);
}