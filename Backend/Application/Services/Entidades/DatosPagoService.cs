using Application.DTOs.Entidades.DatosPagoDTOs;
using Application.Interfaces.Entidades.DatosPagoInterfaces;
using Domain.Entities;

namespace Application.Services.Entidades
{
    public class DatosPagoService : IDatosPagoService
    {
        private readonly IDatosPagoRepository _datospagoRepository;

        public DatosPagoService(IDatosPagoRepository datospagoRepository)
        {
            _datospagoRepository = datospagoRepository;
        }

        public async Task<IEnumerable<DatosPagoResponseDTO>> GetAllAsync()
        {
            var items = await _datospagoRepository.GetAllAsync();
            return items.Select(e => new DatosPagoResponseDTO
            {
                Id = e.Id
                // TODO: Mapear propiedades restantes
            });
        }

        public async Task<DatosPagoResponseDTO?> GetByIdAsync(int id)
        {
            var item = await _datospagoRepository.GetByIdAsync(id);
            if (item == null) return null;
            return new DatosPagoResponseDTO
            {
                Id = item.Id
                // TODO: Mapear propiedades restantes
            };
        }

        public async Task<DatosPagoResponseDTO> CreateAsync(DatosPagoRequestDTO dto)
        {
            var item = new DatosPago
            {
                // TODO: Mapear desde dto a entidad
            };

            await _datospagoRepository.AddAsync(item);

            return new DatosPagoResponseDTO
            {
                Id = item.Id
                // TODO: Mapear propiedades restantes
            };
        }

        public async Task<bool> UpdateAsync(int id, DatosPagoRequestDTO dto)
        {
            var item = await _datospagoRepository.GetByIdAsync(id);
            if (item == null) return false;

            // TODO: Mapear dto a entidad existente

            return await _datospagoRepository.UpdateAsync(item);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await _datospagoRepository.DeleteAsync(id);
        }
    }
}