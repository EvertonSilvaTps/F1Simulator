using F1Simulator.CompetitionService.Services.Interfaces;
using F1Simulator.Models.DTOs.CompetitionService.Response;
using Microsoft.AspNetCore.Mvc;

namespace F1Simulator.CompetitionService.Controllers
{
    [Route("api/competition")]
    [ApiController]
    public class CompetitionController : ControllerBase
    {

        private readonly ILogger<CompetitionController> _logger;
        private readonly ICompetitionService _competitionService;
        public CompetitionController(ILogger<CompetitionController> logger, ICompetitionService competitionService)
        {
            _logger = logger;
            _competitionService = competitionService;
        }

        [HttpGet("season/active")]
        public async Task<ActionResult> GetCompetitionActiveAsync()
        {
            try
            {
                var competition = await _competitionService.GetCompetitionActiveAsync();
                if (competition is null)
                {
                    return StatusCode(404, new { message = "There is no season that has started." });
                }
                return StatusCode(StatusCodes.Status200OK, competition);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving competitions");
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while retrieving competitions.");
            }

        }

        [HttpPost("season/start")]
        public async Task<ActionResult> StartSeasonAsync()
        {
            try
            {
                var result = await _competitionService.StartSeasonAsync();
                return StatusCode(StatusCodes.Status201Created, result);
            }
            catch (InvalidOperationException ex)
            {
                return StatusCode(409, new { message = ex.Message });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error starting season");
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while starting the season.");
            }
        }

        [HttpPatch("races/round:{round}/start")]

        public async Task<ActionResult> StartRaceAsync([FromRoute] int round)
        {
            try
            {
                var race = await _competitionService.StartRaceAsync(round);
                return StatusCode(StatusCodes.Status200OK, race);
            }
            catch (ArgumentException ex)
            {
                return StatusCode(400, new { message = ex.Message });
            }
            catch (InvalidOperationException ex)
            {
                return StatusCode(409, new { message = ex.Message });
            }
            catch (KeyNotFoundException ex)
            {
                return StatusCode(404, new { message = ex.Message });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error starting race for round {RoundId}", round);
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while starting the race.");
            }
        }

        [HttpGet("races/inprogress")]
        public async Task<ActionResult> GetRaceInProgressAsync()
        {
            try
            {
                var race = await _competitionService.GetRaceWithCircuitAsync();
                if (race is null)
                {
                    return StatusCode(404, new { Message = "There isn't a race in progress in the current season." });
                }

                return StatusCode(StatusCodes.Status200OK, race);

            }
            catch (InvalidOperationException ex)
            {
                return StatusCode(409, new { message = ex.Message });
            }

            catch (Exception ex)
            {
                _logger.LogError(ex, "Error get race in progress");
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while get the race.");
            }
        }

        [HttpPatch("races/t1")]

        public async Task<ActionResult> UpdateRaceT1Async()
        {
            try
            {
                await _competitionService.UpdateRaceT1Async();
                return StatusCode(StatusCodes.Status200OK);

            }
            catch (InvalidOperationException bex)
            {
                _logger.LogError(bex, "An error occurred while updating T1");
                return StatusCode(404, new { message = bex.Message });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error updating T1");
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while updating T1.");
            }
        }

        [HttpPatch("races/t2")]

        public async Task<ActionResult> UpdateT2Async()
        {
            try
            {
                await _competitionService.UpdateRaceT2Async();
                return StatusCode(StatusCodes.Status200OK);

            }
            catch (InvalidOperationException bex)
            {
                _logger.LogError(bex, "An error occurred while updating T1");
                return StatusCode(404, new { message = bex.Message });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error updating T2");
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while updating T2.");
            }
        }

        [HttpPatch("races/t3")]

        public async Task<ActionResult> UpdateT3Async()
        {
            try
            {
                await _competitionService.UpdateRaceT3Async();
                return StatusCode(StatusCodes.Status200OK);

            }
            catch (InvalidOperationException bex)
            {
                _logger.LogError(bex, "An error occurred while updating T1");
                return StatusCode(404, new { message = bex.Message });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error updating T3");
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while updating T3.");
            }
        }

        [HttpPatch("races/qualifier")]

        public async Task<ActionResult> UpdateQualifierAsync()
        {
            try
            {
                await _competitionService.UpdateRaceQualifierAsync();
                return StatusCode(StatusCodes.Status200OK);

            }
            catch (InvalidOperationException bex)
            {
                _logger.LogError(bex, "An error occurred while updating T1");
                return StatusCode(404, new { message = bex.Message });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error updating Qualifier");
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while updating Qualifier.");
            }
        }

        [HttpPatch("races/race")]

        public async Task<ActionResult> UpdateRaceRaceAsync()
        {
            try
            {
                await _competitionService.UpdateRaceRaceAsync();
                return StatusCode(StatusCodes.Status200OK);

            }
            catch (InvalidOperationException bex)
            {
                _logger.LogError(bex, "An error occurred while updating T1");
                return StatusCode(404, new { message = bex.Message });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error updating race");
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while updating race.");
            }
        }

        [HttpGet("driverstanding")]
        public async Task<ActionResult> GetDriverStandingAsync()
        {
            try
            {
                var driverStandings = await _competitionService.GetDriverStandingAsync();
                return StatusCode(StatusCodes.Status200OK, driverStandings);
            }
            catch (InvalidOperationException ex)
            {
                return StatusCode(409, new { message = ex.Message });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving driver standings");
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while retrieving driver standings.");
            }
        }

        [HttpGet("teamstanding")]
        public async Task<ActionResult> GetTeamStandingAsync()
        {
            try
            {
                var teamStandings = await _competitionService.GetTeamStandingAsync();
                return StatusCode(StatusCodes.Status200OK, teamStandings);
            }
            catch (InvalidOperationException ex)
            {
                return StatusCode(409, new { message = ex.Message });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving team standings");
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while retrieving team standings.");
            }
        }
 
        [HttpGet("calendar")]
        public async Task<ActionResult> GetTeamRacesAsync()
        {
            try
            {
                var calendar = await _competitionService.GetRacesAsync();
                return StatusCode(StatusCodes.Status200OK, calendar);
            }
            catch (InvalidOperationException ex)
            {
                return StatusCode(409, new { message = ex.Message });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving calendar");
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while retrieving calendar.");
            }
        }

        [HttpPost("endrace")]
        public async Task<ActionResult> EndRaceAsync()
        {
            try
            {
                await _competitionService.EndRaceAsync();
                return StatusCode(StatusCodes.Status200OK);
            }
            catch (InvalidOperationException ex)
            {
                return StatusCode(409, new { message = ex.Message });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error ending race ");
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while ending the race.");
            }
        }

        [HttpPost("endseason")]

        public async Task<ActionResult<StandingsResponseDTO>> EndSeasonAsync()
        {
            try
            {
                var standings = await _competitionService.EndSeasonAsync();
                return StatusCode(StatusCodes.Status200OK, standings);
            }
            catch (InvalidOperationException ex)
            {
                return StatusCode(409, new { message = ex.Message });
            }
            catch (KeyNotFoundException ex)
            {
                return StatusCode(404, new { message = ex.Message });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error ending race ");
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while ending the season.");
            }
        }

        [HttpGet("seasons")]
        public async Task<ActionResult<List<SeasonResponseDTO>>> GetAllSeasonsAsync()
        {
            try
            {
                var seasons = await _competitionService.GetAllSeasonsAsync();
                return StatusCode(StatusCodes.Status200OK, seasons);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving seasons");
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while retrieving seasons.");
            }
        }
    }
}
