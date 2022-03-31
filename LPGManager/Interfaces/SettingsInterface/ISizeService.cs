using LPGManager.Models.Settings;

namespace LPGManager.Interfaces.SettingsInterface
{
    public interface ISizeService
    {
        Task<IEnumerable<Size>> GetAllAsync();
        Task<Size> GetAsync(long id);
        Task<Size> AddAsync(Size size);
        Task<Size> UpdateAsync(Size model);
        Task DeleteAsync(long id);
    }
}
