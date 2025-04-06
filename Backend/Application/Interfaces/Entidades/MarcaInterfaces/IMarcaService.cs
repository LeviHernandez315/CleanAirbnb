using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.DTOs.Entidades.MarcaDTOs;

namespace Application.Interfaces.Entidades.MarcaInterfaces
{
    public interface IMarcaService
    {
        Task<IEnumerable<MarcaRequestDTO>> GetAllAsync();
        Task<MarcaRequestDTO?> GetByIdAsync(int id);
        Task<MarcaResponseDTO> CreateAsync(MarcaRequestDTO dto);
        Task<bool> UpdateAsync(int id, MarcaRequestDTO dto);
        Task<bool> DeleteAsync(int id);
    }
}
