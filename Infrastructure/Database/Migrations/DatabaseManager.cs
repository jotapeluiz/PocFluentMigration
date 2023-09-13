using Dapper;
using Infrastructure.Database.Context;

namespace PocFluentMigration.Infrastructure.Database.Migrations
{
    public class DatabaseManager
    {
        private readonly DapperContext _dapperContext;

        public DatabaseManager(DapperContext dapperContext)
        {
            _dapperContext = dapperContext;
        }

        public void CreateDatabase(string name)
        {
            var query = _dapperContext.CreateQueryDatabase();

            using var connection = _dapperContext.CreateMasterConnection();
            var records = connection.QueryFirstOrDefault<int>(query, new { name });

            if (records == 0)
            {
                connection.Execute($"CREATE DATABASE {name}");
            }
        }
    }
}