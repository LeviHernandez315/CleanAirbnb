using Application.DTOs.AggregateRoots.EncabezadoFacturaDTOs;

namespace Application.Interfaces.AggregateRoots.EncabezadoFacturaInterfaces
{
    public interface IEncabezadoFacturaService
    {
        Task<IEnumerable<EncabezadoFacturaResponseDTO>> GetAllAsync();
        Task<EncabezadoFacturaResponseDTO?> GetByIdAsync(int id);
        Task<EncabezadoFacturaResponseDTO> CreateAsync(EncabezadoFacturaRequestDTO dto);
        Task<bool> UpdateAsync(int id, EncabezadoFacturaRequestDTO dto);
        Task<bool> DeleteAsync(int id);
    }
}