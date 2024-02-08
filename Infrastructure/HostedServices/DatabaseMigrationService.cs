
using DevDanApi.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace DevDanApi.Infrastructure.HostedServices;

public class DatabaseMigrationService(
    IServiceScopeFactory serviceScopeFactory,
    ILogger<DatabaseMigrationService> logger) : IHostedService
{
    private readonly IServiceScopeFactory _serviceScopeFactory = serviceScopeFactory;
    private readonly ILogger<DatabaseMigrationService> _logger = logger;

    public async Task StartAsync(CancellationToken cancellationToken)
    {
        try
        {
            await using AsyncServiceScope scope = _serviceScopeFactory.CreateAsyncScope();
            var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();

            var hasPendingMigrations = context.Database.GetPendingMigrations();
            if (hasPendingMigrations is not null && hasPendingMigrations.Any())
            {
                await context.Database.MigrateAsync(cancellationToken);
            }
        }
        catch (Exception expection)
        {
            _logger.LogError(default, expection);
            throw;
        }
    }
    public Task StopAsync(CancellationToken cancellationToken)
    {
        return Task.CompletedTask;
    }
}
