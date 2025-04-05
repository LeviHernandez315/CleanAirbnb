using Application.DTOs.AggregateRoots.ReservaVehiculoDTOs;
using Application.Interfaces.AggregateRoots.ReservaVehiculoInterfaces;
using Domain.AggregateRoots;

namespace Application.Services.AggregateRoots
{
    public class ReservaVehiculoService : IReservaVehiculoService
    {
        private readonly IReservaVehiculoRepository _reservavehiculoRepository;

        public ReservaVehiculoService(IReservaVehiculoRepository reservavehiculoRepository)
        {
            _reservavehiculoRepository = reservavehiculoRepository;
        }

        public async Task<IEnumerable<ReservaVehiculoResponseDTO>> GetAllAsync()
        {
            var items = await _reservavehiculoRepository.GetAllAsync();
            return items.Select(e => new ReservaVehiculoResponseDTO
            {
                Id = e.Id
                // TODO: Mapear propiedades restantes
            });
        }

        public async Task<ReservaVehiculoResponseDTO?> GetByIdAsync(int id)
        {
            var item = await _reservavehiculoRepository.GetByIdAsync(id);
            if (item == null) return null;
            return new ReservaVehiculoResponseDTO
            {
                Id = item.Id
                // TODO: Mapear propiedades restantes
            };
        }

        public async Task<ReservaVehiculoResponseDTO> CreateAsync(ReservaVehiculoRequestDTO dto)
        {
            var item = new ReservaVehiculo
            {
                // TODO: Mapear desde dto a entidad
            };

            await _reservavehiculoRepository.AddAsync(item);

            return new ReservaVehiculoResponseDTO
            {
                Id = item.Id
                // TODO: Mapear propiedades restantes
            };
        }

        public async Task<bool> UpdateAsync(int id, ReservaVehiculoRequestDTO dto)
        {
            var item = await _reservavehiculoRepository.GetByIdAsync(id);
            if (item == null) return false;

            // TODO: Mapear dto a entidad existente

            return await _reservavehiculoRepository.UpdateAsync(item);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await _reservavehiculoRepository.DeleteAsync(id);
        }
    }
}