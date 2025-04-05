using Application.DTOs.Entidades.DetalleFacturaDTOs;
using Application.Interfaces.Entidades.DetalleFacturaInterfaces;
using Domain.Entities;

namespace Application.Services.Entidades
{
    public class DetalleFacturaService : IDetalleFacturaService
    {
        private readonly IDetalleFacturaRepository _detallefacturaRepository;

        public DetalleFacturaService(IDetalleFacturaRepository detallefacturaRepository)
        {
            _detallefacturaRepository = detallefacturaRepository;
        }

        public async Task<IEnumerable<DetalleFacturaResponseDTO>> GetAllAsync()
        {
            var items = await _detallefacturaRepository.GetAllAsync();
            return items.Select(e => new DetalleFacturaResponseDTO
            {
                Id = e.Id
                // TODO: Mapear propiedades restantes
            });
        }

        public async Task<DetalleFacturaResponseDTO?> GetByIdAsync(int id)
        {
            var item = await _detallefacturaRepository.GetByIdAsync(id);
            if (item == null) return null;
            return new DetalleFacturaResponseDTO
            {
                Id = item.Id
                // TODO: Mapear propiedades restantes
            };
        }

        public async Task<DetalleFacturaResponseDTO> CreateAsync(DetalleFacturaRequestDTO dto)
        {
            var item = new DetalleFactura
            {
                // TODO: Mapear desde dto a entidad
            };

            await _detallefacturaRepository.AddAsync(item);

            return new DetalleFacturaResponseDTO
            {
                Id = item.Id
                // TODO: Mapear propiedades restantes
            };
        }

        public async Task<bool> UpdateAsync(int id, DetalleFacturaRequestDTO dto)
        {
            var item = await _detallefacturaRepository.GetByIdAsync(id);
            if (item == null) return false;

            // TODO: Mapear dto a entidad existente

            return await _detallefacturaRepository.UpdateAsync(item);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await _detallefacturaRepository.DeleteAsync(id);
        }
    }
}