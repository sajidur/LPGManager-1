using LPGManager.Dtos;
using LPGManager.Models;

namespace LPGManager.Interfaces.ExchangeInterface
{
    public interface IExchangeService
    {
        List<ExchangeMaster> GetAllAsync();
        List<ExchangeMasterDtos> GetAllAsync(long startDate, long endDate);
        ExchangeMasterDtos GetAsync(long id);
        ExchangeMaster AddAsync(ExchangeMasterDtos model);
        Task<ExchangeMaster> UpdateAsync(ExchangeMaster model);
        Task DeleteAsync(long id);
    }
}
