using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Common;

namespace Domain.Entities
{
    public class Empresa:Entity
    {
        public string? Nombre { get; set; }
        public string? Rtn { get; set; }
        public string? Correo { get; set; }
        public string? CasaMatriz { get; set; }
        public string? Telefono { get; set; }

        public List<Sucursal> Sucursal { get; set; } = new();
    }
}
