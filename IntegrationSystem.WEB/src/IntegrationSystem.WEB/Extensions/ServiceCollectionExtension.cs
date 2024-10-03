using IntegrationSystem.DataAccess.Configurations;

namespace IntegrationSystem.WEB.Extensions;

/// <summary>
/// Provides extension methods for configuring services in the <see cref="IServiceCollection"/>.
/// </summary>
public static class ServiceCollectionExtension
{
    /// <summary>
    /// Configures and adds the data access services to the specified <see cref="IServiceCollection"/>.
    /// </summary>
    /// <param name="services">The service collection to which data access services are added.</param>
    /// <param name="configuration">The configuration that contains the connection string.</param>
    /// <exception cref="ArgumentNullException">
    /// Thrown when the connection string is not defined in the configuration.
    /// </exception>
    /// <remarks>
    /// This method retrieves the connection string for the database from the configuration
    /// and uses it to register the <see cref="DataContext"/> with the dependency injection container.
    /// </remarks>
    public static void AddDataAccess(this IServiceCollection services, IConfiguration configuration)
    {
        string connectionString = configuration.GetConnectionString("IntegrationSystemDb")
            ?? throw new ArgumentNullException(nameof(connectionString), "Connection string is not defined");

        services.AddDataContext(connectionString);
    }
}
