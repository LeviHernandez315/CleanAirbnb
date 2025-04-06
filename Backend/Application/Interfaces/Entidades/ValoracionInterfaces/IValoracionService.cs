using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.DTOs.Entidades.ValoracionDTOs;

namespace Application.Interfaces.Entidades.ValoracionInterfaces
{
    public interface IValoracionService
    {
        Task<IEnumerable<ValoracionResponseDTO>> GetAllAsync();
        Task<ValoracionResponseDTO> GetByIdAsync(int id);
        Task<ValoracionResponseDTO> CreateAsync(ValoracionRequestDTO dto);
        Task<bool> UpdateAsync(int id, ValoracionRequestDTO dto);
        Task<bool> DeleteAsync(int id);
    }
}
