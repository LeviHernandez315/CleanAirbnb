using Application.DTOs.Entidades.EmpresaDTOs;
using Application.Interfaces.Entidades.EmpresaInterfaces;
using Domain.Entities;

namespace Application.Services.Entidades
{
    public class EmpresaService : IEmpresaService
    {
        private readonly IEmpresaRepository _empresaRepository;

        public EmpresaService(IEmpresaRepository empresaRepository)
        {
            _empresaRepository = empresaRepository;
        }

        public async Task<IEnumerable<EmpresaResponseDTO>> GetAllAsync()
        {
            var items = await _empresaRepository.GetAllAsync();
            return items.Select(e => new EmpresaResponseDTO
            {
                Id = e.Id
                // TODO: Mapear propiedades restantes
            });
        }

        public async Task<EmpresaResponseDTO?> GetByIdAsync(int id)
        {
            var item = await _empresaRepository.GetByIdAsync(id);
            if (item == null) return null;
            return new EmpresaResponseDTO
            {
                Id = item.Id
                // TODO: Mapear propiedades restantes
            };
        }

        public async Task<EmpresaResponseDTO> CreateAsync(EmpresaRequestDTO dto)
        {
            var item = new Empresa
            {
                // TODO: Mapear desde dto a entidad
            };

            await _empresaRepository.AddAsync(item);

            return new EmpresaResponseDTO
            {
                Id = item.Id
                // TODO: Mapear propiedades restantes
            };
        }

        public async Task<bool> UpdateAsync(int id, EmpresaRequestDTO dto)
        {
            var item = await _empresaRepository.GetByIdAsync(id);
            if (item == null) return false;

            // TODO: Mapear dto a entidad existente

            return await _empresaRepository.UpdateAsync(item);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await _empresaRepository.DeleteAsync(id);
        }
    }
}