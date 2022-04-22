using LPGManager.Models.Settings;

namespace LPGManager.Models
{
    public class Inventory : BaseEntity
    {
        public string ProductName { get; set; }
        public string Size { get; set; }
        public string ProductType { get; set; }
        public decimal Price { get; set; }
        public decimal Quantity { get; set; }
        public decimal OpeningQuantity { get; set; }
        public decimal ReceivingQuantity { get; set; }
        public decimal ReturnQuantity { get; set; }
        public decimal DamageQuantity { get; set; }
        public decimal SaleQuantity { get; set; }
        public decimal SupportQty { get; set; }
        public long CompanyId { get; set; }
        public long WarehouseId { get; set; }
        public Company Company { get; set; }
        public Warehouse Warehouse { get; set; }
    }
}
