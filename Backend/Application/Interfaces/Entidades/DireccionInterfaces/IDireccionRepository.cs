using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;

namespace Application.Interfaces.Entidades.DireccionInterfaces
{
    public interface IDireccionRepository
    {
        Task<IEnumerable<Direccion>> GetAllAsync();
        Task<Direccion?> GetByIdAsync(int id);
        Task AddAsync(Direccion direccion);
        Task<bool> UpdateAsync(Direccion direccion);
        Task<bool> DeleteAsync(int id);
    }
}
