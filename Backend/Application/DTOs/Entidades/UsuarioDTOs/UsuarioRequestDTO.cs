namespace Application.DTOs.Entidades.UsuarioDTOs
    {
        public class UsuarioRequestDTO
        {
            public string? Email { get; set; }
        public string? Password { get; set; }
        public string? Dni { get; set; }
        public int RolId { get; set; }
        }
    }