using LPGManager.Interfaces.SupplierInterface;
using LPGManager.Models;

using Microsoft.EntityFrameworkCore;

namespace LPGManager.Data.Services.SupplierService
{
    public class SupplierService : ISupplierService
    {
        private readonly AppsDbContext _dbContext;

        public SupplierService(AppsDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<Supplier> AddAsync(Supplier supplier)
        {
            var existing = await _dbContext.Suppliers.FirstOrDefaultAsync(c => c.SupplierId == supplier.SupplierId);
            if (string.IsNullOrWhiteSpace(supplier.SupplierName))
                throw new ArgumentException("write supplier name");            
            if (existing != null)
                throw new ArgumentException("Already exist");
            _dbContext.Suppliers.Add(supplier);

            return supplier;
        }       
        public async Task<IEnumerable<Supplier>> GetAllAsync()
        {
            var data = await _dbContext.Suppliers.ToListAsync();
            return (data);
        }
        public async Task<Supplier> GetAsync(int id)
        {
            var data = await _dbContext.Suppliers.FirstOrDefaultAsync(i => i.SupplierId == id);
            if (data == null)
                throw new ArgumentException("Suppliers is not exist");
            return (data);
        }
        public async Task<Supplier> UpdateAsync(Supplier model)
        {
            var existing = await _dbContext.Suppliers.FirstOrDefaultAsync(c => c.SupplierId == model.SupplierId);
            if (string.IsNullOrWhiteSpace(model.SupplierName))
                throw new ArgumentException("Supplier name not found");
            if (existing == null)
                throw new ArgumentException("Supplier is not exist");

            _dbContext.Entry(existing).CurrentValues.SetValues(model);

            return model;
        }
        public async Task DeleteAsync(int id)
        {
            var existing = await _dbContext.Suppliers.FirstOrDefaultAsync(c => c.SupplierId == id);

            if (existing == null)
                throw new ArgumentException("Supplier is not exist");

            _dbContext.Suppliers.Remove(existing);
        }
    }
}
