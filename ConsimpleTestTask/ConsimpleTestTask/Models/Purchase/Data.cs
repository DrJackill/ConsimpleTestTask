using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ConsimpleTestTask.Models.Purchase
{
    public class PurchaseTypeConfiguration : IEntityTypeConfiguration<Purchase>
    {
        public void Configure(EntityTypeBuilder<Purchase> builder)
        {
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id).ValueGeneratedOnAdd();
            builder.Property(e => e.Date);
            builder.Property(e => e.TotalValue);
            builder.HasOne(e => e.Client);
            builder.OwnsMany(e => e.Positions,
                p => {
                    p.HasKey(e => e.Id);
                    p.Property(e => e.Id).ValueGeneratedOnAdd();
                    p.Property(e => e.ProductNumber);
                    p.HasOne(e => e.Product);
                });
        }
    }
}