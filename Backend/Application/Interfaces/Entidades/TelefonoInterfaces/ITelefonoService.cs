using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.DTOs.Entidades.TelefonoDTOs;

namespace Application.Interfaces.Entidades.TelefonoInterfaces
{
    public interface ITelefonoService
    {
        Task<IEnumerable<TelefonoResponseDTO>> GetAllAsync();
        Task<TelefonoResponseDTO> GetByIdAsync(int id);
        Task<TelefonoResponseDTO> CreateAsync(TelefonoRequestDTO dto);
        Task<bool> UpdateAsync(int id, TelefonoRequestDTO dto);
        Task<bool> DeleteAsync(int id);
    }
}
