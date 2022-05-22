namespace LPGManager.Models
{
    public class Supplier:BaseEntity
    {
        public string SupplierName { get; set; }
        public string? Image { get; set; }
        public string? Address { get; set; }
        public  string? Phone { get; set; }
        public int Companytype { get; set; }
    }
}
