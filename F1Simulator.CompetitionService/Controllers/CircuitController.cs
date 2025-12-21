using F1Simulator.CompetitionService.Services.Interfaces;
using F1Simulator.Models.DTOs.CompetitionService.Request;
using F1Simulator.Models.DTOs.CompetitionService.Response;
using F1Simulator.Models.DTOs.CompetitionService.Update;
using Microsoft.AspNetCore.Mvc;

namespace F1Simulator.CompetitionService.Controllers
{
    [Route("api/circuit")]
    [ApiController]
    public class CircuitController : ControllerBase
    {
        private readonly ILogger<CircuitController> _logger;
        private readonly ICircuitService _circuitService;

        public CircuitController(ILogger<CircuitController> logger, ICircuitService circuitService)
        {
            _logger = logger;
            _circuitService = circuitService;
        }

        [HttpPost("create")]
        public async Task<ActionResult> CreateCircuitAsync([FromBody] CreateCircuitRequestDTO createCircuit) { 
            try
            {

                 var circuit = await _circuitService.CreateCircuitAsync(createCircuit);
                 return StatusCode(StatusCodes.Status201Created, circuit);
                

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
                _logger.LogError(ex, "Error creating circuit");
                return StatusCode(StatusCodes.Status500InternalServerError, new { Message = "An error occurred while creating the circuit." });
            }
        }

        [HttpPost("create/circuits")]
        public async Task<ActionResult> CreateCircuitsAsync([FromBody] CreateCircuitsRequestDTO createCircuit)
        {
            try
            {
                CreateCircuitsResponseDTO circuit = await _circuitService.CreateCircuitsAsync(createCircuit);
                return StatusCode(StatusCodes.Status201Created, circuit);
                
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
                _logger.LogError(ex, "Error creating circuit");
                return StatusCode(StatusCodes.Status500InternalServerError, new { Message = "An error occurred while creating the circuits." });
            }
        }

        [HttpGet]
        public async Task<ActionResult<List<CreateCircuitResponseDTO>>> GetAllCircuitsAsync()
        {
            try
            {
                var circuits = await _circuitService.GetAllCircuitsAsync();
                return StatusCode(StatusCodes.Status200OK, circuits);
            }
           
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error when getting all circuits");
                return StatusCode(StatusCodes.Status500InternalServerError, new { Message = "An error occurred while getting all circuits." });
            }   
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CreateCircuitResponseDTO>> GetCircuitByIdAsync([FromRoute] Guid id)
        {
            try
            {
                var circuit = await _circuitService.GetCircuitByIdAsync(id);
                if(circuit is null)
                {
                    return StatusCode(404, new { message = "Circuit not found." });
                }
                return StatusCode(StatusCodes.Status200OK, circuit);
            }

            catch (Exception ex)
            {
                _logger.LogError(ex, "Error when get circuit by id");
                return StatusCode(StatusCodes.Status500InternalServerError, new { Message = "An error occurred while get circuit by id." });
            }
        }

        [HttpDelete("{id}")] 
        public async Task<ActionResult> DeleteCircuitAsync([FromRoute] Guid id)
        {
            try
            {
                var circuit = await _circuitService.DeleteCircuitAsync(id);
                return StatusCode(StatusCodes.Status200OK, circuit);
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
                _logger.LogError(ex, "Error when get circuit by id");
                return StatusCode(StatusCodes.Status500InternalServerError, new { Message = "An error occurred while get circuit by id." });
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateCircuitAsync([FromRoute] Guid id, [FromBody] UpdateCircuitDTO updateCircuit)
        {
            try
            {
                var (update, circuit) = await _circuitService.UpdateCircuitAsync(id, updateCircuit);
                return StatusCode(StatusCodes.Status200OK, circuit);
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
                _logger.LogError(ex, "Error when updating circuit");
                return StatusCode(StatusCodes.Status500InternalServerError, new { Message = "An error occurred while updating the circuit." });
            }
        }


    }
}
