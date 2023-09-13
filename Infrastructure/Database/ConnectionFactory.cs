using System.Data;
using Microsoft.Data.SqlClient;
using MySql.Data.MySqlClient;
using Npgsql;
using PocFluentMigration.Infrastructure.Database.Enum;

namespace PocFluentMigration.Infrastructure.Database
{
    public class ConnectionFactory
    {
        private readonly IConfiguration _configuration;

				private readonly string _adapter;

        public ConnectionFactory(IConfiguration configuration)
        {
            _configuration = configuration;
						_adapter = _configuration.GetConnectionString("Adapter") ?? string.Empty;
        }

				public string CreateQueryDatabase()
				{
						if (_adapter == nameof(RDBMS.MYSQL))
						{
							return "SELECT COUNT(*) FROM information_schema.schemata WHERE SCHEMA_NAME = @name";
						}

						if (_adapter == nameof(RDBMS.MSSQLSERVER))
						{
							return "SELECT COUNT(*) FROM sys.databases WHERE name = @name";
						}

						if (_adapter == nameof(RDBMS.POSTGRESQL))
						{
							return "SELECT COUNT(*) FROM pg_catalog.pg_database WHERE LOWER(datname) = LOWER(@name)";
						}

						throw new ArgumentException("Database adapter not supported");
				}

        public IDbConnection CreateConnection(string connectionName)
        {
						if (_adapter == nameof(RDBMS.MYSQL))
						{
							return new MySqlConnection(_configuration.GetConnectionString(connectionName));
						}

						if (_adapter == nameof(RDBMS.MSSQLSERVER))
						{
							return new SqlConnection(_configuration.GetConnectionString(connectionName));
						}

						if (_adapter == nameof(RDBMS.POSTGRESQL))
						{
							return new NpgsqlConnection(_configuration.GetConnectionString(connectionName));
						}

						throw new ArgumentException("Database adapter not supported");
        }
    }
}