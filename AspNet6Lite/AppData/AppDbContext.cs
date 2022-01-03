using AspNet6Lite.AppData.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace AspNet6Lite.AppData
{
    public class AppDbContext: DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlite("Data Source=app.db;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            {   // Default value setting for Created columns
                string defaultCurrentDateSql = this.Database.ProviderName switch
                {
                    "Microsoft.EntityFrameworkCore.SqlServer" => "getutcdate()",
                    "Microsoft.EntityFrameworkCore.Sqlite" => "datetime('now', 'utc')",
                    // https://docs.microsoft.com/tr-tr/ef/core/providers/?tabs=dotnet-core-cli
                    _ => ""
                };

                foreach (var entityType in modelBuilder.Model.GetEntityTypes())
                {
                    var properties = entityType.ClrType.GetProperties().Where(p => p.Name == "Created" && p.PropertyType == typeof(DateTime));

                    foreach (var property in properties)
                    {
                        modelBuilder.Entity(entityType.Name).Property(property.Name).HasDefaultValueSql(defaultCurrentDateSql);
                    }
                }
            }
        }

#pragma warning disable CS8618
        public DbSet<LogEntity> Logs { get; set; }
        public DbSet<CountryEntity> Countries { get; set; }
#pragma warning restore CS8618
    }
}