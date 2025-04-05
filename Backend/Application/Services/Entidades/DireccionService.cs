
using Application.DTOs.Entidades.DireccionDTOs;
using Application.Interfaces.Entidades.DireccionInterfaces;
using Domain.Entities;

namespace Application.Services.Entidades
{
    public class DireccionService : IDireccionService
    {
        private readonly IDireccionRepository _direccionRepository;

        public DireccionService(IDireccionRepository direccionRepository)
        {
            _direccionRepository = direccionRepository;
        }

        public async Task<IEnumerable<DireccionResponseDTO>> GetAllAsync()
        {
            var direcciones = await _direccionRepository.GetAllAsync();

            return direcciones.Select(d => new DireccionResponseDTO
            {
                Id = d.Id,
                NumCasa = d.NumCasa,
                Calle = d.Calle,
                Colonia = d.Colonia,
                IdCiudad = d.IdCiudad,
        
            });
        }

        public async Task<DireccionResponseDTO?> GetByIdAsync(int id)
        {
            var direccion = await _direccionRepository.GetByIdAsync(id);

            if (direccion is null)
                return null;

            return new DireccionResponseDTO
            {
                Id = direccion.Id,
                NumCasa = direccion.NumCasa,
                Calle = direccion.Calle,
                Colonia = direccion.Colonia,
                IdCiudad = direccion.IdCiudad
            };
        }

        public async Task<DireccionResponseDTO> CreateAsync(DireccionRequestDTO dto)
        {
            var direccion = new Direccion
            {
                NumCasa = dto.NumCasa,
                Calle = dto.Calle,
                Colonia = dto.Colonia,
                IdCiudad = dto.IdCiudad
            };

            await _direccionRepository.AddAsync(direccion);

            return new DireccionResponseDTO
            {
                Id = direccion.Id,
                NumCasa = direccion.NumCasa,
                Calle = direccion.Calle,
                Colonia = direccion.Colonia,
                IdCiudad = direccion.IdCiudad
            };
        }

        public async Task<bool> UpdateAsync(int id, DireccionRequestDTO dto)
        {
            var direccion = await _direccionRepository.GetByIdAsync(id);

            if (direccion is null)
                return false;

            direccion.NumCasa = dto.NumCasa;
            direccion.Calle = dto.Calle;
            direccion.Colonia = dto.Colonia;
            direccion.IdCiudad = dto.IdCiudad;

            return await _direccionRepository.UpdateAsync(direccion);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await _direccionRepository.DeleteAsync(id);
        }
    }
}
