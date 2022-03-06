using LPGManager.Models;

using Microsoft.EntityFrameworkCore;

namespace LPGManager.Data
{
    public class AppsDbContext : DbContext
    {
        public AppsDbContext(DbContextOptions<AppsDbContext> options)
            : base(options)
        {
        }

        public DbSet<PurchaseDetails> PurchasesDetails { get; set; }
        public DbSet<PurchaseMaster> PurchaseMasters { get; set; }
        public DbSet<Sell> Sells { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PurchaseDetails>()
                .HasOne(p => p.PurchaseMaster)
                .WithMany(b => b.PurchasesDetails)
                .HasForeignKey(p => p.PurchaseMasterId);   
        }
        
    }
}
