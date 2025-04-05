using Application.DTOs.AggregateRoots.EncabezadoFacturaDTOs;
using Application.Interfaces.AggregateRoots.EncabezadoFacturaInterfaces;
using Domain.AggregateRoots;

namespace Application.Services.AggregateRoots
{
    public class EncabezadoFacturaService : IEncabezadoFacturaService
    {
        private readonly IEncabezadoFacturaRepository _encabezadofacturaRepository;

        public EncabezadoFacturaService(IEncabezadoFacturaRepository encabezadofacturaRepository)
        {
            _encabezadofacturaRepository = encabezadofacturaRepository;
        }

        public async Task<IEnumerable<EncabezadoFacturaResponseDTO>> GetAllAsync()
        {
            var items = await _encabezadofacturaRepository.GetAllAsync();
            return items.Select(e => new EncabezadoFacturaResponseDTO
            {
                Id = e.Id
                // TODO: Mapear propiedades restantes
            });
        }

        public async Task<EncabezadoFacturaResponseDTO?> GetByIdAsync(int id)
        {
            var item = await _encabezadofacturaRepository.GetByIdAsync(id);
            if (item == null) return null;
            return new EncabezadoFacturaResponseDTO
            {
                Id = item.Id
                // TODO: Mapear propiedades restantes
            };
        }

        public async Task<EncabezadoFacturaResponseDTO> CreateAsync(EncabezadoFacturaRequestDTO dto)
        {
            var item = new EncabezadoFactura
            {
                // TODO: Mapear desde dto a entidad
            };

            await _encabezadofacturaRepository.AddAsync(item);

            return new EncabezadoFacturaResponseDTO
            {
                Id = item.Id
                // TODO: Mapear propiedades restantes
            };
        }

        public async Task<bool> UpdateAsync(int id, EncabezadoFacturaRequestDTO dto)
        {
            var item = await _encabezadofacturaRepository.GetByIdAsync(id);
            if (item == null) return false;

            // TODO: Mapear dto a entidad existente

            return await _encabezadofacturaRepository.UpdateAsync(item);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await _encabezadofacturaRepository.DeleteAsync(id);
        }
    }
}