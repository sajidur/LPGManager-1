using AutoMapper;
using LPGManager.Dtos;
using LPGManager.Models;

namespace LPGManager.Data.Services.SellService
{
    public class ReturnMasterService: IReturnMasterService
    {
        IMapper _mapper;
        private IGenericRepository<SellMaster> _sellMasterRepository;
        private IGenericRepository<SellDetails> _sellDetailsRepository;
        private IGenericRepository<Inventory> _inventoryRepository;
        private IGenericRepository<Company> _companyRepository;
        private IGenericRepository<CustomerEntity> _customerRepository;
        private IGenericRepository<ReturnMaster> _returnMaster;
        private IGenericRepository<ReturnDetails> _returnDetails;
        public ReturnMasterService(IMapper mapper,
            IGenericRepository<Inventory> inventoryRepository,
            IGenericRepository<Company> companyRepository,
            IGenericRepository<CustomerEntity> customerRepository,
            IGenericRepository<ReturnMaster> retrunMaster,
            IGenericRepository<ReturnDetails> returnDetails)
        {
            _inventoryRepository = inventoryRepository;
            _companyRepository = companyRepository;
            _customerRepository = customerRepository;
            _mapper = mapper;
            _returnMaster = retrunMaster;
            _returnDetails = returnDetails;


        }
        public ReturnMaster AddAsync(ReturnMasterDtos model)
        {
            ReturnMaster result;
            try
            {
                var sell = _mapper.Map<ReturnMaster>(model);
                if (model.ReturnDetails != null)
                {
                    var res = _returnMaster.Insert(sell);
                    _returnMaster.Save();
                    foreach (var item in model.ReturnDetails)
                    {
                        var inv = _inventoryRepository.FindBy(a => a.ProductName == item.ProductName && a.Size == item.Size && a.CompanyId == item.CompanyId && a.ProductType == item.ProductType && a.WarehouseId == 1).FirstOrDefault();
                        if (inv != null)
                        {
                            inv.Quantity += item.Quantity;
                            inv.ReturnQuantity += item.Quantity;
                            _inventoryRepository.Update(inv);
                        }
                        _inventoryRepository.Save();
                    }
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new ArgumentException(
                  $"{ex}.");
            }

        }

    }

    public interface IReturnMasterService
    {
        ReturnMaster AddAsync(ReturnMasterDtos model);
    }
}
