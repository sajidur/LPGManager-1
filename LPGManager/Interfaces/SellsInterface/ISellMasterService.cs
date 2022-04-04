using LPGManager.Dtos;
using LPGManager.Models;

namespace LPGManager.Interfaces.SellsInterface
{
    public interface ISellMasterService
    {
     
        List<SellMasterDtos> GetAllAsync();
        Task<SellMaster> GetAsync(long id);
        SellMaster AddAsync(SellMasterDtos model);
        Task<SellMaster> UpdateAsync(SellMasterDtos model);
        Task DeleteAsync(long id);
    }
}
