using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Common;

namespace Domain.Entities
{

    public class Empleado : AggregateRoot
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string Dni { get; set; }
        public int RolId { get; set; }
        public int PuestoId { get; set; }
        public decimal Salario { get; set; }
        public int DireccionId { get; set; }

        // Propiedades de navegación
        public Persona? Persona { get; set; }
        public Rol? Rol { get; set; }
        public PuestoTrabajo? PuestoTrabajo { get; set; }
        public Direccion? Direccion { get; set; }
    }
}
