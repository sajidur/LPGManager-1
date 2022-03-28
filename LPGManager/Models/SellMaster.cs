namespace LPGManager.Models
{
    public class SellMaster : BaseEntity
    {
        public decimal TotalPrice { get; set; }
        public decimal Discount { get; set; }
        public decimal DueAdvance { get; set; }
        public decimal PaymentType { get; set; }
        public string? Notes { get; set; }
        public List<SellDetails> SellsDetails { get; set; }
    }
}
