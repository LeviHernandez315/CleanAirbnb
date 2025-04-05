namespace Application.DTOs.Entidades.DatosPagoDTOs
    {
        public class DatosPagoResponseDTO
        {
            public int Id { get; set; }
        public int IdReserva { get; set; }
        public DateTime Fecha { get; set; }
        public int IdMetodoPago { get; set; }
        public string BanderaPago { get; set; }
        }
    }