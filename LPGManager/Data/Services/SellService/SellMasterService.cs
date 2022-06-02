using AutoMapper;
using LPGManager.Common;
using LPGManager.Dtos;
using LPGManager.Interfaces.SellsInterface;
using LPGManager.Models;

using Microsoft.EntityFrameworkCore;

namespace LPGManager.Data.Services.SellService
{
    public class SellMasterService : ISellMasterService
    {
        IMapper _mapper;
        private IGenericRepository<SellMaster> _sellMasterRepository;
        private IGenericRepository<SellDetails> _sellDetailsRepository;
        private IGenericRepository<Inventory> _inventoryRepository;
        private IGenericRepository<Company> _companyRepository;
        private IGenericRepository<CustomerEntity> _customerRepository;
        private IGenericRepository<ReturnMaster> _returnMaster;
        private IGenericRepository<ReturnDetails> _returnDetails;
        public SellMasterService(IMapper mapper, 
            IGenericRepository<SellMaster> sellMasterRepository, 
            IGenericRepository<SellDetails> sellsDetailRepository, 
            IGenericRepository<Inventory> inventoryRepository, 
            IGenericRepository<Company> companyRepository, 
            IGenericRepository<CustomerEntity> customerRepository,
            IGenericRepository<ReturnMaster> retrunMaster,
            IGenericRepository<ReturnDetails> returnDetails)
        {
            _sellMasterRepository = sellMasterRepository;
            _sellDetailsRepository = sellsDetailRepository;
            _inventoryRepository = inventoryRepository;
            _companyRepository = companyRepository;
            _customerRepository = customerRepository;
            _mapper = mapper;
            _returnMaster = retrunMaster;
            _returnDetails = returnDetails;
              

        }
        public SellMaster AddAsync(SellMasterDtos model)
        {
            SellMaster result;
            try
            {
                var sell = _mapper.Map<SellMaster>(model);
                if (model.SellsDetails != null)
                {
                    sell.InvoiceNo = GenerateInvoice();
                    sell.InvoiceDate = Helper.ToEpoch(DateTime.Now);
                    sell.TotalPrice = model.SellsDetails.Sum(a => a.Quantity * a.Price);
                    sell.Discount = model.SellsDetails.Sum(a => a.Discount * a.Quantity);
                    var res = _sellMasterRepository.Insert(sell);
                    _sellMasterRepository.Save();
                    foreach (var item in model.SellsDetails)
                    {
                      //  var selldetails = _mapper.Map<SellDetails>(item);
                      //  selldetails.SellMasterId = res.Id;
                     //   _sellDetailsRepository.Insert(selldetails);
                        var inv = _inventoryRepository.FindBy(a => a.ProductName == item.ProductName && a.Size == item.Size && a.CompanyId == item.CompanyId && a.ProductType == item.ProductType && a.WarehouseId == 1 && a.TenantId == model.TenantId).FirstOrDefault();
                        if (inv != null)
                        {
                            if (item.ProductName == ProductNameEnum.Refill.ToString())
                            {
                                //var bottleInv = _inventoryRepository.FindBy(a => a.ProductName == ProductNameEnum.Bottle.ToString() && a.Size == item.Size && a.CompanyId == item.CompanyId &&a.ProductType==item.ProductType).FirstOrDefault();
                                //bottleInv.SupportQty += item.Quantity;
                                //bottleInv.Quantity-=item.Quantity;
                                //_inventoryRepository.Update(bottleInv);
                                inv.SupportQty += item.Quantity;
                            }
                            inv.Quantity -= item.Quantity;
                            inv.SaleQuantity += item.Quantity;
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

        private string GenerateInvoice()
        {
            var lastId = _sellMasterRepository.GetLastId("SellMasters").Result;
            return DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString("d2") + DateTime.Now.Day.ToString("d2") + lastId.ToString("d3");
        }

        public async Task DeleteAsync(long id)
        {
            var data = _sellMasterRepository.GetById(id).Result;
            if (data == null)
                throw new ArgumentException("Sell is not exist");
            data.SellsDetails = _sellDetailsRepository.FindBy(a => a.SellMasterId == id).ToList();
            var mapData=_mapper.Map<SellMasterDtos>(data);
            var deleteDetails = DeleteSellDetails(mapData);
            _sellMasterRepository.Delete(id);
            _sellMasterRepository.Save();
        }

        private async Task<bool> DeleteSellDetails(SellMasterDtos existingDetails)
        {
            try
            {

                foreach (var item in existingDetails.SellsDetails)
                {
                    _sellDetailsRepository.Delete(item.Id);
                    var inv = _inventoryRepository.FindBy(a => a.ProductName == item.ProductName && a.Size == item.Size && a.CompanyId == item.CompanyId && a.ProductType == item.ProductType && a.WarehouseId == 1 && a.TenantId== existingDetails.TenantId).FirstOrDefault();
                    if (inv != null)
                    {
                        inv.Quantity += item.Quantity;
                        inv.SaleQuantity -= item.Quantity;
                        _inventoryRepository.Update(inv);
                    }
                }
                return true;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        public List<SellMasterDtos> GetAllAsync(long tenantId)
        {
            var data = _sellMasterRepository.FindBy(a=>a.TenantId==tenantId).ToList();
            foreach (var item in data)
            {
                item.SellsDetails = _sellDetailsRepository.FindBy(a => a.SellMasterId == item.Id).ToList();
                foreach (var details in item.SellsDetails)
                {
                    details.Company = _companyRepository.GetById(details.CompanyId).Result;
                }
                item.Customer = _customerRepository.GetById(item.CustomerId).Result;
            }           
            return _mapper.Map<List<SellMasterDtos>>(data);
        }

        public List<SellMasterDtos> GetAllAsync(long startDate,long endDate,long tenantId)
        {
            var data = _sellMasterRepository.FindBy(a=>a.InvoiceDate<=endDate&&a.InvoiceDate>=startDate && a.TenantId==tenantId).ToListAsync();
            foreach (var item in data.Result)
            {
                item.SellsDetails = _sellDetailsRepository.FindBy(a => a.SellMasterId == item.Id).ToList();
                foreach (var details in item.SellsDetails)
                {
                    details.Company = _companyRepository.GetById(details.CompanyId).Result;
                }
                item.Customer = _customerRepository.GetById(item.CustomerId).Result;
            }
            return _mapper.Map<List<SellMasterDtos>>(data.Result);
        }

        public SellMasterDtos GetAsync(long id)
        {
            var data = _sellMasterRepository.GetById(id).Result;
            data.SellsDetails = _sellDetailsRepository.FindBy(a => a.SellMasterId == id).ToList();
            foreach (var details in data.SellsDetails)
            {
                details.Company = _companyRepository.GetById(details.CompanyId).Result;
            }
            data.Customer = _customerRepository.GetById(data.CustomerId).Result;
            var dataDto= _mapper.Map<SellMasterDtos>(data);
            var returnMaster=_returnMaster.FindBy(a=>a.SellMasterId==id).FirstOrDefault();
            if (returnMaster != null)
            {
                var details=_returnDetails.FindBy(a=>a.ReturnMasterId.Equals(returnMaster.Id)).ToList();
                returnMaster.ReturnDetails = details;
            }
            var returnMasterDto = _mapper.Map<ReturnMasterDtos>(returnMaster);
            dataDto.ReturnMaster = returnMasterDto;
            return dataDto;
        }

        public async Task<SellMaster> UpdateAsync(SellMasterDtos model)
        {
            SellMaster result;
            try
            {

                var existingMaster = GetAsync(model.Id);
                var isDeleted = DeleteSellDetails(existingMaster).Result;
                existingMaster.DueAdvance = model.DueAdvance;
                existingMaster.PaymentType = model.PaymentType;
                existingMaster.TotalPrice = model.TotalPrice;

                foreach (var item in model.SellsDetails)
                {
                    var details = _mapper.Map<SellDetails>(item);
                    details.Company = null;
                    _sellDetailsRepository.Insert(details);
                    var inv = _inventoryRepository.FindBy(a => a.ProductName == item.ProductName && a.Size == item.Size && a.CompanyId == item.CompanyId && a.ProductType == item.ProductType && a.WarehouseId == 1 && item.TenantId==model.TenantId).FirstOrDefault();
                    if (inv != null)
                    {
                        inv.Quantity += item.Quantity;
                        inv.ReceivingQuantity += item.Quantity;
                        _inventoryRepository.Update(inv);
                    }
                    _inventoryRepository.Save();
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new ArgumentException(
                  $"{ex}.");
            }
            return null;
        }
    }
}
