using LPGManager.Interfaces.SellsInterface;
using LPGManager.Models;

using Microsoft.EntityFrameworkCore;

namespace LPGManager.Data.Services.SellService
{
    public class SellDetailsService : ISellDetailsService
    {
        private readonly AppsDbContext _dbContext;

        public SellDetailsService(AppsDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<SellDetails> AddAsync(SellDetails sell)
        {
            var existing = await _dbContext.SellMasters.FirstOrDefaultAsync(c => c.Id == sell.SellMasterId);
            if (existing == null)
                throw new ArgumentException("Sell Master Id is not exist");


            _dbContext.SellsDetails.Add(sell);
            return sell;
        }

        public async Task DeleteAsync(int id)
        {
            var existing = await _dbContext.SellsDetails.FirstOrDefaultAsync(c => c.Id == id);

            if (existing == null)
                throw new ArgumentException("Sell Details is not exist");

            _dbContext.SellsDetails.Remove(existing);
        }

        public async Task<IEnumerable<SellDetails>> GetAllAsync()
        {
            var data = await _dbContext.SellsDetails.ToListAsync();
            return (data);
        }

        public async Task<SellDetails> GetAsync(int id)
        {
            var data = await _dbContext.SellsDetails.Include(c => c.SellMasterId).FirstOrDefaultAsync(i => i.Id == id);
            if (data == null)
                throw new ArgumentException("Sells Details is not exist");
            return (data);
        }

        public async Task<SellDetails> UpdateAsync(SellDetails model)
        {
            var existing = await _dbContext.SellsDetails.FirstOrDefaultAsync(c => c.Id == model.Id);
            if (existing == null)
                throw new ArgumentException("Sells Details is not exist");
            var existingOfMasterId = await _dbContext.SellMasters.FirstOrDefaultAsync(c => c.Id == model.SellMasterId);
            if (existingOfMasterId == null)
                throw new ArgumentException("Sells Master Id is not exist");

            _dbContext.Entry(existing).CurrentValues.SetValues(model);

            return model;
        }
    }
}
