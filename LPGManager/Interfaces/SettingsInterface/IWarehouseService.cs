using LPGManager.Models.Settings;

namespace LPGManager.Interfaces.SettingsInterface
{
    public interface IWarehouseService
    {
        Task<IEnumerable<Warehouse>> GetAllAsync();
        Task<Warehouse> AddAsync(Warehouse warehouse);
        Task<Warehouse> UpdateAsync(Warehouse model);
        Task DeleteAsync(long id);
    }
}
