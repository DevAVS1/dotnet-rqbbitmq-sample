using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ScadaTimeTravelApi.Configurations
{
    public class RabbitMQSettings
    {
        public string HostName { get; set; } 
        public int Port { get; set; }
        public string QueueName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }

        public RabbitMQSettings()
        {
            HostName = "localhost";
            Port = 5672;
        }
    }
}

