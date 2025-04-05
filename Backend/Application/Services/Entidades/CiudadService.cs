using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.DTOs.Entidades.CiudadDTOs;
using Application.Interfaces.Entidades.CiudadInterfaces;
using Domain.Entities;

namespace Application.Services.Entidades
{
    public class CiudadService : ICiudadService
    {
        private readonly ICiudadRepository _ciudadRepository;

        public CiudadService(ICiudadRepository ciudadRepository)
        {
            _ciudadRepository = ciudadRepository;
        }

        public async Task<IEnumerable<CiudadResponseDTO>> GetAllAsync()
        {
            var ciudad = await _ciudadRepository.GetAllAsync();
            return ciudad.Select(p => new CiudadResponseDTO { Id = p.Id, Descripcion = p.Descripcion });
        }

        public async Task<CiudadResponseDTO> GetByIdAsync(int id)
        {
            var ciudad = await _ciudadRepository.GetByIdAsync(id);
            return ciudad is null ? null : new CiudadResponseDTO { Id = ciudad.Id, Descripcion = ciudad.Descripcion };
        }

        public async Task<CiudadResponseDTO> CreateAsync(CiudadRequestDTO dto)
        {
            var ciudad = new Domain.Entities.Ciudad(dto.Descripcion)
            {
                DepartamentoId = dto.DepartamentoId
            };

            await _ciudadRepository.AddAsync(ciudad);

            return new CiudadResponseDTO
            {
                Id = ciudad.Id,
                Descripcion = ciudad.Descripcion,
                DepartamentoId = ciudad.DepartamentoId
            };
        }

        public async Task<bool> UpdateAsync(int id, CiudadRequestDTO dto)
        {
            var ciudades = await _ciudadRepository.GetByIdAsync(id);

            if (ciudades is null)
                return false;

            ciudades.Descripcion = dto.Descripcion;

            return await _ciudadRepository.UpdateAsync(ciudades);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await _ciudadRepository.DeleteAsync(id);
        }

    }
}
