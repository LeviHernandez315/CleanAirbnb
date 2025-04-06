using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;

namespace Application.Interfaces.Entidades.TelefonoInterfaces
{
    public interface ITelefonoRepository
    {
        Task<IEnumerable<Telefono>> GetAllAsync();
        Task<Telefono?> GetByIdAsync(int id);
        Task<Telefono> CreateAsync(Telefono telefono);
        Task<bool> UpdateAsync(Telefono telefono);
        Task<bool> DeleteAsync(int id);
    }
}
