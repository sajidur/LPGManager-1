using LPGManager.Dtos;
using LPGManager.Models;

namespace LPGManager.Interfaces.PurchasesInterface
{
    public interface IPurchaseMasterService
    {
        List<PurchaseMasterDtos> GetAllAsync();
        Task<PurchaseMaster> GetAsync(long id);
        PurchaseMaster AddAsync(PurchaseMasterDtos model);
        Task<PurchaseMaster> UpdateAsync(PurchaseMaster model);
        Task DeleteAsync(long id);
    }
}
