using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;

namespace Application.Interfaces.Entidades.DepartamentoInterfaces
{
    public interface IDepartamentoRepository
    {
        Task<IEnumerable<Departamento>> GetAllAsync();
        Task<Departamento?> GetByIdAsync(int id);
        Task AddAsync(Departamento departamento);
        Task<bool> UpdateAsync(Departamento departamento);
        Task<bool> DeleteAsync(int id);
    }
}
