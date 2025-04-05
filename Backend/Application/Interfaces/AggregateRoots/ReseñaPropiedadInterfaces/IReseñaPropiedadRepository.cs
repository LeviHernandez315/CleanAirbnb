using Domain.AggregateRoots;

namespace Application.Interfaces.AggregateRoots.ReseñaPropiedadInterfaces
{
    public interface IReseñaPropiedadRepository
    {
        Task<IEnumerable<ReseñaPropiedad>> GetAllAsync();
        Task<ReseñaPropiedad?> GetByIdAsync(int id);
        Task AddAsync(ReseñaPropiedad entity);
        Task<bool> UpdateAsync(ReseñaPropiedad entity);
        Task<bool> DeleteAsync(int id);
    }
}