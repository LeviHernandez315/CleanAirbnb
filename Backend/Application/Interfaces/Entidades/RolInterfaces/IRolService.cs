using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.DTOs.Entidades.Rol;
using Application.DTOs.Entidades.RolDTOs;

namespace Application.Interfaces.Entidades.RolInterfaces
{
    public interface IRolService
    {
        Task<IEnumerable<RolResponseDTO>> GetAllAsync();
        Task<RolResponseDTO?> GetByIdAsync(int id);
        Task<int> CreateAsync(RolRequestDTO dto);
        Task<bool> UpdateAsync(int id, RolRequestDTO dto);
        Task<bool> DeleteAsync(int id);
    }
}
