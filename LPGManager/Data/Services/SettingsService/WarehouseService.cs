using LPGManager.Interfaces.SettingsInterface;
using LPGManager.Models.Settings;

using Microsoft.EntityFrameworkCore;

namespace LPGManager.Data.Services.SettingsService
{
    public class WarehouseService: IWarehouseService
    {
        private readonly AppsDbContext _dbContext;

        public WarehouseService(AppsDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<Warehouse> AddAsync(Warehouse house)
        {
            var existing = await _dbContext.Warehouses.FirstOrDefaultAsync(c => c.Id == house.Id);
            if (string.IsNullOrWhiteSpace(house.Name))
                throw new ArgumentException("Write Warehouse name");
            if (existing != null)
                throw new ArgumentException("Already exist");

            _dbContext.Warehouses.Add(house);

            return house;
        }
        public async Task<IEnumerable<Warehouse>> GetAllAsync()
        {
            var data = await _dbContext.Warehouses.ToListAsync();
            return (data);
        }
        public async Task<Warehouse> GetAsync(int id)
        {
            var data = await _dbContext.Warehouses.FirstOrDefaultAsync(i => i.Id == id);
            if (data == null)
                throw new ArgumentException("Warehouse is not exist");
            return (data);
        }
        public async Task<Warehouse> UpdateAsync(Warehouse model)
        {
            var existing = await _dbContext.Warehouses.FirstOrDefaultAsync(c => c.Id == model.Id);
            if (string.IsNullOrWhiteSpace(model.Name))
                throw new ArgumentException("Warehouse name not found");
            if (existing == null)
                throw new ArgumentException("Warehouse is not exist");

            _dbContext.Entry(existing).CurrentValues.SetValues(model);

            return model;
        }
        public async Task DeleteAsync(int id)
        {
            var existing = await _dbContext.Warehouses.FirstOrDefaultAsync(c => c.Id == id);

            if (existing == null)
                throw new ArgumentException("Warehouse is not exist");

            _dbContext.Warehouses.Remove(existing);
        }
    }
}
