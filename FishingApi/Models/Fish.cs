using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FishingApi.Models
{
    using System;

    public class Fish
    {
        // Properties
        public string Species { get; set; }
        public string Color { get; set; }
        public double LengthInCentimeters { get; set; }
        public bool IsFreshwater { get; set; }

        // Constructor
        public Fish(string species, string color, double lengthInCentimeters, bool isFreshwater)
        {
            Species = species;
            Color = color;
            LengthInCentimeters = lengthInCentimeters;
            IsFreshwater = isFreshwater;
        }

        // Method to display information about the fish
        public void DisplayInfo()
        {
            Console.WriteLine($"Species: {Species}");
            Console.WriteLine($"Color: {Color}");
            Console.WriteLine($"Length: {LengthInCentimeters} cm");
            Console.WriteLine($"Freshwater: {(IsFreshwater ? "Yes" : "No")}");
        }
    }

}

