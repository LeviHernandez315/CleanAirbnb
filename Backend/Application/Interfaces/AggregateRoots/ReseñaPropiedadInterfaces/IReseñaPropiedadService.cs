using Application.DTOs.AggregateRoots.ReseñaPropiedadDTOs;

namespace Application.Interfaces.AggregateRoots.ReseñaPropiedadInterfaces
{
    public interface IReseñaPropiedadService
    {
        Task<IEnumerable<ReseñaPropiedadResponseDTO>> GetAllAsync();
        Task<ReseñaPropiedadResponseDTO?> GetByIdAsync(int id);
        Task<ReseñaPropiedadResponseDTO> CreateAsync(ReseñaPropiedadRequestDTO dto);
        Task<bool> UpdateAsync(int id, ReseñaPropiedadRequestDTO dto);
        Task<bool> DeleteAsync(int id);
    }
}