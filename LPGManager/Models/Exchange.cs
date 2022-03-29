namespace LPGManager.Models
{
    public class Exchange : BaseEntity
    {
        public string ProductName { get; set; }
        public string? Size { get; set; }
        public decimal Price { get; set; }
        public decimal Quantity { get; set; }
        public decimal AdjustmentAmount { get; set; }
        public decimal? DueAdvance { get; set; }
        public decimal? ReceivingQuantity { get; set; }
        public decimal? ReturnQuantity { get; set; }
        public decimal? DamageQuantity { get; set; }
        public DateTime CreatedOn { get; set; }
        public long ComapnyId { get; set; }
        public Company Company { get; set; }

    }
}
