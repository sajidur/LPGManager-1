using LPGManager.Interfaces.SettingsInterface;
using LPGManager.Models.Settings;

using Microsoft.EntityFrameworkCore;

namespace LPGManager.Data.Services.SettingsService
{
    public class SizeService : ISizeService
    {
        private readonly AppsDbContext _dbContext;

        public SizeService(AppsDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<Size> AddAsync(Size size)
        {
            var existing = await _dbContext.Sizes.FirstOrDefaultAsync(c => c.Id == size.Id);
            if (string.IsNullOrWhiteSpace(size.Name))
                throw new ArgumentException("Write Size name");
            if (existing != null)
                throw new ArgumentException("Already exist");

            _dbContext.Sizes.Add(size);

            return size;
        }
        public async Task<IEnumerable<Size>> GetAllAsync()
        {
            var data = await _dbContext.Sizes.ToListAsync();
            return (data);
        }
        public async Task<Size> GetAsync(int id)
        {
            var data = await _dbContext.Sizes.FirstOrDefaultAsync(i => i.Id == id);
            if (data == null)
                throw new ArgumentException("Size is not exist");
            return (data);
        }
        public async Task<Size> UpdateAsync(Size model)
        {
            var existing = await _dbContext.Sizes.FirstOrDefaultAsync(c => c.Id == model.Id);
            if (string.IsNullOrWhiteSpace(model.Name))
                throw new ArgumentException("Size name not found");
            if (existing == null)
                throw new ArgumentException("Size is not exist");

            _dbContext.Entry(existing).CurrentValues.SetValues(model);

            return model;
        }
        public async Task DeleteAsync(int id)
        {
            var existing = await _dbContext.Sizes.FirstOrDefaultAsync(c => c.Id == id);

            if (existing == null)
                throw new ArgumentException("Size is not exist");

            _dbContext.Sizes.Remove(existing);
        }
    }
}
