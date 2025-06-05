using Microsoft.AspNetCore.Mvc;
using EventosUCB.Interface;
using EventosUCB.Models;

namespace EventosUCB.Controllers;
public class RegistrarEventoController : IRegistrarEventoController
{
    public bool validarUsuarioRepetido(int IdUsuario)
    {
        return true;
    }
    public bool validarFechaEvento(string date, bool isClosed)
    {
        return true;
    }
}

