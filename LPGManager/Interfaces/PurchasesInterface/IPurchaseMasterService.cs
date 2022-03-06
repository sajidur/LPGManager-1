using LPGManager.Models;

namespace LPGManager.Interfaces.PurchasesInterface
{
    public interface IPurchaseMasterService
    {
        Task<IEnumerable<PurchaseMaster>> GetAllAsync();        
        Task<PurchaseMaster> GetAsync(int id);
        Task<PurchaseMaster> AddAsync(PurchaseMaster purchase);
        Task<PurchaseMaster> UpdateAsync(PurchaseMaster model);
        Task DeleteAsync(int id);
    }
}
