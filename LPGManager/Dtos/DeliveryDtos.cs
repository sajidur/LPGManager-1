namespace LPGManager.Dtos
{
    public class DeliveryDtos
    {
        public int SellmasterId { get; set; }
        public long DeliveryDate { get; set; }
        public string DeliveryBy { get; set; }
        public string? ReceiveBy { get; set; }
    }
}
