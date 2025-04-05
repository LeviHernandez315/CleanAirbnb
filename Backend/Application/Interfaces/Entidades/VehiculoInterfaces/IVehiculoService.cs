using Application.DTOs.Entidades.VehiculoDTOs;

namespace Application.Interfaces.Entidades.VehiculoInterfaces
{
    public interface IVehiculoService
    {
        Task<IEnumerable<VehiculoResponseDTO>> GetAllAsync();
        Task<VehiculoResponseDTO?> GetByIdAsync(int id);
        Task<VehiculoResponseDTO> CreateAsync(VehiculoRequestDTO dto);
        Task<bool> UpdateAsync(int id, VehiculoRequestDTO dto);
        Task<bool> DeleteAsync(int id);
    }
}