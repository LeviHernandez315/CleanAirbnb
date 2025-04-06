namespace Application.DTOs.Entidades.PropiedadDTOs
    {
        public class PropiedadResponseDTO
        {
            public int Id { get; set; }
            public string Nombre { get; set; }
            public string Descripcion { get; set; }
            public int IdDireccion { get; set; }
            public int Capacidad { get; set; }
            public int NumeroHabitaciones { get; set; }
            public int NumeroCamas { get; set; }
            public int CapacidadParqueo { get; set; }
            public decimal PrecioPorNoche { get; set; }
            public int IdAnfitrion { get; set; }
            public int IdEstadoReserva { get; set; }
            public decimal MediaValoracion { get; set; }
        }
    }