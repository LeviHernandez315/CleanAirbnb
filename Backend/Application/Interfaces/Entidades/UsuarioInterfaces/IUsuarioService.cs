using Application.DTOs.Entidades.UsuarioDTOs;

namespace Application.Interfaces.Entidades.UsuarioInterfaces
{
    public interface IUsuarioService
    {
        Task<IEnumerable<UsuarioResponseDTO>> GetAllAsync();
        Task<UsuarioResponseDTO?> GetByIdAsync(int id);
        Task<UsuarioResponseDTO> CreateAsync(UsuarioRequestDTO dto);
        Task<bool> UpdateAsync(int id, UsuarioRequestDTO dto);
        Task<bool> DeleteAsync(int id);
    }
}