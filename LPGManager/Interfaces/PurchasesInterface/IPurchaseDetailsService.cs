using LPGManager.Models;

namespace LPGManager.Interfaces.PurchasesInterface
{
    public interface IPurchaseDetailsService
    {
        Task<IEnumerable<PurchaseDetails>> GetAllAsync();        
        Task<PurchaseDetails> GetAsync(int id);
        Task<PurchaseDetails> AddAsync(PurchaseDetails purchase);
        Task<PurchaseDetails> UpdateAsync(PurchaseDetails model);
        Task DeleteAsync(int id);
    }
}
