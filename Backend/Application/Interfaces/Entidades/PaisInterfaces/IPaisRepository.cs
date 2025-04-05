using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;

namespace Application.Interfaces.Entidades.PaisInterfaces
{
    public interface IPaisRepository
    {
        Task<IEnumerable<Pais>> GetAllAsync();
        Task<Pais?> GetByIdAsync(int id);
        Task AddAsync(Pais pais);
        Task<bool> UpdateAsync(Pais pais);
        Task<bool> DeleteAsync(int id);
    }
}
