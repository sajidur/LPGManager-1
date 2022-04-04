using System.ComponentModel.DataAnnotations;

namespace LPGManager.Dtos
{
    public class SellMasterDtos:BaseDtos
    {
        public string InvoiceNo { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please provide valid Customer Id")]
        public long CustomerId { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please provide TotalPrice")]
        public decimal TotalPrice { get; set; }
        public decimal Discount { get; set; }
        public decimal DueAdvance { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please provide valid PaymentType")]
        public string PaymentType { get; set; }
        public string Notes { get; set; }
        public List<SellDetailsDtos> SellsDetails { get; set; }


    }
}
