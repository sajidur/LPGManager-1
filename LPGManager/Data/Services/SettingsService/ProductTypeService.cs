using LPGManager.Interfaces.SettingsInterface;
using LPGManager.Models.Settings;

using Microsoft.EntityFrameworkCore;

namespace LPGManager.Data.Services.SettingsService
{
    public class ProductTypeService: IProductTypeService
    {
        private readonly AppsDbContext _dbContext;

        public ProductTypeService(AppsDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<ProductType> AddAsync(ProductType product)
        {
            var existing = await _dbContext.ProductTypes.FirstOrDefaultAsync(c => c.Id == product.Id);
            if (string.IsNullOrWhiteSpace(product.Name))
                throw new ArgumentException("Write productType name");
            if (existing != null)
                throw new ArgumentException("Already exist");

            _dbContext.ProductTypes.Add(product);

            return product;
        }
        public async Task<IEnumerable<ProductType>> GetAllAsync()
        {
            var data = await _dbContext.ProductTypes.ToListAsync();
            return (data);
        }
        public async Task<ProductType> GetAsync(int id)
        {
            var data = await _dbContext.ProductTypes.FirstOrDefaultAsync(i => i.Id == id);
            if (data == null)
                throw new ArgumentException("ProductType is not exist");
            return (data);
        }
        public async Task<ProductType> UpdateAsync(ProductType model)
        {
            var existing = await _dbContext.ProductTypes.FirstOrDefaultAsync(c => c.Id == model.Id);
            if (string.IsNullOrWhiteSpace(model.Name))
                throw new ArgumentException("ProductType not found");
            if (existing == null)
                throw new ArgumentException("ProductType is not exist");

            _dbContext.Entry(existing).CurrentValues.SetValues(model);

            return model;
        }
        public async Task DeleteAsync(int id)
        {
            var existing = await _dbContext.ProductTypes.FirstOrDefaultAsync(c => c.Id == id);

            if (existing == null)
                throw new ArgumentException("ProductType is not exist");

            _dbContext.ProductTypes.Remove(existing);
        }
    }
}
