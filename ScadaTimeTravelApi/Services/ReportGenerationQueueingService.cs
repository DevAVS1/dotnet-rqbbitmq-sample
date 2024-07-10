using System.Text;
using ScadaTimeTravelApi.DTOs;
using ScadaTimeTravelApi.Configurations;
using RabbitMQ.Client;

namespace ScadaTimeTravelApi.Services
{
    public class ReportQueueService
    {
        private readonly IModel _channel;
        public ReportQueueService(RabbitMQConnectionManager connectionManager)
        {
            _channel = connectionManager.GetChannel();
        }
        public void GeneratePointsReport (GeneratePointsReportRequest request)
        {
            var jsonMessage = System.Text.Json.JsonSerializer.Serialize<GeneratePointsReportRequest>(request);
            var body = Encoding.UTF8.GetBytes(jsonMessage);

            _channel.BasicPublish(exchange:""
                                ,routingKey:"reports_request"
                                ,basicProperties: null
                                ,body: body);
            

        }
        
    }
}