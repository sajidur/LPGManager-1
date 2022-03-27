namespace LPGManager.Dtos
{
    public class PurchaseMasterDtos
    {
        public int Id { get; set; }
        public int TotalPrice { get; set; }
        public int? TotalCommission { get; set; }
        public int? DueAdvance { get; set; }
        public int? PaymentType { get; set; }
        public string? Notes { get; set; }
        public int SupplierId { get; set; }
    }
}
