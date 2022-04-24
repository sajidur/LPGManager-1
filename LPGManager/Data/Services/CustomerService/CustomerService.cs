using LPGManager.Models;

namespace LPGManager.Data.Services.CustomerService
{
    public class CustomerService: ICustomerService
    {
        private IGenericRepository<CustomerEntity> _customerRepository;
        public CustomerService(IGenericRepository<CustomerEntity> customerRepository)
        {
            this._customerRepository = customerRepository;
        }

        public Task<IEnumerable<CustomerEntity>> GetAllAsync()
        {
            return _customerRepository.GetAll();
        }

        public void Save(CustomerEntity customerEntity)
        {
            _customerRepository.Insert(customerEntity);
            _customerRepository.Save();
        }
        public void UpdateAsync(CustomerEntity model)
        {
            var existing = _customerRepository.GetById(model.Id).Result;
            if (existing == null)
                throw new ArgumentException("customer is not exist");
            existing.UpdatedDate = DateTime.UtcNow;
            existing.Name = model.Name;
            existing.Phone = model.Phone;
            existing.CustomerType= model.CustomerType;
            existing.UpdatedBy = model.UpdatedBy;
            existing.Address = model.Address;
            existing.Image= model.Image;
            _customerRepository.Update(existing);
            _customerRepository.Save();
        }
        public async Task DeleteAsync(long id)
        {
            var existing = _customerRepository.GetById(id);

            if (existing == null)
                throw new ArgumentException("Customer is not exist");

            _customerRepository.Delete(id);
            _customerRepository.Save();
        }
    }

    public interface ICustomerService
    {
        Task<IEnumerable<CustomerEntity>> GetAllAsync();
        void Save(CustomerEntity customerEntity);
        Task DeleteAsync(long id);
        void UpdateAsync(CustomerEntity model);
    }
}
