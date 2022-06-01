using AutoMapper;
using LPGManager.Common;
using LPGManager.Dtos;
using LPGManager.Interfaces.PurchasesInterface;
using LPGManager.Interfaces.UnitOfWorkInterface;
using LPGManager.Models;

using Microsoft.EntityFrameworkCore;

namespace LPGManager.Data.Services.PurchaseService
{
    public class PurchaseMasterService : IPurchaseMasterService
    {

        IMapper _mapper;
        private IGenericRepository<PurchaseMaster> _purchaseMasterRepository;
        private IGenericRepository<PurchaseDetails> _purchaseDetailsRepository;
        private IGenericRepository<Inventory> _inventoryRepository;
        private IGenericRepository<Company> _companyRepository;

        public PurchaseMasterService(IMapper mapper, IGenericRepository<PurchaseMaster> purchaseMasterRepository, IGenericRepository<PurchaseDetails> purchaseDetailsRepository, IGenericRepository<Inventory> inventoryRepository, IGenericRepository<Company> companyRepository)
        {
            _purchaseMasterRepository=purchaseMasterRepository;
            _purchaseDetailsRepository = purchaseDetailsRepository;
            _inventoryRepository=inventoryRepository;
            _companyRepository = companyRepository;
            _mapper = mapper;

        }
        public PurchaseMaster AddAsync(PurchaseMasterDtos model)
        {
            PurchaseMaster result;
            try
            {
                var purchase = _mapper.Map<PurchaseMaster>(model);
                if (model.PurchaseDetails != null)
                {
                    purchase.InvoiceNo = GenerateInvoice().Result;
                    purchase.InvoiceDate = Helper.ToEpoch(DateTime.Now);
                    purchase.TotalPrice = model.PurchaseDetails.Sum(a => a.Quantity * a.Price);                  
                    var res = _purchaseMasterRepository.Insert(purchase);
                    _purchaseMasterRepository.Save();
                    foreach (var item in model.PurchaseDetails)
                    {
                        //var purchasedetails = _mapper.Map<PurchaseDetails>(item);
                        //purchasedetails.PurchaseMasterId = res.Id;
                        //_purchaseDetailsRepository.Insert(purchasedetails);
                      //  _inventoryRepository.Save();
                        var inv = _inventoryRepository.FindBy(a=>a.ProductName==item.ProductName && a.Size == item.Size && a.CompanyId == item.CompanyId && a.ProductType == item.ProductType && a.WarehouseId== 1 && a.TenantId == model.TenantId).FirstOrDefault();
                        if (inv != null)
                        {
                            inv.Quantity += item.Quantity;
                            inv.ReceivingQuantity += item.Quantity;
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
                                ExchangeQty = 0,
                                PurchaseReturn = 0,
                                ReturnQuantity = 0,
                                ProductType = item.ProductType,
                                ProductName = item.ProductName,
                                Size = item.Size,
                                TenantId = purchase.TenantId,
                                CreatedBy = purchase.CreatedBy
                            };
                            _inventoryRepository.Insert(inv);
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

        private async Task<string> GenerateInvoice()
        {
            var id = _purchaseMasterRepository.GetLastId("PurchaseMasters").Result;
            return DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString("d2") + DateTime.Now.Day.ToString("d2") +id.ToString("d3") ;
        }
 
        public async Task DeleteAsync(long id)
        {
            var existing = GetAsync(id).Result;
           
            if (existing == null)
                throw new ArgumentException("Purchase is not exist");
            var deleteDetails = DeletePurchaseDetails(existing);
            _purchaseMasterRepository.Delete(id);
            _purchaseMasterRepository.Save();
        }

        public List<PurchaseMasterDtos> GetAllAsync(long tenantId)
        {
            var data = _purchaseMasterRepository.FindBy(a=>a.TenantId==tenantId).ToList();
            foreach (var item in data)
            {
                item.PurchaseDetails = _purchaseDetailsRepository.FindBy(a => a.PurchaseMasterId == item.Id).ToList();
                foreach (var details in item.PurchaseDetails)
                {
                    details.Company = _companyRepository.GetById(details.CompanyId).Result;
                }
            }
            return _mapper.Map<List<PurchaseMasterDtos>>(data);
        }
        public List<PurchaseMasterDtos> GetAllAsync(long startDate, long endDate, long tenantId)
        {
            var data = _purchaseMasterRepository.FindBy(a => a.InvoiceDate <= endDate && a.InvoiceDate >= startDate && a.TenantId==tenantId).ToListAsync();
            foreach (var item in data.Result)
            {
                item.PurchaseDetails = _purchaseDetailsRepository.FindBy(a => a.PurchaseMasterId == item.Id).ToList();
                foreach (var details in item.PurchaseDetails)
                {
                    details.Company = _companyRepository.GetById(details.CompanyId).Result;
                }
            }
            return _mapper.Map<List<PurchaseMasterDtos>>(data.Result);
        }

        public async Task<PurchaseMaster> GetAsync(long id)
        {
            var existingMaster = await _purchaseMasterRepository.GetById(id);
            var existingDetails = await _purchaseDetailsRepository.FindBy(a => a.PurchaseMasterId == id).ToListAsync();
            existingMaster.PurchaseDetails = existingDetails;
            return existingMaster;
        }

        private async Task<bool> DeletePurchaseDetails(PurchaseMaster existingDetails)
        {
            try
            {

                foreach (var item in existingDetails.PurchaseDetails)
                {
                    _purchaseDetailsRepository.Delete(item.Id);
                    var inv = _inventoryRepository.FindBy(a => a.ProductName == item.ProductName && a.Size == item.Size && a.CompanyId == item.CompanyId && a.ProductType == item.ProductType && a.WarehouseId == 1 && a.TenantId== existingDetails.TenantId).FirstOrDefault();
                    if (inv != null)
                    {
                        inv.Quantity -= item.Quantity;
                        inv.ReceivingQuantity -= item.Quantity;
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
        public async Task<PurchaseMaster> UpdateAsync(PurchaseMasterDtos model)
        {
            PurchaseMaster result;
            try
            {

                var existingMaster= GetAsync(model.Id).Result;
                var isDeleted=DeletePurchaseDetails(existingMaster).Result;
                existingMaster.DueAdvance = model.DueAdvance;
                existingMaster.PaymentType = model.PaymentType;
                existingMaster.TotalCommission = model.TotalCommission;
                existingMaster.TotalPrice = model.PurchaseDetails.Sum(a => a.Quantity * a.Price);
                foreach (var item in model.PurchaseDetails)
                {
                    var details=_mapper.Map<PurchaseDetails>(item);
                    details.Company = null;
                    _purchaseDetailsRepository.Insert(details);
                    var inv = _inventoryRepository.FindBy(a => a.ProductName == item.ProductName && a.Size == item.Size && a.CompanyId == item.CompanyId && a.ProductType == item.ProductType && a.WarehouseId == 1 && a.TenantId == model.TenantId).FirstOrDefault();
                    if (inv != null)
                    {
                        inv.Quantity += item.Quantity;
                        inv.ReceivingQuantity += item.Quantity;
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
                            ExchangeQty = 0,
                            PurchaseReturn = 0,
                            ReturnQuantity = 0,
                            ProductType = item.ProductType,
                            ProductName = item.ProductName,
                            Size = item.Size,
                            TenantId = model.TenantId,
                            CreatedBy = model.CreatedBy
                        };
                        _inventoryRepository.Insert(inv);
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
        }

  
    }
}
