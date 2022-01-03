using AspNet6Lite.AppData.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AspNet6Lite.AppData.Configuration
{
    public class CountryConfig : IEntityTypeConfiguration<CountryEntity>
    {
        public void Configure(EntityTypeBuilder<CountryEntity> builder)
        {
            builder.ToTable("Countries");
            builder.HasKey(k => k.Id);
            builder.HasIndex(k => k.Name).IsUnique(true);
            builder.Property(p => p.Name).IsRequired(true).HasMaxLength(255);            
            builder.Property(p => p.Created).IsRequired(true);
        }
    }
}
