using AgendaBackend.DTOs;

namespace AgendaBackend.Services
{
    public interface IContactoService
    {
        Task<IEnumerable<ContactoResponseDto>> GetAllAsync();
        Task<ContactoResponseDto?> GetByIdAsync(int id);
        Task<ContactoResponseDto> CreateAsync(ContactoCreateUpdateDto dto);
        Task<bool> UpdateAsync(int id, ContactoCreateUpdateDto dto);
        Task<bool> DeleteAsync(int id);
    }
}