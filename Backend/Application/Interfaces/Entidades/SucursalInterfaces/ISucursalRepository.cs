using Domain.Entities;

namespace Application.Interfaces.Entidades.SucursalInterfaces
{
    public interface ISucursalRepository
    {
        Task<IEnumerable<Sucursal>> GetAllAsync();
        Task<Sucursal?> GetByIdAsync(int id);
        Task AddAsync(Sucursal entity);
        Task<bool> UpdateAsync(Sucursal entity);
        Task<bool> DeleteAsync(int id);
    }
}