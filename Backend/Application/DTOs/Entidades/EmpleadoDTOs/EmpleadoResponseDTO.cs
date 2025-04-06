namespace Application.DTOs.Entidades.EmpleadoDTOs
    {
        public class EmpleadoResponseDTO
        {
            public int Id { get; set; }
        public string Email { get; set; }
        public string Dni { get; set; }
        public int RolId { get; set; }
        public int PuestoId { get; set; }
        public decimal Salario { get; set; }
        public int DireccionId { get; set; }
        }
    }