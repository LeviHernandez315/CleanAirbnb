using Application.DTOs.Entidades.EmpleadoDTOs;
using Application.Interfaces.Entidades.EmpleadoInterfaces;
using Domain.Entities;

namespace Application.Services.Entidades
{
    public class EmpleadoService : IEmpleadoService
    {
        private readonly IEmpleadoRepository _empleadoRepository;

        public EmpleadoService(IEmpleadoRepository empleadoRepository)
        {
            _empleadoRepository = empleadoRepository;
        }

        public async Task<IEnumerable<EmpleadoResponseDTO>> GetAllAsync()
        {
            var items = await _empleadoRepository.GetAllAsync();
            return items.Select(e => new EmpleadoResponseDTO
            {
                Id = e.Id
                // TODO: Mapear propiedades restantes
            });
        }

        public async Task<EmpleadoResponseDTO?> GetByIdAsync(int id)
        {
            var item = await _empleadoRepository.GetByIdAsync(id);
            if (item == null) return null;
            return new EmpleadoResponseDTO
            {
                Id = item.Id
                // TODO: Mapear propiedades restantes
            };
        }

        public async Task<EmpleadoResponseDTO> CreateAsync(EmpleadoRequestDTO dto)
        {
            var item = new Empleado
            {
                // TODO: Mapear desde dto a entidad
            };

            await _empleadoRepository.AddAsync(item);

            return new EmpleadoResponseDTO
            {
                Id = item.Id
                // TODO: Mapear propiedades restantes
            };
        }

        public async Task<bool> UpdateAsync(int id, EmpleadoRequestDTO dto)
        {
            var item = await _empleadoRepository.GetByIdAsync(id);
            if (item == null) return false;

            // TODO: Mapear dto a entidad existente

            return await _empleadoRepository.UpdateAsync(item);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await _empleadoRepository.DeleteAsync(id);
        }
    }
}