using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.Entidades.DepartamentoDTOs
{
    public class DepartamentoResponseDTO
    {
        public int Id { get; set; }
        public string Descripcion { get; set; } = string.Empty;
        public int IdPais { get; set; }

    }
}
