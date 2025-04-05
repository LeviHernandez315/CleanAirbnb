using Application.DTOs.AggregateRoots.ReservaDTOs;
using Application.Interfaces.AggregateRoots.ReservaInterfaces;
using Domain.AggregateRoots;

namespace Application.Services.AggregateRoots
{
    public class ReservaService : IReservaService
    {
        private readonly IReservaRepository _reservaRepository;

        public ReservaService(IReservaRepository reservaRepository)
        {
            _reservaRepository = reservaRepository;
        }

        public async Task<IEnumerable<ReservaResponseDTO>> GetAllAsync()
        {
            var items = await _reservaRepository.GetAllAsync();
            return items.Select(e => new ReservaResponseDTO
            {
                Id = e.Id
                // TODO: Mapear propiedades restantes
            });
        }

        public async Task<ReservaResponseDTO?> GetByIdAsync(int id)
        {
            var item = await _reservaRepository.GetByIdAsync(id);
            if (item == null) return null;
            return new ReservaResponseDTO
            {
                Id = item.Id
                // TODO: Mapear propiedades restantes
            };
        }

        public async Task<ReservaResponseDTO> CreateAsync(ReservaRequestDTO dto)
        {
            var item = new Reserva
            {
                // TODO: Mapear desde dto a entidad
            };

            await _reservaRepository.AddAsync(item);

            return new ReservaResponseDTO
            {
                Id = item.Id
                // TODO: Mapear propiedades restantes
            };
        }

        public async Task<bool> UpdateAsync(int id, ReservaRequestDTO dto)
        {
            var item = await _reservaRepository.GetByIdAsync(id);
            if (item == null) return false;

            // TODO: Mapear dto a entidad existente

            return await _reservaRepository.UpdateAsync(item);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await _reservaRepository.DeleteAsync(id);
        }
    }
}