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
            var existingSupplierId = await _dbContext.Suppliers.FirstOrDefaultAsync(c => c.SupplierId == purchaseMaster.SupplierId);
            if (existingSupplierId == null)
                throw new ArgumentException("Supplier Id is not exist");

            purchaseMaster.CreatedOn = DateTime.UtcNow;

             _dbContext.PurchaseMasters.Add(purchaseMaster);
            return purchaseMaster;
        }

        public async Task DeleteAsync(int id)
        {
            var existing = await _dbContext.PurchaseMasters.FirstOrDefaultAsync(c => c.Id == id);

            if (existing == null)
                throw new ArgumentException("Purchase is not exist");

            _dbContext.PurchaseMasters.Remove(existing);
        }

        public async Task<IEnumerable<PurchaseMaster>> GetAllAsync()
        {
            var data = await _dbContext.PurchaseMasters.ToListAsync();
            return (data);
        }

        public async Task<PurchaseMaster> GetAsync(int id)
        {
            var data = await _dbContext.PurchaseMasters
                       .Include(c => c.PurchasesDetails)
                       .Include(c => c.SupplierId).FirstOrDefaultAsync(i => i.Id == id);
            if (data == null)
                throw new ArgumentException("Purchase Details is not exist");
            return (data);
        }

        public async Task<PurchaseMaster> UpdateAsync(PurchaseMaster model)
        {
            var existing = await _dbContext.PurchaseMasters.FirstOrDefaultAsync(c => c.Id == model.Id);
            if (existing == null)
                throw new ArgumentException("Purchase Master is not exist");

            var existingSupplierId = await _dbContext.Suppliers.FirstOrDefaultAsync(c => c.SupplierId == model.SupplierId);
            if (existingSupplierId == null)
                throw new ArgumentException("Supplier Id is not exist");

            _dbContext.Entry(existing).CurrentValues.SetValues(model);

            return model;
        }
    }
}
