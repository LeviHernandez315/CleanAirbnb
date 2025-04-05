using Domain.Entities;

namespace Application.Interfaces.Entidades.VehiculoInterfaces
{
    public interface IVehiculoRepository
    {
        Task<IEnumerable<Vehiculo>> GetAllAsync();
        Task<Vehiculo?> GetByIdAsync(int id);
        Task AddAsync(Vehiculo entity);
        Task<bool> UpdateAsync(Vehiculo entity);
        Task<bool> DeleteAsync(int id);
    }
}