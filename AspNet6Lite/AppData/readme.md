# EFCore Summary

## Install dotnet ef CLI tools
``` bash
dotnet tool install --global dotnet-ef
dotnet tool update --global dotnet-ef
```

## Install dotnet ef providers

**This package should be installed to the project containing the DbContext**  
``` bash
PM> Install-Package Microsoft.EntityFrameworkCore.Sqlite
```

**This package should be installed to the startup project**  
``` bash
PM> Install-Package Microsoft.EntityFrameworkCore.Design
```

*Note: Rebuild the in Visual Studio after installing the Microsoft.EntityFrameworkCore.Design package*

After setting up cli tools and providers, create DbContext and DbSets.

## Migration

**Create migrations and update database:**  
``` bash
dotnet ef migrations add InitialCreate -p <ProjectHavingDbContext> -s <StartupProject> -o AppData/Migrations
dotnet ef database update -p <ProjectHavingDbContext> -s <StartupProject>
dotnet ef database drop -p <ProjectHavingDbContext> -s <StartupProject>
dotnet ef migrations remove -p <ProjectHavingDbContext> -s <StartupProject>

# Open dotnetcli (right click project file and select open in terminal)
dotnet ef migrations add InitialCreate -o AppData/Migrations
dotnet ef database update
```

## Configuration

``` csharp
public class QuestionAnswerConfig : IEntityTypeConfiguration<QuestionAnswer>
{
    public void Configure(EntityTypeBuilder<QuestionAnswer> builder)
    {
      builder
        .HasKey(bc => new { bc.QuestionId, bc.AnswerId });// compound PK
      builder
        .HasOne(bc => bc.Question)
        .WithMany(b => b.QuestionAnswers)
        .HasForeignKey(bc => bc.QuestionId);
      builder
        .HasOne(bc => bc.Answer)
        .WithMany(c => c.QuestionAnswers)
        .HasForeignKey(bc => bc.AnswerId);
        builder.Property(x => x.Name).HasColumnName("varchar_name");
    }
}


// Applying all configurations
modelBuilder.ApplyConfiguration(new StudentMapper());

// Appliyin specific configurations:
var mapper = Activator.CreateInstance(mappingType);
mapper.GetType().GetMethod("Configure").Invoke(mapper, new[] { entityBuilder });
```   