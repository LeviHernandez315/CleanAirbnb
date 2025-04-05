using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.Entidades.DepartamentoDTOs
{
     public class DepartamentoRequestDTO
    {
        public string Descripcion { get; set; } = string.Empty;

        public int IdPais { get; set; }

    }
}
