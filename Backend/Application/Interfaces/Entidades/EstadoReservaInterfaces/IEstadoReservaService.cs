using Application.DTOs.Entidades.EstadoReservaDTOs;

namespace Application.Interfaces.Entidades.EstadoReservaInterfaces
{
    public interface IEstadoReservaService
    {
        Task<IEnumerable<EstadoReservaResponseDTO>> GetAllAsync();
        Task<EstadoReservaResponseDTO?> GetByIdAsync(int id);
        Task<EstadoReservaResponseDTO> CreateAsync(EstadoReservaRequestDTO dto);
        Task<bool> UpdateAsync(int id, EstadoReservaRequestDTO dto);
        Task<bool> DeleteAsync(int id);
    }
}