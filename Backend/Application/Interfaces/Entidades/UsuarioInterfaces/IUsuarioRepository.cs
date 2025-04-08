using Domain.Entities;

namespace Application.Interfaces.Entidades.UsuarioInterfaces
{
    public interface IUsuarioRepository
    {
        Task<IEnumerable<Usuario>> GetAllAsync();
        Task<Usuario?> GetByIdAsync(int id);
        Task AddAsync(Usuario entity);
        Task<bool> UpdateAsync(Usuario entity);
        Task<bool> DeleteAsync(int id);
        Task<Usuario?> GetByEmailAsync(string email);

    }
}