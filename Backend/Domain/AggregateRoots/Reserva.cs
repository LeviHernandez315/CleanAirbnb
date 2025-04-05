using Domain.Common;
using Domain.Entities;


namespace Domain.AggregateRoots
{
    public class Reserva:AggregateRoot
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

        // Navegación
        public Propiedad? Propiedad { get; set; }
        public Usuario? Huesped { get; set; }
        public Empleado? EmpleadoLogistica { get; set; }
  
        public ICollection<ReservaVehiculo> ReservaVehiculos { get; set; } = new List<ReservaVehiculo>();
        public List<DatosPago> DatosPago { get; set; } = new();
    }
}