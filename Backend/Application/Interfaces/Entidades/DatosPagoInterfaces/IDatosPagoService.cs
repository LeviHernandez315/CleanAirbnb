using Application.DTOs.Entidades.DatosPagoDTOs;

namespace Application.Interfaces.Entidades.DatosPagoInterfaces
{
    public interface IDatosPagoService
    {
        Task<IEnumerable<DatosPagoResponseDTO>> GetAllAsync();
        Task<DatosPagoResponseDTO?> GetByIdAsync(int id);
        Task<DatosPagoResponseDTO> CreateAsync(DatosPagoRequestDTO dto);
        Task<bool> UpdateAsync(int id, DatosPagoRequestDTO dto);
        Task<bool> DeleteAsync(int id);
    }
}