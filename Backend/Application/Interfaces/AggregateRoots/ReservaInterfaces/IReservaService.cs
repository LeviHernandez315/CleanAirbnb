using Application.DTOs.AggregateRoots.ReservaDTOs;

namespace Application.Interfaces.AggregateRoots.ReservaInterfaces
{
    public interface IReservaService
    {
        Task<IEnumerable<ReservaResponseDTO>> GetAllAsync();
        Task<ReservaResponseDTO?> GetByIdAsync(int id);
        Task<ReservaResponseDTO> CreateAsync(ReservaRequestDTO dto);
        Task<bool> UpdateAsync(int id, ReservaRequestDTO dto);
        Task<bool> DeleteAsync(int id);
    }
}