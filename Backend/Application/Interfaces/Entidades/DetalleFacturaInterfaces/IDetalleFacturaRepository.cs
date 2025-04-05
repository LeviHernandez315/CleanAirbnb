using Domain.Entities;

namespace Application.Interfaces.Entidades.DetalleFacturaInterfaces
{
    public interface IDetalleFacturaRepository
    {
        Task<IEnumerable<DetalleFactura>> GetAllAsync();
        Task<DetalleFactura?> GetByIdAsync(int id);
        Task AddAsync(DetalleFactura entity);
        Task<bool> UpdateAsync(DetalleFactura entity);
        Task<bool> DeleteAsync(int id);
    }
}