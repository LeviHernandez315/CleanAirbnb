using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
using Application.DTOs.Entidades.DepartamentoDTOs;
using Application.Interfaces.Entidades.DepartamentoInterfaces;

namespace Application.Services.Entidades
{
    public class DepartamentoService : IDepartamentoService
    {
        private readonly IDepartamentoRepository _departamentoRepository;

        public DepartamentoService(IDepartamentoRepository departamentoRepository)
        {
            _departamentoRepository = departamentoRepository;
        }

        public async Task<IEnumerable<DepartamentoResponseDTO>> GetAllAsync()
        {
            var paises = await _departamentoRepository.GetAllAsync();
            return paises.Select(p => new DepartamentoResponseDTO { Id = p.Id, Descripcion = p.Descripcion });
        }

        public async Task<DepartamentoResponseDTO> GetByIdAsync(int id)
        {
            var departamentos = await _departamentoRepository.GetByIdAsync(id);
            return departamentos is null ? null : new DepartamentoResponseDTO { Id = departamentos.Id, Descripcion = departamentos.Descripcion };
        }

        public async Task<DepartamentoResponseDTO> CreateAsync(DepartamentoRequestDTO dto)
        {
            var departamento = new Departamento(dto.Descripcion)
            {
                IdPais = dto.IdPais
            };

            await _departamentoRepository.AddAsync(departamento);

            return new DepartamentoResponseDTO
            {
                Id = departamento.Id,
                Descripcion = departamento.Descripcion,
                IdPais = departamento.IdPais
            };
        }

        public async Task<bool> UpdateAsync(int id, DepartamentoRequestDTO dto)
        {
            var departamentos = await _departamentoRepository.GetByIdAsync(id);

            if (departamentos is null)
                return false;

            departamentos.Descripcion = dto.Descripcion;

            return await _departamentoRepository.UpdateAsync(departamentos);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await _departamentoRepository.DeleteAsync(id);
        }

    }
}
