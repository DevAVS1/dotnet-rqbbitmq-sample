using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ScadaTimeTravelApi.Models
{
    public class ReportMetadata
    {
        private Guid ReportId { get; set; } 
        private string RequesterUsername { get; set; }

        private DateTime RequestTimestamp { get; set; } 

        private DateTime? ConclusionTimestamp { get; set; } = null;

        private int? TimeElapsedInSeconds { get; set; } = null;

        private DateTime? ExpireDate { get; set; } = null;

    }
}