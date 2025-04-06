using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;

namespace Application.Interfaces.Entidades.ValoracionInterfaces
{
    public interface IValoracionRepository
    {
        Task<IEnumerable<Valoracion>> GetAllAsync();
        Task<Valoracion?> GetByIdAsync(int id);
        Task<Valoracion> CreateAsync(Valoracion valoracion);
        Task<bool> UpdateAsync(Valoracion valoracion);
        Task<bool> DeleteAsync(int id);
    }
}
