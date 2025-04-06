using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.Entidades.ValoracionDTOs
{
    public class ValoracionRequestDTO
    {
        public string Descripcion { get; set; } = string.Empty;
        public int Valor { get; set; }
    }
}
