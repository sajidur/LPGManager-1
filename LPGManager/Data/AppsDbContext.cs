using LPGManager.Models;
using LPGManager.Models.Settings;

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
        public DbSet<Inventory> Inventories { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<User> Users { get; set; }

        public DbSet<Product> Products { get; set; }
        public DbSet<ProductType> ProductTypes { get; set; }
        public DbSet<Size> Sizes { get; set; }
        public DbSet<Warehouse> Warehouses { get; set; }
        public DbSet<Exchange> Exchanges { get; set; }
        public DbSet<CustomerEntity> Customers { get; set; }
        public DbSet<ReturnMaster> ReturnMasters { get; set; }
        public DbSet<ReturnDetails> ReturnDetails { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PurchaseDetails>()
                .HasOne(p => p.PurchaseMaster)
                .WithMany(b => b.PurchaseDetails)
                .HasForeignKey(p => p.PurchaseMasterId);

            modelBuilder.Entity<SellDetails>()
                .HasOne(p => p.SellMaster)
                .WithMany(b => b.SellsDetails)
                .HasForeignKey(p => p.SellMasterId);

            modelBuilder.Entity<ReturnDetails>()
                .HasOne(p => p.ReturnMaster)
                .WithMany(b => b.ReturnDetails)
                .HasForeignKey(p => p.ReturnMasterId);
            modelBuilder.Entity<Exchange>()
                .HasOne<Company>()
                .WithMany()
                .HasForeignKey(p => p.ComapnyId);

        }
        
    }
}
