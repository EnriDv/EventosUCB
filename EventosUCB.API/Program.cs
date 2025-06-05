using EventApp.Application.Interfaces;
using EventApp.Application.Services;
using EventApp.Infrastructure.Persistence;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddTransient<IGestionarEventosService, GestionarEventosService>();

builder.Services.AddSingleton<IEventoRepository, EventoRepository>();
builder.Services.AddSingleton<IUsuarioRepository, UsuarioRepository>();
builder.Services.AddSingleton<IInscripcionRepository, InscripcionRepository>();
builder.Services.AddSingleton<IPagoRepository, PagoRepository>();


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();