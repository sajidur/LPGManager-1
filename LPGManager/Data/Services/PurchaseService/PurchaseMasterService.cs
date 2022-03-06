using LPGManager.Interfaces.PurchasesInterface;
using LPGManager.Models;

using Microsoft.EntityFrameworkCore;

namespace LPGManager.Data.Services.PurchaseService
{
    public class PurchaseMasterService : IPurchaseMasterService
    {
        private readonly AppsDbContext _dbContext;

        public PurchaseMasterService(AppsDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<PurchaseMaster> AddAsync(PurchaseMaster purchaseMaster)
        {
            _dbContext.PurchaseMasters.Add(purchaseMaster);
            return purchaseMaster;
        }

        public async Task DeleteAsync(int id)
        {
            var existing = await _dbContext.PurchaseMasters.FirstOrDefaultAsync(c => c.Id == id);

            if (existing == null)
                throw new ArgumentException("Purchase Details is not exist");

            _dbContext.PurchaseMasters.Remove(existing);
        }

        public async Task<IEnumerable<PurchaseMaster>> GetAllAsync()
        {
            var data = await _dbContext.PurchaseMasters.ToListAsync();
            return (data);
        }

        public async Task<PurchaseMaster> GetAsync(int id)
        {
            var data = await _dbContext.PurchaseMasters.Include(c => c.PurchasesDetails).FirstOrDefaultAsync(i => i.Id == id);
            if (data == null)
                throw new ArgumentException("Purchase Details is not exist");
            return (data);
        }

        public async Task<PurchaseMaster> UpdateAsync(PurchaseMaster model)
        {
            var existing = await _dbContext.PurchaseMasters.FirstOrDefaultAsync(c => c.Id == model.Id);
            if (existing == null)
                throw new ArgumentException("Purchase Details is not exist");

            _dbContext.Entry(existing).CurrentValues.SetValues(model);

            return model;
        }
    }
}
