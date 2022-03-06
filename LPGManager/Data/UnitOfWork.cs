using LPGManager.Data.Services.PurchaseService;
using LPGManager.Data.Services.SellService;
using LPGManager.Data.Services.SupplierService;
using LPGManager.Interfaces.PurchasesInterface;
using LPGManager.Interfaces.SellsInterface;
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
        public IPurchaseMasterService purchaseMasterService => new PurchaseMasterService(_dbContext);

        public ISupplierService supplierService => new SupplierService(_dbContext);

        public ISellDetailsService sellDetailsService => new SellDetailsService(_dbContext);
        public ISellMasterService sellMasterService => new SellMasterService(_dbContext);

        public async Task<bool> SaveAsync()
        {
            return await _dbContext.SaveChangesAsync() > 0;
        }
    }
}
