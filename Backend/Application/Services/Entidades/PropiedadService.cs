using Application.DTOs.Entidades.PropiedadDTOs;
using Application.Interfaces.Entidades.PropiedadInterfaces;
using Domain.Entities;

namespace Application.Services.Entidades
{
    public class PropiedadService : IPropiedadService
    {
        private readonly IPropiedadRepository _propiedadRepository;

        public PropiedadService(IPropiedadRepository propiedadRepository)
        {
            _propiedadRepository = propiedadRepository;
        }

        public async Task<IEnumerable<PropiedadResponseDTO>> GetAllAsync()
        {
            var items = await _propiedadRepository.GetAllAsync();
            return items.Select(e => new PropiedadResponseDTO
            {
                Id = e.Id
                // TODO: Mapear propiedades restantes
            });
        }

        public async Task<PropiedadResponseDTO?> GetByIdAsync(int id)
        {
            var item = await _propiedadRepository.GetByIdAsync(id);
            if (item == null) return null;
            return new PropiedadResponseDTO
            {
                Id = item.Id
                // TODO: Mapear propiedades restantes
            };
        }

        public async Task<PropiedadResponseDTO> CreateAsync(PropiedadRequestDTO dto)
        {
            var item = new Propiedad
            {
                // TODO: Mapear desde dto a entidad
            };

            await _propiedadRepository.AddAsync(item);

            return new PropiedadResponseDTO
            {
                Id = item.Id
                // TODO: Mapear propiedades restantes
            };
        }

        public async Task<bool> UpdateAsync(int id, PropiedadRequestDTO dto)
        {
            var item = await _propiedadRepository.GetByIdAsync(id);
            if (item == null) return false;

            // TODO: Mapear dto a entidad existente

            return await _propiedadRepository.UpdateAsync(item);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await _propiedadRepository.DeleteAsync(id);
        }
    }
}