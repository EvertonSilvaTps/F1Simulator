using F1Simulator.Models.DTOs.TeamManegementService.CarDTO;
using F1Simulator.Models.Models.TeamManegement;
using F1Simulator.TeamManagementService.Repositories.Interfaces;
using F1Simulator.TeamManagementService.Services.Interfaces;

namespace F1Simulator.TeamManagementService.Services
{
    public class CarService : ICarService
    {
        private ICarRepository _carRepository;

        public CarService(ICarRepository carRepository)
        {
            _carRepository = carRepository;
        }


        public async Task CreateCarAsync(Car car)
        {

        }



        public async Task<List<CarResponseDTO>> GetAllCarAsync(string id)
        {
            var car = await _carRepository.
        }


        public async Task<CarResponseDTO> GetCarByIdAsync(string id)
        {
            var car = await _carRepository.
        }



        public async Task UpdateCarCoefficientsAsync(CarUpdateDTO carUpdate, string carId)
        {



            await _carRepository.UpdateCarCoefficientsAsync(carUpdate, carId);

        }


    }
}
