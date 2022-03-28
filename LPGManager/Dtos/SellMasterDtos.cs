namespace LPGManager.Dtos
{
    public class SellMasterDtos:BaseDtos
    {
        public decimal TotalPrice { get; set; }
        public decimal Discount { get; set; }
        public decimal DueAdvance { get; set; }
        public int PaymentType { get; set; }
        public string Notes { get; set; }
    }
}
