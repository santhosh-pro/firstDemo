using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using firstDemo.Persistence.Entities;

namespace firstDemo.Persistence.Configurations
{
    public class OrderTrackConfiguration : IEntityTypeConfiguration<OrderTrack>
    {
        public void Configure(EntityTypeBuilder<OrderTrack> builder)
        {
            //Table
            builder.ToTable(nameof(OrderTrack), "order");
            // Primary Key
            builder.HasKey(u => u.Id);

            // Configure columns
            builder.Property(e => e.Id).ValueGeneratedOnAdd();

            builder.Property(e => e.OrderId).IsRequired();
            builder.Property(e => e.TrackingDate).IsRequired();
            builder.Property(e => e.OrderStatusId).IsRequired();

            // Rel

            builder
            .HasOne(c => c.Order)
            .WithMany(c => c.OrderTracks)
            .HasForeignKey(c => c.OrderId)
            .OnDelete(DeleteBehavior.Cascade);

            builder
            .HasOne(c => c.OrderStatus)
            .WithMany(c => c.OrderTracks)
            .HasForeignKey(c => c.OrderStatusId)
            .OnDelete(DeleteBehavior.Restrict);
        }
    }
}