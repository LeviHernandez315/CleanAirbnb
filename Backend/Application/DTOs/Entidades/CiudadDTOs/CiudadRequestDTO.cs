using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.Entidades.CiudadDTOs
{
    public class CiudadRequestDTO
    {
        public string Descripcion { get; set; } = string.Empty;

        public int DepartamentoId { get; set; }
    }
}
