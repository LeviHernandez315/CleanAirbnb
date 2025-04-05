using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.DTOs.Entidades.PuestoTrabajoDTOs;
using Application.Interfaces.Entidades.PuestoTrabajoInterfaces;
using Domain.Entities;

namespace Application.Services.Entidades
{
    public class PuestoTrabajoService : IPuestoTrabajoService
    {
        private readonly IPuestoTrabajoRepository _puestoRepository;

        public PuestoTrabajoService(IPuestoTrabajoRepository puestoRepository)
        {
            _puestoRepository = puestoRepository;
        }

        public async Task<IEnumerable<PuestoTrabajoResponseDTO>> GetAllAsync()
        {
            var puestos = await _puestoRepository.GetAllAsync();
            return puestos.Select(p => new PuestoTrabajoResponseDTO
            {
                Id = p.Id,
                Descripcion = p.Descripcion,
                IdArea = p.IdArea
            });
        }

        public async Task<PuestoTrabajoResponseDTO?> GetByIdAsync(int id)
        {
            var puesto = await _puestoRepository.GetByIdAsync(id);
            return puesto is null ? null : new PuestoTrabajoResponseDTO
            {
                Id = puesto.Id,
                Descripcion = puesto.Descripcion,
                IdArea = puesto.IdArea
            };
        }

        public async Task<PuestoTrabajoResponseDTO> CreateAsync(PuestoTrabajoRequestDTO dto)
        {
            var puesto = new PuestoTrabajo(dto.Descripcion)
            {
                IdArea = dto.IdArea
            };

            await _puestoRepository.AddAsync(puesto);

            return new PuestoTrabajoResponseDTO
            {
                Id = puesto.Id,
                Descripcion = puesto.Descripcion,
                IdArea = puesto.IdArea
            };
        }

        public async Task<bool> UpdateAsync(int id, PuestoTrabajoRequestDTO dto)
        {
            var puesto = await _puestoRepository.GetByIdAsync(id);
            if (puesto is null) return false;

            puesto.Descripcion = dto.Descripcion;
            puesto.IdArea = dto.IdArea;

            return await _puestoRepository.UpdateAsync(puesto);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await _puestoRepository.DeleteAsync(id);
        }
    }
}
