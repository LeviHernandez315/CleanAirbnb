using Application.DTOs.AggregateRoots.ReseñaPropiedadDTOs;
using Application.Interfaces.AggregateRoots.ReseñaPropiedadInterfaces;
using Domain.AggregateRoots;

namespace Application.Services.AggregateRoots
{
    public class ReseñaPropiedadService : IReseñaPropiedadService
    {
        private readonly IReseñaPropiedadRepository _reseñapropiedadRepository;

        public ReseñaPropiedadService(IReseñaPropiedadRepository reseñapropiedadRepository)
        {
            _reseñapropiedadRepository = reseñapropiedadRepository;
        }

        public async Task<IEnumerable<ReseñaPropiedadResponseDTO>> GetAllAsync()
        {
            var items = await _reseñapropiedadRepository.GetAllAsync();
            return items.Select(e => new ReseñaPropiedadResponseDTO
            {
                Id = e.Id
                // TODO: Mapear propiedades restantes
            });
        }

        public async Task<ReseñaPropiedadResponseDTO?> GetByIdAsync(int id)
        {
            var item = await _reseñapropiedadRepository.GetByIdAsync(id);
            if (item == null) return null;
            return new ReseñaPropiedadResponseDTO
            {
                Id = item.Id
                // TODO: Mapear propiedades restantes
            };
        }

        public async Task<ReseñaPropiedadResponseDTO> CreateAsync(ReseñaPropiedadRequestDTO dto)
        {
            var item = new ReseñaPropiedad
            {
                // TODO: Mapear desde dto a entidad
            };

            await _reseñapropiedadRepository.AddAsync(item);

            return new ReseñaPropiedadResponseDTO
            {
                Id = item.Id
                // TODO: Mapear propiedades restantes
            };
        }

        public async Task<bool> UpdateAsync(int id, ReseñaPropiedadRequestDTO dto)
        {
            var item = await _reseñapropiedadRepository.GetByIdAsync(id);
            if (item == null) return false;

            // TODO: Mapear dto a entidad existente

            return await _reseñapropiedadRepository.UpdateAsync(item);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await _reseñapropiedadRepository.DeleteAsync(id);
        }
    }
}