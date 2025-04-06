using Application.DTOs.Entidades.DetalleFacturaDTOs;
using Application.Interfaces.Entidades.DetalleFacturaInterfaces;
using Domain.AggregateRoots;
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
            var detalleFacturas = await _detallefacturaRepository.GetAllAsync();
            return detalleFacturas.Select(df => new DetalleFacturaResponseDTO
            {
                Id = df.Id,
                IdEncabezadoFactura = df.IdEncabezadoFactura,
                Subtotal = df.Subtotal,
                Impuesto = df.Impuesto,
                Descuento = df.Descuento,
                Total = df.Total
                
            });
        }

        public async Task<DetalleFacturaResponseDTO?> GetByIdAsync(int id)
        {
            var detalleFacturas = await _detallefacturaRepository.GetByIdAsync(id);
            if (detalleFacturas == null) return null;
            return new DetalleFacturaResponseDTO
            {
                Id = detalleFacturas.Id,
                IdEncabezadoFactura = detalleFacturas.IdEncabezadoFactura,
                Subtotal = detalleFacturas.Subtotal,
                Impuesto = detalleFacturas.Impuesto,
                Descuento = detalleFacturas.Descuento,
                Total = detalleFacturas.Total
            };
        }

        public async Task<DetalleFacturaResponseDTO> CreateAsync(DetalleFacturaRequestDTO dto)
        {
            var detalleFacturas = new DetalleFactura
            {
                IdEncabezadoFactura = dto.IdEncabezadoFactura,
                Subtotal = dto.Subtotal,
                Impuesto = dto.Impuesto,
                Descuento = dto.Descuento,
                Total = dto.Total
            };

            await _detallefacturaRepository.AddAsync(detalleFacturas);

            return new DetalleFacturaResponseDTO
            {
                Id = detalleFacturas.Id,
                IdEncabezadoFactura = detalleFacturas.IdEncabezadoFactura,
                Subtotal = detalleFacturas.Subtotal,
                Impuesto = detalleFacturas.Impuesto,
                Descuento = detalleFacturas.Descuento,
                Total = detalleFacturas.Total
            };
        }

        public async Task<bool> UpdateAsync(int id, DetalleFacturaRequestDTO dto)
        {
            var detalleFacturas = await _detallefacturaRepository.GetByIdAsync(id);
            if (detalleFacturas == null) return false;

            detalleFacturas.IdEncabezadoFactura = dto.IdEncabezadoFactura;
            detalleFacturas.Subtotal = dto.Subtotal;
            detalleFacturas.Impuesto = dto.Impuesto;
            detalleFacturas.Descuento = dto.Descuento;
            detalleFacturas.Total = dto.Total;

            return await _detallefacturaRepository.UpdateAsync(detalleFacturas);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await _detallefacturaRepository.DeleteAsync(id);
        }
    }
}