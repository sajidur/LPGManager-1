using LPGManager.Dtos;
using LPGManager.Models;

namespace LPGManager.Interfaces.InventoryInterface
{
    public interface IInventoryService
    {
        List<InventoryDtos> GetAllAsync(long tenantId);
        List<InventoryDtos> GetAllAsync(long tenantId,long companyId);
        List<Inventory> GetInventory(int companyId, string type, string size);
        InventoryDtos Get(long tenantId, long companyId, string productType, string size);
        Inventory AddAsync(InventoryDtos model);
        Task<Inventory> UpdateAsync(InventoryDtos model);
        Task DeleteAsync(long id);
    }
}
