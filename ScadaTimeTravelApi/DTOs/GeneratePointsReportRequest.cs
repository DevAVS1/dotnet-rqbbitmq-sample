using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ScadaTimeTravelApi.DTOs
{
    public class GeneratePointsReportRequest
    {
        public string? Requester { get; set; }
        public DateTime RequestedAt { get; set; } = DateTime.Now;
        public string? B1 { get; set; } = null;
        public string? B2 { get; set; } = null; 
        public string? B3 { get; set; } = null;
        public string? Element { get; set; } = null;
        public string? PointType { get; set; } = null;
    
        public GeneratePointsReportRequest(GeneratePointsReportRequestDTO requestDTO)
        {
            Requester = requestDTO.Requester;
            B1 = requestDTO.B1;
            B2 = requestDTO.B2; 
            B3 = requestDTO.B3;
            Element = requestDTO.Element;
            PointType = requestDTO.PointType;
        }
    }

}