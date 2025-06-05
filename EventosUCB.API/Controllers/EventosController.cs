using Microsoft.AspNetCore.Mvc;
using EventApp.Application.Interfaces;
using EventApp.Api.Models;
using EventApp.Infrastructure.Persistence;
using System.Net;

namespace EventApp.Api.Controllers
{
    [ApiController]
    [Route("api/eventos")]
    public class EventosController : ControllerBase
    {
        private readonly IGestionarEventosService _gestionarEventosService;

        public EventosController(IGestionarEventosService gestionarEventosService)
        {
            _gestionarEventosService = gestionarEventosService;
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<EventResponse>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetAvailableEvents()
        {
            var events = await _gestionarEventosService.GetAvailableEvents();
            var response = events.Select(e => new EventResponse
            {
                Id = e.Id,
                Nombre = e.Nombre,
                Fecha = e.Fecha,
                Costo = e.Costo,
                Capacidad = e.Capacidad,
                Inscritos = e.Inscritos
            });
            return Ok(response);
        }

        [HttpPost("registrarse")]
        [ProducesResponseType(typeof(IEnumerable<RegisteredUserResponse>), (int)HttpStatusCode.Created)]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> RegisterForEvent([FromBody] RegisterRequest request)
        {
            var inscripcionDto = await _gestionarEventosService.RegisterForEvent(request.EventoId, request.UsuarioCi);

            if (inscripcionDto == null)
            {
                return BadRequest("No se pudo completar el registro al evento. Verifique los datos o si el evento está disponible/tiene cupo.");
            }

            var currentEventInscripciones = DataStore.Inscripciones.Where(i => i.IdEvento == request.EventoId).ToList();
            var registeredUsersForEvent = new List<RegisteredUserResponse>();

            foreach (var insc in currentEventInscripciones)
            {
                var user = DataStore.Usuarios.FirstOrDefault(u => u.CI == insc.UsuarioCi);
                var payment = DataStore.Pagos.FirstOrDefault(p => p.InscripcionId == insc.IdInscripcion);
                if (user != null)
                {
                    registeredUsersForEvent.Add(new RegisteredUserResponse
                    {
                        UsuarioCi = user.CI,
                        NombreUsuario = user.Nombre,
                        CiUsuario = user.CI,
                        EstadoInscripcion = insc.Estado,
                        EstadoPago = payment?.Estado ?? "N/A"
                    });
                }
            }
            return StatusCode((int)HttpStatusCode.Created, registeredUsersForEvent);
        }

        [HttpPost("pagar")]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> PayForInscription([FromBody] PayRequest request)
        {
            var success = await _gestionarEventosService.PayForInscription(request.InscripcionId, request.MontoPagado);

            if (!success)
            {
                return BadRequest("No se pudo procesar el pago. Verifique la inscripción o el monto.");
            }
            return NoContent();
        }

        [HttpGet("usuario/{userCi}/inscripciones")]
        [ProducesResponseType(typeof(IEnumerable<EventApp.Application.Dtos.InscripcionDto>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> GetUserInscribedEvents(string userCi)
        {
            var inscripciones = await _gestionarEventosService.GetUserInscribedEvents(userCi);

            if (!inscripciones.Any())
            {
                return NotFound($"Usuario con CI '{userCi}' no encontrado o no tiene inscripciones.");
            }
            return Ok(inscripciones);
        }

        [HttpGet("usuario/{userCi}/pagos")]
        [ProducesResponseType(typeof(IEnumerable<EventApp.Application.Dtos.InscripcionDto>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> GetUserPaidEvents(string userCi)
        {
            var inscripciones = await _gestionarEventosService.GetUserPaidEvents(userCi);

            if (!inscripciones.Any())
            {
                return NotFound($"Usuario con CI '{userCi}' no encontrado o no tiene pagos completados.");
            }
            return Ok(inscripciones);
        }
        
        [HttpGet("usuario/{userCi}/pagos-pendientes")]
        [ProducesResponseType(typeof(IEnumerable<EventApp.Application.Dtos.InscripcionDto>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> GetUserPendingPayments(string userCi)
        {
            var inscripcionesPendientes = await _gestionarEventosService.GetUserPendingPayments(userCi);
            
            if (!inscripcionesPendientes.Any())
            {
                return NotFound($"Usuario con CI '{userCi}' no encontrado o no tiene pagos pendientes.");
            }
            return Ok(inscripcionesPendientes);
        }
    }
}