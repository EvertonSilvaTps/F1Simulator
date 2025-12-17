using System;
using System.Collections.Generic;
using System.Text;

namespace F1Simulator.Models.DTOs.TeamManegementService.DriverDTO
{
    public class DriverResponseDTO
    {
        public string DriverNumber { get; set; }
        public string TeamId { get; set; }
        public string CarId { get; set; }
        public string FirstName { get; set; }
        public string FullName { get; set; }
        public string NameAcronym { get; set; }
        public double WeightKg { get; set; }
        public double HandiCap { get; set; }
        public bool IsActive { get; set; }
    }
}
