using Microsoft.AspNetCore.Mvc;
using EventosUCB.Interface;
using EventosUCB.Models;


namespace EventosUCB.Controllers;
public class EventoController : IEventoController
{
    public List<Evento> listarEventos()
    {
        return new List<Evento>();
    }
    public List<Evento> listarEventosInscritos(int IdUsuario)
    {
        return new List<Evento>();
    }
}