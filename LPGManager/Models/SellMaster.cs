namespace LPGManager.Models
{
    public class SellMaster : BaseEntity
    {
        public string InvoiceNo { get; set; }
        public long InvoiceDate { get; set; }
        public long CustomerId { get; set; }
        public decimal TotalPrice { get; set; }
        public decimal Discount { get; set; }
        public decimal DueAdvance { get; set; }
        public string PaymentType { get; set; }
        public string? Notes { get; set; }
        public DateTime DeliveryDate { get; set; }
        public int OrderId { get; set; }
        public CustomerEntity Customer { get; set; }
        public List<SellDetails> SellsDetails { get; set; }
    }
}
