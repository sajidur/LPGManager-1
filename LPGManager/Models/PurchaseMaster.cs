namespace LPGManager.Models
{
    public class PurchaseMaster
    {        
        public int Id { get; set; }
        public int SupplierId { get; set; }
        public int TotalPrice { get; set; }
        public int? TotalCommission { get; set; }
        public int? DueAdvance { get; set; }
        public int? PaymentType { get; set; }
        public string? Notes { get; set; }
        public DateTime CreatedOn { get; set; }
        public List<PurchaseDetails> PurchasesDetails { get; set; }

    }
}
