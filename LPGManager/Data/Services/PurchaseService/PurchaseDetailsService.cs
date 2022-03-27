using LPGManager.Dtos;
using LPGManager.Interfaces.PurchasesInterface;
using LPGManager.Models;

using Microsoft.EntityFrameworkCore;

namespace LPGManager.Data.Services.PurchaseService
{
    public class PurchaseDetailsService : IPurchaseDetailsService
    {
        private readonly AppsDbContext _dbContext;

        public PurchaseDetailsService(AppsDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public  async Task<PurchaseDetails> AddAsync(PurchaseDetails purchaseDetails)
        {
            var existing = await _dbContext.PurchaseMasters.FirstOrDefaultAsync(c => c.Id == purchaseDetails.PurchaseMasterId);            
            if (existing == null)
                throw new ArgumentException("Purchase Master Id is not exist");
            var existingSupplierId = await _dbContext.Suppliers.FirstOrDefaultAsync(c => c.SupplierId == purchaseDetails.SupplierId);
            if (existingSupplierId == null)
                throw new ArgumentException("Supplier Id is not exist");

            purchaseDetails.CreatedOn = DateTime.UtcNow;       

            _dbContext.PurchasesDetails.Add(purchaseDetails);
            return purchaseDetails;
        }

        public async Task DeleteAsync(int id)
        {
            var existing = await _dbContext.PurchasesDetails.FirstOrDefaultAsync(c => c.Id == id);

            if (existing == null)
                throw new ArgumentException("Purchase Details is not exist");

            _dbContext.PurchasesDetails.Remove(existing);
        }

        public async Task<IEnumerable<PurchaseDetails>> GetAllAsync()
        {
            var data = await _dbContext.PurchasesDetails.ToListAsync();
            return (data);
        }

        public async Task<PurchaseDetails> GetAsync(int id)
        {
            var data = await _dbContext.PurchasesDetails
                           .Include(c => c.PurchaseMasterId)
                           .Include(c =>c.SupplierId).FirstOrDefaultAsync(i => i.Id == id);
            if (data == null)
                throw new ArgumentException("Purchase Details is not exist");
            return (data);
        }

        public async Task<PurchaseDetails> UpdateAsync(PurchaseDetails model)
        {
            var existing = await _dbContext.PurchasesDetails.FirstOrDefaultAsync(c => c.Id == model.Id);            
            if (existing == null)
                throw new ArgumentException("Purchase Details is not exist");
            var existingOfMasterId = await _dbContext.PurchaseMasters.FirstOrDefaultAsync(c => c.Id == model.PurchaseMasterId);
            if (existingOfMasterId == null)
                throw new ArgumentException("Purchase Master Id is not exist");
            var existingSupplierId = await _dbContext.Suppliers.FirstOrDefaultAsync(c => c.SupplierId == model.SupplierId);
            if (existingSupplierId == null)
                throw new ArgumentException("Supplier Id is not exist");

            model.CreatedOn = DateTime.UtcNow;

            _dbContext.Entry(existing).CurrentValues.SetValues(model);

            return model;
        }
    }
}
