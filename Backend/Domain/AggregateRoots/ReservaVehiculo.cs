using Domain.Common;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Domain.AggregateRoots
{
    public class ReservaVehiculo : AggregateRoot
    {
 
        public int IdVehiculo { get; set; }
        public int IdReserva { get; set; }
        public decimal PrecioVehiculo { get; set; }
        public decimal ImpuestoVehiculo { get; set; }

        public Reserva? Reserva { get; set; }
        public Vehiculo? Vehiculo { get; set; }
    }

}
