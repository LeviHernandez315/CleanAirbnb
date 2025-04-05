namespace Application.DTOs.AggregateRoots.ReseñaVehiculoDTOs
    {
        public class ReseñaVehiculoResponseDTO
        {
            public int Id { get; set; }
        public int IdUsuarioHuesped { get; set; }
        public int IdVehiculo { get; set; }
        public DateTime FechaReseña { get; set; }
        public string Comentario { get; set; }
        public int IdValoracion { get; set; }
        }
    }