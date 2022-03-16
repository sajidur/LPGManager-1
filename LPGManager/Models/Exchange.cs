namespace LPGManager.Models
{
    public class Exchange
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public string? Size { get; set; }
        public int Price { get; set; }
        public int Quantity { get; set; }
        public string AdjustmentAmount { get; set; }
        public int? DueAdvance { get; set; }
        public int? ReceivingQuantity { get; set; }
        public int? ReturnQuantity { get; set; }
        public int? DamageQuantity { get; set; }
        public DateTime CreatedOn { get; set; }
        public int ComapnyId { get; set; }
        public Company Company { get; set; }

    }
}
