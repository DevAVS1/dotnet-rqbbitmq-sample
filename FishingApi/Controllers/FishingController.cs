using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;
using FishingApi.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace FishingApi.Controllers
{
    [Route("fishing")]
    public class FishingController : Controller
    {
        private readonly ILogger<FishingController> _logger;
        private readonly FishService _service; 
        private readonly FishingRequestService _queueService; 

        public FishingController(ILogger<FishingController> logger
                                ,FishService service
                                ,FishingRequestService queueService)
        {
            _logger = logger;
            _service = service;
            _queueService = queueService;
        }

        [HttpGet("fish")]
        public IActionResult GetFish()
        {
            var fish = _service.GetFish();
            if (fish is not null)
            {
                return Ok(fish);
            }
            else 
            {
                return Ok("maybe next time");
            }
        }

        [HttpPost("fish")]
        public IActionResult GoFishing([FromBody] string message)
        {
            _queueService.SendFishingRequest();
            return Ok();
        }

    }
}