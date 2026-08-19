using Microsoft.EntityFrameworkCore;
using AgendaBackend.Data;

var builder = WebApplication.CreateBuilder(args);

// Cargar variables de entorno del sistema explícitamente
builder.Configuration.AddEnvironmentVariables();

// 1. Configuraciones de la API y Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// 2. Controladores
builder.Services.AddControllers(); 

// 3. Conexión a la base de datos PostgreSQL
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") 
    ?? builder.Configuration["DefaultConnection"] 
    ?? Environment.GetEnvironmentVariable("DefaultConnection");

builder.Services.AddDbContext<AgendaContext>(options =>
    options.UseNpgsql(connectionString));

// 4. Configuración de CORS
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

// 5. Swagger
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Agenda Backend V1");
    c.RoutePrefix = string.Empty;
});

// 6. Activar CORS
app.UseCors("AllowAll");

app.UseAuthorization();

// 7. Enlazar controladores
app.MapControllers();

// Aplicar migraciones automáticamente al iniciar en la nube
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<AgendaContext>();
    context.Database.Migrate();
}

app.Run();