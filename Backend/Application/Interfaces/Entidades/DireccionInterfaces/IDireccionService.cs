using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.DTOs.Entidades.DireccionDTOs;

namespace Application.Interfaces.Entidades.DireccionInterfaces
{
    public interface IDireccionService
    {
        Task<IEnumerable<DireccionResponseDTO>> GetAllAsync();
        Task<DireccionResponseDTO?> GetByIdAsync(int id);
        Task<DireccionResponseDTO> CreateAsync(DireccionRequestDTO dto);
        Task<bool> UpdateAsync(int id, DireccionRequestDTO dto);
        Task<bool> DeleteAsync(int id);
    }
}
