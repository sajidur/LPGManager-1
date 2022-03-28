namespace LPGManager.Dtos
{
    public class PurchaseMasterDtos:BaseDtos
    {
        public int SupplierId { get; set; }
        public decimal TotalPrice { get; set; }
        public decimal TotalCommission { get; set; }
        public decimal DueAdvance { get; set; }
        public string PaymentType { get; set; }
        public string? Notes { get; set; }
        public List<PurchaseDetailsDtos> PurchaseDetails { get; set; }
    }
}
