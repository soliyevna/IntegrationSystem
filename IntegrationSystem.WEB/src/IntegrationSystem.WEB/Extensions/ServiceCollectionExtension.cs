using IntegrationSystem.DataAccess.Configurations;

namespace IntegrationSystem.WEB.Extensions;

/// <summary>
/// Provides extension methods for configuring services in the <see cref="IServiceCollection"/>.
/// </summary>
public static class ServiceCollectionExtension
{
    public static void AddDataAccess(this IServiceCollection services, IConfiguration configuration)
    {
        string connectionString = configuration.GetConnectionString("IntegrationSystemDb")
            ?? throw new ArgumentNullException(nameof(connectionString), "Connection string is not defined");

        services.AddDataContext(connectionString);
    }
}
