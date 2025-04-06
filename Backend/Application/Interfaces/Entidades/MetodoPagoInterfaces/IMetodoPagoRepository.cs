using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;

namespace Application.Interfaces.Entidades.MetodoPagoInterfaces
{
    public interface IMetodoPagoRepository
    {
        Task<IEnumerable<MetodoPago>> GetAllAsync();
        Task<MetodoPago?> GetByIdAsync(int id);
        Task<MetodoPago> CreateAsync(MetodoPago metodoPago);
        Task<bool> UpdateAsync(MetodoPago metodoPago);
        Task<bool> DeleteAsync(int id);
    }
}
