
using LPGManager.Interfaces.CompanyInterface;
using LPGManager.Models;

using Microsoft.EntityFrameworkCore;

namespace LPGManager.Data.Services.CompanyService
{
    public class CompanyService : ICompanyService
    {
        private readonly AppsDbContext _dbContext;

        public CompanyService(AppsDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<Company> AddAsync(Company company)
        {
            var existing = await _dbContext.Companies.FirstOrDefaultAsync(c => c.CompanyName == company.CompanyName);
            if (string.IsNullOrWhiteSpace(company.CompanyName))
                throw new ArgumentException("write supplier name");
            if (existing != null)
                throw new ArgumentException("Already exist");
            _dbContext.Companies.Add(company);
            company.CreatedOn = DateTime.UtcNow;
            return company;
        }
        public async Task<IEnumerable<Company>> GetAllAsync()
        {
            var data = await _dbContext.Companies.ToListAsync();
            return (data);
        }
        public async Task<Company> GetAsync(int id)
        {
            var data = await _dbContext.Companies.FirstOrDefaultAsync(i => i.Id == id);
            if (data == null)
                throw new ArgumentException("Company is not exist");
            return (data);
        }
        public async Task<Company> UpdateAsync(Company model)
        {
            var existing = await _dbContext.Companies.FirstOrDefaultAsync(c => c.Id == model.Id);
            if (string.IsNullOrWhiteSpace(model.CompanyName))
                throw new ArgumentException("Supplier name not found");
            if (existing == null)
                throw new ArgumentException("Company is not exist");
            model.CreatedOn = DateTime.UtcNow;
            _dbContext.Entry(existing).CurrentValues.SetValues(model);

            return model;
        }
        public async Task DeleteAsync(int id)
        {
            var existing = await _dbContext.Companies.FirstOrDefaultAsync(c => c.Id == id);

            if (existing == null)
                throw new ArgumentException("Company is not exist");

            _dbContext.Companies.Remove(existing);
        }
    }

}
