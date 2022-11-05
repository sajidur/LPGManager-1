namespace LPGManager.Dtos
{
    public class DueReceiveDtos
    {
        public long SalesMasterId { get; set; }
        public string InvoiceNo { get; set; }
        public decimal PaidAmount { get; set; }
        public long PostingDate { get; set; }
        public string Notes { get; set; }
    }
}
