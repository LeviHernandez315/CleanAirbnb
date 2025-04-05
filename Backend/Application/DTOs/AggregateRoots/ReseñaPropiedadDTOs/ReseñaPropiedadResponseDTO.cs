namespace Application.DTOs.Entidades.ReseñaPropiedadDTOs
    {
        public class ReseñaPropiedadResponseDTO
        {
            public int Id { get; set; }
        public int IdUsuarioHuesped { get; set; }
        public int IdPropiedad { get; set; }
        public DateTime FechaReseña { get; set; }
        public string Comentario { get; set; }
        public int IdValoracion { get; set; }
        }
    }