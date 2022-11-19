using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace LPGManager.Dtos
{
    public class ReturnMasterDtos : BaseDtos
    {
        public long SellMasterId { get; set; }
        public string InvoiceNo { get; set; }
        public long CustomerId { get; set; }
        public decimal TotalReturnAmount { get; set; }
        public decimal TotalReturnQty { get; set; }
        public decimal Discount { get; set; }
        public decimal DueAdvance { get; set; }
        public string PaymentType { get; set; }
        public string? Notes { get; set; }
        public List<ReturnDetailsDto> ReturnDetails { get; set; }
    }
    public class ReturnDetailsDto:BaseDtos
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
        public long SellMasterId { get; set; }
        public long ReturnMasterId { get; set; }
        public CompanyDtos? Company { get; set; }
        [JsonIgnore]
        public ReturnMasterDtos? ReturnMaster { get; set; }
    }
}
