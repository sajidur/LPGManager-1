using LPGManager.Interfaces.ExchangeInterface;
using LPGManager.Models;

using Microsoft.EntityFrameworkCore;

namespace LPGManager.Data.Services.ExchangeService
{
    public class ExchangeService : IExchangeService
    {
        private readonly AppsDbContext _dbContext;

        public ExchangeService(AppsDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<Exchange> AddAsync(Exchange exchange)
        {            
            _dbContext.Exchanges.Add(exchange);
            exchange.CreatedOn = DateTime.UtcNow;
            return exchange;
        }
        public async Task<IEnumerable<Exchange>> GetAllAsync()
        {
            var data = await _dbContext.Exchanges.ToListAsync();
            return (data);
        }
        public async Task<Exchange> GetAsync(int id)
        {
            var data = await _dbContext.Exchanges.FirstOrDefaultAsync(i => i.Id == id);
            if (data == null)
                throw new ArgumentException("Exchange is not exist");
            return (data);
        }
        public async Task<Exchange> UpdateAsync(Exchange model)
        {
            var existing = await _dbContext.Exchanges.FirstOrDefaultAsync(c => c.Id == model.Id);            
            if (existing == null)
                throw new ArgumentException("Exchange is not exist");
             model.CreatedOn = DateTime.UtcNow;
            _dbContext.Entry(existing).CurrentValues.SetValues(model);

            return model;
        }
        public async Task DeleteAsync(int id)
        {
            var existing = await _dbContext.Exchanges.FirstOrDefaultAsync(c => c.Id == id);

            if (existing == null)
                throw new ArgumentException("Exchange is not exist");

            _dbContext.Exchanges.Remove(existing);
        }
    }
}
