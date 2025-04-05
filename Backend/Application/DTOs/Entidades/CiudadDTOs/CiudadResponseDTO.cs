using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.Entidades.CiudadDTOs
{
    public class CiudadResponseDTO
    {
        public int Id { get; set; }

        public string Descripcion { get; set; } = string.Empty;

        public int DepartamentoId { get; set; }

    }
}
