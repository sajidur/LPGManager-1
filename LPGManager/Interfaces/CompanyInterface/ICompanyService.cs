using LPGManager.Models;
namespace LPGManager.Interfaces.CompanyInterface
{
    public interface ICompanyService
    {       
        Task<IEnumerable<Company>> GetAllAsync();
        Task<Company> GetAsync(int id);
        Task<Company> AddAsync(Company company);
        Task<Company> UpdateAsync(Company model);
        Task DeleteAsync(int id);
    }
}
