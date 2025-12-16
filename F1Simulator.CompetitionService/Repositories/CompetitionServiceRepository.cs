using F1Simulator.CompetitionService.Data;
using F1Simulator.CompetitionService.Repositories.Interfaces;
using F1Simulator.Models.DTOs.CompetitionService.Request;
using F1Simulator.Models.Models;
using Microsoft.Data.SqlClient;

namespace F1Simulator.CompetitionService.Repositories
{
    public class CompetitionServiceRepository : ICompetitionServiceRepository
    {

        private readonly ILogger<CompetitionServiceRepository> _logger;
        private readonly SqlConnection _connection;

        public CompetitionServiceRepository(ILogger<CompetitionServiceRepository> logger, CompetitionServiceConnection connection)
        {
            _logger = logger;
            _connection = connection.GetConnection();
        }


        public async Task CreateCircuitAsync(Circuit createCircuit)
        {
            try
            {
                var query = "INSERT INTO Circuits (Id, Name, Country, NumberOfLaps, Tl1, Tl2, Tl3, Qualifier, Race) " +
                             "VALUES (@Id, @Name, @Country, @NumberOfLaps, @Tl1, @Tl2, @Tl3, @Qualifier, @Race)";
                using var command = new SqlCommand(query, _connection);
                command.Parameters.AddWithValue("@Id", createCircuit.Id);
                command.Parameters.AddWithValue("@Name", createCircuit.Name);
                command.Parameters.AddWithValue("@Country", createCircuit.Country);
                command.Parameters.AddWithValue("@NumberOfLaps", createCircuit.NumberOfLaps);
                command.Parameters.AddWithValue("@Tl1", createCircuit.Tl1);
                command.Parameters.AddWithValue("@Tl2", createCircuit.Tl2);
                command.Parameters.AddWithValue("@Tl3", createCircuit.Tl3);
                command.Parameters.AddWithValue(@"Qualifier", createCircuit.Qualifier);
                command.Parameters.AddWithValue("@Race", createCircuit.Race);
                await _connection.OpenAsync();
                await command.ExecuteNonQueryAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error in CreateCircuitAsync");
                throw;
            }
            finally
            {
                await _connection.CloseAsync();
            }
        }
    }
}
