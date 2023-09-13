using System.Data;
using PocFluentMigration.Infrastructure.Database;

namespace Infrastructure.Database.Context
{
  public class DapperContext
	{
		private readonly IConfiguration _configuration;
		private readonly ConnectionFactory _connectionFactory;

		public DapperContext(IConfiguration configuration, ConnectionFactory connectionFactory)
		{
			_configuration = configuration;
			_connectionFactory = connectionFactory;
		}

		public string CreateQueryDatabase() => _connectionFactory.CreateQueryDatabase();

		public IDbConnection CreateSqlConnection() => CreateConnection("SqlConnection");

    public IDbConnection CreateMasterConnection() => CreateConnection("MasterConnection");

    private IDbConnection CreateConnection(string connectionName) => _connectionFactory.CreateConnection(connectionName);
	}
}