using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;


namespace Application.Interfaces
{
    public interface IRolRepository
    {
        Task<IEnumerable<Rol>> GetAllAsync();
        Task<Rol?> GetByIdAsync(int id);
        Task AddAsync(Rol rol);
        Task UpdateAsync(Rol rol);
        Task DeleteAsync(int id);
    }
}
