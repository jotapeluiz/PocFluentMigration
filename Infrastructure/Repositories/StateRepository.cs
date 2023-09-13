using System.Data;
using Dapper;
using Infrastructure.Database.Context;
using PocFluentMigration.Models;

namespace PocFluentMigration.Infrastructure.Repositories
{
    public class StateRepository : IStateRepository
    {
        private readonly IDbConnection _connection;

        public StateRepository(DapperContext dapperContext)
        {
            _connection = dapperContext.CreateSqlConnection();
        }

        public IEnumerable<State> All()
        {
            var query = @"
                SELECT
                    s.Id,
                    s.Name,
                    s.Acronym,
                    s.CountryId,
                    c.Id,
                    c.Name
                FROM states s
                INNER JOIN countries c ON c.Id = s.CountryId;";

            var states = _connection.Query<State, Country, State>(
                query,
                (state, country) =>
                {
                    state.Country = country;
                    return state;
                },
                splitOn: "CountryId"
            );

            return states;
        }
    }
}