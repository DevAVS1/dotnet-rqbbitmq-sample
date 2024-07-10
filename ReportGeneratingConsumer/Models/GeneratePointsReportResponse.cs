using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReportGeneratingConsumer.Models
{
    public class GeneratePointsReportResponse
    {
        public Guid ReportId { get; set; } 
        public string? Requester { get; set; }
        public DateTime RequestedAt { get; set; }
        public DateTime ReadyAt { get; set; }
        public DateTime ExpireAt { get; set; }
        public TimeSpan TimeElapsed { get; set; }

        public GeneratePointsReportResponse(Guid reportId, DateTime requestedAt, string? requester)
        {
            ReportId = reportId;
            Requester = requester;
            RequestedAt = requestedAt;
        }
    }
}