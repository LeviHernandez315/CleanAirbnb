using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.Entidades.ModeloDTOs
{
    public class ModeloResponseDTO
    {
        public int Id { get; set; }
        public string Descripcion { get; set; } = string.Empty;
        public int IdMarca { get; set; }
        public string? MarcaDescripcion { get; set; }
    }
}
