using LPGManager.Models;
using LPGManager.Models.Settings;

namespace LPGManager.Dtos
{
    public class InventoryDtos:BaseDtos
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
        public int CompanyId { get; set; }
        public int WarehouseId { get; set; }
        public CompanyDtos? Company { get; set; }
        public WarehouseDtos? Warehouse { get; set; }
    }
}
