﻿using LPGManager.Models.Settings;

namespace LPGManager.Models
{
    public class Inventory : BaseEntity
    {
        public string ProductName { get; set; }
        public string Size { get; set; }
        public string? ProductType { get; set; }
        public int? Price { get; set; }
        public int? Quantity { get; set; }
        public int? OpeningQuantity { get; set; }
        public int? ReceivingQuantity { get; set; }
        public int? ReturnQuantity { get; set; }
        public int? DamageQuantity { get; set; }
        public int SaleQuantity { get; set; }
        public DateTime CreatedOn { get; set; }

        public int SupplierId { get; set; }
        public int WarehouseId { get; set; }

        public Supplier Supplier { get; set; }
        public Warehouse Warehouse { get; set; }
    }
}
