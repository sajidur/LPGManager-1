using LPGManager.Interfaces.SellsInterface;
using LPGManager.Models;

using Microsoft.EntityFrameworkCore;

namespace LPGManager.Data.Services.SellService
{
    public class SellMasterService : ISellMasterService
    {
        private readonly AppsDbContext _dbContext;

        public SellMasterService(AppsDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<SellMaster> AddAsync(SellMaster sells)
        {
            sells.CreatedOn = DateTime.UtcNow;

            _dbContext.SellMasters.Add(sells);
            return sells;
        }

        public async Task DeleteAsync(int id)
        {
            var existing = await _dbContext.SellMasters.FirstOrDefaultAsync(c => c.Id == id);

            if (existing == null)
                throw new ArgumentException("Sell is not exist");

            _dbContext.SellMasters.Remove(existing);
        }

        public async Task<IEnumerable<SellMaster>> GetAllAsync()
        {
            var data = await _dbContext.SellMasters.ToListAsync();
            return (data);
        }

        public async Task<SellMaster> GetAsync(int id)
        {
            var data = await _dbContext.SellMasters.Include(c => c.SellsDetails).FirstOrDefaultAsync(i => i.Id == id);
            if (data == null)
                throw new ArgumentException("Sells is not exist");
            return (data);
        }

        public async Task<SellMaster> UpdateAsync(SellMaster model)
        {
            var existing = await _dbContext.SellMasters.FirstOrDefaultAsync(c => c.Id == model.Id);
            if (existing == null)
                throw new ArgumentException("Sell is not exist");

            _dbContext.Entry(existing).CurrentValues.SetValues(model);

            return model;
        }
    }
}
