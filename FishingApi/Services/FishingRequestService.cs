using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;
using RabbitMQ.Client;

namespace FishingApi.Services
{
    public class FishingRequestService
    {

        private readonly IModel _channel;
        public FishingRequestService()
        {
            ConnectionFactory factory = new ConnectionFactory { HostName = "localhost", Port = 5672 };
            var connection = factory.CreateConnection();
            var channel = connection.CreateModel();

            channel.QueueDeclare(queue: "fishing",
                                durable: false,
                                exclusive: false,
                                autoDelete:false,
                                arguments: null);
            
            _channel = channel;
        }

        public Boolean? SendFishingRequest() 
        {
            const string message = "i want to fish";
            var body = Encoding.UTF8.GetBytes(message);

            _channel.BasicPublish(exchange: string.Empty,
                                routingKey: "fishing",
                                basicProperties: null,
                                body:body);
            
            Console.WriteLine($" [x] Sent message {message}");

            return true;
        }
    }
}