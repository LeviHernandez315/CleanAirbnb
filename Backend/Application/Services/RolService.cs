using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.DTOs.Rol;
using Application.Interfaces;

using Domain.Entities;

namespace Application.Services
{
    public class RolService : IRolService
    {
        private readonly IRolRepository _rolRepository;

        public RolService(IRolRepository rolRepository)
        {
            _rolRepository = rolRepository;
        }

        public async Task<IEnumerable<RolResponseDTO>> GetAllAsync()
        {
            var roles = await _rolRepository.GetAllAsync();
            return roles.Select(r => new RolResponseDTO
            {
                Id = r.Id,
                Descripcion = r.Descripcion
            });
        }

        public async Task<RolResponseDTO?> GetByIdAsync(int id)
        {
            var rol = await _rolRepository.GetByIdAsync(id);
            if (rol == null) return null;

            return new RolResponseDTO
            {
                Id = rol.Id,
                Descripcion = rol.Descripcion
            };
        }

        public async Task<int> CreateAsync(RolRequestDTO dto)
        {
            var nuevoRol = new Rol(dto.Descripcion);
            await _rolRepository.AddAsync(nuevoRol);
            return nuevoRol.Id;
        }

        public async Task<bool> UpdateAsync(int id, RolRequestDTO dto)
        {
            var rol = await _rolRepository.GetByIdAsync(id);
            if (rol == null) return false;

            rol.Descripcion = dto.Descripcion;
            await _rolRepository.UpdateAsync(rol);
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var rol = await _rolRepository.GetByIdAsync(id);
            if (rol == null) return false;

            await _rolRepository.DeleteAsync(id);
            return true;
        }
    }
}
