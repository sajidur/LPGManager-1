using LPGManager.Interfaces.CompanyInterface;
using LPGManager.Interfaces.ExchangeInterface;
using LPGManager.Interfaces.InventoryInterface;
using LPGManager.Interfaces.PurchasesInterface;
using LPGManager.Interfaces.RoleInterface;
using LPGManager.Interfaces.SellsInterface;
using LPGManager.Interfaces.SupplierInterface;

namespace LPGManager.Interfaces.UnitOfWorkInterface
{
    public interface IUnitOfWork
    {
        IPurchaseDetailsService purchaseDetailsService { get; }
        IPurchaseMasterService purchaseMasterService { get; }
        ISupplierService supplierService { get; }
        ISellDetailsService sellDetailsService { get; }
        ISellMasterService sellMasterService { get; }
        ICompanyService companyService { get; }
        IInventoryService inventoryService { get; }
        IRoleService roleService { get; }
        IExchangeService exchangeService { get; }
        Task<bool> SaveAsync();
    }
}
