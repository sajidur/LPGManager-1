namespace LPGManager.Models
{
    public class PurchaseMaster : BaseEntity
    { 
        public PurchaseMaster()
        {
            PurchaseDetails = new List<PurchaseDetails>();
        }
        public long InvoiceDate { get; set; }
        public string InvoiceNo { get; set; }
        public long SupplierId { get; set; }
        public decimal TotalPrice { get; set; }
        public decimal TotalCommission { get; set; }
        public decimal DueAdvance { get; set; }
        public string PaymentType { get; set; }
        public DateTime ReceiveDate { get; set; }
        public string ReceiveBy { get; set; }
        public string OrderBy { get; set; }
        public string? Notes { get; set; }
        public List<PurchaseDetails> PurchaseDetails { get; set; }
    }
}
