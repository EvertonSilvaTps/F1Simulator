using System;
using System.Collections.Generic;
using System.Text;

namespace F1Simulator.Models.DTOs.TeamManegementService.CarDTO
{
    public class CarRequestDTO
    {
        public string TeamId { get; set; }
        public string Model { get; set; }
        public double WeightKg { get; set; }
        public int Speed { get; set; }
    }
}
