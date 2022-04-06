using AutoMapper;
using LPGManager.Dtos;
using LPGManager.Interfaces.InventoryInterface;
using LPGManager.Models;
using LPGManager.Models.Settings;
using Microsoft.EntityFrameworkCore;

namespace LPGManager.Data.Services.InventoryService
{
    public class InventoryService : IInventoryService
    {
        private IGenericRepository<Inventory> _inventoryRepository;
        private IGenericRepository<Company> _companyRepository;
        private IGenericRepository<Warehouse> _wareRepository;

        IMapper _mapper;
        public InventoryService(IGenericRepository<Warehouse> wareRepository,IMapper mapper,IGenericRepository<Inventory> inventoryRepository, IGenericRepository<Company> companyRepository)
        {
            _inventoryRepository = inventoryRepository;
            _companyRepository = companyRepository;
            _wareRepository = wareRepository;
            _mapper= mapper;
        }
        public Inventory AddAsync(InventoryDtos model)
        {
            SellMaster result;
            try
            {
                var item = _mapper.Map<Inventory>(model);
                    var inv = _inventoryRepository.FindBy(a => a.ProductName == item.ProductName && a.Size == item.Size && a.CompanyId == item.CompanyId && a.ProductType == item.ProductType && a.WarehouseId == 1).FirstOrDefault();
                    if (inv != null)
                    {
                        inv.Quantity -= item.Quantity;
                        inv.SaleQuantity += item.Quantity;
                        _inventoryRepository.Update(inv);
                    }
                    _inventoryRepository.Insert(item);
                
                return null;
            }
            catch (Exception ex)
            {
                throw new ArgumentException(
                  $"{ex}.");
            }

        }


        public async Task DeleteAsync(long id)
        {
            var existing = _inventoryRepository.GetById(id);

            if (existing == null)
                throw new ArgumentException("Inventory is not exist");

            _inventoryRepository.Delete(id);
            _inventoryRepository.Save();
        }

        public List<InventoryDtos> GetAllAsync()
        {
            var res = _inventoryRepository.GetAll().Result;
            var data =_mapper.Map<List<InventoryDtos>>(res);
            foreach (var item in data)
            {
                item.Company = _mapper.Map<CompanyDtos>(_companyRepository.GetById(item.CompanyId).Result);
                item.Warehouse = _mapper.Map<WarehouseDtos>(_wareRepository.GetById(item.WarehouseId).Result);
            }
            return data;
        }

        public async Task<Inventory> GetAsync(long id)
        {
            //var data = await _dbContext.PurchaseMasters
            //           .Include(c => c.PurchasesDetails)
            //           .Include(c => c.SupplierId).FirstOrDefaultAsync(i => i.Id == id);
            //if (data == null)
            //    throw new ArgumentException("Purchase Details is not exist");
            //return (data);
            return null;
        }

        public async Task<Inventory> UpdateAsync(InventoryDtos model)
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
