namespace F1Simulator.Models.DTOs.RaceControlService
{
    public class DriverToRaceDTO
    {
        public Guid DriverId { get; init; }
        public string DriverName { get; init; }
        public double Handicap { get; set; }
        public double DriverExp { get; init; }
        public Guid TeamId { get; init; }
        public string TeamName { get; init; }
        public Guid EnginneringAId { get; init; }
        public Guid EnginneringPId { get; init; }
        public Guid CarId { get; init; }
        public double Ca { get; set; }
        public double Cp { get; set; }
    }
}
