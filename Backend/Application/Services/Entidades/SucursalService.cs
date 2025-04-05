using Application.DTOs.Entidades.SucursalDTOs;
using Application.Interfaces.Entidades.SucursalInterfaces;
using Domain.Entities;

namespace Application.Services.Entidades
{
    public class SucursalService : ISucursalService
    {
        private readonly ISucursalRepository _sucursalRepository;

        public SucursalService(ISucursalRepository sucursalRepository)
        {
            _sucursalRepository = sucursalRepository;
        }

        public async Task<IEnumerable<SucursalResponseDTO>> GetAllAsync()
        {
            var items = await _sucursalRepository.GetAllAsync();
            return items.Select(e => new SucursalResponseDTO
            {
                Id = e.Id
                // TODO: Mapear propiedades restantes
            });
        }

        public async Task<SucursalResponseDTO?> GetByIdAsync(int id)
        {
            var item = await _sucursalRepository.GetByIdAsync(id);
            if (item == null) return null;
            return new SucursalResponseDTO
            {
                Id = item.Id
                // TODO: Mapear propiedades restantes
            };
        }

        public async Task<SucursalResponseDTO> CreateAsync(SucursalRequestDTO dto)
        {
            var item = new Sucursal
            {
                // TODO: Mapear desde dto a entidad
            };

            await _sucursalRepository.AddAsync(item);

            return new SucursalResponseDTO
            {
                Id = item.Id
                // TODO: Mapear propiedades restantes
            };
        }

        public async Task<bool> UpdateAsync(int id, SucursalRequestDTO dto)
        {
            var item = await _sucursalRepository.GetByIdAsync(id);
            if (item == null) return false;

            // TODO: Mapear dto a entidad existente

            return await _sucursalRepository.UpdateAsync(item);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await _sucursalRepository.DeleteAsync(id);
        }
    }
}