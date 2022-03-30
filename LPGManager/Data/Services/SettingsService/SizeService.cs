using LPGManager.Interfaces.SettingsInterface;
using LPGManager.Models.Settings;

using Microsoft.EntityFrameworkCore;

namespace LPGManager.Data.Services.SettingsService
{
    public class SizeService : ISizeService
    {
        private IGenericRepository<Size> _genericRepository;

        public SizeService(IGenericRepository<Size> genericRepository)
        {
            _genericRepository = genericRepository;
        }
        public async Task<Size> AddAsync(Size product)
        {
            var existing = await _genericRepository.GetById(product.Id);
            if (string.IsNullOrWhiteSpace(product.Name))
                throw new ArgumentException("Write Size name");
            if (existing != null)
                throw new ArgumentException("Already exist");

            _genericRepository.Insert(product);
            _genericRepository.Save();

            return product;
        }
        public async Task<IEnumerable<Size>> GetAllAsync()
        {
            var data = await _genericRepository.GetAll();
            return (data);
        }
        public async Task<Size> GetAsync(int id)
        {
            var existing = await _genericRepository.GetById(id);
            if (existing == null)
                throw new ArgumentException("Size is not exist");
            return (existing);
        }
        public async Task<Size> UpdateAsync(Size model)
        {
            var existing = await _genericRepository.GetById(model.Id);
            if (string.IsNullOrWhiteSpace(model.Name))
                throw new ArgumentException("Size name not found");
            if (existing == null)
                throw new ArgumentException("Size is not exist");

            _genericRepository.Update(existing);

            return model;
        }
        public async Task DeleteAsync(int id)
        {
            var existing = await _genericRepository.GetById(id);

            if (existing == null)
                throw new ArgumentException("Size is not exist");

            _genericRepository.Delete(existing);
        }
    }
}
