using Application.DTOs.Entidades.EstadoReservaDTOs;
using Application.Interfaces.Entidades.EstadoReservaInterfaces;
using Domain.Entities;

namespace Application.Services.Entidades
{
    public class EstadoReservaService : IEstadoReservaService
    {
        private readonly IEstadoReservaRepository _estadoreservaRepository;

        public EstadoReservaService(IEstadoReservaRepository estadoreservaRepository)
        {
            _estadoreservaRepository = estadoreservaRepository;
        }

        public async Task<IEnumerable<EstadoReservaResponseDTO>> GetAllAsync()
        {
            var items = await _estadoreservaRepository.GetAllAsync();
            return items.Select(e => new EstadoReservaResponseDTO
            {
                Id = e.Id
                // TODO: Mapear propiedades restantes
            });
        }

        public async Task<EstadoReservaResponseDTO?> GetByIdAsync(int id)
        {
            var item = await _estadoreservaRepository.GetByIdAsync(id);
            if (item == null) return null;
            return new EstadoReservaResponseDTO
            {
                Id = item.Id
                // TODO: Mapear propiedades restantes
            };
        }

        public async Task<EstadoReservaResponseDTO> CreateAsync(EstadoReservaRequestDTO dto)
        {
            var item = new EstadoReserva
            {
                // TODO: Mapear desde dto a entidad
            };

            await _estadoreservaRepository.AddAsync(item);

            return new EstadoReservaResponseDTO
            {
                Id = item.Id
                // TODO: Mapear propiedades restantes
            };
        }

        public async Task<bool> UpdateAsync(int id, EstadoReservaRequestDTO dto)
        {
            var item = await _estadoreservaRepository.GetByIdAsync(id);
            if (item == null) return false;

            // TODO: Mapear dto a entidad existente

            return await _estadoreservaRepository.UpdateAsync(item);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await _estadoreservaRepository.DeleteAsync(id);
        }
    }
}