using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.DTOs.Entidades.ModeloDTOs;

namespace Application.Interfaces.Entidades.ModeloInterfaces
{
    public interface IModeloService
    {
        Task<IEnumerable<ModeloResponseDTO>> GetAllAsync();
        Task<ModeloResponseDTO?> GetByIdAsync(int id);
        Task<ModeloResponseDTO> CreateAsync(ModeloRequestDTO dto);
        Task<bool> UpdateAsync(int id, ModeloRequestDTO dto);
        Task<bool> DeleteAsync(int id);
    }
}
