using LPGManager.Models;

namespace LPGManager.Interfaces.SellsInterface
{
    public interface ISellDetailsService
    {
        Task<IEnumerable<SellDetails>> GetAllAsync();
        Task<SellDetails> GetAsync(int id);
        Task<SellDetails> AddAsync(SellDetails purchase);
        Task<SellDetails> UpdateAsync(SellDetails model);
        Task DeleteAsync(int id);
    }
}
