using CleanArchitecture.Core.Domain.Sales;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CleanArchitecture.Core.Persistence.Sales
{
    public class SaleConfiguration : IEntityTypeConfiguration<Sale>
    {
        public void Configure(EntityTypeBuilder<Sale> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Date)
                .IsRequired();
            
            builder.HasOne(p => p.Customer);

            builder.HasOne(p => p.Employee);

            builder.HasOne(p => p.Product);
            
            builder.Property(p => p.TotalPrice)
                .HasColumnType("decimal(5,2)")
                .IsRequired();
        }
    }
}