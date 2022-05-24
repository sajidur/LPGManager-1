using LPGManager.Dtos;
using LPGManager.Models;

namespace LPGManager.Interfaces.InventoryInterface
{
    public interface IInventoryService
    {
        List<InventoryDtos> GetAllAsync(long tenantId);
        Task<Inventory> GetAsync(long id);
        Inventory AddAsync(InventoryDtos model);
        Task<Inventory> UpdateAsync(InventoryDtos model);
        Task DeleteAsync(long id);
    }
}
