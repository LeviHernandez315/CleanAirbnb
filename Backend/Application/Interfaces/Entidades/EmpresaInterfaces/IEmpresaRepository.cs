using Domain.Entities;

namespace Application.Interfaces.Entidades.EmpresaInterfaces
{
    public interface IEmpresaRepository
    {
        Task<IEnumerable<Empresa>> GetAllAsync();
        Task<Empresa?> GetByIdAsync(int id);
        Task AddAsync(Empresa entity);
        Task<bool> UpdateAsync(Empresa entity);
        Task<bool> DeleteAsync(int id);
    }
}