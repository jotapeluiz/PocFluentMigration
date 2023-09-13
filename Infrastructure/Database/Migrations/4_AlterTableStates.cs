using FluentMigrator;

namespace PocFluentMigration.Infrastructure.Database.Migrations
{
    [Migration(4)]
    public class AlterTableStates : Migration
    {
        public override void Down() {}

        public override void Up()
        {
            Alter.Table("States")
                .AddColumn("Acronym").AsString(2).NotNullable().Unique();
        }
    }
}