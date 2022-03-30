using LPGManager.Models;

namespace LPGManager.Interfaces.InventoryInterface
{
    public interface IInventoryService
    {
        Task<IEnumerable<Inventory>> GetAllAsync();
        Task<Inventory> GetAsync(int id);
        Inventory GetInventory(string productName, string sizeName, int companyId, string productType, int warehouse);
        Task<Inventory> AddAsync(Inventory purchase);
        Task<Inventory> UpdateAsync(Inventory model);
        Task DeleteAsync(int id);
    }
}
