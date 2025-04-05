using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Persona
    {
        public string DNI { get; set; } = string.Empty;
        public string? RTN { get; set; }

        public string PrimerNombre { get; set; } = string.Empty;
        public string? SegundoNombre { get; set; }

        public string PrimerApellido { get; set; } = string.Empty;
        public string? SegundoApellido { get; set; }

        public int Edad { get; set; }
        public DateTime FechaNacimiento { get; set; }

        public List<Telefono> Telefono { get; set; } = new();
    }
}
