using System;
using System.Collections.Generic;
using System.Text;

namespace F1Simulator.Models.Models
{
    public class Circuit
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public string Country { get; private set; }
        public int NumberOfLaps { get; private set; }
        public bool Tl1 { get; private set; }
        public bool Tl2 { get; private set; }
        public bool Tl3 { get; private set; }
        public bool Qualifier { get; private set; }
        public bool Race { get; private set; }

        public Circuit(string name, string country, int numberOfLaps)
        {
            Id = Guid.NewGuid();
            Name = name;
            Country = country;
            NumberOfLaps = numberOfLaps;
            Tl1 = false;
            Tl2 = false;
            Tl3 = false;
            Qualifier = false;
            Race = false;
        }
    }
}
