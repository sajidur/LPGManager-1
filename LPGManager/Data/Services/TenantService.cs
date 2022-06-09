using LPGManager.Models;

namespace LPGManager.Data.Services
{
    public interface ITenantService
    {

        Task<IEnumerable<Tenant>> GetAllAsync();
        IEnumerable<Tenant> GetByAsync(List<long> tenantIds, User user);
        Task<Tenant> GetAsync(long id);
        Task<Tenant> AddAsync(Tenant supplier);
        Task<Tenant> UpdateAsync(Tenant model);
        Task DeleteAsync(long id);
    }
    public class TenantService: ITenantService
    {
        private IGenericRepository<Tenant> _genericRepository;

        public TenantService(IGenericRepository<Tenant> genericRepository)
        {
            _genericRepository = genericRepository;
        }
        public async Task<Tenant> AddAsync(Tenant tenant)
        {
            var existing = await _genericRepository.GetById(tenant.Id);
            if (string.IsNullOrWhiteSpace(tenant.TenantName))
                throw new ArgumentException("Write TenantName");
            if (existing != null)
                throw new ArgumentException("Already exist");

            _genericRepository.Insert(tenant);
            _genericRepository.Save();

            return tenant;
        }
        public IEnumerable<Tenant> GetByAsync(List<long> tenantIds, User user)
        {
            var searchResult = _genericRepository.FindBy(a => tenantIds.Contains(a.Id));
            return searchResult;
        }
        public async Task<IEnumerable<Tenant>> GetAllAsync()
        {
            var data = await _genericRepository.GetAll();
            return (data);
        }
        public async Task<Tenant> GetAsync(long id)
        {
            var existing = await _genericRepository.GetById(id);
            if (existing == null)
                throw new ArgumentException("Tenant is not exist");
            return (existing);
        }
        public async Task<Tenant> UpdateAsync(Tenant model)
        {
            var existing = await _genericRepository.GetById(model.Id);
            if (string.IsNullOrWhiteSpace(model.TenantName))
                throw new ArgumentException("TenantName name not found");
            if (existing == null)
                throw new ArgumentException("TenantName is not exist");

            _genericRepository.Update(existing);

            return model;
        }
        public async Task DeleteAsync(long id)
        {
            var existing = await _genericRepository.GetById(id);

            if (existing == null)
                throw new ArgumentException("TenantName is not exist");

            _genericRepository.Delete(id);
            _genericRepository.Save();
        }
    }
}
