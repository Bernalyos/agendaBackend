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

// 4. Configuración de CORS permitiendo explícitamente a Vercel
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

// Sin HttpsRedirection para evitar choques con el proxy de Render
// 6. Activar CORS
app.UseCors("AllowAll");

app.UseAuthorization();

// 7. Enlazar controladores
app.MapControllers();

app.Run();