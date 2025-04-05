using Domain.Common;

namespace Domain.Entities
{
    public class Sucursal:Entity
    {
        public string Nombre { get; set; }
        public int IdDireccion { get; set; }
        public string Telefono { get; set; }
        public string CodigoSAR { get; set; }

        public int IdEmpresa { get; set; }

        // Propiedades de navegación
        public Direccion? Direccion { get; set; }
        public Empresa? Empresa { get; set; }
    }
}