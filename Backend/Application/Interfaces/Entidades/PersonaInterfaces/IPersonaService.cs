using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.DTOs.Entidades.PersonaDTOs;

namespace Application.Interfaces.Entidades.PersonaInterfaces
{
    public interface IPersonaService
    {
        Task<IEnumerable<PersonaResponseDTO>> GetAllAsync();
        Task<PersonaResponseDTO?> GetByIdAsync(string dni);
        Task<PersonaResponseDTO> CreateAsync(PersonaRequestDTO dto);
        Task<bool> UpdateAsync(string dni, PersonaRequestDTO dto);
        Task<bool> DeleteAsync(string dni);
    }
}
