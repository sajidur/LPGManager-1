using LPGManager.Models;
namespace LPGManager.Interfaces.CompanyInterface
{
    public interface ICompanyService
    {       
        Task<IEnumerable<Company>> GetAllAsync(long tenant);
        Task<Company> GetAsync(long id);
        Task<Company> AddAsync(Company company);
        Task<Company> UpdateAsync(Company model);
        Task DeleteAsync(long id);
    }
}
