namespace LPGManager.Models
{
    public class PurchaseMaster : BaseEntity
    { 
        public PurchaseMaster()
        {
            PurchaseDetails = new List<PurchaseDetails>();
        }
        public string InvoiceNo { get; set; }
        public long SupplierId { get; set; }
        public decimal TotalPrice { get; set; }
        public decimal TotalCommission { get; set; }
        public decimal DueAdvance { get; set; }
        public string PaymentType { get; set; }
        public string? Notes { get; set; }
        public List<PurchaseDetails> PurchaseDetails { get; set; }
    }
}
