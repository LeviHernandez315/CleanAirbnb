namespace Application.DTOs.AggregateRoots.ReservaDTOs
    {
        public class ReservaRequestDTO
        {
            public DateTime FechaCheckIn { get; set; }
        public DateTime FechaCheckOut { get; set; }
        public int NumeroHuespedes { get; set; }
        public int IdPropiedad { get; set; }
        public decimal PrecioEstadia { get; set; }
        public int IdHuesped { get; set; }
        public decimal MontoImpuesto { get; set; }
        public int IdEmpleadoLogistica { get; set; }
        public decimal Adelanto { get; set; }
        }
    }