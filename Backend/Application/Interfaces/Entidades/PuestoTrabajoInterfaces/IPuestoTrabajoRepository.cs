using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;

namespace Application.Interfaces.Entidades.PuestoTrabajoInterfaces
{
    public interface IPuestoTrabajoRepository
    {
        Task<IEnumerable<PuestoTrabajo>> GetAllAsync();
        Task<PuestoTrabajo?> GetByIdAsync(int id);
        Task AddAsync(PuestoTrabajo puesto);
        Task<bool> UpdateAsync(PuestoTrabajo puesto);
        Task<bool> DeleteAsync(int id);
    }
}
