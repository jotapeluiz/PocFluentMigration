using FluentMigrator;

namespace PocFluentMigration.Infrastructure.Database.Migrations
{
    [Migration(3)]
    public class CreateTableCities : Migration
    {
        private readonly string _tableName = "Cities";

        public override void Down()
        {
            Delete.Table(_tableName);
        }

        public override void Up()
        {
            Create.Table(_tableName)
                .WithColumn("Id").AsInt32().NotNullable().PrimaryKey()
                .WithColumn("Name").AsString().NotNullable().Unique()
                .WithColumn("StateId").AsInt32().NotNullable().ForeignKey("States", "Id");
        }
    }
}