using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using CsvHelper;
using System.Globalization;
using Microsoft.VisualBasic;
using System.IO.Enumeration;

namespace ReportGeneratingConsumer.Helper
{
    public class CsvGenerator : IDisposable
    {

        public (Guid,string) GenerateCsv(IEnumerable<object> records)
        {
            var reportId = Guid.NewGuid();

            string relativePath = $"Reports\\CSV\\{reportId}.csv";

            var filePath = Path.Combine(Directory.GetCurrentDirectory(),relativePath);

            filePath = $"D:\\Dev\\Backend\\dotnet-rqbbitmq-sample\\ReportGeneratingConsumer\\Reports\\CSV\\{reportId}.csv";

            // Write data to CSV
            using (var writer = new StreamWriter(filePath))
            using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
            {
                csv.WriteRecords(records);
            }

            Console.WriteLine($"O arquivo CSV foi gerado em: {filePath}");

            return (reportId,filePath);

        }
        // Path to the CSV file
        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}