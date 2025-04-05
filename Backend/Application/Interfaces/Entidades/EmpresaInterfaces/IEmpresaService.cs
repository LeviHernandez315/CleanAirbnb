using Application.DTOs.Entidades.EmpresaDTOs;

namespace Application.Interfaces.Entidades.EmpresaInterfaces
{
    public interface IEmpresaService
    {
        Task<IEnumerable<EmpresaResponseDTO>> GetAllAsync();
        Task<EmpresaResponseDTO?> GetByIdAsync(int id);
        Task<EmpresaResponseDTO> CreateAsync(EmpresaRequestDTO dto);
        Task<bool> UpdateAsync(int id, EmpresaRequestDTO dto);
        Task<bool> DeleteAsync(int id);
    }
}