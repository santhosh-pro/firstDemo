using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using firstDemo.Persistence.Entities;

namespace firstDemo.Persistence.Configurations
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            //Table
            builder.ToTable(nameof(Category), "product");
            // Primary Key
            builder.HasKey(u => u.Id);
            

            // Configure columns
            builder.Property(e => e.Id).ValueGeneratedOnAdd();

            builder.Property(x=>x.Name).IsRequired().HasMaxLength(50);
            builder.Property(x=>x.Description).IsRequired(false).HasMaxLength(500);
        }
    }
}