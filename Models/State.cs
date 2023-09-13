using Dapper.Contrib.Extensions;

namespace PocFluentMigration.Models
{
    public class State
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public string Acronym { get; set; } = string.Empty;

        public int CountryId { get; set; }

        [Computed]
        public Country? Country { get; set; }
    }
}