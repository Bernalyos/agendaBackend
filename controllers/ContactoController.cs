using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AgendaBackend.Models;
using AgendaBackend.Data;

namespace AngendaBackend.Controller{

     [Route("api/[controller]")]
     [ApiController]
    public class ContactosController : ControllerBase
    {
        private readonly AgendaContext _context;

        public ContactosController(AgendaContext context)
        {
            _context = context;
        }

        // GET: api/Contactos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Contacto>>> GetContactos()
        {
            return await _context.Contactos.ToListAsync();
        }

        // Post: api/Contactos
        [HttpPost]
        public async Task<ActionResult<Contacto>> PostContacto(Contacto contacto)
        {
            _context.Contactos.Add(contacto);
            await _context.SaveChangesAsync();

            return Ok(contacto);
        }

       // PUT: api/contactos/5 (Actualizar)
        [HttpPut("{id}")]
        public async Task<IActionResult> PutContacto(int id, Contacto contacto)
        {
            // Validamos que el ID de la URL sea el mismo del objeto enviado
            if (id != contacto.Id)
            {
                return BadRequest("El ID de la URL no coincide con el del contacto.");
            }

            // Le decimos a Entity Framework que este registro ha sido modificado
            _context.Entry(contacto).State = EntityState.Modified;

            try
            {
                // Guardamos los cambios en PostgreSQL
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                // Si el contacto ya no existe en la base de datos, devolvemos un 404
                if (!_context.Contactos.Any(e => e.Id == id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            // 204 No Content es la respuesta estándar de éxito para un PUT
            return NoContent();
        }

        // DELETE: api/contactos/5 (Eliminar)
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteContacto(int id)
        {
            // Buscamos si el contacto existe en PostgreSQL
            var contacto = await _context.Contactos.FindAsync(id);
            if (contacto == null)
            {
                return NotFound(); // Error 404 si no se encuentra
            }

            // Preparamos la orden de eliminación
            _context.Contactos.Remove(contacto);
            
            // Ejecutamos el DELETE en la base de datos
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}