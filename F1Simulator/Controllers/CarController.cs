using F1Simulator.Models.DTOs.TeamManegementService.CarDTO;
using F1Simulator.Models.Models.TeamManegement;
using F1Simulator.TeamManagementService.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace F1Simulator.TeamManagementService.Controllers
{
    [Route("api/car")]
    [ApiController]
    public class CarController : ControllerBase
    {
        private readonly ILogger<CarController> _logger;
        private readonly ICarService _carService;

        public CarController(ILogger<CarController> logger, ICarService carService)
        {
            _logger = logger;
            _carService = carService;
        }



        [HttpPost]
        public async Task<ActionResult> CreateCarAsync(Car car)
        {
            try
            {
                _carService.CreateCarAsync(car);
            }
            catch (Exception ex)
            {

                throw;
            }
        }


        [HttpGet]
        public async Task GetAllCarAsync(string id)
        {
            try
            {
                _carService.GetAllCarAsync(id);
            }
            catch (Exception ex)
            {

                throw;
            }
        }



        [HttpGet("{carId}")]
        public async Task<ActionResult<CarResponseDTO> GetCarByIdAsync(string carId)
        {
            try
            {
                var car = await _carService.GetCarByIdAsync(carId);


            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An unexpected error occurred while searching for the car.");

                return Problem(ex.Message);
            }
        }



        [HttpPut("{carId}")]
        public async Task<IActionResult> UpdateCarCoefficientsAsync(CarUpdateDTO carUpdate, string carId)
        {
            try
            {
                await _carService.UpdateCarCoefficientsAsync(carUpdate, carId);

                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An unexpected error occurred while updating the coefficients.");

                return Problem(ex.Message);
            }
        }


    }
}
