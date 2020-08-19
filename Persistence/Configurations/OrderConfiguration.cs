using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using firstDemo.Persistence.Entities;

namespace firstDemo.Persistence.Configurations
{
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            //Table
            builder.ToTable(nameof(Order), "order");
            // Primary Key
            builder.HasKey(u => u.Id);

            // Configure columns
            builder.Property(e => e.Id).ValueGeneratedOnAdd();

            builder.Property(e => e.Description).IsRequired().HasMaxLength(500);
            builder.Property(e => e.OrderStatusId).IsRequired();

            builder.HasAlternateKey(x => x.OrderNumber);
            builder.Property(e => e.OrderNumber).IsRequired().ValueGeneratedOnAdd();

            // Rel

            builder
            .HasOne(c => c.OrderStatus)
            .WithMany(c => c.Orders)
            .HasForeignKey(c => c.OrderStatusId)
            .OnDelete(DeleteBehavior.Restrict);
        }
    }
}