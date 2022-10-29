using AutoMapper;
using LPGManager.Common;
using LPGManager.Data.Services.Ledger;
using LPGManager.Dtos;
using LPGManager.Interfaces.InventoryInterface;
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
        private IInventoryService _inventoryService;
        private ILedgerPostingService _ledgerPostingService;
        public SellMasterService(IMapper mapper, 
            IGenericRepository<SellMaster> sellMasterRepository, 
            IGenericRepository<SellDetails> sellsDetailRepository, 
            IGenericRepository<Inventory> inventoryRepository, 
            IGenericRepository<Company> companyRepository, 
            IGenericRepository<CustomerEntity> customerRepository,
            IGenericRepository<ReturnMaster> retrunMaster,
            IGenericRepository<ReturnDetails> returnDetails,
            IInventoryService inventoryService,
            ILedgerPostingService ledgerPostingService)
        {
            _sellMasterRepository = sellMasterRepository;
            _sellDetailsRepository = sellsDetailRepository;
            _inventoryRepository = inventoryRepository;
            _companyRepository = companyRepository;
            _customerRepository = customerRepository;
            _mapper = mapper;
            _returnMaster = retrunMaster;
            _returnDetails = returnDetails;
            _inventoryService = inventoryService;
            _ledgerPostingService = ledgerPostingService;

        }
        public SellMaster AddAsync(SellMasterDtos model)
        {
            SellMaster result;
            try
            {
                if (model.SellsDetails != null)
                {
                    foreach (var sellDetails in model.SellsDetails)
                    {
                        if (sellDetails.ProductName==ProductNameEnum.Bottle.ToString())
                        {
                            var data = _inventoryService.Get(model.TenantId, sellDetails.CompanyId, sellDetails.ProductType, sellDetails.Size);
                            var riffle = model.SellsDetails.Where(a => a.ProductName == ProductNameEnum.Refill.ToString() && a.Size == sellDetails.Size && a.CompanyId == sellDetails.CompanyId && a.ProductType == sellDetails.ProductType).FirstOrDefault();
                            if (riffle != null)
                            {
                                if (data == null || data.EmptyBottle + riffle.Quantity < sellDetails.Quantity)
                                {
                                    throw new Exception("Empty bottle qty is not enough to store riffle");
                                }
                            }
                            else if (data == null || data.EmptyBottle < sellDetails.Quantity)
                            {
                                throw new Exception("Empty bottle qty is not enough to store riffle");
                            }
                        }
                        else
                        {
                            if (sellDetails.ProductName == ProductNameEnum.Refill.ToString())
                            {
                                var riffle = model.SellsDetails.Where(a => a.ProductName == ProductNameEnum.Refill.ToString() && a.Size == sellDetails.Size && a.CompanyId == sellDetails.CompanyId && a.ProductType == sellDetails.ProductType).FirstOrDefault();
                                var bottleInv = model.SellsDetails.Where(a => a.ProductName == ProductNameEnum.Bottle.ToString() && a.Size == sellDetails.Size && a.CompanyId == sellDetails.CompanyId && a.ProductType == sellDetails.ProductType).FirstOrDefault();
                                var supportqty = 0.0m;
                                if (bottleInv != null)
                                {
                                    if (bottleInv.Quantity < riffle.Quantity)
                                    {
                                        supportqty = sellDetails.Quantity - bottleInv.Quantity;
                                    }
                                }
                                else
                                {
                                    supportqty = sellDetails.Quantity;
                                }
                                sellDetails.SupportQty += supportqty;
                            }
                        }
                        // support quantity

                    }
                    var sell = _mapper.Map<SellMaster>(model);
                    sell.InvoiceNo = GenerateInvoice();
                    sell.InvoiceDate = Helper.ToEpoch(DateTime.Now);
                    sell.Discount = model.SellsDetails.Sum(a => a.Discount * a.Quantity);
                    sell.TotalPrice = model.SellsDetails.Sum(a => a.Quantity * a.Price)-sell.Discount;
                    sell.DeliveryStatus = DeliveryEnum.Pending.ToString();
                    var res = _sellMasterRepository.Insert(sell);
                    _sellMasterRepository.Save();
                    foreach (var item in model.SellsDetails)
                    {
                        var inv = _inventoryRepository.FindBy(a => a.ProductName == item.ProductName && a.Size == item.Size && a.CompanyId == item.CompanyId && a.ProductType == item.ProductType && a.WarehouseId == 1 && a.TenantId == model.TenantId).FirstOrDefault();         
                        if (inv != null)
                        {
                            if (item.ProductName == ProductNameEnum.Refill.ToString())
                            {
                                var bottleInv = model.SellsDetails.Where(a => a.ProductName == ProductNameEnum.Bottle.ToString() && a.Size == item.Size && a.CompanyId == item.CompanyId && a.ProductType == item.ProductType).FirstOrDefault();
                                var supportqty = 0.0m;
                                if (bottleInv != null)
                                {
                                    if (bottleInv.Quantity < inv.Quantity)
                                    {
                                        supportqty = item.Quantity - bottleInv.Quantity;
                                    }
                                }
                                else
                                {
                                    supportqty = item.Quantity;
                                }
                                inv.SupportQty += supportqty;
                            }
                            inv.Quantity -= item.Quantity;
                            inv.SaleQuantity += item.Quantity;
                            _inventoryRepository.Update(inv);
                        }
                        _inventoryRepository.Save();
                    }
                    //ledger posting
                    var ledger = new LedgerPostingDtos()
                    {
                        LedgerId = model.CustomerId,
                        Credit = sell.TotalPrice,
                        TransactionType=(int)TransactionTypeEnum.Sell,
                        VoucherTypeId= 0,
                        VoucherNo=sell.InvoiceNo,
                        ReferanceInvoiceNo=sell.InvoiceNo,
                        Notes=sell.Notes,
                        CreatedDate= sell.CreatedDate,
                        CreatedBy=sell.CreatedBy,
                        PostingDate=sell.InvoiceDate
                    };
                    _ledgerPostingService.AddAsync(ledger);
                    return res;
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
            var sellMasterDetails = _mapper.Map<List<SellMasterDtos>>(data);
            var returns = _returnMaster.FindBy(a => sellMasterDetails.Select(a => a.Id).Contains(a.SellMasterId)).Include(a => a.ReturnDetails);
            foreach (var item in sellMasterDetails)
            {
                var returnMastre = returns.Where(a => a.SellMasterId == item.Id).FirstOrDefault();
                var returnMasterDto = _mapper.Map<ReturnMasterDtos>(returnMastre);
                item.ReturnMaster = returnMasterDto;
            }
            return sellMasterDetails;
        }
        public List<SellMasterDtos> GetAllAsyncByCustomerId(int customerId)
        {
            var data = _sellMasterRepository.FindBy(a => a.CustomerId == customerId).ToList();
            foreach (var item in data)
            {
                item.SellsDetails = _sellDetailsRepository.FindBy(a => a.SellMasterId == item.Id).ToList();
                foreach (var details in item.SellsDetails)
                {
                    details.Company = _companyRepository.GetById(details.CompanyId).Result;
                }
                item.Customer = _customerRepository.GetById(item.CustomerId).Result;
            }
            var sellMasterDetails = _mapper.Map<List<SellMasterDtos>>(data);
            var returns = _returnMaster.FindBy(a => sellMasterDetails.Select(a => a.Id).Contains(a.SellMasterId)).Include(a => a.ReturnDetails);
            foreach (var item in sellMasterDetails)
            {
                var returnMastre = returns.Where(a => a.SellMasterId == item.Id).FirstOrDefault();
                var returnMasterDto = _mapper.Map<ReturnMasterDtos>(returnMastre);
                item.ReturnMaster = returnMasterDto;
            }
            return sellMasterDetails;
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
            var sellMasterDetails= _mapper.Map<List<SellMasterDtos>>(data.Result);
            var returns=_returnMaster.FindBy(a => sellMasterDetails.Select(a => a.Id).Contains(a.SellMasterId)).Include(a=>a.ReturnDetails);
            foreach (var item in sellMasterDetails)
            {
              var returnMastre = returns.Where(a => a.SellMasterId == item.Id).FirstOrDefault();
                var returnMasterDto = _mapper.Map<ReturnMasterDtos>(returnMastre);
                item.ReturnMaster = returnMasterDto;
            }
            return sellMasterDetails;
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

        public async Task<SellMaster> Delivery(DeliveryDtos delivery)
        {
            try
            {
                var sellMaster = _sellMasterRepository.GetById(delivery.SellmasterId).Result;
                sellMaster.DeliveryDate = delivery.DeliveryDate;
                sellMaster.DeliveryStatus = DeliveryEnum.Delivered.ToString();
                sellMaster.ReceiveBy=delivery.ReceiveBy;
                sellMaster.DeliveryBy = delivery.DeliveryBy;
                _sellMasterRepository.Update(sellMaster);
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
