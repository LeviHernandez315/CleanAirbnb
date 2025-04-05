using Domain.Entities;

namespace Application.Interfaces.Entidades.EstadoReservaInterfaces
{
    public interface IEstadoReservaRepository
    {
        Task<IEnumerable<EstadoReserva>> GetAllAsync();
        Task<EstadoReserva?> GetByIdAsync(int id);
        Task AddAsync(EstadoReserva entity);
        Task<bool> UpdateAsync(EstadoReserva entity);
        Task<bool> DeleteAsync(int id);
    }
}