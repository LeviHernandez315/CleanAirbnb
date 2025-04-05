using Application.DTOs.Entidades.AreaTrabajoDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.Entidades.AreaTrabajoInterfaces
{
    public interface IAreaTrabajoService
    {
        Task<IEnumerable<AreaTrabajoResponseDTO>> GetAllAsync();
        Task<AreaTrabajoResponseDTO> GetByIdAsync(int id);
        Task<AreaTrabajoResponseDTO> CreateAsync(AreaTrabajoRequestDTO dto);
        Task<bool> UpdateAsync(int id, AreaTrabajoRequestDTO dto);
        Task<bool> DeleteAsync(int id);
    }
}
