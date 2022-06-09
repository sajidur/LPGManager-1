using LPGManager.Models;
using Microsoft.EntityFrameworkCore;

namespace LPGManager.Data.Services.CustomerService
{
    public class CustomerService: ICustomerService
    {
        private IGenericRepository<CustomerEntity> _customerRepository;
        private IGenericRepository<CustomerDealerMapping> _mappingRepository;
        private IGenericRepository<Tenant> _tenantService;
        public CustomerService(IGenericRepository<Tenant> tenantService,IGenericRepository<CustomerEntity> customerRepository, IGenericRepository<CustomerDealerMapping> mappingRepository)
        {
            this._customerRepository = customerRepository;
            this._mappingRepository = mappingRepository;
            _tenantService = tenantService;
        }

        public CustomerEntity GetByAsync(long tenantId)
        {
            return _customerRepository.FindBy(a=>a.TenantId==tenantId).FirstOrDefault();
        }
        public IEnumerable<CustomerEntity> SearchAsync(string customerName,User user)
        {
            var alreadyAssigned = CustomerDealerMappingsList(user);
            var searchResult= _customerRepository.FindBy(a => a.Name.ToLower().Contains(customerName.ToLower())||a.Phone==customerName);
            return searchResult.Except(alreadyAssigned);
        }
        public CustomerDealerMapping IsMappingAlready(CustomerDealerMapping mapping)
        {
            return _mappingRepository.FindBy(a => a.TenantId==mapping.TenantId&&a.RefCustomerId==mapping.RefCustomerId).FirstOrDefault();
        }

        public IEnumerable<CustomerEntity> CustomerDealerMappingsList(User tenant)
        {
            var list= _mappingRepository.FindBy(a => a.TenantId == tenant.TenantId).Select(a=>a.RefCustomerId).ToList();
            return _customerRepository.FindBy(a => list.Contains(a.Id)&&a.CustomerType!=tenant.UserType);
        }
        public CustomerEntity Save(CustomerEntity customerEntity)
        {
            _customerRepository.Insert(customerEntity);
            _customerRepository.Save();
            return customerEntity;
        }
        public void Assign(CustomerDealerMapping mapping)
        {
            if (IsMappingAlready(mapping)==null)
            {
                _mappingRepository.Insert(mapping);
                _mappingRepository.Save();
            }
        }
        public void DeAssign(CustomerDealerMapping mapping)
        {
            var isExists = IsMappingAlready(mapping);
            if (isExists!=null)
            {
                _mappingRepository.Delete(isExists.Id);
                _mappingRepository.Save();
            }

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
        CustomerEntity GetByAsync(long tenantId);
        IEnumerable<CustomerEntity> SearchAsync(string customerName,User user);
        CustomerEntity Save(CustomerEntity customerEntity);
        IEnumerable<CustomerEntity> CustomerDealerMappingsList(User user);
        void Assign(CustomerDealerMapping mapping);
        void DeAssign(CustomerDealerMapping mapping);

        Task DeleteAsync(long id);
        void UpdateAsync(CustomerEntity model);
    }
}
