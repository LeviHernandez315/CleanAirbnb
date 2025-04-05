using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.AggregateRoots.EncabezadoFacturaDTOs
{
    public class EncabezadoFacturaRequestDTO
    
    {
        public int IdUsuario { get; set; }
        public int IdReserva { get; set; }
        public int IdEmpresa { get; set; }
        public DateTime FechaFactura { get; set; }
        public string NumFactura { get; set; } = string.Empty;
        public bool Exonerado { get; set; }
        public int IdSucursal { get; set; }
    }
}
