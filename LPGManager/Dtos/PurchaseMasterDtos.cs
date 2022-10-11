using System.ComponentModel.DataAnnotations;

namespace LPGManager.Dtos
{
    public class PurchaseMasterDtos:BaseDtos
    {
        public string? InvoiceNo { get; set; }
        public long InvoiceDate { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please provide valid SupplierId")]
        public int SupplierId { get; set; }
        public SupplierDtos? Supplier { get; set; }
        public decimal TotalPrice { get; set; }
        public decimal TotalCommission { get; set; }
        public decimal DueAdvance { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please provide valid PaymentType")]
        public string PaymentType { get; set; }
        public long ReceiveDate { get; set; }
        public string? ReceiveBy { get; set; }
        public string? OrderBy { get; set; }
        public string? Notes { get; set; }
        public List<PurchaseDetailsDtos> PurchaseDetails { get; set; }

    }
}
