using FluentMigrator.Runner;
using PocFluentMigration.Infrastructure.Database.Migrations;

namespace PocFluentMigration.Infrastructure.Database.Extensions
{
    public static class MigrationManager
    {
        public static IHost MigrateDatabase(this IHost host)
        {
            using (var scope = host.Services.CreateScope())
            {
                var databaseManager = scope.ServiceProvider.GetRequiredService<DatabaseManager>();
                var migrationRunner = scope.ServiceProvider.GetRequiredService<IMigrationRunner>();

                databaseManager.CreateDatabase("BrazilianCities");

                migrationRunner.ListMigrations();
                migrationRunner.MigrateUp();
            }

            return host;
        }
    }
}