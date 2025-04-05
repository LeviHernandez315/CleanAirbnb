namespace Application.DTOs.Entidades.UsuarioDTOs
    {
        public class UsuarioResponseDTO
        {
            public int Id { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public string? Dni { get; set; }
        public int RolId { get; set; }
        }
    }