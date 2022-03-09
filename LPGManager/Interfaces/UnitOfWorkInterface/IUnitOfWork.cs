using LPGManager.Interfaces.CompanyInterface;
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
        ICompanyService companyService { get; }
        Task<bool> SaveAsync();
    }
}
