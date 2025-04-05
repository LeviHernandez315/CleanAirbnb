using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.Entidades.AreaTrabajoInterfaces
{
    public interface IAreaTrabajoRepository
    {
        Task<IEnumerable<AreaTrabajo>> GetAllAsync();
        Task<AreaTrabajo?> GetByIdAsync(int id);
        Task AddAsync(AreaTrabajo areaTrabajo);
        Task<bool> UpdateAsync(AreaTrabajo areaTrabajo);
        Task<bool> DeleteAsync(int id);
    }
}
