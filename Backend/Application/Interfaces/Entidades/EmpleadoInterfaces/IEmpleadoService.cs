using Application.DTOs.Entidades.EmpleadoDTOs;

namespace Application.Interfaces.Entidades.EmpleadoInterfaces
{
    public interface IEmpleadoService
    {
        Task<IEnumerable<EmpleadoResponseDTO>> GetAllAsync();
        Task<EmpleadoResponseDTO?> GetByIdAsync(int id);
        Task<EmpleadoResponseDTO> CreateAsync(EmpleadoRequestDTO dto);
        Task<bool> UpdateAsync(int id, EmpleadoRequestDTO dto);
        Task<bool> DeleteAsync(int id);
    }
}