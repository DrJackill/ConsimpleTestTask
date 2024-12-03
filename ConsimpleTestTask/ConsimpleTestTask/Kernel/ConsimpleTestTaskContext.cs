using ConsimpleTestTask.Models.Clients;
using ConsimpleTestTask.Models.Products;
using ConsimpleTestTask.Models.Purchase;
using Microsoft.EntityFrameworkCore;

namespace ConsimpleTestTask.Kernel
{
    public class ConsimpleTestTaskContext : DbContext
    {
        public ConsimpleTestTaskContext(DbContextOptions options)
         : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            new ClientTypeConfiguration().Configure(modelBuilder.Entity<Client>());
            new ProductTypeConfiguration().Configure(modelBuilder.Entity<Product>());
            new PurchaseTypeConfiguration().Configure(modelBuilder.Entity<Purchase>());
        }
    }
}