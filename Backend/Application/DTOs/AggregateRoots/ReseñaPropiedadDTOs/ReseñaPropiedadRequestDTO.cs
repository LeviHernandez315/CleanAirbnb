namespace Application.DTOs.AggregateRoots.ReseñaPropiedadDTOs
    {
        public class ReseñaPropiedadRequestDTO
        {
            public int IdUsuarioHuesped { get; set; }
        public int IdPropiedad { get; set; }
        public DateTime FechaReseña { get; set; }
        public string Comentario { get; set; }
        public int IdValoracion { get; set; }
        }
    }