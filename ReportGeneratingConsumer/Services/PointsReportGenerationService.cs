using RabbitMQ.Client.Events;
using RabbitMQ.Client;
using ReportGeneratingConsumer;
using ReportGeneratingConsumer.Data.Repositories;
using System.Text;
using ReportGeneratingConsumer.Models;
using ReportGeneratingConsumer.Helper;
using Common.Requests;

namespace ReportGeneratingConsumer.Services
{
    public class PointsReportGenerationService
    {
        private readonly IModel _channel;
        private readonly PointsRepository _pointsRepository;

        public PointsReportGenerationService(RabbitMQConnectionManager connectionManager,
                                            PointsRepository repository)
        {
            _channel = connectionManager.GetChannel();
            _pointsRepository = repository;
        }
        public void GeneratePointsReport()
        {

            var consumer = new EventingBasicConsumer(_channel);
            consumer.Received += (sender, eventArgs) =>
            {
                var messageBody = eventArgs.Body.ToArray();
                var request = GeneratePointsReportRequest.FromBytes(messageBody);
                Console.WriteLine($"[x] Message Recevied {request}");

                var points = _pointsRepository.GetPoints(request);

                Console.WriteLine($"Results : {points.Count()} records");
                _channel.BasicAck(eventArgs.DeliveryTag, multiple: false);


                var csvHelper = new CsvGenerator();
                (Guid reportId, string filePath) = csvHelper.GenerateCsv(points);


                var reportResponse = new GeneratePointsReportResponse(reportId: reportId
                                                                    , requester: request.Requester
                                                                    , requestedAt: request.RequestedAt);

                reportResponse.ReadyAt = DateTime.Now;
                reportResponse.TimeElapsed = DateTime.Now - reportResponse.RequestedAt;
                reportResponse.ExpireAt = DateTime.Now.AddDays(3);

                var response = System.Text.Json.JsonSerializer.Serialize(reportResponse);
                var responseMessageBody = Encoding.UTF8.GetBytes(response);

                _channel.BasicPublish(exchange: ""
                                , routingKey: "reports_response"
                                , basicProperties: null
                                , body: responseMessageBody);

            };

            // channel.BasicQos(2,2,true);

            _channel.BasicConsume(
                queue: "reports_request",
                autoAck: false,
                consumer: consumer);

            Console.ReadLine();

        }
    }
}






