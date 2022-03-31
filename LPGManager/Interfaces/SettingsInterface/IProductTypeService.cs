using LPGManager.Models.Settings;

namespace LPGManager.Interfaces.SettingsInterface
{
    public interface IProductTypeService
    {
        Task<IEnumerable<ProductType>> GetAllAsync();
        Task<ProductType> GetAsync(long id);
        Task<ProductType> AddAsync(ProductType productType);
        Task<ProductType> UpdateAsync(ProductType model);
        Task DeleteAsync(long id);
    }
}
