using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ScadaTimeTravelApi.DTOs;
using ScadaTimeTravelApi.Services;

namespace ScadaTimeTravelApi.Controllers
{
    [ApiController]
    [Route("api/reports")]
    public class ReportsController : ControllerBase
    {
        private readonly ReportQueueService _service;

        public ReportsController(ReportQueueService service)
        {
            _service = service;
        }
        [HttpPost("points")]
        public IActionResult GeneratePointsReport([FromQuery]GeneratePointsReportRequestDTO requestDTO)
        {
            var request = new GeneratePointsReportRequest(requestDTO);
            _service.GeneratePointsReport(request);
            return Ok();
        }
    }
}