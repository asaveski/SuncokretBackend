using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SuncokretBackend.Models;
using System.Net;

namespace SuncokretBackend.DBContexts
{
    public class ParasolDbContext(DbContextOptions<ParasolDbContext> options) : DbContext(options)
    {
        public DbSet<Manufacturer> Manufecturer { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<ProductPromotion> ProductPromotion { get; set; }
        public DbSet<ProductImage> ProductImage { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<CategorizedProduct> CategorizedProduct { get; set; }
        public DbSet<Customer> Customer { get; set; }
        public DbSet<Address> Address { get; set; }
        public DbSet<Cart> Cart { get; set; }
        public DbSet<OrderedProduct> OrderedProduct { get; set; }
        public DbSet<CartStatus> CartStatus { get; set; }
        public DbSet<Event> Event { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CategorizedProduct>()
                .HasKey(cp => new { cp.ProductID, cp.CategoryID }); // Composite primary key

            modelBuilder.Entity<Event>()
                .HasOne(e => e.Manufacturer)
                .WithMany()
                .HasForeignKey(e => e.ManufacturerID)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Cart>()
                .HasOne(c => c.Customer)
                .WithMany()
                .HasForeignKey(c => c.CustomerID)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
