using F1Simulator.Models.Enums.TeamManegementService;
using System.Text.Json.Serialization;

namespace F1Simulator.Models.DTOs.TeamManegementService.EngineerDTO
{
    public class EngineerResponseDTO
    {
        public Guid EngineerId { get; init; }
        public Guid TeamId { get; init; }
        public Guid CarId { get; init; }
        public string FirstName { get; init; }
        public string FullName { get; init; }
        [JsonIgnore]
        public Specialization Specialization { get; init; }
        public string EngineerSpecializationDescription => Specialization.ToString(); 
        public double ExperienceFactor { get; init; }
    }
}
