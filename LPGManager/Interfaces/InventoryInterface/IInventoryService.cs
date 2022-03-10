using LPGManager.Models;

namespace LPGManager.Interfaces.InventoryInterface
{
    public interface IInventoryService
    {
        Task<IEnumerable<Inventory>> GetAllAsync();
        Task<Inventory> GetAsync(int id);
        Task<Inventory> AddAsync(Inventory purchase);
        Task<Inventory> UpdateAsync(Inventory model);
        Task DeleteAsync(int id);
    }
}
