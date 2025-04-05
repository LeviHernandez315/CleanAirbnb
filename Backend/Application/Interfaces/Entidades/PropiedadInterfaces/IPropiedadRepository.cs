using Domain.Entities;

namespace Application.Interfaces.Entidades.PropiedadInterfaces
{
    public interface IPropiedadRepository
    {
        Task<IEnumerable<Propiedad>> GetAllAsync();
        Task<Propiedad?> GetByIdAsync(int id);
        Task AddAsync(Propiedad entity);
        Task<bool> UpdateAsync(Propiedad entity);
        Task<bool> DeleteAsync(int id);
    }
}