using AutoMapper;
using LPGManager.Common;
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
            IGenericRepository<ReturnDetails> returnDetails,
            IGenericRepository<SellDetails> sellDetailsRepository)
        {
            _inventoryRepository = inventoryRepository;
            _companyRepository = companyRepository;
            _customerRepository = customerRepository;
            _mapper = mapper;
            _returnMaster = retrunMaster;
            _returnDetails = returnDetails;
            _sellDetailsRepository=sellDetailsRepository;

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
                    var salesDetails = _sellDetailsRepository.FindBy(a => a.SellMasterId == model.SellMasterId);
                    foreach (var item in model.ReturnDetails)
                    {
                        if (item.ProductName == ProductNameEnum.Bottle.ToString())
                        {
                            var returndetailsMatchWithReturn = salesDetails.Where(a => a.ProductType == item.ProductType && a.Size == item.Size && a.CompanyId == item.CompanyId && a.ProductName == ProductNameEnum.Refill.ToString());
                            if (returndetailsMatchWithReturn.Any())
                            {
                                foreach (var ret in returndetailsMatchWithReturn)
                                {
                                    var invv = _inventoryRepository.FindBy(a => a.ProductType == ret.ProductType && a.Size == ret.Size && a.CompanyId == ret.CompanyId && a.ProductName == ProductNameEnum.Refill.ToString() && a.WarehouseId == 1 && a.TenantId == ret.TenantId).FirstOrDefault();
                                    if (invv != null)
                                    {
                                        invv.SupportQty -= ret.Quantity;
                                        _inventoryRepository.Update(invv);
                                    }
                                }
                            }
                            else
                            {
                                var inv = _inventoryRepository.FindBy(a => a.ProductType == item.ProductType && a.Size == item.Size && a.CompanyId == item.CompanyId && a.ProductName == ProductNameEnum.Refill.ToString() && a.WarehouseId == 1 && a.TenantId == item.TenantId).FirstOrDefault();
                                if (inv != null)
                                {
                                    inv.ExchangeQty += item.Quantity;
                                    _inventoryRepository.Update(inv);
                                }
                                else
                                {
                                    inv = new Inventory()
                                    {
                                        WarehouseId = 1,
                                        CompanyId = item.CompanyId,
                                        DamageQuantity = 0,
                                        ReceivingQuantity = item.Quantity,
                                        OpeningQuantity = 0,
                                        Price = item.Price,
                                        Quantity = item.Quantity,
                                        SaleQuantity = 0,
                                        SupportQty = 0,
                                        ExchangeQty = item.Quantity,
                                        PurchaseReturn = 0,
                                        ReturnQuantity = 0,
                                        ProductType = item.ProductType,
                                        ProductName = item.ProductName,
                                        Size = item.Size,
                                        TenantId = item.TenantId,
                                        CreatedBy = item.CreatedBy
                                    };
                                    _inventoryRepository.Insert(inv);
                                }
                            }
                        }
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
