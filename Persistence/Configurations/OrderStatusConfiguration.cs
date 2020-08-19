using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using firstDemo.Persistence.Entities;

namespace firstDemo.Persistence.Configurations
{
    public class OrderStatusConfiguration : IEntityTypeConfiguration<OrderStatus>
    {
        public void Configure(EntityTypeBuilder<OrderStatus> builder)
        {
            //Table
            builder.ToTable(nameof(OrderStatus), "order");
            // Primary Key
            builder.HasKey(u => u.Id);

            // Configure columns
            builder.Property(e => e.Id).ValueGeneratedOnAdd();

            builder.Property(e => e.Name).IsRequired().HasMaxLength(50);

            // Has Default Data

            builder.HasData(new OrderStatus
            {
                Id = 1,
                Name = "Created"
            });

            builder.HasData(new OrderStatus
            {
                Id = 2,
                Name = "Packing"
            });

            builder.HasData(new OrderStatus
            {
                Id = 3,
                Name = "Shipping"
            });

            builder.HasData(new OrderStatus
            {
                Id = 4,
                Name = "Delivered"
            });

        }
    }
}