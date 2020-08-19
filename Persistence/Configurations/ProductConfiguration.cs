using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using firstDemo.Persistence.Entities;

namespace firstDemo.Persistence.Configurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            //Table
            builder.ToTable(nameof(Product), "product");
            // Primary Key
            builder.HasKey(u => u.Id);

            // Configure columns
            builder.Property(e => e.Id).ValueGeneratedOnAdd();

            builder.Property(e=>e.Name).IsRequired().HasMaxLength(50);
            builder.Property(e=>e.CategoryId).IsRequired().HasMaxLength(500);
            builder.Property(e=>e.Price).IsRequired();

            // Rel

            builder
            .HasOne (c => c.Category)
            .WithMany (c => c.Products)
            .HasForeignKey (c => c.CategoryId)
            .OnDelete (DeleteBehavior.Restrict);
            
        }
    }
}