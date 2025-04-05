using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.DTOs.Entidades.PuestoTrabajoDTOs;

namespace Application.Interfaces.Entidades.PuestoTrabajoInterfaces
{
    public interface  IPuestoTrabajoService
    {
        Task<IEnumerable<PuestoTrabajoResponseDTO>> GetAllAsync();
        Task<PuestoTrabajoResponseDTO?> GetByIdAsync(int id);
        Task<PuestoTrabajoResponseDTO> CreateAsync(PuestoTrabajoRequestDTO dto);
        Task<bool> UpdateAsync(int id, PuestoTrabajoRequestDTO dto);
        Task<bool> DeleteAsync(int id);
    }
}
