
using Domain.AggregateRoots;
using Domain.Common;


namespace Domain.Entities
{
    public class DatosPago:Entity
    {

        public int IdReserva { get; set; }
        public DateTime Fecha { get; set; }
        public int IdMetodoPago { get; set; }
        public string BanderaPago { get; set; }

        // Propiedades de navegación
        public Reserva? Reserva { get; set; }
        public MetodoPago? MetodoPago { get; set; }
    }
}