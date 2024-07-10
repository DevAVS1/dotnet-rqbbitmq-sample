using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RabbitMQ.Client;

namespace ScadaTimeTravelApi.Configurations
{
    public class RabbitMQConnectionManager : IDisposable
    {

        private IConnection _connection;
        private IModel _channel;
        public RabbitMQConnectionManager()
        {
            if (_connection == null)
            {
                ConnectionFactory factory = new ConnectionFactory { HostName = "localhost", Port = 5672 };
                _connection = factory.CreateConnection();
            }

            if (_channel == null)
            {
                _channel = _connection.CreateModel();
                ConfigureReportsQueue();
            }
        }

        public IModel GetChannel() 
        {
            return _channel;
        }

        public void ConfigureReportsQueue()
        {
            
            _channel.QueueDeclare(queue: "reports_request",
                                durable: false,
                                exclusive: false,
                                autoDelete:false,
                                arguments: null);
            
        }

        public void Dispose()
        {
            _channel?.Dispose();
            _connection?.Dispose();
        }
    }
}