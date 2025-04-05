using Domain.Entities;

namespace Application.Interfaces.Entidades.DatosPagoInterfaces
{
    public interface IDatosPagoRepository
    {
        Task<IEnumerable<DatosPago>> GetAllAsync();
        Task<DatosPago?> GetByIdAsync(int id);
        Task AddAsync(DatosPago entity);
        Task<bool> UpdateAsync(DatosPago entity);
        Task<bool> DeleteAsync(int id);
    }
}