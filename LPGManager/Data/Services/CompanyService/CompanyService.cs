
using LPGManager.Interfaces.CompanyInterface;
using LPGManager.Models;

using Microsoft.EntityFrameworkCore;

namespace LPGManager.Data.Services.CompanyService
{
    public class CompanyService : ICompanyService
    {
        private IGenericRepository<Company> _genericRepository;

        public CompanyService(IGenericRepository<Company> genericRepository)
        {
            _genericRepository = genericRepository;
        }
        public async Task<Company> AddAsync(Company company)
        {
            var existing = await _genericRepository.FindBy(c => c.CompanyName == company.CompanyName).FirstOrDefaultAsync();
            if (string.IsNullOrWhiteSpace(company.CompanyName))
                throw new ArgumentException("write supplier name");
            if (existing != null)
                throw new ArgumentException("Already exist");
            _genericRepository.Insert(company);
            _genericRepository.Save();
            return company;
        }
        public async Task<IEnumerable<Company>> GetAllAsync(long tenant)
        {
            var data = await _genericRepository.FindBy(a=>a.TenantId==tenant).ToListAsync();
            return (data);
        }
        public async Task<Company> GetAsync(long id)
        {
            var data = _genericRepository.GetById(id);
            if (data == null)
                throw new ArgumentException("Company is not exist");
            return (data.Result);
        }
        public async Task<Company> UpdateAsync(Company model)
        {
            //var existing = await _dbContext.Companies.FirstOrDefaultAsync(c => c.Id == model.Id);
            //if (string.IsNullOrWhiteSpace(model.CompanyName))
            //    throw new ArgumentException("Supplier name not found");
            //if (existing == null)
            //    throw new ArgumentException("Company is not exist");
            //model.CreatedOn = DateTime.UtcNow;
            //_dbContext.Entry(existing).CurrentValues.SetValues(model);

            //return model;
            return null;
        }
        public async Task DeleteAsync(long id)
        {
            var existing = _genericRepository.GetById(id);

            if (existing == null)
                throw new ArgumentException("Company is not exist");

            _genericRepository.Delete(id);
            _genericRepository.Save();
        }
    }

}
