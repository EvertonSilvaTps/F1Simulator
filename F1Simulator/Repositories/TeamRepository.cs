using Dapper;
using F1Simulator.Models.DTOs.TeamManegementService.TeamDTO;
using F1Simulator.Models.Models.TeamManegement;
using F1Simulator.TeamManagementService.Data;
using F1Simulator.TeamManagementService.Services;
using Microsoft.Data.SqlClient;

namespace F1Simulator.TeamManagementService.Repositories
{
    public class TeamRepository
    {
        private readonly ILogger<Team> _logger;
        private readonly TeamManagementServiceConnection _connection;
        public TeamRepository(ILogger<Team> logger, TeamManagementServiceConnection connection)
        {
            _logger = logger;
            _connection = connection;
        }

        public async Task<int> GetTeamsCountAsync()
        {
            using var connection = _connection.GetConnection();

            var sql = @"SELECT COUNT(*) FROM Teams";

            return await connection.ExecuteScalarAsync<int>(sql);
        }

        public async Task CreateTeamAsync(TeamRequestDTO teamRequestDto)
        {
            try
            {
                using var sqlConnection = _connection.GetConnection();
                var query = "INSERT INTO Teams (Name, NameAcronym, Country) " +
                            "VALUES (@Name, @NameAcronym, @Country)";

                using var connection = _connection.GetConnection();
                await connection.ExecuteAsync(query, teamRequestDto);
            }
            catch (Exception ex)
            {
                _logger.LogError($"An error occurred while creating the team: {ex.Message}", ex);
            }
        }
    }
}
