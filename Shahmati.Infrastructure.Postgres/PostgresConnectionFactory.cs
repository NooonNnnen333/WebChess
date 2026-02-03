using System.Data;
using Shahmati.Application;
using Microsoft.Extensions.Configuration;
using Npgsql;
using Shahmati.Infrastructure.Postgres;

namespace CRMSolution.Infrastructure.Postgres;

public class SqlConnectionFactory : ISqlConnectionFactory
{
    private IConfiguration _configuration;

    public SqlConnectionFactory(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public IDbConnection Create()
    {
        var connection = new NpgsqlConnection(_configuration.GetConnectionString("Database"));

        return connection;
    }
}