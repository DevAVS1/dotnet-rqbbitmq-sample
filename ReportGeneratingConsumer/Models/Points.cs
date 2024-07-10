using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ReportGeneratingConsumer.Models
{
    public class Point
    {
        public int PointNumber { get; set; }
        public string B1 { get; set; }
        public string B2 { get; set; } 
        public string B3 { get; set; }
        public string Element { get; set; }
        public string PointType { get; set; }
        public DateTime LastModified { get; set; }
        public bool Active { get; set; }

    }
}