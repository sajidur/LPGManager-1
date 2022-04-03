using LPGManager.Data.Services.CompanyService;
using LPGManager.Data.Services.ExchangeService;
using LPGManager.Data.Services.InventoryService;
using LPGManager.Data.Services.PurchaseService;
using LPGManager.Data.Services.RoleService;
using LPGManager.Data.Services.SellService;
using LPGManager.Data.Services.SettingsService;
using LPGManager.Data.Services.SupplierService;
using LPGManager.Interfaces.CompanyInterface;
using LPGManager.Interfaces.ExchangeInterface;
using LPGManager.Interfaces.InventoryInterface;
using LPGManager.Interfaces.PurchasesInterface;
using LPGManager.Interfaces.RoleInterface;
using LPGManager.Interfaces.SellsInterface;
using LPGManager.Interfaces.SettingsInterface;
using LPGManager.Interfaces.SupplierInterface;
using LPGManager.Interfaces.UnitOfWorkInterface;

namespace LPGManager.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppsDbContext _dbContext;
        public UnitOfWork(AppsDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IPurchaseDetailsService purchaseDetailsService => new PurchaseDetailsService(_dbContext);
     //   public IPurchaseMasterService purchaseMasterService => new PurchaseMasterService(_dbContext);


        public ISellDetailsService sellDetailsService => new SellDetailsService(_dbContext);

      //  public ICompanyService companyService => new CompanyService(_dbContext);
        public IInventoryService inventoryService => new InventoryService(_dbContext);
        public IRoleService roleService => new RoleService(_dbContext);
        public IExchangeService exchangeService => new ExchangeService(_dbContext);
        public async Task<bool> SaveAsync()
        {
            return await _dbContext.SaveChangesAsync() > 0;
        }
    }
}
