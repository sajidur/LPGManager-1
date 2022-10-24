using LPGManager.Common;
using LPGManager.Models;

namespace LPGManager.Data.Services.SellService
{
    public class SellRequisitionService : ISellRequisitionMasterService
    {
        private IGenericRepository<SellRequisitionMaster> _sellMasterRepository;
        private IGenericRepository<SellRequisitionDetails> _sellDetailsRepository;
        private IGenericRepository<Company> _companyRepository;
        private IGenericRepository<CustomerEntity> _customerRepository;

        public SellRequisitionService(IGenericRepository<SellRequisitionMaster> sellMasterRepository,
            IGenericRepository<SellRequisitionDetails> sellsDetailRepository,
            IGenericRepository<Company> companyRepository,
            IGenericRepository<CustomerEntity> customerRepository)
        {
            _sellMasterRepository = sellMasterRepository;
            _sellDetailsRepository = sellsDetailRepository;
            _companyRepository = companyRepository;
            _customerRepository = customerRepository;

        }
        public SellRequisitionMaster AddAsync(SellRequisitionMaster sell)
        {
            SellRequisitionMaster result;
            try
            {
                if (sell.SellRequisitionDetails != null)
                {
                    sell.InvoiceNo = GenerateInvoice();
                    sell.InvoiceDate = Helper.ToEpoch(DateTime.Now);
                    sell.TotalPrice = sell.SellRequisitionDetails.Sum(a => a.Quantity * a.Price);
                    var res = _sellMasterRepository.Insert(sell);
                    _sellMasterRepository.Save();
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new ArgumentException(
                  $"{ex}.");
            }
        }
        private string GenerateInvoice()
        {
            var lastId = _sellMasterRepository.GetLastId("SellRequisitionMasters").Result;
            return DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString("d2") + DateTime.Now.Day.ToString("d2") + lastId.ToString("d3");
        }
        public async Task DeleteAsync(long id)
        {
            var data = _sellMasterRepository.GetById(id).Result;
            if (data == null)
                throw new ArgumentException("Sell is not exist");
            var details = _sellDetailsRepository.FindBy(a => a.SellRequisitionMasterId == id).ToList();
            foreach (var item in details)
            {
                _sellDetailsRepository.Delete(item.Id);
            }
            _sellMasterRepository.Delete(id);
            _sellMasterRepository.Save();
        }

        public List<SellRequisitionMaster> GetAllAsync(long tenantId)
        {
            var data = _sellMasterRepository.FindBy(a => a.TenantId == tenantId && a.IsActive==1).ToList();
            foreach (var item in data)
            {
                item.SellRequisitionDetails = _sellDetailsRepository.FindBy(a => a.SellRequisitionMasterId == item.Id).ToList();
                foreach (var details in item.SellRequisitionDetails)
                {
                    details.Company = _companyRepository.GetById(details.CompanyId).Result;
                }
                item.Customer = _customerRepository.GetById(item.CustomerId).Result;
            }
            return data;
        }

        public SellRequisitionMaster UpdateAsync(SellRequisitionMaster model)
        {
            try
            {
                _sellMasterRepository.Update(model);
                _sellMasterRepository.Save();
                return null;
            }
            catch (Exception ex)
            {
                throw new ArgumentException(
                  $"{ex}.");
            }
            return null;
        }

        public SellRequisitionMaster GetAsync(long id)
        {
            var data = _sellMasterRepository.GetById(id).Result;
            if (data==null)
            {
                return data;
            }
            data.SellRequisitionDetails = _sellDetailsRepository.FindBy(a => a.SellRequisitionMasterId == id).ToList();
            foreach (var details in data.SellRequisitionDetails)
            {
                details.Company = _companyRepository.GetById(details.CompanyId).Result;
            }
            data.Customer = _customerRepository.GetById(data.CustomerId).Result;
            return data;
        }
    }
    public interface ISellRequisitionMasterService
    {

        List<SellRequisitionMaster> GetAllAsync(long tenantId);
        SellRequisitionMaster GetAsync(long id);
        SellRequisitionMaster AddAsync(SellRequisitionMaster model);
        SellRequisitionMaster UpdateAsync(SellRequisitionMaster model);
        Task DeleteAsync(long id);
    }

}
