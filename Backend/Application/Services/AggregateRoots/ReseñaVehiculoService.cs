using Application.DTOs.AggregateRoots.ReseñaVehiculoDTOs;
using Application.Interfaces.AggregateRoots.ReseñaVehiculoInterfaces;
using Domain.AggregateRoots;

namespace Application.Services.AggregateRoots
{
    public class ReseñaVehiculoService : IReseñaVehiculoService
    {
        private readonly IReseñaVehiculoRepository _reseñavehiculoRepository;

        public ReseñaVehiculoService(IReseñaVehiculoRepository reseñavehiculoRepository)
        {
            _reseñavehiculoRepository = reseñavehiculoRepository;
        }

        public async Task<IEnumerable<ReseñaVehiculoResponseDTO>> GetAllAsync()
        {
            var items = await _reseñavehiculoRepository.GetAllAsync();
            return items.Select(e => new ReseñaVehiculoResponseDTO
            {
                Id = e.Id
                // TODO: Mapear propiedades restantes
            });
        }

        public async Task<ReseñaVehiculoResponseDTO?> GetByIdAsync(int id)
        {
            var item = await _reseñavehiculoRepository.GetByIdAsync(id);
            if (item == null) return null;
            return new ReseñaVehiculoResponseDTO
            {
                Id = item.Id
                // TODO: Mapear propiedades restantes
            };
        }

        public async Task<ReseñaVehiculoResponseDTO> CreateAsync(ReseñaVehiculoRequestDTO dto)
        {
            var item = new ReseñaVehiculo
            {
                // TODO: Mapear desde dto a entidad
            };

            await _reseñavehiculoRepository.AddAsync(item);

            return new ReseñaVehiculoResponseDTO
            {
                Id = item.Id
                // TODO: Mapear propiedades restantes
            };
        }

        public async Task<bool> UpdateAsync(int id, ReseñaVehiculoRequestDTO dto)
        {
            var item = await _reseñavehiculoRepository.GetByIdAsync(id);
            if (item == null) return false;

            // TODO: Mapear dto a entidad existente

            return await _reseñavehiculoRepository.UpdateAsync(item);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await _reseñavehiculoRepository.DeleteAsync(id);
        }
    }
}