using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ReportGeneratingConsumer.Services;

namespace ReportGeneratingConsumer
{
    public class App
    {
        private readonly PointsReportGenerationService _service;
        public App(PointsReportGenerationService service)
        {
            _service = service;
        }

        public void Run(string[] args)
        {
            _service.GeneratePointsReport();
        }
    }
}