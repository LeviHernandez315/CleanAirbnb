using Domain.AggregateRoots;

namespace Application.Interfaces.AggregateRoots.ReservaInterfaces
{
    public interface IReservaRepository
    {
        Task<IEnumerable<Reserva>> GetAllAsync();
        Task<Reserva?> GetByIdAsync(int id);
        Task AddAsync(Reserva entity);
        Task<bool> UpdateAsync(Reserva entity);
        Task<bool> DeleteAsync(int id);
    }
}