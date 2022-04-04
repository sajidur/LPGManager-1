using System.ComponentModel.DataAnnotations;

namespace LPGManager.Dtos
{
    public class PurchaseDetailsDtos: BaseDtos
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please provide valid CompanyId")]
        public int CompanyId { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please provide valid ProductName")]
        public string ProductName { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please provide valid Size")]
        public string Size { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please provide valid ProductType")]
        public string ProductType { get; set; }
        public decimal Commission { get; set; }
        public decimal Price { get; set; }
        public decimal Quantity { get; set; }
        public decimal OpeningQuantity { get; set; }
        public decimal ReceivingQuantity { get; set; }
        public decimal ReturnQuantity { get; set; }
        public decimal DamageQuantity { get; set; }
        public decimal SaleQuantity { get; set; }
        public int PurchaseMasterId { get; set; }
        public CompanyDtos? Company { get; set; }

    }
}
