using Application.DTOs.Entidades.SucursalDTOs;

namespace Application.Interfaces.Entidades.SucursalInterfaces
{
    public interface ISucursalService
    {
        Task<IEnumerable<SucursalResponseDTO>> GetAllAsync();
        Task<SucursalResponseDTO?> GetByIdAsync(int id);
        Task<SucursalResponseDTO> CreateAsync(SucursalRequestDTO dto);
        Task<bool> UpdateAsync(int id, SucursalRequestDTO dto);
        Task<bool> DeleteAsync(int id);
    }
}