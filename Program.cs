using Microsoft.EntityFrameworkCore;
using AgendaBackend.Data;
using Microsoft.AspNetCore.Diagnostics;

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

// ESTO FUERZA A QUE .NET MUESTRE EL ERROR REAL EN LUGAR DE UN 500 CALLADO
app.UseExceptionHandler(exceptionHandlerApp =>
{
    exceptionHandlerApp.Run(async context =>
    {
        context.Response.StatusCode = 500;
        context.Response.ContentType = "text/plain";
        var exceptionFeature = context.Features.Get<IExceptionHandlerPathFeature>();
        var ex = exceptionFeature?.Error;
        await context.Response.WriteAsync($"ERROR DE NEON/BD: {ex?.Message} --- DETALLE: {ex?.InnerException?.Message}");
    });
});

app.UseSwagger();
app.UseSwaggerUI();

app.UseCors("AllowAll");
app.UseAuthorization();
app.MapControllers();

using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<AgendaContext>();
    db.Database.EnsureCreated();
}

app.Run();