namespace Application.DTOs.AggregateRoots.ReservaVehiculoDTOs
    {
        public class ReservaVehiculoResponseDTO
        {
            public int Id { get; set; }
        public int IdVehiculo { get; set; }
        public int IdReserva { get; set; }
        public decimal PrecioVehiculo { get; set; }
        public decimal ImpuestoVehiculo { get; set; }
        }
    }