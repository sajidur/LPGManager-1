using LPGManager.Models.Settings;

namespace LPGManager.Interfaces.SettingsInterface
{
    public interface IProductService
    {
        Task<IEnumerable<Product>> GetAllAsync();
        Task<Product> GetAsync(long id);
        Task<Product> AddAsync(Product supplier);
        Task<Product> UpdateAsync(Product model);
        Task DeleteAsync(long id);
    }
}
