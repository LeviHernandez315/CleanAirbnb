using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;

namespace Application.Interfaces.Entidades.ModeloInterfaces
{
    public interface IModeloRepository
    {
        Task<IEnumerable<Modelo>> GetAllAsync();
        Task<Modelo?> GetByIdAsync(int id);
        Task AddAsync(Modelo modelo);
        Task<bool> UpdateAsync(Modelo modelo);
        Task<bool> DeleteAsync(int id);
    }
}
