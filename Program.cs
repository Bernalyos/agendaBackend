using Microsoft.EntityFrameworkCore;
using AgendaBackend.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var connectionString = Environment.GetEnvironmentVariable("DefaultConnection") 
                       ?? builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<AgendaContext>(options =>
    options.UseNpgsql(connectionString));

builder.Services.AddCors(options =>
    options.AddPolicy("AllowAll", p => p.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader()));

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseCors("AllowAll");
app.UseAuthorization();
app.MapControllers();

// RUTA DE SEGURIDAD: Esto crea las tablas manualmente si no existen
app.MapGet("/creartablas", (AgendaContext db) =>
{
    try
    {
        db.Database.EnsureCreated();
        return Results.Ok("¡Tablas creadas con exito! La base de datos esta lista.");
    }
    catch (Exception ex)
    {
        return Results.Content($"ERROR EXACTO: {ex.Message} --- DETALLE: {ex.InnerException?.Message}", "text/plain");
    }
});

app.Run();