using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Common.Requests
{
    public record GeneratePointsReportRequest
    {
        public string? Requester { get; set; }
        public DateTime RequestedAt { get; set; } = DateTime.Now;
        public string? B1 { get; set; } = null;
        public string? B2 { get; set; } = null; 
        public string? B3 { get; set; } = null;
        public string? Element { get; set; } = null;
        public string? PointType { get; set; } = null;

        public static GeneratePointsReportRequest? FromBytes(byte[] requestAsBytes)
        {
            if (requestAsBytes is null)
                throw new ArgumentNullException(nameof(requestAsBytes));

            return JsonSerializer.Deserialize<GeneratePointsReportRequest>(Encoding.UTF8.GetString(requestAsBytes));
        }
    
    }

}