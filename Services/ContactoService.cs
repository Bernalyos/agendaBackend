using AgendaBackend.Data;
using AgendaBackend.DTOs;
using AgendaBackend.Models;
using Microsoft.EntityFrameworkCore;

namespace AgendaBackend.Services
{
    public class ContactoService : IContactoService
    {
        private readonly AgendaContext _context;

        public ContactoService(AgendaContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ContactoResponseDto>> GetAllAsync()
        {
            return await _context.Contactos
                .Select(c => new ContactoResponseDto
                {
                    Id = c.Id,
                    TipoDeContacto = c.TipoDeContacto,
                    Nombre = c.Nombre,
                    Telefono = c.Telefono,
                    Comentarios = c.Comentarios,
                    CamposAdicionales = c.CamposAdicionales
                })
                .ToListAsync();
        }

        public async Task<ContactoResponseDto?> GetByIdAsync(int id)
        {
            var contacto = await _context.Contactos.FindAsync(id);
            if (contacto == null) return null;

            return new ContactoResponseDto
            {
                Id = contacto.Id,
                TipoDeContacto = contacto.TipoDeContacto,
                Nombre = contacto.Nombre,
                Telefono = contacto.Telefono,
                Comentarios = contacto.Comentarios,
                CamposAdicionales = contacto.CamposAdicionales
            };
        }

        public async Task<ContactoResponseDto> CreateAsync(ContactoCreateUpdateDto dto)
        {
            var contacto = new Contacto
            {
                TipoDeContacto = dto.TipoDeContacto,
                Nombre = dto.Nombre,
                Telefono = dto.Telefono,
                Comentarios = dto.Comentarios,
                CamposAdicionales = dto.CamposAdicionales
            };

            _context.Contactos.Add(contacto);
            await _context.SaveChangesAsync();

            return new ContactoResponseDto
            {
                Id = contacto.Id,
                TipoDeContacto = contacto.TipoDeContacto,
                Nombre = contacto.Nombre,
                Telefono = contacto.Telefono,
                Comentarios = contacto.Comentarios,
                CamposAdicionales = contacto.CamposAdicionales
            };
        }

        public async Task<bool> UpdateAsync(int id, ContactoCreateUpdateDto dto)
        {
            var contacto = await _context.Contactos.FindAsync(id);
            if (contacto == null) return false;

            contacto.TipoDeContacto = dto.TipoDeContacto;
            contacto.Nombre = dto.Nombre;
            contacto.Telefono = dto.Telefono;
            contacto.Comentarios = dto.Comentarios;
            contacto.CamposAdicionales = dto.CamposAdicionales;

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var contacto = await _context.Contactos.FindAsync(id);
            if (contacto == null) return false;

            _context.Contactos.Remove(contacto);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}