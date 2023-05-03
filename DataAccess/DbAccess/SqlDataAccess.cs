using Microsoft.Extensions.Configuration;
using Dapper;
using System.Data;
using System.Data.SqlClient;

namespace DataAccess.DbAccess;
public class SqlDataAccess : ISqlDataAccess
{
	private readonly IConfiguration configuration;

	public SqlDataAccess(IConfiguration configuration)
	{
		this.configuration = configuration;
	}

	public async Task<IEnumerable<T>> LoadData<T, U>(string storedProcedure, U parameters, string connectionId = "Default")
	{
		using IDbConnection connection = new SqlConnection(configuration.GetConnectionString(connectionId));

		return await connection.QueryAsync<T>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
	}

	public async Task SaveData<T>(string storedProcedure, T parameters, string connectionId = "Default")
	{
		using IDbConnection connection = new SqlConnection(configuration.GetConnectionString(connectionId));

		await connection.ExecuteAsync(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
	}
}
