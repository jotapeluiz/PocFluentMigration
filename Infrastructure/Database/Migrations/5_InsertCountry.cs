using FluentMigrator;
using PocFluentMigration.Infrastructure.Database.Migrations.Seeds;

namespace PocFluentMigration.Infrastructure.Database.Migrations
{
    [Migration(5)]
    public class InsertCountry : Migration
    {
        public override void Down() {}

        public override void Up()
        {
            Country country = new() { Id = 1, Name = "Brasil" };

            Insert.IntoTable("Countries").Row(country);
        }
    }
}