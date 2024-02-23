
using ExcelBD_API.Services;

namespace ExcelBD_API.HostedServices
{
    public class DbMigrationAndSeederHostedService (IServiceProvider serviceProvider) : IHostedService
    {
        //private readonly IServiceProvider serviceProvider;
        //public DbMigrationAndSeederHostedService(IServiceProvider serviceProvider)
        //{
        //    this.serviceProvider = serviceProvider;
        //}

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            using var scope = serviceProvider.CreateScope();
            var seeder = scope.ServiceProvider.GetRequiredService<DbMigrationAndSeederService>();
            await seeder.MigrateAsync();
            await seeder.SeedAsync();
        }

        public Task StopAsync(CancellationToken cancellationToken) => Task.CompletedTask;
    }
}

