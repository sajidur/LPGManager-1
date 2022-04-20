using LPGManager.Dtos;
using LPGManager.Models;

namespace LPGManager.Interfaces.PurchasesInterface
{
    public interface IPurchaseMasterService
    {
        List<PurchaseMasterDtos> GetAllAsync();
        List<PurchaseMasterDtos> GetAllAsync(long startDate, long endDate);
        Task<PurchaseMaster> GetAsync(long id);
        PurchaseMaster AddAsync(PurchaseMasterDtos model);
        Task<PurchaseMaster> UpdateAsync(PurchaseMasterDtos model);
        Task DeleteAsync(long id);
    }
}
