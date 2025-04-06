using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;

namespace Application.Interfaces.Entidades.MarcaInterfaces
{
    public interface IMarcaRepository
    {
        Task<IEnumerable<Marca>> GetAllAsync();
        Task<Marca?> GetByIdAsync(int id);
        Task AddAsync(Marca marca);
        Task<bool> UpdateAsync(Marca marca);
        Task<bool> DeleteAsync(int id);
    }
}
