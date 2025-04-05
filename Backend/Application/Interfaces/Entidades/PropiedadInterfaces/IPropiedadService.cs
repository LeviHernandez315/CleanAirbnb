using Application.DTOs.Entidades.PropiedadDTOs;

namespace Application.Interfaces.Entidades.PropiedadInterfaces
{
    public interface IPropiedadService
    {
        Task<IEnumerable<PropiedadResponseDTO>> GetAllAsync();
        Task<PropiedadResponseDTO?> GetByIdAsync(int id);
        Task<PropiedadResponseDTO> CreateAsync(PropiedadRequestDTO dto);
        Task<bool> UpdateAsync(int id, PropiedadRequestDTO dto);
        Task<bool> DeleteAsync(int id);
    }
}