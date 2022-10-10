namespace LPGManager.Models
{
    public class SellRequisitionMaster : BaseEntity
    {
        public string InvoiceNo { get; set; }
        public long InvoiceDate { get; set; }
        public long CustomerId { get; set; }
        public decimal TotalPrice { get; set; }
        public decimal Discount { get; set; }
        public string? Notes { get; set; }
        public CustomerEntity? Customer { get; set; }
        public List<SellRequisitionDetails> SellRequisitionDetails { get; set; }
    }
}
