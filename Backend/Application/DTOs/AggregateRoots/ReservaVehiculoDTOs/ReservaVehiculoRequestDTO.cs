namespace Application.DTOs.AggregateRoots.ReservaVehiculoDTOs
    {
        public class ReservaVehiculoRequestDTO
        {
            public int IdVehiculo { get; set; }
        public int IdReserva { get; set; }
        public decimal PrecioVehiculo { get; set; }
        public decimal ImpuestoVehiculo { get; set; }
        }
    }