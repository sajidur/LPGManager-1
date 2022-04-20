using System.Text.Json.Serialization;

namespace LPGManager.Models
{
    public class ReturnMaster:BaseEntity
    {
        public long SellMasterId { get; set; }
        public string InvoiceNo { get; set; }
        public long CustomerId { get; set; }
        public decimal TotalReturnAmount { get; set; }
        public decimal Discount { get; set; }
        public decimal DueAdvance { get; set; }
        public string PaymentType { get; set; }
        public string? Notes { get; set; }
        public List<ReturnDetails> ReturnDetails { get; set; }
    }
    public class ReturnDetails:BaseEntity
    {
        public long CompanyId { get; set; }
        public string ProductName { get; set; }
        public string Size { get; set; }
        public string? ProductType { get; set; }
        public decimal Price { get; set; }
        public decimal Discount { get; set; }
        public decimal Quantity { get; set; }
        public decimal OpeningQuantity { get; set; }
        public decimal ReceivingQuantity { get; set; }
        public decimal ReturnQuantity { get; set; }
        public decimal DamageQuantity { get; set; }
        public long ReturnMasterId { get; set; }
        public long SellMasterId { get; set; }

        public Company Company { get; set; }
        [JsonIgnore]
        public ReturnMaster ReturnMaster { get; set; }
    }
}
