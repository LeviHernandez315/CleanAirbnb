using Application.DTOs.Entidades.PersonaDTOs;
using Application.DTOs.Entidades.Rol;
using Application.DTOs.Entidades.RolDTOs;
namespace Application.DTOs.Entidades.UsuarioDTOs
    {
        public class UsuarioResponseDTO
        {
        public int Id { get; set; }
        public string? Email { get; set; }
        public string? Dni { get; set; }
        public int RolId { get; set; }


        public PersonaResponseDTO? Persona { get; set; }
        public RolResponseDTO? Rol { get; set; }
    }
    }