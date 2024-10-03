using IntegrationSystem.DataAccess.Configurations;
using IntegrationSystem.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace IntegrationSystem.DataAccess.DbContexts;

/// <summary>
/// Represents the database context for the Integration System.
/// </summary>
public class DataContext: DbContext
{
    public DbSet<Employee> Employees { get; set; }

    /// <summary>
    /// Initializes a new instance of the <see cref="DataContext"/> class with the provided options.
    /// </summary>
    /// <param name="options">The options for configuring the database context.</param>
    public DataContext(DbContextOptions<DataContext> options)
            : base(options)
    {

    }

    /// <inheritdoc/>
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);

        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseSqlServer("IntegrationSystem");
        }
    }

    /// <inheritdoc/>
    protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
    {
        base.ConfigureConventions(configurationBuilder);
        configurationBuilder.Properties<DateOnly>()
            .HaveConversion<DateOnlyConverter>();
    }
}