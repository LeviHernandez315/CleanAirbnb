using Application.DTOs.AggregateRoots.ReseñaVehiculoDTOs;

namespace Application.Interfaces.AggregateRoots.ReseñaVehiculoInterfaces
{
    public interface IReseñaVehiculoService
    {
        Task<IEnumerable<ReseñaVehiculoResponseDTO>> GetAllAsync();
        Task<ReseñaVehiculoResponseDTO?> GetByIdAsync(int id);
        Task<ReseñaVehiculoResponseDTO> CreateAsync(ReseñaVehiculoRequestDTO dto);
        Task<bool> UpdateAsync(int id, ReseñaVehiculoRequestDTO dto);
        Task<bool> DeleteAsync(int id);
    }
}