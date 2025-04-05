using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.DTOs.Entidades.PaisDTOs;

namespace Application.Interfaces.Entidades.PaisInterfaces
{
    public interface IPaisService
    {
        Task<IEnumerable<PaisResponseDTO>> GetAllAsync();
        Task<PaisResponseDTO> GetByIdAsync(int id);
        Task<PaisResponseDTO> CreateAsync(PaisRequestDTO dto);
        Task<bool> UpdateAsync(int id, PaisRequestDTO dto);
        Task<bool> DeleteAsync(int id);
    }
}
