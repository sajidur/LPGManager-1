using LPGManager.Interfaces.PurchasesInterface;
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
        Task<bool> SaveAsync();
    }
}
