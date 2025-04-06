using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.DTOs.Entidades.ModeloDTOs;
using Application.Interfaces.Entidades.ModeloInterfaces;
using Domain.Entities;

namespace Application.Services.Entidades
{
    public class ModeloService: IModeloService
    {
        private readonly IModeloRepository _modeloRepository;

        public ModeloService(IModeloRepository modeloRepository)
        {
            _modeloRepository = modeloRepository;
        }

        public async Task<IEnumerable<ModeloResponseDTO>> GetAllAsync()
        {
            var modelos = await _modeloRepository.GetAllAsync();
            return modelos.Select(m => new ModeloResponseDTO
            {
                Id = m.Id,
                Descripcion = m.Descripcion,
                IdMarca = m.IdMarca
            });
        }

        public async Task<ModeloResponseDTO?> GetByIdAsync(int id)
        {
            var modelo = await _modeloRepository.GetByIdAsync(id);
            if (modelo == null) return null;

            return new ModeloResponseDTO
            {
                Id = modelo.Id,
                Descripcion = modelo.Descripcion,
                IdMarca = modelo.IdMarca
            };
        }

        public async Task<ModeloResponseDTO> CreateAsync(ModeloRequestDTO dto)
        {
            var modelo = new Modelo
            {
                Descripcion = dto.Descripcion,
                IdMarca = dto.IdMarca
            };

            await _modeloRepository.AddAsync(modelo);

            return new ModeloResponseDTO
            {
                Id = modelo.Id,
                Descripcion = modelo.Descripcion,
                IdMarca = modelo.IdMarca
            };
        }

        public async Task<bool> UpdateAsync(int id, ModeloRequestDTO dto)
        {
            var modelo = await _modeloRepository.GetByIdAsync(id);
            if (modelo == null) return false;

            modelo.Descripcion = dto.Descripcion;
            modelo.IdMarca = dto.IdMarca;

            return await _modeloRepository.UpdateAsync(modelo);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await _modeloRepository.DeleteAsync(id);
        }
    }
}
