using LPGManager.Models;

namespace LPGManager.Interfaces.SupplierInterface
{
    public interface ISupplierService
    {

        Task<IEnumerable<Supplier>> GetAllAsync();        
        Task<Supplier> GetAsync(int id);
        Task<Supplier> AddAsync(Supplier supplier);
        Task<Supplier> UpdateAsync(Supplier model);
        Task DeleteAsync(int id);
    }
}
