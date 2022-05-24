using LPGManager.Dtos;
using LPGManager.Models;

namespace LPGManager.Interfaces.SellsInterface
{
    public interface ISellMasterService
    {
     
        List<SellMasterDtos> GetAllAsync(long tenantId);
        List<SellMasterDtos> GetAllAsync(long startDate, long endDate, long tenantId);
        SellMasterDtos GetAsync(long id);
        SellMaster AddAsync(SellMasterDtos model);
        Task<SellMaster> UpdateAsync(SellMasterDtos model);
        Task DeleteAsync(long id);
    }
}
