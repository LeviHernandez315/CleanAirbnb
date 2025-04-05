using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.DTOs.Entidades.DepartamentoDTOs;

namespace Application.Interfaces.Entidades.DepartamentoInterfaces
{
    public interface IDepartamentoService
    {
        Task<IEnumerable<DepartamentoResponseDTO>> GetAllAsync();
        Task<DepartamentoResponseDTO> GetByIdAsync(int id);
        Task<DepartamentoResponseDTO> CreateAsync(DepartamentoRequestDTO dto);
        Task<bool> UpdateAsync(int id, DepartamentoRequestDTO dto);
        Task<bool> DeleteAsync(int id);
    }
}
