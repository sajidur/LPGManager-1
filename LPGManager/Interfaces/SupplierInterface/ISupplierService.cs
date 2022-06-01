using LPGManager.Models;

namespace LPGManager.Interfaces.SupplierInterface
{
    public interface ISupplierService
    {

        Task<IEnumerable<Supplier>> GetAllAsync(long tenantId);
        Task<Supplier> GetAsync(long id);
        Task<Supplier> AddAsync(Supplier supplier);
        Task<Supplier> UpdateAsync(Supplier model);
        Task DeleteAsync(long id);
    }
}
