using AutoMapper;
using LPGManager.Common;
using LPGManager.Dtos;
using LPGManager.Interfaces.ExchangeInterface;
using LPGManager.Models;

using Microsoft.EntityFrameworkCore;

namespace LPGManager.Data.Services.ExchangeService
{
    public class ExchangeService : IExchangeService
    {
        IMapper _mapper;
        private IGenericRepository<ExchangeMaster> _exchangeMasterRepository;
        private IGenericRepository<ExchangeDetails> _exchangeDetailsRepository;
        private IGenericRepository<Inventory> _inventoryRepository;
        private IGenericRepository<Company> _companyRepository;
        public ExchangeService(IMapper mapper,
            IGenericRepository<ExchangeMaster> exchangeMasterRepository,
            IGenericRepository<ExchangeDetails> exchangeDetailsRepository,
            IGenericRepository<Inventory> inventoryRepository,
            IGenericRepository<Company> companyRepository)
        {
            _exchangeMasterRepository = exchangeMasterRepository;
            _exchangeDetailsRepository = exchangeDetailsRepository;
            _inventoryRepository = inventoryRepository;
            _companyRepository = companyRepository;
            _mapper = mapper;
        }
        public ExchangeMaster AddAsync(ExchangeMasterDtos model)
        {
            ExchangeMaster result;
            try
            {
                var sell = _mapper.Map<ExchangeMaster>(model);
                if (model.ReceiveProductDetails != null || model.MyProductDetails!=null)
                {
                    sell.InvoiceNo = GenerateInvoice();
                    sell.InvoiceDate = Helper.ToEpoch(DateTime.Now);
                    sell.MyProductDetails = null;
                    sell.ReceiveProductDetails = null;
                    var res = _exchangeMasterRepository.Insert(sell);
                    _exchangeMasterRepository.Save();
                    foreach (var item in model.MyProductDetails)
                    {
                          var details = _mapper.Map<ExchangeDetails>(item);
                          details.ExchangeMasterId = res.Id;
                        _exchangeDetailsRepository.Insert(details);
                        _exchangeDetailsRepository.Save();
                        var inv = _inventoryRepository.FindBy(a => a.ProductName == item.ProductName && a.Size == item.Size && a.CompanyId == item.CompanyId && a.ProductType == item.ProductType && a.WarehouseId == 1).FirstOrDefault();
                        if (inv != null)
                        {
                            inv.Quantity -= item.Quantity;
                            inv.PurchaseReturn += item.Quantity;
                            inv.ExchangeQty -= item.Quantity;
                            _inventoryRepository.Update(inv);
                        }
                        else
                        {
                            inv = new Inventory();
                            inv.WarehouseId = 1;
                            inv.CompanyId = item.CompanyId;
                            inv.DamageQuantity = 0;
                            inv.ReceivingQuantity = 0;
                            inv.OpeningQuantity = 0;
                            inv.Price = 0;
                            inv.Quantity = item.Quantity;
                            inv.SaleQuantity = item.Quantity;
                            inv.ReturnQuantity = 0;
                            inv.ProductType = item.ProductType;
                            inv.ProductName = item.ProductName;
                            inv.Size = item.Size;
                            _inventoryRepository.Insert(inv);
                        }
                        _inventoryRepository.Save();
                    }
                    foreach (var item in model.ReceiveProductDetails)
                    {
                        var details = _mapper.Map<ExchangeDetails>(item);
                        details.ExchangeMasterId = res.Id;
                        _exchangeDetailsRepository.Insert(details);
                        _exchangeDetailsRepository.Save();
                        var inv = _inventoryRepository.FindBy(a => a.ProductName == item.ProductName && a.Size == item.Size && a.CompanyId == item.CompanyId && a.ProductType == item.ProductType && a.WarehouseId == 1).FirstOrDefault();
                        if (inv != null)
                        {
                            inv.Quantity += item.Quantity;
                            inv.ReceivingQuantity += item.Quantity;
                            _inventoryRepository.Update(inv);
                        }
                        else
                        {
                            inv = new Inventory();
                            inv.WarehouseId = 1;
                            inv.CompanyId = item.CompanyId;
                            inv.DamageQuantity = 0;
                            inv.ReceivingQuantity = 0;
                            inv.OpeningQuantity = 0;
                            inv.Price = 0;
                            inv.Quantity = item.Quantity;
                            inv.SaleQuantity = item.Quantity;
                            inv.ReturnQuantity = 0;
                            inv.ProductType = item.ProductType;
                            inv.ProductName = item.ProductName;
                            inv.Size = item.Size;
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

        private string GenerateInvoice()
        {
            var lastId = _exchangeMasterRepository.GetLastId("ExchangeMasters").Result;
            return DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString("d2") + DateTime.Now.Day.ToString("d2") + lastId.ToString("d3");
        }

        public async Task DeleteAsync(long id)
        {
            var data = _exchangeMasterRepository.GetById(id).Result;
            if (data == null)
                throw new ArgumentException("Sell is not exist");
            var details= _exchangeDetailsRepository.FindBy(a => a.ExchangeMasterId == id).ToList();
            data.MyProductDetails = details.Where(a => a.ExchangeType == 1).ToList();
            data.ReceiveProductDetails = details.Where(a => a.ExchangeType == 2).ToList();

            var deleteDetails = DeleteSellDetails(data);
            _exchangeMasterRepository.Delete(id);
            _exchangeMasterRepository.Save();
        }

        private async Task<bool> DeleteSellDetails(ExchangeMaster existingDetails)
        {
            try
            {

                foreach (var item in existingDetails.MyProductDetails)
                {
                    _exchangeDetailsRepository.Delete(item.Id);
                    var inv = _inventoryRepository.FindBy(a => a.ProductName == item.ProductName && a.Size == item.Size && a.CompanyId == item.CompanyId && a.ProductType == item.ProductType && a.WarehouseId == 1).FirstOrDefault();
                    if (inv != null)
                    {
                        inv.Quantity += item.Quantity;
                        inv.PurchaseReturn -= item.Quantity;
                        _inventoryRepository.Update(inv);
                    }
                }
                foreach (var item in existingDetails.ReceiveProductDetails)
                {
                    _exchangeDetailsRepository.Delete(item.Id);
                    var inv = _inventoryRepository.FindBy(a => a.ProductName == item.ProductName && a.Size == item.Size && a.CompanyId == item.CompanyId && a.ProductType == item.ProductType && a.WarehouseId == 1).FirstOrDefault();
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
        public List<ExchangeMaster> GetAllAsync()
        {
            var data = _exchangeMasterRepository.GetAll();
            foreach (var item in data.Result)
            {
                var exchangedetails=_exchangeDetailsRepository.FindBy(a => a.ExchangeMasterId == item.Id).ToList();
                item.ReceiveProductDetails = exchangedetails.Where(a=>a.ExchangeType==2).ToList();
                item.MyProductDetails = exchangedetails.Where(a => a.ExchangeType == 1).ToList();

                foreach (var details in item.ReceiveProductDetails)
                {
                    details.Company = _companyRepository.GetById(details.CompanyId).Result;
                }
                foreach (var details in item.MyProductDetails)
                {
                    details.Company = _companyRepository.GetById(details.CompanyId).Result;
                }
            }
            return _mapper.Map<List<ExchangeMaster>>(data.Result);
        }

        public List<ExchangeMasterDtos> GetAllAsync(long startDate, long endDate)
        {
            var data = _exchangeMasterRepository.FindBy(a => a.InvoiceDate <= endDate && a.InvoiceDate >= startDate).ToListAsync();
            foreach (var item in data.Result)
            {
                var exchangedetails = _exchangeDetailsRepository.FindBy(a => a.ExchangeMasterId == item.Id).ToList();
                item.ReceiveProductDetails = exchangedetails.Where(a => a.ExchangeType == 2).ToList();
                item.MyProductDetails = exchangedetails.Where(a => a.ExchangeType == 1).ToList();

                foreach (var details in item.ReceiveProductDetails)
                {
                    details.Company = _companyRepository.GetById(details.CompanyId).Result;
                }
                foreach (var details in item.MyProductDetails)
                {
                    details.Company = _companyRepository.GetById(details.CompanyId).Result;
                }
            }
            return _mapper.Map<List<ExchangeMasterDtos>>(data.Result);
        }

        public ExchangeMasterDtos GetAsync(long id)
        {
            var item = _exchangeMasterRepository.GetById(id).Result;
            var exchangedetails = _exchangeDetailsRepository.FindBy(a => a.ExchangeMasterId == id).ToList();
            item.ReceiveProductDetails = exchangedetails.Where(a => a.ExchangeType == 2).ToList();
            item.MyProductDetails = exchangedetails.Where(a => a.ExchangeType == 1).ToList();

            foreach (var details in item.ReceiveProductDetails)
            {
                details.Company = _companyRepository.GetById(details.CompanyId).Result;
            }
            foreach (var details in item.MyProductDetails)
            {
                details.Company = _companyRepository.GetById(details.CompanyId).Result;
            }
            return _mapper.Map<ExchangeMasterDtos>(item);
        }

        public async Task<ExchangeMaster> UpdateAsync(ExchangeMaster model)
        {
            //var existing = await _dbContext.PurchaseMasters.FirstOrDefaultAsync(c => c.Id == model.Id);
            //if (existing == null)
            //    throw new ArgumentException("Purchase Master is not exist");

            //var existingSupplierId = await _dbContext.Suppliers.FirstOrDefaultAsync(c => c.Id == model.SupplierId);
            //if (existingSupplierId == null)
            //    throw new ArgumentException("Supplier Id is not exist");

            //_dbContext.Entry(existing).CurrentValues.SetValues(model);

            //return model;
            return null;
        }
    }
}
