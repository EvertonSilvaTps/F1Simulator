using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace F1Simulator.Models.DTOs.RaceControlService
{
    public class CarCoefficientsResponseDTO
    {
        [JsonPropertyName("Ca")]
        public double Ca { get; init; }

        [JsonPropertyName("Cp")]
        public double Cp { get; init; }
    }
}
