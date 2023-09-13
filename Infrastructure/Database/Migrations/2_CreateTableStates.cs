using FluentMigrator;

namespace PocFluentMigration.Infrastructure.Database.Migrations
{
    [Migration(2)]
    public class CreateTableStates : Migration
    {
        private readonly string _tableName = "States";

        public override void Down()
        {
            Delete.Table(_tableName);
        }

        public override void Up()
        {
            Create.Table(_tableName)
                .WithColumn("Id").AsInt32().NotNullable().PrimaryKey()
                .WithColumn("Name").AsString().NotNullable().Unique()
                .WithColumn("CountryId").AsInt32().NotNullable().ForeignKey("Countries", "Id");
        }
    }
}