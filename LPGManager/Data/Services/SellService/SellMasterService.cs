using AutoMapper;
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
                    var res = _sellMasterRepository.Insert(sell);
                    _sellMasterRepository.Save();
                    foreach (var item in model.SellsDetails)
                    {
                      //  var selldetails = _mapper.Map<SellDetails>(item);
                      //  selldetails.SellMasterId = res.Id;
                     //   _sellDetailsRepository.Insert(selldetails);
                        _inventoryRepository.Save();
                        var inv = _inventoryRepository.FindBy(a => a.ProductName == item.ProductName && a.Size == item.Size && a.CompanyId == item.CompanyId && a.ProductType == item.ProductType && a.WarehouseId == 1).FirstOrDefault();
                        if (inv != null)
                        {
                            inv.Quantity -= item.Quantity;
                            inv.SaleQuantity += item.Quantity;
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
                            inv.Price = item.Price;
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
            var lastId = _sellMasterRepository.GetLastId("SellMasters").Result;
            return DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString("d2") + DateTime.Now.Day.ToString("d2") + lastId.ToString("d3");
        }

        public async Task DeleteAsync(long id)
        {
            //var existing = await _dbContext.pur.FirstOrDefaultAsync(c => c.Id == id);

            //if (existing == null)
            //    throw new ArgumentException("Purchase is not exist");

            //_dbContext.PurchaseMasters.Remove(existing);
        }

        public List<SellMasterDtos> GetAllAsync()
        {
            var data = _sellMasterRepository.GetAll();
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

        public List<SellMasterDtos> GetAllAsync(long startDate,long endDate)
        {
            var data = _sellMasterRepository.FindBy(a=>a.InvoiceDate>=endDate&&a.InvoiceDate<=startDate).ToListAsync();
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
