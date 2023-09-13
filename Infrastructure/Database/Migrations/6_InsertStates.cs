using FluentMigrator;
using PocFluentMigration.Infrastructure.Database.Migrations.Seeds;

namespace PocFluentMigration.Infrastructure.Database.Migrations
{
    [Migration(6)]
    public class InsertStates : Migration
    {
        public override void Down() {}

        public override void Up()
        {
            var states = BrazilianStates();

            foreach (var state in states)
            {
                Insert.IntoTable("States").Row(state);
            }
        }

        private static IEnumerable<State> BrazilianStates()
        {
            var countryId = 1;

            return new List<State>
            {
                new() { Id = 1, Name = "Acre", Acronym = "AC", CountryId = countryId },
                new() { Id = 2, Name = "Alagoas", Acronym = "AL", CountryId = countryId },
                new() { Id = 3, Name = "Amapá", Acronym = "AP", CountryId = countryId },
                new() { Id = 4, Name = "Amazonas", Acronym = "AM", CountryId = countryId },
                new() { Id = 5, Name = "Bahia", Acronym = "BA", CountryId = countryId },
                new() { Id = 6, Name = "Ceará", Acronym = "CE", CountryId = countryId },
                new() { Id = 7, Name = "Espírito Santo", Acronym = "ES", CountryId = countryId },
                new() { Id = 8, Name = "Goiás", Acronym = "GO", CountryId = countryId },
                new() { Id = 9, Name = "Maranhão", Acronym = "MA", CountryId = countryId },
                new() { Id = 10, Name = "Mato Grosso", Acronym = "MT", CountryId = countryId },
                new() { Id = 11, Name = "Mato Grosso do Sul", Acronym = "MS", CountryId = countryId },
                new() { Id = 12, Name = "Minas Gerais", Acronym = "MG", CountryId = countryId },
                new() { Id = 13, Name = "Pará", Acronym = "PA", CountryId = countryId },
                new() { Id = 14, Name = "Paraíba", Acronym = "PB", CountryId = countryId },
                new() { Id = 15, Name = "Paraná", Acronym = "PR", CountryId = countryId },
                new() { Id = 16, Name = "Pernambuco", Acronym = "PE", CountryId = countryId },
                new() { Id = 17, Name = "Piauí", Acronym = "PI", CountryId = countryId },
                new() { Id = 18, Name = "Rio de Janeiro", Acronym = "RJ", CountryId = countryId },
                new() { Id = 19, Name = "Rio Grande do Norte", Acronym = "RN", CountryId = countryId },
                new() { Id = 20, Name = "Rio Grande do Sul", Acronym = "RS", CountryId = countryId },
                new() { Id = 21, Name = "Rondônia", Acronym = "RO", CountryId = countryId },
                new() { Id = 22, Name = "Roraima", Acronym = "RR", CountryId = countryId },
                new() { Id = 23, Name = "Santa Catarina", Acronym = "SC", CountryId = countryId },
                new() { Id = 24, Name = "São Paulo", Acronym = "SP", CountryId = countryId },
                new() { Id = 25, Name = "Sergipe", Acronym = "SE", CountryId = countryId },
                new() { Id = 26, Name = "Tocantins", Acronym = "TO", CountryId = countryId }
            };
        }
    }
}