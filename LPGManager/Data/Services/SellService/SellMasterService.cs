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

        public SellMasterService(IMapper mapper, IGenericRepository<SellMaster> sellMasterRepository, IGenericRepository<SellDetails> sellsDetailRepository, IGenericRepository<Inventory> inventoryRepository, IGenericRepository<Company> companyRepository)
        {
            _sellMasterRepository = sellMasterRepository;
            _sellDetailsRepository = sellsDetailRepository;
            _inventoryRepository = inventoryRepository;
            _companyRepository = companyRepository;
            _mapper = mapper;

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
                        var selldetails = _mapper.Map<SellDetails>(item);
                        selldetails.SellMasterId = res.Id;
                        _sellDetailsRepository.Insert(selldetails);
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
            return DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString("d2") + DateTime.Now.Day.ToString("d2") + _sellMasterRepository.GetLastId();
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
            }
            return _mapper.Map<List<SellMasterDtos>>(data.Result);
        }

        public async Task<SellMaster> GetAsync(long id)
        {
            //var data = await _dbContext.PurchaseMasters
            //           .Include(c => c.PurchasesDetails)
            //           .Include(c => c.SupplierId).FirstOrDefaultAsync(i => i.Id == id);
            //if (data == null)
            //    throw new ArgumentException("Purchase Details is not exist");
            //return (data);
            return null;
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
