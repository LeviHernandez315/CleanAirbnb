using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Application.Interfaces.Entidades.CiudadInterfaces
{
    public interface ICiudadRepository
    {
        Task<IEnumerable<Ciudad>> GetAllAsync();
        Task<Ciudad?> GetByIdAsync(int id);
        Task AddAsync(Ciudad ciudad);
        Task<bool> UpdateAsync(Ciudad ciudad);
        Task<bool> DeleteAsync(int id);
    }
}
