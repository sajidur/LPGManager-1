using LPGManager.Interfaces.SettingsInterface;
using LPGManager.Models.Settings;

using Microsoft.EntityFrameworkCore;

namespace LPGManager.Data.Services.SettingsService
{
    public class ProductTypeService: IProductTypeService
    {
        private IGenericRepository<ProductType> _genericRepository;

        public ProductTypeService(IGenericRepository<ProductType> genericRepository)
        {
            _genericRepository = genericRepository;
        }
        public async Task<ProductType> AddAsync(ProductType product)
        {
            var existing = _genericRepository.FindBy(a => a.Name == product.Name).FirstOrDefault();
            if (string.IsNullOrWhiteSpace(product.Name))
                throw new ArgumentException("Write productType name");
            if (existing != null)
                throw new ArgumentException("Already exist");

            _genericRepository.Insert(product);
            _genericRepository.Save();
            return product;
        }
        public async Task<IEnumerable<ProductType>> GetAllAsync()
        {
            var data = await _genericRepository.GetAll();
            return (data);
        }
        public async Task<ProductType> GetAsync(long id)
        {
            var data = await _genericRepository.GetById(id);
            if (data == null)
                throw new ArgumentException("ProductType is not exist");
            return (data);
        }
        public async Task<ProductType> UpdateAsync(ProductType model)
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
