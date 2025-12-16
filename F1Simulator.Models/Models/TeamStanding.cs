using System;
using System.Collections.Generic;
using System.Text;

namespace F1Simulator.Models.Models
{
    public class TeamStanding
    {
        public Guid Id { get; private set; }
        public Guid SeasonId { get; private set; }
        public string TeamId { get; private set; }
        public int Points { get; set; }

        public TeamStanding(Guid seasonId, string teamId, int points)
        {
            Id = Guid.NewGuid();
            SeasonId = seasonId;
            TeamId = teamId;
            Points = points;
        }
    }
}
