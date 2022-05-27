namespace LPGManager.Models
{
    public class CustomerDealerMapping:BaseEntity
    {
        public long CustomerId { get; set; }
        public long RefCustomerId { get; set; }
        public int CustomerType { get; set; }

    }
}
