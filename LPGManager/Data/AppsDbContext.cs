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
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<SellDetails> SellsDetails { get; set; }
        public DbSet<SellMaster> SellMasters { get; set; }
        public DbSet<Company> Companies { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PurchaseDetails>()
                .HasOne(p => p.PurchaseMaster)
                .WithMany(b => b.PurchasesDetails)
                .HasForeignKey(p => p.PurchaseMasterId);

            modelBuilder.Entity<SellDetails>()
                .HasOne(p => p.SellMaster)
                .WithMany(b => b.SellsDetails)
                .HasForeignKey(p => p.SellMasterId);

            modelBuilder.Entity<PurchaseDetails>()
                .HasOne<Supplier>()
                .WithMany()
                .HasForeignKey(p => p.SupplierId);

            modelBuilder.Entity<PurchaseMaster>()
                .HasOne<Supplier>()
                .WithMany()
                .HasForeignKey(p => p.SupplierId);
        }
        
    }
}
