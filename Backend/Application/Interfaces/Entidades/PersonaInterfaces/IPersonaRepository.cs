using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;

namespace Application.Interfaces.Entidades.PersonaInterfaces
{
    public interface IPersonaRepository
    {
        Task<IEnumerable<Persona>> GetAllAsync();
        Task<Persona?> GetByIdAsync(string dni);
        Task AddAsync(Persona persona);
        Task<bool> UpdateAsync(Persona persona);
        Task<bool> DeleteAsync(string dni);
    }
}
