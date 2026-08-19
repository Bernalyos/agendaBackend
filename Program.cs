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

// 5. Swagger habilitado globalmente (para que lo veas al abrir tu URL de Render)
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Agenda Backend V1");
    c.RoutePrefix = string.Empty; // Esto hace que Swagger abra directamente en la página principal de tu link de Render
});

//app.UseHttpsRedirection();

// 6. Activar CORS (Debe ir estrictamente antes de MapControllers)
app.UseCors("AllowAll");

app.UseAuthorization();

// 7. Enlazar controladores
app.MapControllers();

// 8. Configuración del puerto dinámico para Render (¡Soluciona el error 139!)
var port = Environment.GetEnvironmentVariable("PORT") ?? "8080";
app.Urls.Add($"http://*:{port}");

app.Run();