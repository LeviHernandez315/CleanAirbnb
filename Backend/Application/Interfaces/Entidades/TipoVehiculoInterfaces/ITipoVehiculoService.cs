using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.DTOs.Entidades.Rol;
using Application.DTOs.Entidades.TipoVehiculoDTOs;

namespace Application.Interfaces.Entidades.TipoVehiculoInterfaces
{
    public interface ITipoVehiculoService
    {
        Task<IEnumerable<TipoVehiculoResponseDTO>> GetAllAsync();
        Task<TipoVehiculoResponseDTO?> GetByIdAsync(int id);
        Task<TipoVehiculoResponseDTO> CreateAsync(TipoVehiculoRequestDTO dto);
        Task<bool> UpdateAsync(int id, TipoVehiculoRequestDTO dto);
        Task<bool> DeleteAsync(int id);
    }
}
