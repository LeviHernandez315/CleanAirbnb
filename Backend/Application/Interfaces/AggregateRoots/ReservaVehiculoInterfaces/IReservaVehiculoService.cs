using Application.DTOs.AggregateRoots.ReservaVehiculoDTOs;

namespace Application.Interfaces.AggregateRoots.ReservaVehiculoInterfaces
{
    public interface IReservaVehiculoService
    {
        Task<IEnumerable<ReservaVehiculoResponseDTO>> GetAllAsync();
        Task<ReservaVehiculoResponseDTO?> GetByIdAsync(int id);
        Task<ReservaVehiculoResponseDTO> CreateAsync(ReservaVehiculoRequestDTO dto);
        Task<bool> UpdateAsync(int id, ReservaVehiculoRequestDTO dto);
        Task<bool> DeleteAsync(int id);
    }
}