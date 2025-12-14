using Microsoft.Data.SqlClient;

namespace F1Simulator.CompetitionService.Data
{
    public class CompetitionServiceConnection
    {
        private readonly string _connectionString;
        public CompetitionServiceConnection(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("SqlServer");
        }
        public SqlConnection GetConnection()
        {
            return new SqlConnection(_connectionString);
        }
    }
}
