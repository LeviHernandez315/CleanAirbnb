using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.Entidades.PersonaDTOs
{
    public class PersonaResponseDTO
    {
        public string DNI { get; set; }
        public string? RTN { get; set; }
        public string PrimerNombre { get; set; }
        public string? SegundoNombre { get; set; }
        public string PrimerApellido { get; set; }
        public string? SegundoApellido { get; set; }
        public int Edad { get; set; }
        public DateTime FechaNacimiento { get; set; }

    }
}
