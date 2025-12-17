using System;
using System.Collections.Generic;
using System.Text;

namespace F1Simulator.Models.DTOs.TeamManegementService.CarDTO
{
    public class CarResponseDTO
    {
        public string CarId { get; set; }
        public string TeamId { get; set; }
        public string Model { get; set; }
        public double WeightKg { get; set; }
        public int Speed { get; set; }
        public double Ca { get; set; }
        public double Cp { get; set; }
    }
}
