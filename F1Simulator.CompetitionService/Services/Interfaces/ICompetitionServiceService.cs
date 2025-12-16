using F1Simulator.Models.DTOs.CompetitionService.Request;

namespace F1Simulator.CompetitionService.Services.Interfaces
{
    public interface ICompetitionServiceService
    {
        Task CreateCircuitAsync(CreateCircuitRequestDTO createCircuit);
    }
}
