using LPGManager.Interfaces.SupplierInterface;
using LPGManager.Models;

using Microsoft.EntityFrameworkCore;

namespace LPGManager.Data.Services.SupplierService
{
    public class SupplierService : ISupplierService
    {
        private IGenericRepository<Supplier> _genericRepository;

        public SupplierService(IGenericRepository<Supplier> genericRepository)
        {
            _genericRepository = genericRepository;
        }
        public async Task<Supplier> AddAsync(Supplier product)
        {
            var existing = await _genericRepository.GetById(product.Id);
            if (string.IsNullOrWhiteSpace(product.SupplierName))
                throw new ArgumentException("Write SupplierName");
            if (existing != null)
                throw new ArgumentException("Already exist");

            _genericRepository.Insert(product);
            _genericRepository.Save();

            return product;
        }
        public async Task<IEnumerable<Supplier>> GetAllAsync(long tenantId)
        {
            var data =  _genericRepository.FindBy(a => a.TenantId == tenantId).ToList();
            return (data);
        }
        public async Task<Supplier> GetAsync(long id)
        {
            var existing = await _genericRepository.GetById(id);
            if (existing == null)
                throw new ArgumentException("Product is not exist");
            return (existing);
        }
        public async Task<Supplier> UpdateAsync(Supplier model)
        {
            var existing = await _genericRepository.GetById(model.Id);
            if (string.IsNullOrWhiteSpace(model.SupplierName))
                throw new ArgumentException("SupplierName name not found");
            if (existing == null)
                throw new ArgumentException("SupplierName is not exist");

            _genericRepository.Update(existing);

            return model;
        }
        public async Task DeleteAsync(long id)
        {
            var existing = await _genericRepository.GetById(id);

            if (existing == null)
                throw new ArgumentException("SupplierName is not exist");

            _genericRepository.Delete(id);
            _genericRepository.Save();
        }
    }
}
