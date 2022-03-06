namespace LPGManager.Models
{
    public class SellMaster
    {
        public int Id { get; set; }
        public int TotalPrice { get; set; }
        public int? Discount { get; set; }
        public int? DueAdvance { get; set; }
        public int? PaymentType { get; set; }
        public string? Notes { get; set; }
        public DateTime CreatedOn { get; set; }
        public List<SellDetails> SellsDetails { get; set; }
    }
}
