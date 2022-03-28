namespace LPGManager.Models
{
    public class PurchaseMaster : BaseEntity
    { 
        public PurchaseMaster()
        {
            PurchasesDetails = new List<PurchaseDetails>();
        }
        public long SupplierId { get; set; }
        public decimal TotalPrice { get; set; }
        public decimal TotalCommission { get; set; }
        public decimal DueAdvance { get; set; }
        public string PaymentType { get; set; }
        public string? Notes { get; set; }
        public List<PurchaseDetails> PurchasesDetails { get; set; }
    }
}
