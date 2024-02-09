using DevDanApi.Infrastructure.Data;
using DevDanApi.Infrastructure.HostedServices;
using Microsoft.EntityFrameworkCore;

namespace DevDanApi.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<AppDbContext>(options =>
                   options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

        services.AddHostedService<DatabaseMigrationService>();
        return services;
    }
}