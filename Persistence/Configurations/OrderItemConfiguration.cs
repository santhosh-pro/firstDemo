using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using firstDemo.Persistence.Entities;

namespace firstDemo.Persistence.Configurations
{
    public class OrderItemConfiguration : IEntityTypeConfiguration<OrderItem>
    {
        public void Configure(EntityTypeBuilder<OrderItem> builder)
        {
            //Table
            builder.ToTable(nameof(OrderItem), "order");
            // Primary Key
            builder.HasKey(u => u.Id);

            // Configure columns
            builder.Property(e => e.Id).ValueGeneratedOnAdd();
            builder.Property(e => e.OrderId).IsRequired();
            builder.Property(e => e.ProductId).IsRequired();
            builder.Property(e => e.ProductName).IsRequired().HasMaxLength(50);
            builder.Property(e => e.Quantity).IsRequired();
            builder.Property(e => e.UnitPrice).IsRequired();
            builder.Property(e => e.TotalPrice).IsRequired();

            //rel

            builder
            .HasOne(c => c.Order)
            .WithMany(c => c.OrderItems)
            .HasForeignKey(c => c.OrderId)
            .OnDelete(DeleteBehavior.Cascade);

            builder
            .HasOne(c => c.Product)
            .WithMany(c => c.OrderItems)
            .HasForeignKey(c => c.ProductId)
            .OnDelete(DeleteBehavior.Restrict);
        }
    }
}