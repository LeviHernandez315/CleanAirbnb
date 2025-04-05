using Application.DTOs.Entidades.DetalleFacturaDTOs;

namespace Application.Interfaces.Entidades.DetalleFacturaInterfaces
{
    public interface IDetalleFacturaService
    {
        Task<IEnumerable<DetalleFacturaResponseDTO>> GetAllAsync();
        Task<DetalleFacturaResponseDTO?> GetByIdAsync(int id);
        Task<DetalleFacturaResponseDTO> CreateAsync(DetalleFacturaRequestDTO dto);
        Task<bool> UpdateAsync(int id, DetalleFacturaRequestDTO dto);
        Task<bool> DeleteAsync(int id);
    }
}