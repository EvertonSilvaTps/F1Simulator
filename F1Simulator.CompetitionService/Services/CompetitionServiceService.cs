using F1Simulator.CompetitionService.Repositories.Interfaces;
using F1Simulator.Models.DTOs.CompetitionService.Request;
using F1Simulator.Models.Models;

namespace F1Simulator.CompetitionService.Services
{
    public class CompetitionServiceService : ICompetitionServiceService
    {
        private readonly ILogger<CompetitionServiceService> _logger;
        private readonly ICompetitionServiceRepository competitioServiceRepository;
        public CompetitionServiceService(ILogger<CompetitionServiceService> logger, 
            ICompetitionServiceRepository competitionServiceRepository)
        {
            _logger = logger;
            this.competitioServiceRepository = competitionServiceRepository;
        }

        public async Task CreateCircuitAsync(CreateCircuitRequestDTO createCircuit)
        {
            try
            {
                Circuit circuit = new Circuit(createCircuit.Name, createCircuit.Country, createCircuit.NumberOfLaps); 
                await competitioServiceRepository.CreateCircuitAsync(circuit);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error in CreateCircuitAsync");
                throw;
            }
        }
    }
}
