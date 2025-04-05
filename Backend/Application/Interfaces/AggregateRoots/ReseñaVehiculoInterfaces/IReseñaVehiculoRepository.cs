using Domain.AggregateRoots;

namespace Application.Interfaces.AggregateRoots.ReseñaVehiculoInterfaces
{
    public interface IReseñaVehiculoRepository
    {
        Task<IEnumerable<ReseñaVehiculo>> GetAllAsync();
        Task<ReseñaVehiculo?> GetByIdAsync(int id);
        Task AddAsync(ReseñaVehiculo entity);
        Task<bool> UpdateAsync(ReseñaVehiculo entity);
        Task<bool> DeleteAsync(int id);
    }
}