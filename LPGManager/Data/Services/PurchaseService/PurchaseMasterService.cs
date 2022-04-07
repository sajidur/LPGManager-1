using AutoMapper;
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
                    var res = _purchaseMasterRepository.Insert(purchase);
                    _purchaseMasterRepository.Save();
                    foreach (var item in model.PurchaseDetails)
                    {
                        //var purchasedetails = _mapper.Map<PurchaseDetails>(item);
                        //purchasedetails.PurchaseMasterId = res.Id;
                        //_purchaseDetailsRepository.Insert(purchasedetails);
                      //  _inventoryRepository.Save();
                        var inv = _inventoryRepository.FindBy(a=>a.ProductName==item.ProductName && a.Size == item.Size && a.CompanyId == item.CompanyId && a.ProductType == item.ProductType && a.WarehouseId== 1).FirstOrDefault();
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
                            inv.ReceivingQuantity = item.Quantity;
                            inv.OpeningQuantity = 0;
                            inv.Price = item.Price;
                            inv.Quantity = item.Quantity;
                            inv.SaleQuantity = 0;
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

        private async Task<string> GenerateInvoice()
        {
            var id = _purchaseMasterRepository.GetLastId("PurchaseMasters").Result;
            return DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString("d2") + DateTime.Now.Day.ToString("d2") +id.ToString("d3") ;
        }
 
        public async Task DeleteAsync(long id)
        {
            var existing = await _purchaseMasterRepository.GetById(id);

            if (existing == null)
                throw new ArgumentException("Purchase is not exist");

            _purchaseMasterRepository.Delete(id);
            _purchaseMasterRepository.Save();
        }

        public List<PurchaseMasterDtos> GetAllAsync()
        {
            var data = _purchaseMasterRepository.GetAll();
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
            //var data = await _dbContext.PurchaseMasters
            //           .Include(c => c.PurchasesDetails)
            //           .Include(c => c.SupplierId).FirstOrDefaultAsync(i => i.Id == id);
            //if (data == null)
            //    throw new ArgumentException("Purchase Details is not exist");
            //return (data);
            return null;
        }

        public async Task<PurchaseMaster> UpdateAsync(PurchaseMaster model)
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
