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
            throw new NotImplementedException();
        }

        public void Save(CustomerEntity customerEntity)
        {
            _customerRepository.Insert(customerEntity);
            _customerRepository.Save();
        }
    }

    public interface ICustomerService
    {
        Task<IEnumerable<CustomerEntity>> GetAllAsync();
        void Save(CustomerEntity customerEntity);
    }
}
