namespace PocFluentMigration.Infrastructure.Database.Migrations.Seeds
{
    public struct State
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Acronym { get; set; }

        public int CountryId { get; set; }
    }
}