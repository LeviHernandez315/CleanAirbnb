namespace Application.DTOs.Entidades.DetalleFacturaDTOs
    {
        public class DetalleFacturaResponseDTO
        {
            public int Id { get; set; }
        public int IdEncabezadoFactura { get; set; }
        public decimal Subtotal { get; set; }
        public int Impuesto { get; set; }
        public int Descuento { get; set; }
        public decimal Total { get; set; }
        }
    }