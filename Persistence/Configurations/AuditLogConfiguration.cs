using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using firstDemo.Common;

namespace firstDemo.Persistence.Configurations
{
    public class AuditLogConfiguration: IEntityTypeConfiguration<AuditLog>
    {
         public void Configure(EntityTypeBuilder<AuditLog> builder)
        {
             //Table
            builder.ToTable(nameof(AuditLog),"audit");
            // Primary Key
            builder.HasKey(u => u.Id);

            // Configure columns
            builder.Property(e => e.Id).ValueGeneratedOnAdd();
          

            
        }
    }
}