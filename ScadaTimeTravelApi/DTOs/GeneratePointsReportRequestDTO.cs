using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ScadaTimeTravelApi.DTOs
{
    public class GeneratePointsReportRequestDTO
    {
        public string? Requester { get; set; }
        public string? B1 { get; set; } = null;
        public string? B2 { get; set; } = null; 
        public string? B3 { get; set; } = null;
        public string? Element { get; set; } = null;
        public string? PointType { get; set; } = null;
    
    }

}