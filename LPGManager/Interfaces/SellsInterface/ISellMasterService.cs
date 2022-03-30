using LPGManager.Dtos;
using LPGManager.Models;

namespace LPGManager.Interfaces.SellsInterface
{
    public interface ISellMasterService
    {
     
        Task<IEnumerable<SellMaster>> GetAllAsync();
        Task<SellMaster> GetAsync(int id);
        SellMaster AddAsync(SellMasterDtos model);
        Task<SellMaster> UpdateAsync(SellMasterDtos model);
        Task DeleteAsync(int id);
    }
}
