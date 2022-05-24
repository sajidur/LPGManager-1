namespace LPGManager.Models
{
    public class Tenant
    {
        public Tenant()
        {
            CreatedDate = DateTime.SpecifyKind(DateTime.Now, DateTimeKind.Utc);
            UpdatedDate = DateTime.SpecifyKind(DateTime.Now, DateTimeKind.Utc);
            IsActive = 1;
        }
        public string TenantName { get; set; }
        public string? Image { get; set; }
        public string? Address { get; set; }
        public string? Phone { get; set; }
        public int Tenanttype { get; set; } //1 for supplier/dealer
        public long Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public long CreatedBy { get; set; }
        public long UpdatedBy { get; set; }
        public int IsActive { get; set; }
    }
}
