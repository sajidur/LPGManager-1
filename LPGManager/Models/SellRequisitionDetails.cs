using System.Text.Json.Serialization;

namespace LPGManager.Models
{
    public class SellRequisitionDetails : BaseEntity
    {

        //public int SupplierId { get; set; }
        //
        public long CompanyId { get; set; }
        public string ProductName { get; set; }
        public string Size { get; set; }
        public string? ProductType { get; set; }
        public decimal Price { get; set; }
        public decimal Quantity { get; set; }
        public decimal FilledQuantity { get; set; }
        public long SellRequisitionMasterId { get; set; }
        [JsonIgnore]
        public Company? Company { get; set; }
        [JsonIgnore]
        public SellRequisitionMaster? SellRequisitionMaster { get; set; }
    }
}
