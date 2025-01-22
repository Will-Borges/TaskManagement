using Npgsql;
using System.Data;

namespace Eclipseworks.TaskManagement.Infraestruture.Persistence.Data.Configuration
{
    public class DapperContext
    {
        private readonly string _connectionString;

        public DapperContext()
        {
            //  _connectionString = "Host=127.0.0.1;Port=5433;Database=eclipseworks;Username=postgres;Password=@Will00;Pooling=true;Timeout=300";
            _connectionString = "Host=localhost;Port=5432;Database=eclipseworks;Username=postgres;Password=@Will00;Pooling=true;Timeout=300";
        }

        public IDbConnection CreateConnection() => new NpgsqlConnection(_connectionString);
    }
}
