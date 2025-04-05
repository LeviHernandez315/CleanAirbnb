using Domain.AggregateRoots;

namespace Application.Interfaces.AggregateRoots.EncabezadoFacturaInterfaces
{
    public interface IEncabezadoFacturaRepository
    {
        Task<IEnumerable<EncabezadoFactura>> GetAllAsync();
        Task<EncabezadoFactura?> GetByIdAsync(int id);
        Task AddAsync(EncabezadoFactura entity);
        Task<bool> UpdateAsync(EncabezadoFactura entity);
        Task<bool> DeleteAsync(int id);
    }
}