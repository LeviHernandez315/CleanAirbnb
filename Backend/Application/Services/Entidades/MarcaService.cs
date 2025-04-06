
using Application.DTOs.Entidades.MarcaDTOs;
using Application.Interfaces.Entidades.MarcaInterfaces;
using Domain.Entities;

namespace Application.Services.Entidades
{
    public class MarcaService : IMarcaService
    {
        private readonly IMarcaRepository _marcaRepository;

        public MarcaService(IMarcaRepository marcaRepository)
        {
            _marcaRepository = marcaRepository;
        }

        public async Task<IEnumerable<MarcaRequestDTO>> GetAllAsync()
        {
            var marcas = await _marcaRepository.GetAllAsync();
            return marcas.Select(m => new MarcaRequestDTO
            {
                Descripcion = m.Descripcion
            });
        }

        public async Task<MarcaRequestDTO?> GetByIdAsync(int id)
        {
            var marca = await _marcaRepository.GetByIdAsync(id);
            if (marca == null) return null;

            return new MarcaRequestDTO
            {
                Descripcion = marca.Descripcion
            };
        }

        public async Task<MarcaResponseDTO> CreateAsync(MarcaRequestDTO dto)
        {
            var nuevaMarca = new Marca
            {
                Descripcion = dto.Descripcion
            };

            await _marcaRepository.AddAsync(nuevaMarca);

            return new MarcaResponseDTO
            {
                Id = nuevaMarca.Id,
                Descripcion = nuevaMarca.Descripcion
            };
        }

        public async Task<bool> UpdateAsync(int id, MarcaRequestDTO dto)
        {
            var marcaExistente = await _marcaRepository.GetByIdAsync(id);
            if (marcaExistente == null) return false;

            marcaExistente.Descripcion = dto.Descripcion;
            return await _marcaRepository.UpdateAsync(marcaExistente);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await _marcaRepository.DeleteAsync(id);
        }
    }
}
