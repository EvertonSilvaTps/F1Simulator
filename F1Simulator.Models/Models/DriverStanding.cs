using System;
using System.Collections.Generic;
using System.Text;

namespace F1Simulator.Models.Models
{
    public class DriverStanding
    {
        public Guid Id { get; private set; }
        public string DriverId { get; private set; }
        public Guid SeasonId { get; private set; }
        public int Position { get; private set; }
        public decimal Points { get; private set; }


        public DriverStanding(string driverId, Guid seasonId, int position, decimal points)
        {
            Id = Guid.NewGuid();
            DriverId = driverId;
            SeasonId = seasonId;
            Position = position;
            Points = points;
        }
    }

    
}
