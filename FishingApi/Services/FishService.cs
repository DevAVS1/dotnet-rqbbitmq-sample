using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FishingApi.Data.Repositories;
using FishingApi.Models;

namespace FishingApi.Services
{
    public class FishService
    {
        
        private readonly FishRepository _repository;
        public FishService(FishRepository repository)
        {
            _repository = repository;
        }

        public Fish? GetFish()
        {
            var forceToGetAFish = false;
            return _repository.GetRandomFish(forceToGetAFish);
        }
    }
}