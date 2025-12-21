using F1Simulator.Models.Enums.TeamManegementService;

namespace F1Simulator.Models.Models.TeamManegement
{
    public class Engineer
    {
        public Engineer(Guid teamId, Guid carId, string firstName, string fullName, Specialization engineerSpecialization, double experienceFactor)
        {
            EngineerId = Guid.NewGuid();
            TeamId = teamId;
            CarId = carId;
            FirstName = firstName;
            LastName = fullName;
            Specialization = engineerSpecialization;
            ExperienceFactor = experienceFactor;
        }

        public Guid EngineerId { get; set; }
        public Guid TeamId { get; set; }
        public Guid CarId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Specialization Specialization { get; set; }
        public double ExperienceFactor { get; set; }


        public Engineer()
        {
            
        }
    }
}
