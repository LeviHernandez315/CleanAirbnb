using Application.DTOs.Entidades.AreaTrabajoDTOs;
using Application.Interfaces.Entidades.AreaTrabajoInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Entidades
{
    public class AreaTrabajoService : IAreaTrabajoService
    {
        private readonly IAreaTrabajoRepository _areaTrabajoRepository;

        public AreaTrabajoService(IAreaTrabajoRepository areaTrabajoRepository)
        {
            _areaTrabajoRepository = areaTrabajoRepository;
        }

        public async Task<IEnumerable<AreaTrabajoResponseDTO>> GetAllAsync()
        {
            var areasTrabajo = await _areaTrabajoRepository.GetAllAsync();
            return areasTrabajo.Select(p => new AreaTrabajoResponseDTO { Id = p.Id, Descripcion = p.Descripcion });
        }

        public async Task<AreaTrabajoResponseDTO> GetByIdAsync(int id)
        {
            var areasTrabajo = await _areaTrabajoRepository.GetByIdAsync(id);
            return areasTrabajo is null ? null : new AreaTrabajoResponseDTO { Id = areasTrabajo.Id, Descripcion = areasTrabajo.Descripcion };
        }

        public async Task<AreaTrabajoResponseDTO> CreateAsync(AreaTrabajoRequestDTO dto)
        {
            var areasTrabajo = new Domain.Entities.AreaTrabajo(dto.Descripcion);
            await _areaTrabajoRepository.AddAsync(areasTrabajo);
            return new AreaTrabajoResponseDTO { Id = areasTrabajo.Id, Descripcion = dto.Descripcion, };
        }

        public async Task<bool> UpdateAsync(int id, AreaTrabajoRequestDTO dto)
        {
            var areasTrabajo = await _areaTrabajoRepository.GetByIdAsync(id);

            if (areasTrabajo is null)
                return false;

            areasTrabajo.Descripcion = dto.Descripcion;

            return await _areaTrabajoRepository.UpdateAsync(areasTrabajo);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await _areaTrabajoRepository.DeleteAsync(id);
        }

    }
}
