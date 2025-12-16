using F1Simulator.CompetitionService.Services.Interfaces;
using F1Simulator.Models.DTOs.CompetitionService.Request;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace F1Simulator.CompetitionService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompetitionServiceController : ControllerBase
    {
        private readonly ILogger<CompetitionServiceController> _logger;
        private readonly ICompetitionServiceService _competitionServiceService;

        public CompetitionServiceController(ILogger<CompetitionServiceController> logger, ICompetitionServiceService competitionServiceService)
        {
            _logger = logger;
            _competitionServiceService = competitionServiceService;
        }

        [HttpPost]
        public async Task<ActionResult> CreateCircuit(CreateCircuitRequestDTO createCircuit) { 
            try
            {
                 await _competitionServiceService.CreateCircuitAsync(createCircuit);
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error creating circuit");
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while creating the circuit.");
            }
        }
    }
}
