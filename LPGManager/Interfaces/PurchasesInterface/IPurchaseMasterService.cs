using LPGManager.Dtos;
using LPGManager.Models;

namespace LPGManager.Interfaces.PurchasesInterface
{
    public interface IPurchaseMasterService
    {
        List<PurchaseMasterDtos> GetAllAsync(long tenantId);
        List<PurchaseMasterDtos> GetAllAsync(long startDate, long endDate,long tenantId);
        Task<PurchaseMaster> GetAsync(long id);
        PurchaseMaster AddAsync(PurchaseMasterDtos model);
        Task<PurchaseMaster> UpdateAsync(PurchaseMasterDtos model);
        Task DeleteAsync(long id);
    }
}
