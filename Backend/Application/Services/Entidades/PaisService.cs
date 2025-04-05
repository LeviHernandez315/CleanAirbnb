using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.DTOs.Entidades.PaisDTOs;
using Application.Interfaces.Entidades.PaisInterfaces;

namespace Application.Services.Entidades
{
    public class PaisService : IPaisService
    {
        private readonly IPaisRepository _paisRepository;

        public PaisService(IPaisRepository paisRepository)
        {
            _paisRepository = paisRepository;
        }

        public async Task<IEnumerable<PaisResponseDTO>> GetAllAsync()
        {
            var paises = await _paisRepository.GetAllAsync();
            return paises.Select(p => new PaisResponseDTO { Id = p.Id, Descripcion = p.Descripcion });
        }

        public async Task<PaisResponseDTO> GetByIdAsync(int id)
        {
            var paises = await _paisRepository.GetByIdAsync(id);
            return paises is null ? null : new PaisResponseDTO { Id = paises.Id, Descripcion = paises.Descripcion };
        }

        public async Task<PaisResponseDTO> CreateAsync(PaisRequestDTO dto)
        {
            var paises = new Domain.Entities.Pais(dto.Descripcion);
            await _paisRepository.AddAsync(paises);
            return new PaisResponseDTO { Id = paises.Id, Descripcion = dto.Descripcion, };
        }

        public async Task<bool> UpdateAsync(int id, PaisRequestDTO dto)
        {
            var paises = await _paisRepository.GetByIdAsync(id);

            if (paises is null)
                return false;

            paises.Descripcion = dto.Descripcion;

            return await _paisRepository.UpdateAsync(paises);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await _paisRepository.DeleteAsync(id);
        }

    }
}
