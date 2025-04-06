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
            var estadoReservas = await _estadoreservaRepository.GetAllAsync();
            return estadoReservas.Select(er => new EstadoReservaResponseDTO
            {
                Id = er.Id,
                Descripcion = er.Descripcion
            });
        }

        public async Task<EstadoReservaResponseDTO?> GetByIdAsync(int id)
        {
            var estadoReserva = await _estadoreservaRepository.GetByIdAsync(id);
            if (estadoReserva == null) return null;
            return new EstadoReservaResponseDTO
            {
                Id = estadoReserva.Id,
                Descripcion = estadoReserva.Descripcion
                
            };
        }

        public async Task<EstadoReservaResponseDTO> CreateAsync(EstadoReservaRequestDTO dto)
        {
            var estadoReserva = new EstadoReserva
            {
                Descripcion = dto.Descripcion
            };

            await _estadoreservaRepository.AddAsync(estadoReserva);

            return new EstadoReservaResponseDTO
            {
                Id = estadoReserva.Id,
                Descripcion = estadoReserva.Descripcion
            };
        }

        public async Task<bool> UpdateAsync(int id, EstadoReservaRequestDTO dto)
        {
            var estadoReserva = await _estadoreservaRepository.GetByIdAsync(id);
            if (estadoReserva == null) return false;

            estadoReserva.Descripcion = dto.Descripcion;

            return await _estadoreservaRepository.UpdateAsync(estadoReserva);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await _estadoreservaRepository.DeleteAsync(id);
        }
    }
}