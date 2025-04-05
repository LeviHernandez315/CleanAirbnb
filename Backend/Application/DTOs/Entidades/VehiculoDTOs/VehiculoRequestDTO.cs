namespace Application.DTOs.Entidades.VehiculoDTOs
    {
        public class VehiculoRequestDTO
        {
            public int IdModelo { get; set; }
        public int IdDireccion { get; set; }
        public int Año { get; set; }
        public int IdTipoVehiculo { get; set; }
        public decimal PrecioDia { get; set; }
        public int IdEstadoReserva { get; set; }
        }
    }