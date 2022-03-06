using LPGManager.Models;

namespace LPGManager.Interfaces.SellsInterface
{
    public interface ISellMasterService
    {
        Task<IEnumerable<SellMaster>> GetAllAsync();
        Task<SellMaster> GetAsync(int id);
        Task<SellMaster> AddAsync(SellMaster purchase);
        Task<SellMaster> UpdateAsync(SellMaster model);
        Task DeleteAsync(int id);
    }
}
