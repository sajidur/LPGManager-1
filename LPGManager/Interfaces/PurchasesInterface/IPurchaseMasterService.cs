using LPGManager.Dtos;
using LPGManager.Models;

namespace LPGManager.Interfaces.PurchasesInterface
{
    public interface IPurchaseMasterService
    {
        Task<IEnumerable<PurchaseMaster>> GetAllAsync();        
        Task<PurchaseMaster> GetAsync(int id);
        PurchaseMaster AddAsync(PurchaseMasterDtos model);
        Task<PurchaseMaster> UpdateAsync(PurchaseMaster model);
        Task DeleteAsync(int id);
    }
}
