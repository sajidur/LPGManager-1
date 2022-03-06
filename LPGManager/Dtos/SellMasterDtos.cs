namespace LPGManager.Dtos
{
    public class SellMasterDtos
    {
        public int Id { get; set; }
        public int TotalPrice { get; set; }
        public int? Discount { get; set; }
        public int? DueAdvance { get; set; }
        public int? PaymentType { get; set; }
        public string? Notes { get; set; }
    }
}
