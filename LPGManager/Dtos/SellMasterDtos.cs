using LPGManager.Models;
using System.ComponentModel.DataAnnotations;

namespace LPGManager.Dtos
{
    public class SellMasterDtos : BaseDtos
    {
        public string? InvoiceNo { get; set; }
        public long InvoiceDate { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please provide valid Customer Id")]
        public long CustomerId { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please provide TotalPrice")]
        public decimal TotalPrice { get; set; }
        public decimal TotalPaid { get; set; }
        public decimal TotalDue { get; set; }
        public decimal Discount { get; set; }
        public decimal DueAdvance { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please provide valid PaymentType")]
        public string PaymentType { get; set; }
        public long DeliveryDate { get; set; }
        public string DeliveryStatus { get; set; }
        public long DeliveryConfirmationDate { get; set; }
        public string DeliveryBy { get; set; }
        public string? ReceiveBy { get; set; }
        public string? OrderBy { get; set; }
        public int SellRequisitionMasterId { get; set; }
        public string? Notes { get; set; }
        public List<SellDetailsDtos> SellsDetails { get; set; }
        public CustomerDto? Customer { get; set; }
        public ReturnMasterDtos? ReturnMaster {get;set;}

    }
}
