namespace LPGManager.Models
{
    public class SellMaster : BaseEntity
    {
        public string InvoiceNo { get; set; }
        public long InvoiceDate { get; set; }
        public long CustomerId { get; set; }
        public decimal TotalPrice { get; set; }
        public decimal Discount { get; set; }
        public decimal TotalPaid { get; set; }
        public decimal TotalDue { get; set; }
        public decimal DueAdvance { get; set; }
        public string PaymentType { get; set; }
        public string? Notes { get; set; }
        public long DeliveryDate { get; set; }
        public string ReceiveBy { get; set; }
        public string OrderBy { get; set; }
        public string DeliveryStatus { get; set; }
        public CustomerEntity Customer { get; set; }
        public List<SellDetails> SellsDetails { get; set; }
        public string DeliveryBy { get; set; }
    }
}
