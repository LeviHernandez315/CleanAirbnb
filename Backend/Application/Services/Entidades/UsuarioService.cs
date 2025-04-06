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
            var items = await _usuarioRepository.GetAllAsync();
            return items.Select(e => new UsuarioResponseDTO
            {
                Id = e.Id
                // TODO: Mapear propiedades restantes
            });
        }

        public async Task<UsuarioResponseDTO?> GetByIdAsync(int id)
        {
            var item = await _usuarioRepository.GetByIdAsync(id);
            if (item == null) return null;
            return new UsuarioResponseDTO
            {
                Id = item.Id
                // TODO: Mapear propiedades restantes
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
            var item = await _usuarioRepository.GetByIdAsync(id);
            if (item == null) return false;

            // TODO: Mapear dto a entidad existente

            return await _usuarioRepository.UpdateAsync(item);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await _usuarioRepository.DeleteAsync(id);
        }
    }
}