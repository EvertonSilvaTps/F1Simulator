using System;
using System.Collections.Generic;
using System.Text;

namespace F1Simulator.Models.DTOs.TeamManegementService.BossDTO
{
    public class BossResponseDTO
    {
        public string BossId { get; set; }
        public string TeamId { get; set; }
        public string FirstName { get; set; }
        public string FullName { get; set; }
        public int Age { get; set; }
        public bool IsActive { get; set; }
    }
}
