using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FishingApi.Models;
using Microsoft.AspNetCore.Http.Features;

namespace FishingApi.Data.Repositories
{
    public class FishRepository
    {
        // Method to generate and return a list of fish instances
        public List<Fish> GetFishList()
        {
            List<Fish> fishes = new List<Fish>
        {
            new Fish("Salmon", "Silver", 60.5, true),
            new Fish("Goldfish", "Orange", 10.2, true),
            new Fish("Swordfish", "Grey", 150.8, false),
            new Fish("Angelfish", "Striped", 7.5, true),
            new Fish("Guppy", "Multicolored", 3.2, true)
        };

            return fishes;
        }

        public Fish? GetRandomFish(bool? forceToGetAFish = false) 
        {
            Boolean shouldGetAFish = Convert.ToBoolean(new Random().Next(0,2));
            shouldGetAFish = (forceToGetAFish == true) ? true : shouldGetAFish;

            if (shouldGetAFish) 
            {
                var fishes = GetFishList();

                Random random = new Random();

                int randomIndex = random.Next(0,fishes.Count);
                
                return fishes[randomIndex];
            }

            else 
            {
                return null;                
            }


        }
    }
}