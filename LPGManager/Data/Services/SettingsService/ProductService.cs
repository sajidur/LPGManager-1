using LPGManager.Interfaces.SettingsInterface;
using LPGManager.Models.Settings;

using Microsoft.EntityFrameworkCore;

namespace LPGManager.Data.Services.SettingsService
{
    public class ProductService : IProductService
    {
        private readonly AppsDbContext _dbContext;

        public ProductService(AppsDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<Product> AddAsync(Product product)
        {
            var existing = await _dbContext.Products.FirstOrDefaultAsync(c => c.Id == product.Id);
            if (string.IsNullOrWhiteSpace(product.Name))
                throw new ArgumentException("Write product name");
            if (existing != null)
                throw new ArgumentException("Already exist");

            _dbContext.Products.Add(product);

            return product;
        }
        public async Task<IEnumerable<Product>> GetAllAsync()
        {
            var data = await _dbContext.Products.ToListAsync();
            return (data);
        }
        public async Task<Product> GetAsync(int id)
        {
            var data = await _dbContext.Products.FirstOrDefaultAsync(i => i.Id == id);
            if (data == null)
                throw new ArgumentException("Product is not exist");
            return (data);
        }
        public async Task<Product> UpdateAsync(Product model)
        {
            var existing = await _dbContext.Products.FirstOrDefaultAsync(c => c.Id == model.Id);
            if (string.IsNullOrWhiteSpace(model.Name))
                throw new ArgumentException("Products name not found");
            if (existing == null)
                throw new ArgumentException("Products is not exist");

            _dbContext.Entry(existing).CurrentValues.SetValues(model);

            return model;
        }
        public async Task DeleteAsync(int id)
        {
            var existing = await _dbContext.Products.FirstOrDefaultAsync(c => c.Id == id);

            if (existing == null)
                throw new ArgumentException("Product is not exist");

            _dbContext.Products.Remove(existing);
        }
    }
}
