using F1Simulator.Models.Models.RaceControlService;
using F1Simulator.RaceControlService.Repositories.Interfaces;
using F1Simulator.Utils.DatabaseConnectionFactory;
using MongoDB.Driver;

namespace F1Simulator.RaceControlService.Repositories
{
    public class RaceControlRepository : IRaceControlRepository
    {
        private readonly IMongoDatabase _mongoDatabase;
        private readonly IMongoCollection<RaceControl> _raceControlCollection;

        public RaceControlRepository(IDatabaseConnection<IMongoDatabase> mongoDatabase)
        {
            _mongoDatabase = mongoDatabase.Connect();
            _raceControlCollection = _mongoDatabase.GetCollection<RaceControl>("RaceControll");
        }

        
    }
}
