using Application.DTOs.Entidades.UsuarioDTOs;
using Application.Interfaces.Entidades.UsuarioInterfaces;
using Domain.Entities;
using System.Net;

namespace Application.Services.Entidades
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public UsuarioService(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        public async Task<IEnumerable<UsuarioResponseDTO>> GetAllAsync()
        {
            var usuario = await _usuarioRepository.GetAllAsync();
            return usuario.Select(u => new UsuarioResponseDTO
            {
                Id = u.Id,
                Email = u.Email,
                Dni = u.Dni,
                RolId = u.RolId
            });
        }

        public async Task<UsuarioResponseDTO?> GetByIdAsync(int id)
        {
            var usuario = await _usuarioRepository.GetByIdAsync(id);
            if (usuario == null) return null;
            return new UsuarioResponseDTO
            {
                Id = usuario.Id,
                Email = usuario.Email,
                Dni = usuario.Dni,
                RolId = usuario.RolId

            };
        }

        public async Task<UsuarioResponseDTO> CreateAsync(UsuarioRequestDTO dto)
        {
            var usuario = new Usuario
            {
                Email = dto.Email,
                Password = dto.Password,
                Dni = dto.Dni,
                RolId = dto.RolId

            };
                
           
            await _usuarioRepository.AddAsync(usuario);

            return new UsuarioResponseDTO
            {
                Id = usuario.Id,
                Email = usuario.Email

                // TODO: Mapear propiedades restantes
            };
        }

        public async Task<bool> UpdateAsync(int id, UsuarioRequestDTO dto)
        {
            var usuario = await _usuarioRepository.GetByIdAsync(id);
            if (usuario == null) return false;

            usuario.Email = dto.Email;
            usuario.Password = dto.Password;
            usuario.Dni = dto.Dni;
            usuario.RolId = dto.RolId;

            return await _usuarioRepository.UpdateAsync(usuario);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await _usuarioRepository.DeleteAsync(id);
        }
    }
}