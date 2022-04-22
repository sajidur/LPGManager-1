using System.Text.Json.Serialization;

namespace LPGManager.Models
{
    public class PurchaseDetails : BaseEntity
    {        
        public long CompanyId { get; set; }        
        public string ProductName { get; set; }        
        public string Size { get; set; }        
        public string ProductType { get; set; }   
        public decimal Commission { get; set; }
        public decimal Price { get; set; }        
        public decimal Quantity { get; set; }        
        public decimal OpeningQuantity { get; set; }        
        public decimal ReceivingQuantity { get; set; }        
        public decimal ReturnQuantity { get; set; }        
        public decimal DamageQuantity { get; set; }        
        public decimal SaleQuantity { get; set; }
        public decimal SupportQty { get; set; }
        public long PurchaseMasterId { get; set; }
        [JsonIgnore]
        public Company Company { get; set; }

        [JsonIgnore]
        public PurchaseMaster PurchaseMaster { get; set; }


    }
}
