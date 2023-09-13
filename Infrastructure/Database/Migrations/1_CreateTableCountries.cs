using FluentMigrator;

namespace PocFluentMigration.Infrastructure.Database.Migrations
{
    [Migration(1)]
    public class CreateTableCountries : Migration
    {
        private readonly string _tableName = "Countries";

        public override void Down()
        {
            Delete.Table(_tableName);
        }

        public override void Up()
        {
            Create.Table(_tableName)
                .WithColumn("Id").AsInt32().NotNullable().PrimaryKey()
                .WithColumn("Name").AsString().NotNullable().Unique();
        }
    }
}