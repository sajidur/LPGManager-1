using LPGManager.Interfaces.InventoryInterface;
using LPGManager.Models;

using Microsoft.EntityFrameworkCore;

namespace LPGManager.Data.Services.InventoryService
{
    public class InventoryService : IInventoryService
    {
        private readonly AppsDbContext _dbContext;

        public InventoryService(AppsDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<Inventory> AddAsync(Inventory inventory)
        {
            var existing = await _dbContext.Warehouses.FirstOrDefaultAsync(c => c.Id == inventory.WarehouseId);
            if (existing == null)
                throw new ArgumentException("Warehouse Id is not exist");
            var existingSupplierId = await _dbContext.Suppliers.FirstOrDefaultAsync(c => c.SupplierId == inventory.SupplierId);
            if (existingSupplierId == null)
                throw new ArgumentException("Supplier Id is not exist");

            inventory.CreatedOn = DateTime.UtcNow;

            _dbContext.Inventories.Add(inventory);
            return inventory;
        }

        public async Task DeleteAsync(int id)
        {
            var existing = await _dbContext.Inventories.FirstOrDefaultAsync(c => c.Id == id);

            if (existing == null)
                throw new ArgumentException("Inventories is not exist");

            _dbContext.Inventories.Remove(existing);
        }

        public async Task<IEnumerable<Inventory>> GetAllAsync()
        {
            var data = await _dbContext.Inventories.ToListAsync();
            return (data);
        }

        public async Task<Inventory> GetAsync(int id)
        {
            var data = await _dbContext.Inventories
                           .Include(c => c.WarehouseId)
                           .Include(c => c.SupplierId).FirstOrDefaultAsync(i => i.Id == id);
            if (data == null)
                throw new ArgumentException("Inventories is not exist");
            return (data);
        }

        public async Task<Inventory> UpdateAsync(Inventory model)
        {
            var existing = await _dbContext.Inventories.FirstOrDefaultAsync(c => c.Id == model.Id);
            if (existing == null)
                throw new ArgumentException("Inventories is not exist");
            var existingOfMasterId = await _dbContext.Warehouses.FirstOrDefaultAsync(c => c.Id == model.WarehouseId);
            if (existingOfMasterId == null)
                throw new ArgumentException("Warehouse Id is not exist");
            var existingSupplierId = await _dbContext.Suppliers.FirstOrDefaultAsync(c => c.SupplierId == model.SupplierId);
            if (existingSupplierId == null)
                throw new ArgumentException("Supplier Id is not exist");

            model.CreatedOn = DateTime.UtcNow;

            _dbContext.Entry(existing).CurrentValues.SetValues(model);

            return model;
        }
    }
}
