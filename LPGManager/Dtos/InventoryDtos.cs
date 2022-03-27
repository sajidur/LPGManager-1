namespace LPGManager.Dtos
{
    public class InventoryDtos
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public string Size { get; set; }
        public string? ProductType { get; set; }
        public int? Price { get; set; }
        public int? Quantity { get; set; }
        public int OpeningQuantity { get; set; }
        public int ReceivingQuantity { get; set; }
        public int ReturnQuantity { get; set; }
        public int DamageQuantity { get; set; }
        public int SaleQuantity { get; set; }
        public int SupplierId { get; set; }
        public int WarehouseId { get; set; }
    }
}
