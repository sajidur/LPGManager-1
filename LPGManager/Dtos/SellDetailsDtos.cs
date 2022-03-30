namespace LPGManager.Dtos
{
    public class SellDetailsDtos:BaseDtos
    {
        public long CompanyId { get; set; }
        public string ProductName { get; set; }
        public string Size { get; set; }
        public string? ProductType { get; set; }
        public decimal Price { get; set; }
        public decimal Quantity { get; set; }
        public decimal OpeningQuantity { get; set; }
        public decimal ReceivingQuantity { get; set; }
        public decimal ReturnQuantity { get; set; }
        public decimal DamageQuantity { get; set; }

        public long SellMasterId { get; set; }
    }
}
