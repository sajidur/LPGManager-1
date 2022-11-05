namespace LPGManager.Dtos
{
    public class LedgerPostingDtos:BaseDtos
    {
        public long PostingDate { get; set; }
        public int VoucherTypeId { get; set; }
        public string VoucherNo { get; set; }
        public long LedgerId { get; set; }
        public decimal Debit { get; set; }
        public decimal Credit { get; set; }
        public decimal Balance { get; set; }
        public string ChequeNo { get; set; }
        public long ChequeDate { get; set; }
        public int PaymentType { get; set; } //1=cash 2=cheque //3=adjust
        public int TransactionType { get; set; } //1 sell, 1=receive, 3=purchase, 4=payment 
        public long ReferanceId { get; set; } //sell , purchase table id
        public string ReferanceInvoiceNo { get; set; } //sell purchase id
        public string Notes { get; set; }
    }
}
