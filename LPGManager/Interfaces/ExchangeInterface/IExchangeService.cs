using LPGManager.Models;

namespace LPGManager.Interfaces.ExchangeInterface
{
    public interface IExchangeService
    {
        Task<IEnumerable<Exchange>> GetAllAsync();
        Task<Exchange> GetAsync(int id);
        Task<Exchange> AddAsync(Exchange company);
        Task<Exchange> UpdateAsync(Exchange model);
        Task DeleteAsync(int id);
    }
}
