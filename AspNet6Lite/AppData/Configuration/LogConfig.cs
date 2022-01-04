using AspNet6Lite.AppData.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AspNet6Lite.AppData.Configuration
{
    public class LogConfig : IEntityTypeConfiguration<LogEntity>
    {
        public void Configure(EntityTypeBuilder<LogEntity> builder)
        {
            builder.ToTable("Logs");
            // builder.HasKey(k => k.Id);
            builder.HasIndex(k => k.Guid).IsUnique(true);
            builder.Property(p => p.LogType).IsRequired(true);
            builder.Property(p => p.LogMessage).IsRequired(true);
            builder.Property(p => p.Created).IsRequired(true);
        }
    }
}
