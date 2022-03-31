using LPGManager.Interfaces.SettingsInterface;
using LPGManager.Models.Settings;

using Microsoft.EntityFrameworkCore;

namespace LPGManager.Data.Services.SettingsService
{
    public class ProductService : IProductService
    {
        private IGenericRepository<Product> _genericRepository;

        public ProductService(IGenericRepository<Product> genericRepository)
        {
            _genericRepository = genericRepository;
        }
        public async Task<Product> AddAsync(Product product)
        {
            var existing = await _genericRepository.GetById(product.Id);
            if (string.IsNullOrWhiteSpace(product.Name))
                throw new ArgumentException("Write product name");
            if (existing != null)
                throw new ArgumentException("Already exist");

            _genericRepository.Insert(product);
            _genericRepository.Save();

            return product;
        }
        public async Task<IEnumerable<Product>> GetAllAsync()
        {
            var data = await _genericRepository.GetAll();
            return (data);
        }
        public async Task<Product> GetAsync(long id)
        {
            var existing = await _genericRepository.GetById(id);
            if (existing == null)
                throw new ArgumentException("Product is not exist");
            return (existing);
        }
        public async Task<Product> UpdateAsync(Product model)
        {
            var existing = await _genericRepository.GetById(model.Id);
            if (string.IsNullOrWhiteSpace(model.Name))
                throw new ArgumentException("Products name not found");
            if (existing == null)
                throw new ArgumentException("Products is not exist");

            _genericRepository.Update(existing);

            return model;
        }
        public async Task DeleteAsync(long id)
        {
            var existing = await _genericRepository.GetById(id);

            if (existing == null)
                throw new ArgumentException("Product is not exist");

            _genericRepository.Delete(id);
            _genericRepository.Save();
        }
    }
}
