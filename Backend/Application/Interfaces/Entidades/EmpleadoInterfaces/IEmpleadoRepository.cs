using Domain.Entities;

namespace Application.Interfaces.Entidades.EmpleadoInterfaces
{
    public interface IEmpleadoRepository
    {
        Task<IEnumerable<Empleado>> GetAllAsync();
        Task<Empleado?> GetByIdAsync(int id);
        Task AddAsync(Empleado entity);
        Task<bool> UpdateAsync(Empleado entity);
        Task<bool> DeleteAsync(int id);
    }
}