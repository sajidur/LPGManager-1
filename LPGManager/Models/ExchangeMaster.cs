using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace LPGManager.Models
{
    public class ExchangeMaster:BaseEntity
    {
        public long InvoiceDate { get; set; }
        public string InvoiceNo { get; set; }
        public long SupplierId { get; set; }
        public decimal TotalPricePaid { get; set; }
        public decimal TotalPriceReceive { get; set; }
        public string PaymentType { get; set; }
        public string? Notes { get; set; }
        [NotMapped]
        public List<ExchangeDetails> MyProductDetails { get; set; }
        [NotMapped]
        public List<ExchangeDetails> ReceiveProductDetails { get; set; }

    }
    public class ExchangeDetails : BaseEntity
    {
        public long CompanyId { get; set; }
        public string ProductName { get; set; }
        public string Size { get; set; }
        public string ProductType { get; set; }
        public decimal PaidAmount { get; set; }
        public decimal Quantity { get; set; }
        public long ExchangeMasterId { get; set; }
        public int ExchangeType { get; set; }//1 for my product 2 for receive product

        [JsonIgnore]
        public Company Company { get; set; }

        [NotMapped]
        public ExchangeMaster ExchangeMaster { get; set; }
    }
}
