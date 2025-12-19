using F1Simulator.Models.DTOs.TeamManegementService.EngineerDTO;
using F1Simulator.TeamManagementService.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace F1Simulator.TeamManagementService.Controllers
{
    [Route("api/engineer")]
    [ApiController]
    public class EngineerController : ControllerBase
    {
        private readonly IEngineerService _engineerService;

        public EngineerController(IEngineerService engineerService)
        {
            _engineerService = engineerService;
        }

        [HttpPost]
        public async Task<ActionResult<EngineerResponseDTO>> CreateEngineerAsync([FromBody] EngineerRequestDTO engineerRequestDTO)
        {
            try
            {
                var engineer = await _engineerService.CreateEngineerAsync(engineerRequestDTO);
                return StatusCode(201, engineer);
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
                return StatusCode(500, new { message = ex.Message });
            }
        }

        [HttpGet]
        public async Task<ActionResult<List<EngineerResponseDTO>>> GetAllEngineersAsync()
        {
            try
            {
                var enginners = await _engineerService.GetAllEngineersAsync();
                if (enginners is null || enginners.Count == 0)
                    return NoContent();
                return Ok(enginners);
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
                return StatusCode(500, new { message = ex.Message });
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<EngineerResponseDTO>> GetEngineerByIdAsync([FromRoute] Guid id)
        {
            try
            {
                var engineer = await _engineerService.GetEngineerByIdAsync(id);
                if (engineer is null)
                    return NoContent();
                return Ok(engineer);
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
                return StatusCode(500, new { message = ex.Message });
            }
        }
    }
}
