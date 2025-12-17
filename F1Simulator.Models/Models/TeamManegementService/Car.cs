using System;
using System.Collections.Generic;
using System.Text;

namespace F1Simulator.Models.Models.TeamManegement
{
    public class Car
    {
        public Guid CarId { get; set; }
        public Guid TeamId { get; set; }
        public string Model { get; set; }
        public double WeightKg { get; set; }
        public int Speed { get; set; }
        public double Ca { get; set; }
        public double Cp { get; set; }
    }
}
