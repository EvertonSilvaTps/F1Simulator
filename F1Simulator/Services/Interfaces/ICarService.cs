using F1Simulator.Models.DTOs.TeamManegementService.CarDTO;
using F1Simulator.Models.Models.TeamManegement;

namespace F1Simulator.TeamManagementService.Services.Interfaces
{
    public interface ICarService
    {
        Task CreateCarAsync(Car car);

        Task<List<CarResponseDTO>> GetAllCarAsync(string id);

        Task<CarResponseDTO> GetCarByIdAsync(string id);

        Task UpdateCarCoefficientsAsync(CarUpdateDTO carUpdate, string carId);
    }
}
