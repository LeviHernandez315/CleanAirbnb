using Domain.AggregateRoots;

namespace Application.Interfaces.AggregateRoots.ReservaVehiculoInterfaces
{
    public interface IReservaVehiculoRepository
    {
        Task<IEnumerable<ReservaVehiculo>> GetAllAsync();
        Task<ReservaVehiculo?> GetByIdAsync(int id);
        Task AddAsync(ReservaVehiculo entity);
        Task<bool> UpdateAsync(ReservaVehiculo entity);
        Task<bool> DeleteAsync(int id);
    }
}