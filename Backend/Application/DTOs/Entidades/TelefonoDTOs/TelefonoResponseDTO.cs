using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.Entidades.TelefonoDTOs
{
    public class TelefonoResponseDTO
    {
        public int Id { get; set; }
        public string? NumTelefono { get; set; }
        public string? IdPersona { get; set; }
    }
}
