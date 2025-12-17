using F1Simulator.Models.DTOs.TeamManegementService.TeamDTO;
using F1Simulator.Models.Models.TeamManegement;
using F1Simulator.TeamManagementService.Data;
using F1Simulator.TeamManagementService.Repositories;
using Microsoft.Data.SqlClient;

namespace F1Simulator.TeamManagementService.Services
{
    public class TeamService
    {
        private readonly TeamManagementServiceConnection _connection;
        private readonly ILogger<Team> _logger;
        private readonly TeamRepository _teamRepository;
        public TeamService( ILogger<Team> logger,TeamManagementServiceConnection connection, TeamRepository teamRepository)
        {
            _logger = logger;
            _teamRepository = teamRepository;
            _connection = connection;
        }

        public async Task<int> GetTeamsCountAsync()
        {
            try
            {
                return await _teamRepository.GetTeamsCountAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError($"An error occurred while getting count the team: {ex.Message}", ex);
                throw;
            }
        }
        public async Task CreateTeamAsync(TeamRequestDTO teamRequestDto)
        {
            try
            {
                var count = await _teamRepository.GetTeamsCountAsync();

                if (count > 11)
                    throw new Exception("Max teams reached!");

                await _teamRepository.CreateTeamAsync(teamRequestDto);
            }
            catch(Exception ex)
            {
                _logger.LogError($"An error occurred while creating the team: {ex.Message}", ex);
            }
        }
    }
}
