using Microsoft.EntityFrameworkCore;
using AgendaBackend.Data;

var builder = WebApplication.CreateBuilder(args);

// 1. Configuraciones de la API y Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// 2. Controladores
builder.Services.AddControllers(); 

// 3. Conexión a la base de datos PostgreSQL
builder.Services.AddDbContext<AgendaContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

// 4. Configuración de CORS (permite conexiones desde Angular sin bloqueos)
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});

var app = builder.Build();

// 5. Entorno de desarrollo y Swagger
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// 6. Activar CORS (Debe ir estrictamente antes de MapControllers)
app.UseCors("AllowAll");

app.UseAuthorization();

// 7. Enlazar controladores
app.MapControllers();

app.Run();

record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}