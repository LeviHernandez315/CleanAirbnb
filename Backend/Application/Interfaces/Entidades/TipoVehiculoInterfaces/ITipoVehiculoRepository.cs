using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;

namespace Application.Interfaces.Entidades.TipoVehiculoInterfaces
{
    public interface ITipoVehiculoRepository
    {
        Task<IEnumerable<TipoVehiculo>> GetAllAsync();
        Task<TipoVehiculo?> GetByIdAsync(int id);
        Task AddAsync(TipoVehiculo tipo);
        Task UpdateAsync(TipoVehiculo tipo);
        Task DeleteAsync(int id);
    }
}
