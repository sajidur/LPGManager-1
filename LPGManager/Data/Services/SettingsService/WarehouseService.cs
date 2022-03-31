using LPGManager.Interfaces.SettingsInterface;
using LPGManager.Models.Settings;

using Microsoft.EntityFrameworkCore;

namespace LPGManager.Data.Services.SettingsService
{
    public class WarehouseService: IWarehouseService
    {
        private IGenericRepository<Warehouse> _genericRepository;

        public WarehouseService(IGenericRepository<Warehouse> genericRepository)
        {
            _genericRepository = genericRepository;
        }
        public async Task<Warehouse> AddAsync(Warehouse house)
        {
            var existing = await _genericRepository.GetById(house.Id);
            if (string.IsNullOrWhiteSpace(house.Name))
                throw new ArgumentException("Write Warehouse name");
            if (existing != null)
                throw new ArgumentException("Already exist");

            _genericRepository.Insert(house);
            _genericRepository.Save();
            return house;
        }
        public async Task<IEnumerable<Warehouse>> GetAllAsync()
        {
            var data = await _genericRepository.GetAll();
            return (data);
        }
        public async Task<Warehouse> UpdateAsync(Warehouse model)
        {
            var existing = await _genericRepository.GetById(model.Id);
            if (string.IsNullOrWhiteSpace(model.Name))
                throw new ArgumentException("Warehouse name not found");
            if (existing == null)
                throw new ArgumentException("Warehouse is not exist");

            _genericRepository.Update(existing);

            return model;
        }
        public async Task DeleteAsync(long id)
        {
            var existing = await _genericRepository.GetById(id);

            if (existing == null)
                throw new ArgumentException("Warehouse is not exist");

            _genericRepository.Delete(id);
            _genericRepository.Save();

        }
    }
}
