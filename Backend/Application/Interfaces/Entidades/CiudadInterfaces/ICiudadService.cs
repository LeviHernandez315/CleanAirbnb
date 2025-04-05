using Application.DTOs.Entidades.CiudadDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Application.Interfaces.Entidades.CiudadInterfaces
{
    public interface ICiudadService
    {
        Task<IEnumerable<CiudadResponseDTO>> GetAllAsync();
        Task<CiudadResponseDTO> GetByIdAsync(int id);
        Task<CiudadResponseDTO> CreateAsync(CiudadRequestDTO dto);
        Task<bool> UpdateAsync(int id, CiudadRequestDTO dto);
        Task<bool> DeleteAsync(int id);
    }
}
