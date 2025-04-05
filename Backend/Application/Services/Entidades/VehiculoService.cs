using Application.DTOs.Entidades.VehiculoDTOs;
using Application.Interfaces.Entidades.VehiculoInterfaces;
using Domain.Entities;

namespace Application.Services.Entidades
{
    public class VehiculoService : IVehiculoService
    {
        private readonly IVehiculoRepository _vehiculoRepository;

        public VehiculoService(IVehiculoRepository vehiculoRepository)
        {
            _vehiculoRepository = vehiculoRepository;
        }

        public async Task<IEnumerable<VehiculoResponseDTO>> GetAllAsync()
        {
            var items = await _vehiculoRepository.GetAllAsync();
            return items.Select(e => new VehiculoResponseDTO
            {
                Id = e.Id
                // TODO: Mapear propiedades restantes
            });
        }

        public async Task<VehiculoResponseDTO?> GetByIdAsync(int id)
        {
            var item = await _vehiculoRepository.GetByIdAsync(id);
            if (item == null) return null;
            return new VehiculoResponseDTO
            {
                Id = item.Id
                // TODO: Mapear propiedades restantes
            };
        }

        public async Task<VehiculoResponseDTO> CreateAsync(VehiculoRequestDTO dto)
        {
            var item = new Vehiculo
            {
                // TODO: Mapear desde dto a entidad
            };

            await _vehiculoRepository.AddAsync(item);

            return new VehiculoResponseDTO
            {
                Id = item.Id
                // TODO: Mapear propiedades restantes
            };
        }

        public async Task<bool> UpdateAsync(int id, VehiculoRequestDTO dto)
        {
            var item = await _vehiculoRepository.GetByIdAsync(id);
            if (item == null) return false;

            // TODO: Mapear dto a entidad existente

            return await _vehiculoRepository.UpdateAsync(item);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await _vehiculoRepository.DeleteAsync(id);
        }
    }
}