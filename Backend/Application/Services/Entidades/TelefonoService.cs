using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.DTOs.Entidades.TelefonoDTOs;
using Application.Interfaces.Entidades.TelefonoInterfaces;
using Domain.Entities;

namespace Application.Services.Entidades
{
    public class TelefonoService : ITelefonoService
    {
        private readonly ITelefonoRepository _repository;

        public TelefonoService(ITelefonoRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<TelefonoResponseDTO>> GetAllAsync()
        {
            var lista = await _repository.GetAllAsync();

            return lista.Select(t => new TelefonoResponseDTO
            {
                Id = t.Id,
                NumTelefono = t.NumTelefono,
                IdPersona = t.IdPersona
            });
        }

        public async Task<TelefonoResponseDTO> GetByIdAsync(int id)
        {
            var telefono = await _repository.GetByIdAsync(id);

            if (telefono == null)
                throw new Exception("Teléfono no encontrado");

            return new TelefonoResponseDTO
            {
                Id = telefono.Id,
                NumTelefono = telefono.NumTelefono,
                IdPersona = telefono.IdPersona
            };
        }

        public async Task<TelefonoResponseDTO> CreateAsync(TelefonoRequestDTO dto)
        {
            var telefono = new Telefono
            {
                NumTelefono = dto.NumTelefono,
                IdPersona = dto.IdPersona
            };

            var creado = await _repository.CreateAsync(telefono);

            return new TelefonoResponseDTO
            {
                Id = creado.Id,
                NumTelefono = creado.NumTelefono,
                IdPersona = creado.IdPersona
            };
        }

        public async Task<bool> UpdateAsync(int id, TelefonoRequestDTO dto)
        {
            var telefono = await _repository.GetByIdAsync(id);

            if (telefono == null)
                return false;

            telefono.NumTelefono = dto.NumTelefono;
            telefono.IdPersona = dto.IdPersona;

            return await _repository.UpdateAsync(telefono);
        }


        public async Task<bool> DeleteAsync(int id)
        {
            return await _repository.DeleteAsync(id);
        }
    }
}
