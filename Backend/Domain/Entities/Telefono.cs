using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Telefono
    {
        public string? NumTelefono { get; set; }
        public string? IdPersona { get; set; }
        public Persona? Persona { get; set; }
    }
}
