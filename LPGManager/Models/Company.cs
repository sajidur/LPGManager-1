namespace LPGManager.Models
{
    public class Company:BaseEntity
    {
        public string? Image { get; set; }
        public string CompanyName { get; set; }
        public string? Address { get; set; }
        public int? Phone { get; set; }
        public int? CompanyType { get; set; }
        public DateTime CreatedOn { get; set; }
    }
}
