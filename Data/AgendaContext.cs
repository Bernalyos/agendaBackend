using Microsoft.EntityFrameworkCore;
using AgendaBackend.Models;

namespace AgendaBackend.Data
{
    public class AgendaContext : DbContext{
    public AgendaContext(DbContextOptions<AgendaContext> options) : base(options)
        {
        }

        // Cada DbSet representa una tabla en tu base de datos
        public DbSet<Contacto> Contactos { get; set; }
    }
}
